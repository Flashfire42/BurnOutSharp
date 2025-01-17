﻿using System;
using System.IO;

namespace BurnOutSharp.Wrappers
{
    public class Nitro : WrapperBase
    {
        #region Pass-Through Properties

        #region Common Header

        /// <inheritdoc cref="Models.Nitro.CommonHeader.GameTitle"/>
        public string GameTitle => _cart.CommonHeader.GameTitle;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.GameCode"/>
        public uint GameCode => _cart.CommonHeader.GameCode;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.MakerCode"/>
        public string MakerCode => _cart.CommonHeader.MakerCode;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.UnitCode"/>
        public Models.Nitro.Unitcode UnitCode => _cart.CommonHeader.UnitCode;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.EncryptionSeedSelect"/>
        public byte EncryptionSeedSelect => _cart.CommonHeader.EncryptionSeedSelect;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.DeviceCapacity"/>
        public byte DeviceCapacity => _cart.CommonHeader.DeviceCapacity;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.Reserved1"/>
        public byte[] Reserved1 => _cart.CommonHeader.Reserved1;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.GameRevision"/>
        public ushort GameRevision => _cart.CommonHeader.GameRevision;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.RomVersion"/>
        public byte RomVersion => _cart.CommonHeader.RomVersion;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.InternalFlags"/>
        public byte InternalFlags => _cart.CommonHeader.InternalFlags;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM9RomOffset"/>
        public uint ARM9RomOffset => _cart.CommonHeader.ARM9RomOffset;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM9EntryAddress"/>
        public uint ARM9EntryAddress => _cart.CommonHeader.ARM9EntryAddress;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM9LoadAddress"/>
        public uint ARM9LoadAddress => _cart.CommonHeader.ARM9LoadAddress;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM9Size"/>
        public uint ARM9Size => _cart.CommonHeader.ARM9Size;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM7RomOffset"/>
        public uint ARM7RomOffset => _cart.CommonHeader.ARM7RomOffset;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM7EntryAddress"/>
        public uint ARM7EntryAddress => _cart.CommonHeader.ARM7EntryAddress;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM7LoadAddress"/>
        public uint ARM7LoadAddress => _cart.CommonHeader.ARM7LoadAddress;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM7Size"/>
        public uint ARM7Size => _cart.CommonHeader.ARM7Size;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.FileNameTableOffset"/>
        public uint FileNameTableOffset => _cart.CommonHeader.FileNameTableOffset;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.FileNameTableLength"/>
        public uint FileNameTableLength => _cart.CommonHeader.FileNameTableLength;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.FileAllocationTableOffset"/>
        public uint FileAllocationTableOffset => _cart.CommonHeader.FileAllocationTableOffset;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.FileAllocationTableLength"/>
        public uint FileAllocationTableLength => _cart.CommonHeader.FileAllocationTableLength;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM9OverlayOffset"/>
        public uint ARM9OverlayOffset => _cart.CommonHeader.ARM9OverlayOffset;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM9OverlayLength"/>
        public uint ARM9OverlayLength => _cart.CommonHeader.ARM9OverlayLength;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM7OverlayOffset"/>
        public uint ARM7OverlayOffset => _cart.CommonHeader.ARM7OverlayOffset;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM7OverlayLength"/>
        public uint ARM7OverlayLength => _cart.CommonHeader.ARM7OverlayLength;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.NormalCardControlRegisterSettings"/>
        public uint NormalCardControlRegisterSettings => _cart.CommonHeader.NormalCardControlRegisterSettings;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.SecureCardControlRegisterSettings"/>
        public uint SecureCardControlRegisterSettings => _cart.CommonHeader.SecureCardControlRegisterSettings;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.IconBannerOffset"/>
        public uint IconBannerOffset => _cart.CommonHeader.IconBannerOffset;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.SecureAreaCRC"/>
        public ushort SecureAreaCRC => _cart.CommonHeader.SecureAreaCRC;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.SecureTransferTimeout"/>
        public ushort SecureTransferTimeout => _cart.CommonHeader.SecureTransferTimeout;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM9Autoload"/>
        public uint ARM9Autoload => _cart.CommonHeader.ARM9Autoload;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.ARM7Autoload"/>
        public uint ARM7Autoload => _cart.CommonHeader.ARM7Autoload;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.SecureDisable"/>
        public byte[] SecureDisable => _cart.CommonHeader.SecureDisable;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.NTRRegionRomSize"/>
        public uint NTRRegionRomSize => _cart.CommonHeader.NTRRegionRomSize;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.HeaderSize"/>
        public uint HeaderSize => _cart.CommonHeader.HeaderSize;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.Reserved2"/>
        public byte[] Reserved2 => _cart.CommonHeader.Reserved2;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.NintendoLogo"/>
        public byte[] NintendoLogo => _cart.CommonHeader.NintendoLogo;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.NintendoLogoCRC"/>
        public ushort NintendoLogoCRC => _cart.CommonHeader.NintendoLogoCRC;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.HeaderCRC"/>
        public ushort HeaderCRC => _cart.CommonHeader.HeaderCRC;

        /// <inheritdoc cref="Models.Nitro.CommonHeader.DebuggerReserved"/>
        public byte[] DebuggerReserved => _cart.CommonHeader.DebuggerReserved;

        #endregion

        #region Extended DSi Header

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.GlobalMBK15Settings"/>
        public uint[] GlobalMBK15Settings => _cart.ExtendedDSiHeader?.GlobalMBK15Settings;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.LocalMBK68SettingsARM9"/>
        public uint[] LocalMBK68SettingsARM9 => _cart.ExtendedDSiHeader?.LocalMBK68SettingsARM9;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.LocalMBK68SettingsARM7"/>
        public uint[] LocalMBK68SettingsARM7 => _cart.ExtendedDSiHeader?.LocalMBK68SettingsARM7;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.GlobalMBK9Setting"/>
        public uint? GlobalMBK9Setting => _cart.ExtendedDSiHeader?.GlobalMBK9Setting;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.RegionFlags"/>
        public uint? RegionFlags => _cart.ExtendedDSiHeader?.RegionFlags;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.AccessControl"/>
        public uint? AccessControl => _cart.ExtendedDSiHeader?.AccessControl;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM7SCFGEXTMask"/>
        public uint? ARM7SCFGEXTMask => _cart.ExtendedDSiHeader?.ARM7SCFGEXTMask;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ReservedFlags"/>
        public uint? ReservedFlags => _cart.ExtendedDSiHeader?.ReservedFlags;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM9iRomOffset"/>
        public uint? ARM9iRomOffset => _cart.ExtendedDSiHeader?.ARM9iRomOffset;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.Reserved3"/>
        public uint? Reserved3 => _cart.ExtendedDSiHeader?.Reserved3;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM9iLoadAddress"/>
        public uint? ARM9iLoadAddress => _cart.ExtendedDSiHeader?.ARM9iLoadAddress;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM9iSize"/>
        public uint? ARM9iSize => _cart.ExtendedDSiHeader?.ARM9iSize;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM7iRomOffset"/>
        public uint? ARM7iRomOffset => _cart.ExtendedDSiHeader?.ARM7iRomOffset;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.Reserved4"/>
        public uint? Reserved4 => _cart.ExtendedDSiHeader?.Reserved4;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM7iLoadAddress"/>
        public uint? ARM7iLoadAddress => _cart.ExtendedDSiHeader?.ARM7iLoadAddress;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM7iSize"/>
        public uint? ARM7iSize => _cart.ExtendedDSiHeader?.ARM7iSize;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestNTRRegionOffset"/>
        public uint? DigestNTRRegionOffset => _cart.ExtendedDSiHeader?.DigestNTRRegionOffset;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestNTRRegionLength"/>
        public uint? DigestNTRRegionLength => _cart.ExtendedDSiHeader?.DigestNTRRegionLength;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestTWLRegionOffset"/>
        public uint? DigestTWLRegionOffset => _cart.ExtendedDSiHeader?.DigestTWLRegionOffset;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestTWLRegionLength"/>
        public uint? DigestTWLRegionLength => _cart.ExtendedDSiHeader?.DigestTWLRegionLength;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestSectorHashtableRegionOffset"/>
        public uint? DigestSectorHashtableRegionOffset => _cart.ExtendedDSiHeader?.DigestSectorHashtableRegionOffset;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestSectorHashtableRegionLength"/>
        public uint? DigestSectorHashtableRegionLength => _cart.ExtendedDSiHeader?.DigestSectorHashtableRegionLength;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestBlockHashtableRegionOffset"/>
        public uint? DigestBlockHashtableRegionOffset => _cart.ExtendedDSiHeader?.DigestBlockHashtableRegionOffset;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestBlockHashtableRegionLength"/>
        public uint? DigestBlockHashtableRegionLength => _cart.ExtendedDSiHeader?.DigestBlockHashtableRegionLength;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestSectorSize"/>
        public uint? DigestSectorSize => _cart.ExtendedDSiHeader?.DigestSectorSize;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestBlockSectorCount"/>
        public uint? DigestBlockSectorCount => _cart.ExtendedDSiHeader?.DigestBlockSectorCount;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.IconBannerSize"/>
        public uint? IconBannerSize => _cart.ExtendedDSiHeader?.IconBannerSize;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.Unknown1"/>
        public uint? Unknown1 => _cart.ExtendedDSiHeader?.Unknown1;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ModcryptArea1Offset"/>
        public uint? ModcryptArea1Offset => _cart.ExtendedDSiHeader?.ModcryptArea1Offset;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ModcryptArea1Size"/>
        public uint? ModcryptArea1Size => _cart.ExtendedDSiHeader?.ModcryptArea1Size;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ModcryptArea2Offset"/>
        public uint? ModcryptArea2Offset => _cart.ExtendedDSiHeader?.ModcryptArea2Offset;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ModcryptArea2Size"/>
        public uint? ModcryptArea2Size => _cart.ExtendedDSiHeader?.ModcryptArea2Size;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.TitleID"/>
        public byte[] TitleID => _cart.ExtendedDSiHeader?.TitleID;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DSiWarePublicSavSize"/>
        public uint? DSiWarePublicSavSize => _cart.ExtendedDSiHeader?.DSiWarePublicSavSize;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DSiWarePrivateSavSize"/>
        public uint? DSiWarePrivateSavSize => _cart.ExtendedDSiHeader?.DSiWarePrivateSavSize;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ReservedZero"/>
        public byte[] ReservedZero => _cart.ExtendedDSiHeader?.ReservedZero;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.Unknown2"/>
        public byte[] Unknown2 => _cart.ExtendedDSiHeader?.Unknown2;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM9WithSecureAreaSHA1HMACHash"/>
        public byte[] ARM9WithSecureAreaSHA1HMACHash => _cart.ExtendedDSiHeader?.ARM9WithSecureAreaSHA1HMACHash;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM7SHA1HMACHash"/>
        public byte[] ARM7SHA1HMACHash => _cart.ExtendedDSiHeader?.ARM7SHA1HMACHash;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.DigestMasterSHA1HMACHash"/>
        public byte[] DigestMasterSHA1HMACHash => _cart.ExtendedDSiHeader?.DigestMasterSHA1HMACHash;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.BannerSHA1HMACHash"/>
        public byte[] BannerSHA1HMACHash => _cart.ExtendedDSiHeader?.BannerSHA1HMACHash;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM9iDecryptedSHA1HMACHash"/>
        public byte[] ARM9iDecryptedSHA1HMACHash => _cart.ExtendedDSiHeader?.ARM9iDecryptedSHA1HMACHash;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM7iDecryptedSHA1HMACHash"/>
        public byte[] ARM7iDecryptedSHA1HMACHash => _cart.ExtendedDSiHeader?.ARM7iDecryptedSHA1HMACHash;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.Reserved5"/>
        public byte[] Reserved5 => _cart.ExtendedDSiHeader?.Reserved5;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ARM9NoSecureAreaSHA1HMACHash"/>
        public byte[] ARM9NoSecureAreaSHA1HMACHash => _cart.ExtendedDSiHeader?.ARM9NoSecureAreaSHA1HMACHash;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.Reserved6"/>
        public byte[] Reserved6 => _cart.ExtendedDSiHeader?.Reserved6;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.ReservedAndUnchecked"/>
        public byte[] ReservedAndUnchecked => _cart.ExtendedDSiHeader?.ReservedAndUnchecked;

        /// <inheritdoc cref="Models.Nitro.ExtendedDSiHeader.RSASignature"/>
        public byte[] RSASignature => _cart.ExtendedDSiHeader?.RSASignature;

        #endregion

        #region Secure Area

        /// <inheritdoc cref="Models.Nitro.Cart.SecureArea"/>
        public byte[] SecureArea => _cart.SecureArea;

        #endregion

        #region Name Table

        /// <inheritdoc cref="Models.Nitro.NameTable.FolderAllocationTable"/>
        public Models.Nitro.FolderAllocationTableEntry[] FolderAllocationTable => _cart.NameTable.FolderAllocationTable;

        /// <inheritdoc cref="Models.Nitro.NameTable.NameList"/>
        public Models.Nitro.NameListEntry[] NameList => _cart.NameTable.NameList;

        #endregion

        #region Name Table

        /// <inheritdoc cref="Models.Nitro.Cart.FileAllocationTable"/>
        public Models.Nitro.FileAllocationTableEntry[] FileAllocationTable => _cart.FileAllocationTable;

        #endregion

        #endregion

        #region Instance Variables

        /// <summary>
        /// Internal representation of the cart
        /// </summary>
        private Models.Nitro.Cart _cart;

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor
        /// </summary>
        private Nitro() { }

        /// <summary>
        /// Create a NDS cart image from a byte array and offset
        /// </summary>
        /// <param name="data">Byte array representing the archive</param>
        /// <param name="offset">Offset within the array to parse</param>
        /// <returns>A NDS cart image wrapper on success, null on failure</returns>
        public static Nitro Create(byte[] data, int offset)
        {
            // If the data is invalid
            if (data == null)
                return null;

            // If the offset is out of bounds
            if (offset < 0 || offset >= data.Length)
                return null;

            // Create a memory stream and use that
            MemoryStream dataStream = new MemoryStream(data, offset, data.Length - offset);
            return Create(dataStream);
        }

        /// <summary>
        /// Create a NDS cart image from a Stream
        /// </summary>
        /// <param name="data">Stream representing the archive</param>
        /// <returns>A NDS cart image wrapper on success, null on failure</returns>
        public static Nitro Create(Stream data)
        {
            // If the data is invalid
            if (data == null || data.Length == 0 || !data.CanSeek || !data.CanRead)
                return null;

            var archive = Builders.Nitro.ParseCart(data);
            if (archive == null)
                return null;

            var wrapper = new Nitro
            {
                _cart = archive,
                _dataSource = DataSource.Stream,
                _streamData = data,
            };
            return wrapper;
        }

        #endregion

        #region Printing

        /// <inheritdoc/>
        public override void Print()
        {
            Console.WriteLine("NDS Cart Information:");
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            PrintCommonHeader();
            PrintExtendedDSiHeader();
            PrintSecureArea();
            PrintNameTable();
            PrintFileAllocationTable();
        }

        /// <summary>
        /// Print common header information
        /// </summary>
        private void PrintCommonHeader()
        {
            Console.WriteLine("  Common Header Information:");
            Console.WriteLine("  -------------------------");
            Console.WriteLine($"  Game title: {GameTitle ?? "[NULL]"}");
            Console.WriteLine($"  Game code: {GameCode} (0x{GameCode:X})");
            Console.WriteLine($"  Maker code: {MakerCode ?? "[NULL]"}");
            Console.WriteLine($"  Unit code: {UnitCode} (0x{UnitCode:X})");
            Console.WriteLine($"  Encryption seed select: {EncryptionSeedSelect} (0x{EncryptionSeedSelect:X})");
            Console.WriteLine($"  Device capacity: {DeviceCapacity} (0x{DeviceCapacity:X})");
            Console.WriteLine($"  Reserved 1: {BitConverter.ToString(Reserved1).Replace('-', ' ')}");
            Console.WriteLine($"  Game revision: {GameRevision} (0x{GameRevision:X})");
            Console.WriteLine($"  Rom version: {RomVersion} (0x{RomVersion:X})");
            Console.WriteLine($"  ARM9 rom offset: {ARM9RomOffset} (0x{ARM9RomOffset:X})");
            Console.WriteLine($"  ARM9 entry address: {ARM9EntryAddress} (0x{ARM9EntryAddress:X})");
            Console.WriteLine($"  ARM9 load address: {ARM9LoadAddress} (0x{ARM9LoadAddress:X})");
            Console.WriteLine($"  ARM9 size: {ARM9Size} (0x{ARM9Size:X})");
            Console.WriteLine($"  ARM7 rom offset: {ARM7RomOffset} (0x{ARM7RomOffset:X})");
            Console.WriteLine($"  ARM7 entry address: {ARM7EntryAddress} (0x{ARM7EntryAddress:X})");
            Console.WriteLine($"  ARM7 load address: {ARM7LoadAddress} (0x{ARM7LoadAddress:X})");
            Console.WriteLine($"  ARM7 size: {ARM7Size} (0x{ARM7Size:X})");
            Console.WriteLine($"  File name table offset: {FileNameTableOffset} (0x{FileNameTableOffset:X})");
            Console.WriteLine($"  File name table length: {FileNameTableLength} (0x{FileNameTableLength:X})");
            Console.WriteLine($"  File allocation table offset: {FileAllocationTableOffset} (0x{FileAllocationTableOffset:X})");
            Console.WriteLine($"  File allocation table length: {FileAllocationTableLength} (0x{FileAllocationTableLength:X})");
            Console.WriteLine($"  ARM9 overlay offset: {ARM9OverlayOffset} (0x{ARM9OverlayOffset:X})");
            Console.WriteLine($"  ARM9 overlay length: {ARM9OverlayLength} (0x{ARM9OverlayLength:X})");
            Console.WriteLine($"  ARM7 overlay offset: {ARM7OverlayOffset} (0x{ARM7OverlayOffset:X})");
            Console.WriteLine($"  ARM7 overlay length: {ARM7OverlayLength} (0x{ARM7OverlayLength:X})");
            Console.WriteLine($"  Normal card control register settings: {NormalCardControlRegisterSettings} (0x{NormalCardControlRegisterSettings:X})");
            Console.WriteLine($"  Secure card control register settings: {SecureCardControlRegisterSettings} (0x{SecureCardControlRegisterSettings:X})");
            Console.WriteLine($"  Icon banner offset: {IconBannerOffset} (0x{IconBannerOffset:X})");
            Console.WriteLine($"  Secure area CRC: {SecureAreaCRC} (0x{SecureAreaCRC:X})");
            Console.WriteLine($"  Secure transfer timeout: {SecureTransferTimeout} (0x{SecureTransferTimeout:X})");
            Console.WriteLine($"  ARM9 autoload: {ARM9Autoload} (0x{ARM9Autoload:X})");
            Console.WriteLine($"  ARM7 autoload: {ARM7Autoload} (0x{ARM7Autoload:X})");
            Console.WriteLine($"  Secure disable: {SecureDisable} (0x{SecureDisable:X})");
            Console.WriteLine($"  NTR region rom size: {NTRRegionRomSize} (0x{NTRRegionRomSize:X})");
            Console.WriteLine($"  Header size: {HeaderSize} (0x{HeaderSize:X})");
            Console.WriteLine($"  Reserved 2: {BitConverter.ToString(Reserved2).Replace('-', ' ')}");
            Console.WriteLine($"  Nintendo logo: {BitConverter.ToString(NintendoLogo).Replace('-', ' ')}");
            Console.WriteLine($"  Nintendo logo CRC: {NintendoLogoCRC} (0x{NintendoLogoCRC:X})");
            Console.WriteLine($"  Header CRC: {HeaderCRC} (0x{HeaderCRC:X})");
            Console.WriteLine($"  Debugger reserved: {BitConverter.ToString(DebuggerReserved).Replace('-', ' ')}");
            Console.WriteLine();
        }

        /// <summary>
        /// Print extended DSi header information
        /// </summary>
        private void PrintExtendedDSiHeader()
        {
            Console.WriteLine("  Extended DSi Header Information:");
            Console.WriteLine("  -------------------------");
            if (_cart.ExtendedDSiHeader == null)
            {
                Console.WriteLine("  No extended DSi header");
            }
            else
            {
                Console.WriteLine($"  Global MBK1..MBK5 settings: {string.Join(", ", GlobalMBK15Settings)}");
                Console.WriteLine($"  Local MBK6..MBK8 settings for ARM9: {string.Join(", ", LocalMBK68SettingsARM9)}");
                Console.WriteLine($"  Local MBK6..MBK8 settings for ARM7: {string.Join(", ", LocalMBK68SettingsARM7)}");
                Console.WriteLine($"  Global MBK9 setting: {GlobalMBK9Setting} (0x{GlobalMBK9Setting:X})");
                Console.WriteLine($"  Region flags: {RegionFlags} (0x{RegionFlags:X})");
                Console.WriteLine($"  Access control: {AccessControl} (0x{AccessControl:X})");
                Console.WriteLine($"  ARM7 SCFG EXT mask: {ARM7SCFGEXTMask} (0x{ARM7SCFGEXTMask:X})");
                Console.WriteLine($"  Reserved/flags?: {ReservedFlags} (0x{ReservedFlags:X})");
                Console.WriteLine($"  ARM9i rom offset: {ARM9iRomOffset} (0x{ARM9iRomOffset:X})");
                Console.WriteLine($"  Reserved 3: {Reserved3} (0x{Reserved3:X})");
                Console.WriteLine($"  ARM9i load address: {ARM9iLoadAddress} (0x{ARM9iLoadAddress:X})");
                Console.WriteLine($"  ARM9i size: {ARM9iSize} (0x{ARM9iSize:X})");
                Console.WriteLine($"  ARM7i rom offset: {ARM7iRomOffset} (0x{ARM7iRomOffset:X})");
                Console.WriteLine($"  Reserved 4: {Reserved4} (0x{Reserved4:X})");
                Console.WriteLine($"  ARM7i load address: {ARM7iLoadAddress} (0x{ARM7iLoadAddress:X})");
                Console.WriteLine($"  ARM7i size: {ARM7iSize} (0x{ARM7iSize:X})");
                Console.WriteLine($"  Digest NTR region offset: {DigestNTRRegionOffset} (0x{DigestNTRRegionOffset:X})");
                Console.WriteLine($"  Digest NTR region length: {DigestNTRRegionLength} (0x{DigestNTRRegionLength:X})");
                Console.WriteLine($"  Digest TWL region offset: {DigestTWLRegionOffset} (0x{DigestTWLRegionOffset:X})");
                Console.WriteLine($"  Digest TWL region length: {DigestTWLRegionLength} (0x{DigestTWLRegionLength:X})");
                Console.WriteLine($"  Digest sector hashtable region offset: {DigestSectorHashtableRegionOffset} (0x{DigestSectorHashtableRegionOffset:X})");
                Console.WriteLine($"  Digest sector hashtable region length: {DigestSectorHashtableRegionLength} (0x{DigestSectorHashtableRegionLength:X})");
                Console.WriteLine($"  Digest block hashtable region offset: {DigestBlockHashtableRegionOffset} (0x{DigestBlockHashtableRegionOffset:X})");
                Console.WriteLine($"  Digest block hashtable region length: {DigestBlockHashtableRegionLength} (0x{DigestBlockHashtableRegionLength:X})");
                Console.WriteLine($"  Digest sector size: {DigestSectorSize} (0x{DigestSectorSize:X})");
                Console.WriteLine($"  Digest block sector count: {DigestBlockSectorCount} (0x{DigestBlockSectorCount:X})");
                Console.WriteLine($"  Icon banner size: {IconBannerSize} (0x{IconBannerSize:X})");
                Console.WriteLine($"  Unknown 1: {Unknown1} (0x{Unknown1:X})");
                Console.WriteLine($"  Modcrypt area 1 offset: {ModcryptArea1Offset} (0x{ModcryptArea1Offset:X})");
                Console.WriteLine($"  Modcrypt area 1 size: {ModcryptArea1Size} (0x{ModcryptArea1Size:X})");
                Console.WriteLine($"  Modcrypt area 2 offset: {ModcryptArea2Offset} (0x{ModcryptArea2Offset:X})");
                Console.WriteLine($"  Modcrypt area 2 size: {ModcryptArea2Size} (0x{ModcryptArea2Size:X})");
                Console.WriteLine($"  Title ID: {BitConverter.ToString(TitleID).Replace('-', ' ')}");
                Console.WriteLine($"  DSiWare 'public.sav' size: {DSiWarePublicSavSize} (0x{DSiWarePublicSavSize:X})");
                Console.WriteLine($"  DSiWare 'private.sav' size: {DSiWarePrivateSavSize} (0x{DSiWarePrivateSavSize:X})");
                Console.WriteLine($"  Reserved (zero): {BitConverter.ToString(ReservedZero).Replace('-', ' ')}");
                Console.WriteLine($"  Unknown 2: {BitConverter.ToString(Unknown2).Replace('-', ' ')}");
                Console.WriteLine($"  ARM9 (with encrypted secure area) SHA1 HMAC hash: {BitConverter.ToString(ARM9WithSecureAreaSHA1HMACHash).Replace('-', ' ')}");
                Console.WriteLine($"  ARM7 SHA1 HMAC hash: {BitConverter.ToString(ARM7SHA1HMACHash).Replace('-', ' ')}");
                Console.WriteLine($"  Digest master SHA1 HMAC hash: {BitConverter.ToString(DigestMasterSHA1HMACHash).Replace('-', ' ')}");
                Console.WriteLine($"  Banner SHA1 HMAC hash: {BitConverter.ToString(BannerSHA1HMACHash).Replace('-', ' ')}");
                Console.WriteLine($"  ARM9i (decrypted) SHA1 HMAC hash: {BitConverter.ToString(ARM9iDecryptedSHA1HMACHash).Replace('-', ' ')}");
                Console.WriteLine($"  ARM7i (decrypted) SHA1 HMAC hash: {BitConverter.ToString(ARM7iDecryptedSHA1HMACHash).Replace('-', ' ')}");
                Console.WriteLine($"  Reserved 5: {BitConverter.ToString(Reserved5).Replace('-', ' ')}");
                Console.WriteLine($"  ARM9 (without secure area) SHA1 HMAC hash: {BitConverter.ToString(ARM9NoSecureAreaSHA1HMACHash).Replace('-', ' ')}");
                Console.WriteLine($"  Reserved 6: {BitConverter.ToString(Reserved6).Replace('-', ' ')}");
                Console.WriteLine($"  Reserved and unchecked region: {BitConverter.ToString(ReservedAndUnchecked).Replace('-', ' ')}");
                Console.WriteLine($"  RSA signature: {BitConverter.ToString(RSASignature).Replace('-', ' ')}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print secure area information
        /// </summary>
        private void PrintSecureArea()
        {
            Console.WriteLine("  Secure Area Information:");
            Console.WriteLine("  -------------------------");
            Console.WriteLine($"  {BitConverter.ToString(SecureArea).Replace('-', ' ')}");
            Console.WriteLine();
        }

        /// <summary>
        /// Print name table information
        /// </summary>
        private void PrintNameTable()
        {
            Console.WriteLine("  Name Table Information:");
            Console.WriteLine("  -------------------------");
            Console.WriteLine();

            PrintFolderAllocationTable();
            PrintNameList();
        }

        /// <summary>
        /// Print folder allocation table information
        /// </summary>
        private void PrintFolderAllocationTable()
        {
            Console.WriteLine($"  Folder Allocation Table:");
            Console.WriteLine("  -------------------------");
            if (FolderAllocationTable == null || FolderAllocationTable.Length == 0)
            {
                Console.WriteLine("  No folder allocation table entries");
            }
            else
            {
                for (int i = 0; i < FolderAllocationTable.Length; i++)
                {
                    var entry = FolderAllocationTable[i];
                    Console.WriteLine($"  Folder Allocation Table Entry {i}");
                    Console.WriteLine($"    Start offset: {entry.StartOffset} (0x{entry.StartOffset:X})");
                    Console.WriteLine($"    First file index: {entry.FirstFileIndex} (0x{entry.FirstFileIndex:X})");
                    if (entry.Unknown == 0xF0)
                    {
                        Console.WriteLine($"    Parent folder index: {entry.ParentFolderIndex} (0x{entry.ParentFolderIndex:X})");
                        Console.WriteLine($"    Unknown: {entry.Unknown} (0x{entry.Unknown:X})");
                    }
                    else
                    {
                        ushort totalEntries = (ushort)((entry.Unknown << 8) | entry.ParentFolderIndex);
                        Console.WriteLine($"    Total entries: {totalEntries} (0x{totalEntries:X})");
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print folder allocation table information
        /// </summary>
        private void PrintNameList()
        {
            Console.WriteLine($"  Name List:");
            Console.WriteLine("  -------------------------");
            if (NameList == null || NameList.Length == 0)
            {
                Console.WriteLine("  No name list entries");
            }
            else
            {
                for (int i = 0; i < NameList.Length; i++)
                {
                    var entry = NameList[i];
                    Console.WriteLine($"  Name List Entry {i}");
                    Console.WriteLine($"    Folder: {entry.Folder} (0x{entry.Folder:X})");
                    Console.WriteLine($"    Name: {entry.Name ?? "[NULL]"}");
                    if (entry.Folder)
                        Console.WriteLine($"    Index: {entry.Index} (0x{entry.Index:X})");
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print file allocation table information
        /// </summary>
        private void PrintFileAllocationTable()
        {
            Console.WriteLine($"  File Allocation Table:");
            Console.WriteLine("  -------------------------");
            if (FileAllocationTable == null || FileAllocationTable.Length == 0)
            {
                Console.WriteLine("  No file allocation table entries");
            }
            else
            {
                for (int i = 0; i < FileAllocationTable.Length; i++)
                {
                    var entry = FileAllocationTable[i];
                    Console.WriteLine($"  File Allocation Table Entry {i}");
                    Console.WriteLine($"    Start offset: {entry.StartOffset} (0x{entry.StartOffset:X})");
                    Console.WriteLine($"    End offset: {entry.EndOffset} (0x{entry.EndOffset:X})");
                }
            }
            Console.WriteLine();
        }

        #endregion
    }
}