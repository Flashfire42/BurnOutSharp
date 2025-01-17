﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using BurnOutSharp.Interfaces;
using BurnOutSharp.Matching;
using BurnOutSharp.Wrappers;

namespace BurnOutSharp.ProtectionType
{
    public class GFWL : IPathCheck, IPortableExecutableCheck
    {
        /// <inheritdoc/>
        public string CheckPortableExecutable(string file, PortableExecutable pex, bool includeDebug)
        {
            // Get the sections from the executable, if possible
            var sections = pex?.SectionTable;
            if (sections == null)
                return null;

            string name = pex.FileDescription;
            if (name?.StartsWith("Games for Windows - LIVE Zero Day Piracy Protection", StringComparison.OrdinalIgnoreCase) == true)
                return $"Games for Windows LIVE - Zero Day Piracy Protection Module {Tools.Utilities.GetInternalVersion(pex)}";
            else if (name?.StartsWith("Games for Windows", StringComparison.OrdinalIgnoreCase) == true)
                return $"Games for Windows LIVE {Tools.Utilities.GetInternalVersion(pex)}";

            // Get the import directory table
            if (pex.ImportTable?.ImportDirectoryTable != null)
            {
                bool match = pex.ImportTable.ImportDirectoryTable.Any(idte => idte.Name == "xlive.dll");
                if (match)
                    return "Games for Windows LIVE";
            }

            return null;
        }

        /// <inheritdoc/>
        public ConcurrentQueue<string> CheckDirectoryPath(string path, IEnumerable<string> files)
        {
            var matchers = new List<PathMatchSet>
            {
                // Might be specifically GFWL/Gfwlivesetup.exe
                new PathMatchSet(new PathMatch("Gfwlivesetup.exe", useEndsWith: true), "Games for Windows LIVE"),
                new PathMatchSet(new PathMatch("xliveinstall.dll", useEndsWith: true), "Games for Windows LIVE"),
                new PathMatchSet(new PathMatch("XLiveRedist.msi", useEndsWith: true), "Games for Windows LIVE"),
            };

            return MatchUtil.GetAllMatches(files, matchers, any: true);
        }

        /// <inheritdoc/>
        public string CheckFilePath(string path)
        {
            var matchers = new List<PathMatchSet>
            {
                // Might be specifically GFWL/Gfwlivesetup.exe
                new PathMatchSet(new PathMatch("Gfwlivesetup.exe", useEndsWith: true), "Games for Windows LIVE"),
                new PathMatchSet(new PathMatch("xliveinstall.dll", useEndsWith: true), "Games for Windows LIVE"),
                new PathMatchSet(new PathMatch("XLiveRedist.msi", useEndsWith: true), "Games for Windows LIVE"),
            };

            return MatchUtil.GetFirstMatch(path, matchers, any: true);
        }
    }
}
