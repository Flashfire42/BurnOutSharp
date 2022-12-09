using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using BurnOutSharp.Interfaces;
using BurnOutSharp.Matching;
using BurnOutSharp.Wrappers;

namespace BurnOutSharp.PackerType
{
    // TODO: Add extraction
    // https://raw.githubusercontent.com/wolfram77web/app-peid/master/userdb.txt
    public class GenteeInstaller : IPortableExecutableCheck, IScannable
    {
        /// <inheritdoc/>
        public string CheckPortableExecutable(string file, PortableExecutable pex, bool includeDebug)
        {
            // Get the sections from the executable, if possible
            var sections = pex?.SectionTable;
            if (sections == null)
                return null;

            // Get the .data/DATA section, if it exists
            var dataSectionRaw = pex.GetFirstSectionData(".data") ?? pex.GetFirstSectionData("DATA");
            if (dataSectionRaw != null)
            {
                var matchers = new List<ContentMatchSet>
                {
                    // Gentee installer
                    new ContentMatchSet(new byte?[]
                    {
                        0x47, 0x65, 0x6E, 0x74, 0x65, 0x65, 0x20, 0x69,
                        0x6E, 0x73, 0x74, 0x61, 0x6C, 0x6C, 0x65, 0x72,
                    }, "Gentee Installer"),

                    // ginstall.dll
                    new ContentMatchSet(new byte?[]
                    {
                        0x67, 0x69, 0x6E, 0x73, 0x74, 0x61, 0x6C, 0x6C,
                        0x2E, 0x64, 0x6C, 0x6C,
                    }, "Gentee Installer"),
                };

                return MatchUtil.GetFirstMatch(file, dataSectionRaw, matchers, includeDebug);
            }

            return null;
        }

        /// <inheritdoc/>
        public ConcurrentDictionary<string, ConcurrentQueue<string>> Scan(Scanner scanner, string file)
        {
            if (!File.Exists(file))
                return null;

            using (var fs = File.OpenRead(file))
            {
                return Scan(scanner, fs, file);
            }
        }

        /// <inheritdoc/>
        public ConcurrentDictionary<string, ConcurrentQueue<string>> Scan(Scanner scanner, Stream stream, string file)
        {
            return null;
        }
    }
}
