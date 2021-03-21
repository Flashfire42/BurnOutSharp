﻿namespace BurnOutSharp.ProtectionType
{
    public class PSXAntiModchip : IContentCheck
    {
        // TODO: Figure out PSX binary header so this can be checked explicitly
        // TODO: Detect Red Hand protection
        /// <inheritdoc/>
        public string CheckContents(string file, byte[] fileContent, bool includePosition = false)
        {
            // "     SOFTWARE TERMINATED\nCONSOLE MAY HAVE BEEN MODIFIED\n     CALL 1-888-780-7690"
            byte[] check = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x53, 0x4F, 0x46, 0x54, 0x57, 0x41, 0x52, 0x45, 0x20, 0x54, 0x45, 0x52, 0x4D, 0x49, 0x4E, 0x41, 0x54, 0x45, 0x44, 0x5C, 0x6E, 0x43, 0x4F, 0x4E, 0x53, 0x4F, 0x4C, 0x45, 0x20, 0x4D, 0x41, 0x59, 0x20, 0x48, 0x41, 0x56, 0x45, 0x20, 0x42, 0x45, 0x45, 0x4E, 0x20, 0x4D, 0x4F, 0x44, 0x49, 0x46, 0x49, 0x45, 0x44, 0x5C, 0x6E, 0x20, 0x20, 0x20, 0x20, 0x20, 0x43, 0x41, 0x4C, 0x4C, 0x20, 0x31, 0x2D, 0x38, 0x38, 0x38, 0x2D, 0x37, 0x38, 0x30, 0x2D, 0x37, 0x36, 0x39, 0x30 };
            if (fileContent.FirstPosition(check, out int position))
                return $"PlayStation Anti-modchip (English)" + (includePosition ? $"(Index {position})" : string.Empty);

            // "強制終了しました。\n本体が改造されている\nおそれがあります。"
            check = new byte[] { 0x5F, 0x37, 0x52, 0x36, 0x7D, 0x42, 0x4E, 0x86, 0x30, 0x57, 0x30, 0x7E, 0x30, 0x57, 0x30, 0x5F, 0x30, 0x02, 0x5C, 0x6E, 0x67, 0x2C, 0x4F, 0x53, 0x30, 0x4C, 0x65, 0x39, 0x90, 0x20, 0x30, 0x55, 0x30, 0x8C, 0x30, 0x66, 0x30, 0x44, 0x30, 0x8B, 0x5C, 0x6E, 0x30, 0x4A, 0x30, 0x5D, 0x30, 0x8C, 0x30, 0x4C, 0x30, 0x42, 0x30, 0x8A, 0x30, 0x7E, 0x30, 0x59, 0x30, 0x02 };
            if (fileContent.FirstPosition(check, out position))
                return $"PlayStation Anti-modchip (Japanese)" + (includePosition ? $"(Index {position})" : string.Empty);

            return null;
        }
    }
}
