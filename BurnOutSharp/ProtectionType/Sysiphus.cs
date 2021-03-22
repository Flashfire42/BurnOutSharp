﻿using System.Collections.Generic;
using BurnOutSharp.Matching;

namespace BurnOutSharp.ProtectionType
{
    public class Sysiphus : IContentCheck
    {
        /// <inheritdoc/>
        public string CheckContents(string file, byte[] fileContent, bool includePosition = false)
        {
            var matchers = new List<Matcher>
            {
                // V SUHPISYSDVD
                new Matcher(new byte?[]
                {
                    0x56, 0x20, 0x53, 0x55, 0x48, 0x50, 0x49, 0x53,
                    0x59, 0x53, 0x44, 0x56, 0x44
                }, GetVersion, "Sysiphus DVD"),

                // V SUHPISYSDVD
                new Matcher(new byte?[]
                {
                    0x56, 0x20, 0x53, 0x55, 0x48, 0x50, 0x49, 0x53,
                    0x59, 0x53
                }, GetVersion, "Sysiphus"),
            };

            return MatchUtil.GetFirstContentMatch(file, fileContent, matchers, includePosition);
        }

        public static string GetVersion(string file, byte[] fileContent, int position)
        {
            int index = position - 3;
            char subVersion = (char)fileContent[index];
            index++;
            index++;
            char version = (char)fileContent[index];

            if (char.IsNumber(version) && char.IsNumber(subVersion))
                return $"{version}.{subVersion}";
            else
                return "";
        }
    }
}
