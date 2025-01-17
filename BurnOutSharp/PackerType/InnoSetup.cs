﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BurnOutSharp.Interfaces;
using BurnOutSharp.Matching;
using BurnOutSharp.Wrappers;

namespace BurnOutSharp.PackerType
{
    // TODO: Add extraction - https://github.com/dscharrer/InnoExtract
    // https://raw.githubusercontent.com/wolfram77web/app-peid/master/userdb.txt
    public class InnoSetup : INewExecutableCheck, IPortableExecutableCheck, IScannable
    {
        /// <inheritdoc/>
        public string CheckNewExecutable(string file, NewExecutable nex, bool includeDebug)
        {
            // Check we have a valid executable
            if (nex == null)
                return null;
            
            // Check for "Inno" in the reserved words
            if (nex.Stub_Reserved2[4] == 0x6E49 && nex.Stub_Reserved2[5] == 0x6F6E)
            {
                string version = GetOldVersion(file, nex);
                if (!string.IsNullOrWhiteSpace(version))
                    return $"Inno Setup {version}";
                
                return "Inno Setup (Unknown Version)";
            }

            return null;
        }

        /// <inheritdoc/>
        public string CheckPortableExecutable(string file, PortableExecutable pex, bool includeDebug)
        {
            // Get the sections from the executable, if possible
            var sections = pex?.SectionTable;
            if (sections == null)
                return null;

            // Get the .data/DATA section strings, if they exist
            List<string> strs = pex.GetFirstSectionStrings(".data") ?? pex.GetFirstSectionStrings("DATA");
            if (strs != null)
            {
                string str = strs.FirstOrDefault(s => s.StartsWith("Inno Setup Setup Data"));
                if (str != null)
                {
                    return str.Replace("Inno Setup Setup Data", "Inno Setup")
                        .Replace("(u)", "[Unicode]")
                        .Replace("(", string.Empty)
                        .Replace(")", string.Empty)
                        .Replace("[Unicode]", "(Unicode)");
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public ConcurrentDictionary<string, ConcurrentQueue<string>> Scan(Scanner scanner, string file)
        {
            if (!File.Exists(file))
                return null;

            using (var fs = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return Scan(scanner, fs, file);
            }
        }

        /// <inheritdoc/>
        public ConcurrentDictionary<string, ConcurrentQueue<string>> Scan(Scanner scanner, Stream stream, string file)
        {
            return null;
        }

        private static string GetOldVersion(string file, NewExecutable nex)
        {
            // Notes:
            // Look into `SETUPLDR` in the resident-name table
            // Look into `SETUPLDR.EXE` in the nonresident-name table

            // TODO: Don't read entire file
            // TODO: Only 64 bytes at the end of the file is needed
            var data = nex.ReadArbitraryRange();
            if (data != null)
            {
                var matchers = new List<ContentMatchSet>
                {
                    // "rDlPtS02" + (char)0x87 + "eVx"
                    new ContentMatchSet(new byte?[] { 0x72, 0x44, 0x6C, 0x50, 0x74, 0x53, 0x30, 0x32, 0x87, 0x65, 0x56, 0x78 }, "1.2.16 or earlier"),
                };

                return MatchUtil.GetFirstMatch(file, data, matchers, false) ?? "Unknown 1.X";
            }
            
            return "Unknown 1.X"; 
        }
    }
}
