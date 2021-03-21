﻿namespace BurnOutSharp.ProtectionType
{
    public class ActiveMARK : IContentCheck
    {
        /// <inheritdoc/>
        public string CheckContents(string file, byte[] fileContent, bool includePosition = false)
        {
            // "TMSAMVOF"
            byte[] check = new byte[] { 0x54, 0x4D, 0x53, 0x41, 0x4D, 0x56, 0x4F, 0x46 };
            if (fileContent.FirstPosition(check, out int position))
                return "ActiveMARK" + (includePosition ? $" (Index {position})" : string.Empty);

            // " " + (char)0xC2 + (char)0x16 + (char)0x00 + (char)0xA8 + (char)0xC1 + (char)0x16 + (char)0x00 + (char)0xB8 + (char)0xC1 + (char)0x16 + (char)0x00 + (char)0x86 + (char)0xC8 + (char)0x16 + (char)0x0 + (char)0x9A + (char)0xC1 + (char)0x16 + (char)0x00 + (char)0x10 + (char)0xC2 + (char)0x16 + (char)0x00
            check = new byte[] { 0x20, 0xC2, 0x16, 0x00, 0xA8, 0xC1, 0x16, 0x00, 0xB8, 0xC1, 0x16, 0x00, 0x86, 0xC8, 0x16, 0x0, 0x9A, 0xC1, 0x16, 0x00, 0x10, 0xC2, 0x16, 0x00 };
            if (fileContent.FirstPosition(check, out position))
                return "ActiveMARK 5" + (includePosition ? $" (Index {position})" : string.Empty);

            return null;
        }
    }
}
