﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using BurnOutSharp.Interfaces;
using BurnOutSharp.Matching;

namespace BurnOutSharp.ProtectionType
{
    /// <summary>
    /// CD-Protector is a form of DRM that allows users to create their own copy protected discs.
    /// It prevents copying via "Phantom Trax", intended to confuse dumping software, and by obfuscating a specified EXE.
    /// The official website seems to be https://web.archive.org/web/20000302173822/http://surf.to/nrgcrew.
    /// The author's site should be https://members.xoom.it/_XOOM/Dudez/index.htm, but no captures of this site appear to be functional.
    /// Instructions on how this software can be used: https://3dnews.ru/166065
    /// Download: https://www.cdmediaworld.com/hardware/cdrom/cd_utils_3.shtml#CD-Protector
    /// TODO: See if any of the older versions of CD-Protector are archived, and check if they need to be detected differently.
    /// </summary>
    public class CDProtector : IPathCheck
    {
        /// <inheritdoc/>
        public ConcurrentQueue<string> CheckDirectoryPath(string path, IEnumerable<string> files)
        {
            var matchers = new List<PathMatchSet>
            {
                // These are the main files used by CD-Protector, which should all be present in every protected disc.
                // "_cdp16.dll" and "_cdp32.dll" are actually renamed WAV files.
                // "_cdp32.dat" is actually an archive that contains the original executable.
                // Another EXE is created, with the name of the original executable. I'm not sure what this executable does, but it appears to be compressed with NeoLite.
                // TODO: Invesitage if this EXE itself can be detected in any way.
                new PathMatchSet(new PathMatch("_cdp16.dat", useEndsWith: true), "CD-Protector"),
                new PathMatchSet(new PathMatch("_cdp16.dll", useEndsWith: true), "CD-Protector"),
                new PathMatchSet(new PathMatch("_cdp32.dat", useEndsWith: true), "CD-Protector"),
                new PathMatchSet(new PathMatch("_cdp32.dll", useEndsWith: true), "CD-Protector"),

                // This is the "Phantom Trax" file generated by CD-Protector, intended to be burned to a protected CD as an audio track.
                new PathMatchSet(new PathMatch("Track#1 - Track#2 Cd-Protector.wav", useEndsWith: true), "CD-Protector"),
            };

            return MatchUtil.GetAllMatches(files, matchers, any: true);
        }

        /// <inheritdoc/>
        public string CheckFilePath(string path)
        {
            var matchers = new List<PathMatchSet>
            {
                // These are the main files used by CD-Protector, which should all be present in every protected disc.
                // "_cdp16.dll" and "_cdp32.dll" are actually renamed WAV files.
                // "_cdp32.dat" is actually an archive that contains the original executable.
                // Another EXE is created, with the name of the original executable. I'm not sure what this executable does, but it appears to be compressed with NeoLite.
                // TODO: Invesitage if this EXE itself can be detected in any way.
                new PathMatchSet(new PathMatch("_cdp16.dat", useEndsWith: true), "CD-Protector"),
                new PathMatchSet(new PathMatch("_cdp16.dll", useEndsWith: true), "CD-Protector"),
                new PathMatchSet(new PathMatch("_cdp32.dat", useEndsWith: true), "CD-Protector"),
                new PathMatchSet(new PathMatch("_cdp32.dll", useEndsWith: true), "CD-Protector"),

                // This is the "Phantom Trax" file generated by CD-Protector, intended to be burned to a protected CD as an audio track.
                new PathMatchSet(new PathMatch("Track#1 - Track#2 Cd-Protector.wav", useEndsWith: true), "CD-Protector"),
            };

            return MatchUtil.GetFirstMatch(path, matchers, any: true);
        }
    }
}
