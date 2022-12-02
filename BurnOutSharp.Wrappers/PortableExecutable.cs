﻿using System.IO;

namespace BurnOutSharp.Wrappers
{
    public class PortableExecutable
    {
        #region Pass-Through Properties

        // TODO: Determine what properties can be passed through

        #endregion

        #region Extension Properties

        // TODO: Determine what extension properties are needed

        #endregion

        #region Instance Variables

        /// <summary>
        /// Internal representation of the executable
        /// </summary>
        private BurnOutSharp.Models.PortableExecutable.Executable _executable;

        #endregion

        /// <summary>
        /// Private constructor
        /// </summary>
        private PortableExecutable() { }

        /// <summary>
        /// Create a PE executable from a byte array and offset
        /// </summary>
        /// <param name="data">Byte array representing the executable</param>
        /// <param name="offset">Offset within the array to parse</param>
        /// <returns>A PE executable wrapper on success, null on failure</returns>
        public static PortableExecutable Create(byte[] data, int offset)
        {
            var executable = BurnOutSharp.Builder.PortableExecutable.ParseExecutable(data, offset);
            if (executable == null)
                return null;

            var wrapper = new PortableExecutable { _executable = executable };
            return wrapper;
        }

        /// <summary>
        /// Create a PE executable from a Stream
        /// </summary>
        /// <param name="data">Stream representing the executable</param>
        /// <returns>A PE executable wrapper on success, null on failure</returns>
        public static PortableExecutable Create(Stream data)
        {
            var executable = BurnOutSharp.Builder.PortableExecutable.ParseExecutable(data);
            if (executable == null)
                return null;

            var wrapper = new PortableExecutable { _executable = executable };
            return wrapper;
        }
    }
}