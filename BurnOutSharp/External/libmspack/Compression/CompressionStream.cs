﻿/* This file is part of libmspack.
 * (C) 2003-2013 Stuart Caie.
 *
 * The LZX method was created by Jonathan Forbes and Tomi Poutanen, adapted
 * by Microsoft Corporation.
 *
 * libmspack is free software { get; set; } you can redistribute it and/or modify it under
 * the terms of the GNU Lesser General Public License (LGPL) version 2.1
 *
 * For further details, see the file COPYING.LIB distributed with libmspack
 */

using System;
using System.IO;

namespace LibMSPackSharp.Compression
{
    public abstract class CompressionStream
    {
        private const int CHAR_BIT = 8;

        public const int BITBUF_WIDTH = 4 * CHAR_BIT;

        /// <summary>
        /// I/O routines
        /// </summary>
        public SystemImpl Sys { get; set; }

        /// <summary>
        /// Input file handle
        /// </summary>
        public FileStream Input { get; set; }

        /// <summary>
        /// Output file handle
        /// </summary>
        public FileStream Output { get; set; }

        public Error Error { get; set; }

        #region I/O buffering

        public byte[] InputBuffer { get; set; }

        public uint InputBufferSize { get; set; }

        public int InputPointer { get; set; }

        public int InputLength { get; set; }

        public int OutputPointer { get; set; }

        public int OutputLength { get; set; }

        public uint BitBuffer { get; set; }

        public int BitsLeft { get; set; }

        /// <summary>
        /// Have we reached the end of input?
        /// </summary>
        public int InputEnd { get; set; }

        #endregion

        #region ReadBits Methods

        /* This header defines macros that read data streams by
         * the individual bits
         *
         * INIT_BITS         initialises bitstream state in state structure
         * STORE_BITS        stores bitstream state in state structure
         * RESTORE_BITS      restores bitstream state from state structure
         * ENSURE_BITS(n)    ensure there are at least N bits in the bit buffer
         * READ_BITS(var,n)  takes N bits from the buffer and puts them in var
         * PEEK_BITS(n)      extracts without removing N bits from the bit buffer
         * REMOVE_BITS(n)    removes N bits from the bit buffer
         *
         * READ_BITS simply calls ENSURE_BITS, PEEK_BITS and REMOVE_BITS,
         * which means it's limited to reading the number of bits you can
         * ensure at any one time. It also fails if asked to read zero bits.
         * If you need to read zero bits, or more bits than can be ensured in
         * one go, use READ_MANY_BITS instead.
         *
         * These macros have variable names baked into them, so to use them
         * you have to define some macros:
         * - BITS_TYPE: the type name of your state structure
         * - BITS_VAR: the variable that points to your state structure
         * - define BITS_ORDER_MSB if bits are read from the MSB, or
         *   define BITS_ORDER_LSB if bits are read from the LSB
         * - READ_BYTES: some code that reads more data into the bit buffer,
         *   it should use READ_IF_NEEDED (calls read_input if the byte buffer
         *   is empty), then INJECT_BITS(data,n) to put data from the byte
         *   buffer into the bit buffer.
         *
         * You also need to define some variables and structure members:
         * - byte[] i_ptr;    // current position in the byte buffer
         * - byte[] i_end;    // end of the byte buffer
         * - uint bit_buffer; // the bit buffer itself
         * - uint bits_left;  // number of bits remaining
         *
         * If you use read_input() and READ_IF_NEEDED, they also expect these
         * structure members:
         * - struct mspack_system *sys;  // to access sys->read()
         * - uint error;         // to record/return read errors
         * - byte input_end;    // to mark reaching the EOF
         * - byte[] inbuf;       // the input byte buffer
         * - uint inbuf_size;    // the size of the input byte buffer
         *
         * Your READ_BYTES implementation should read data from *i_ptr and
         * put them in the bit buffer. READ_IF_NEEDED will call read_input()
         * if i_ptr reaches i_end, and will fill up inbuf and set i_ptr to
         * the start of inbuf and i_end to the end of inbuf.
         *
         * If you're reading in MSB order, the routines work by using the area
         * beyond the MSB and the LSB of the bit buffer as a free source of
         * zeroes when shifting. This avoids having to mask any bits. So we
         * have to know the bit width of the bit buffer variable. We use
         * <limits.h> and CHAR_BIT to find the size of the bit buffer in bits.
         *
         * If you are reading in LSB order, bits need to be masked. Normally
         * this is done by computing the mask: N bits are masked by the value
         * (1<<N)-1). However, you can define BITS_LSB_TABLE to use a lookup
         * table instead of computing this. This adds two new macros,
         * PEEK_BITS_T and READ_BITS_T which work the same way as PEEK_BITS
         * and READ_BITS, except they use this lookup table. This is useful if
         * you need to look up a number of bits that are only known at
         * runtime, so the bit mask can't be turned into a constant by the
         * compiler.
         * The bit buffer datatype should be at least 32 bits wide: it must be
         * possible to ENSURE_BITS(17), so it must be possible to add 16 new bits
         * to the bit buffer when the bit buffer already has 1 to 15 bits left.
         */

        public void READ_BITS_MSB(ref int val, int nbits, ref int i_ptr, ref int i_end, ref int bits_left, ref uint bit_buffer)
        {
            //READ_BITS(val, nbits)
            {
                //ENSURE_BITS(nbits)
                while (bits_left < (nbits))
                {
                    READ_BYTES;
                }

                val = (int)(bit_buffer >> (BITBUF_WIDTH - (nbits)));

                // REMOVE_BITS(nbits);
                bit_buffer <<= (nbits);
                bits_left -= (nbits);
            }
        }

        public void READ_BITS_LSB(ref int val, int nbits, ref int i_ptr, ref int i_end, ref int bits_left, ref uint bit_buffer)
        {
            //READ_BITS(val, nbits)

            //ENSURE_BITS(nbits)
            while (bits_left < nbits)
            {
                READ_BYTES;
            }

            val = (int)(bit_buffer & ((1 << (nbits)) - 1));

            //REMOVE_BITS(nbits);
            bit_buffer >>= (nbits);
            bits_left -= (nbits);
        }

        public Error ReadInput()
        {
            int read = Sys.Read(Input, InputBuffer, 0, (int)InputBufferSize);
            if (read < 0)
                return Error = Error.MSPACK_ERR_READ;

            // We might overrun the input stream by asking for bits we don't use,
            // so fake 2 more bytes at the end of input
            if (read == 0)
            {
                if (InputEnd != 0)
                {
                    Console.WriteLine("out of input bytes");
                    return Error = Error.MSPACK_ERR_READ;
                }
                else
                {
                    read = 2;
                    InputBuffer[0] = InputBuffer[1] = 0;
                    InputEnd = 1;
                }
            }

            // Update i_ptr and i_end
            InputPointer = 0;
            InputLength = read;
            return Error = Error.MSPACK_ERR_OK;
        }

        #endregion

        #region ReadHuff Methods

        private const int HUFF_MAXBITS = 16;

        /// <summary>
        /// Decodes the next huffman symbol from the input bitstream into var.
        /// Do not use this macro on a table unless build_decode_table() succeeded.
        /// </summary>
        public int READ_HUFFSYM(ushort[] decodingTable, ref uint var, int tablebits, byte[] lengthTable, int maxsymbols, ref int i, ref int i_ptr, ref int i_end, ref int bits_left, ref uint bit_buffer, bool msb)
        {
            // ENSURE_BITS(HUFF_MAXBITS)
            while (bits_left < HUFF_MAXBITS)
            {
                READ_BYTES;
            }

            if (Error != Error.MSPACK_ERR_OK)
                return (int)Error;

            int peek;
            if (msb)
                peek = (int)(bit_buffer >> (BITBUF_WIDTH - (tablebits)));
            else
                peek = (int)(bit_buffer & ((1 << (tablebits)) - 1));

            ushort sym = decodingTable[peek];
            if (sym >= maxsymbols)
            {
                int ret = HUFF_TRAVERSE(decodingTable, tablebits, maxsymbols, ref i, ref sym, bit_buffer, msb);
                if (ret != 0)
                    return ret;
            }

            var = sym;
            i = lengthTable[sym];

            // REMOVE_BITS(i);
            if (msb)
            {
                bit_buffer <<= i;
                bits_left -= i;
            }
            else
            {
                bit_buffer >>= i;
                bits_left -= i;
            }

            return (int)Error.MSPACK_ERR_OK;
        }

        public int HUFF_TRAVERSE(ushort[] decodingTable, int tablebits, int maxsymbols, ref int i, ref ushort sym, uint bit_buffer, bool msb)
        {
            if (msb)
            {
                i = 1 << (BITBUF_WIDTH - tablebits);
                do
                {
                    if ((i >>= 1) == 0)
                        return HUFF_ERROR();

                    sym = decodingTable[(sym << 1) | ((bit_buffer & i) != 0 ? 1 : 0)];
                } while (sym >= maxsymbols);
            }
            else
            {
                i = tablebits - 1;
                do
                {
                    if (i++ > HUFF_MAXBITS)
                        return HUFF_ERROR();

                    try { sym = decodingTable[(sym << 1) | ((bit_buffer >> i) & 1)]; } catch { }
                } while (sym >= maxsymbols);
            }

            return (int)Error.MSPACK_ERR_OK;
        }

        public abstract int HUFF_ERROR();

        /// <summary>
        /// This function was originally coded by David Tritscher.
        /// 
        /// It builds a fast huffman decoding table from
        /// a canonical huffman code lengths table.
        /// </summary>
        /// <param name="nsyms">total number of symbols in this huffman tree.</param>
        /// <param name="nbits">any symbols with a code length of nbits or less can be decoded in one lookup of the table.</param>
        /// <param name="length">A table to get code lengths from [0 to nsyms-1]</param>
        /// <param name="table">
        /// The table to fill up with decoded symbols and pointers.
        /// Should be ((1<<nbits) + (nsyms*2)) in length.
        /// </param>
        /// <returns>true for OK or false for error</returns>
        public static bool MakeDecodeTable(int nsyms, int nbits, byte[] length, ushort[] table, bool msb)
        {
            int next_symbol;
            long leaf, fill;
            long reverse; // Only used when !msb
            long pos = 0; // The current position in the decode table
            int table_mask = 1 << nbits;
            long bit_mask = table_mask >> 1; // Don't do 0 length codes

            // Fill entries for codes short enough for a direct mapping
            for (byte bit_num = 1; bit_num <= nbits; bit_num++)
            {
                for (ushort sym = 0; sym < nsyms; sym++)
                {
                    if (length[sym] != bit_num)
                        continue;

                    if (msb)
                    {
                        leaf = pos;
                    }
                    else
                    {
                        // Reverse the significant bits
                        fill = length[sym];
                        reverse = pos >> (nbits - (byte)fill);
                        leaf = 0;

                        do
                        {
                            leaf <<= 1;
                            leaf |= reverse & 1;
                            reverse >>= 1;
                        } while (--fill != 0);
                    }

                    if ((pos += bit_mask) > table_mask)
                        return false; // Table overrun

                    // Fill all possible lookups of this symbol with the symbol itself
                    if (msb)
                    {
                        for (fill = bit_mask; fill-- > 0;)
                        {
                            table[leaf++] = sym;
                        }
                    }
                    else
                    {
                        fill = bit_mask;
                        next_symbol = 1 << bit_num;

                        do
                        {
                            table[leaf] = sym;
                            leaf += next_symbol;
                        } while (--fill != 0);
                    }
                }

                bit_mask >>= 1;
            }

            // Exit with success if table is now complete
            if (pos == table_mask)
                return true;

            // Mark all remaining table entries as unused
            for (long sym = pos; sym < table_mask; sym++)
            {
                if (msb)
                {
                    table[sym] = 0xFFFF;
                }
                else
                {
                    reverse = sym;
                    leaf = 0;
                    fill = nbits;

                    do
                    {
                        leaf <<= 1;
                        leaf |= reverse & 1;
                        reverse >>= 1;
                    } while (--fill != 0);

                    table[leaf] = 0xFFFF;
                }
            }

            // next_symbol = base of allocation for long codes
            next_symbol = ((table_mask >> 1) < nsyms) ? nsyms : (table_mask >> 1);

            // Give ourselves room for codes to grow by up to 16 more bits.
            // codes now start at bit nbits+16 and end at (nbits+16-codelength)
            pos <<= 16;
            table_mask <<= 16;
            bit_mask = 1 << 15;

            for (int bit_num = nbits + 1; bit_num <= HUFF_MAXBITS; bit_num++)
            {
                for (ushort sym = 0; sym < nsyms; sym++)
                {
                    if (length[sym] != bit_num)
                        continue;
                    if (pos >= table_mask)
                        return false; // Table overflow

                    if (msb)
                    {
                        leaf = pos >> 16;
                    }
                    else
                    {
                        // leaf = the first nbits of the code, reversed
                        reverse = pos >> 16;
                        leaf = 0;
                        fill = nbits;

                        do
                        {
                            leaf <<= 1;
                            leaf |= reverse & 1;
                            reverse >>= 1;
                        } while (--fill != 0);
                    }

                    for (fill = 0; fill < (bit_num - nbits); fill++)
                    {
                        // If this path hasn't been taken yet, 'allocate' two entries
                        if (table[leaf] == 0xFFFF)
                        {
                            table[(next_symbol << 1)] = 0xFFFF;
                            table[(next_symbol << 1) + 1] = 0xFFFF;
                            table[leaf] = (ushort)next_symbol++;
                        }

                        // Follow the path and select either left or right for next bit
                        leaf = table[leaf] << 1;
                        if (((pos >> (15 - (int)fill)) & 1) != 0)
                            leaf++;
                    }

                    table[leaf] = sym;
                    pos += bit_mask;
                }

                bit_mask >>= 1;
            }

            // Full table?
            return pos == table_mask;
        }

        #endregion
    }
}