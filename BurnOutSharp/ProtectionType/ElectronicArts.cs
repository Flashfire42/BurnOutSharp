﻿namespace BurnOutSharp.ProtectionType
{
    public class ElectronicArts
    {
        // TODO: Verify this doesn't over-match
        // TODO: Do more research into the Cucko protection:
        //      - Reference to `EASTL` and `EAStl` are standard for EA products and does not indicate Cucko by itself
        //      - There's little information outside of PiD detection that actually knows about Cucko
        public static string CheckContents(string file, byte[] fileContent, bool includePosition = false)
        {
            // EASTL
            // byte[] check = new byte[] { 0x45, 0x41, 0x53, 0x54, 0x4C };
            // if (fileContent.Contains(check, out int position))
            //     return "Cucko (EA Custom)" + (includePosition ? $" (Index {position})" : string.Empty);

            // R + (char)0x00 + e + (char)0x00 + g + (char)0x00 + i + (char)0x00 + s + (char)0x00 + t + (char)0x00 + r + (char)0x00 + a + (char)0x00 + t + (char)0x00 + i + (char)0x00 + o + (char)0x00 + n + (char)0x00 +   + (char)0x00 + C + (char)0x00 + o + (char)0x00 + d + (char)0x00 + e + (char)0x00
            byte[] check = new byte[] { 0x52, 0x00, 0x65, 0x00, 0x67, 0x00, 0x69, 0x00, 0x73, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x20, 0x00, 0x43, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x65, 0x00 };
            if (fileContent.Contains(check, out int position))
                return $"EA CdKey Registration Module {Utilities.GetFileVersion(file)}" + (includePosition ? $" (Index {position})" : string.Empty);

            // R + (char)0x00 + e + (char)0x00 + g + (char)0x00 + i + (char)0x00 + s + (char)0x00 + t + (char)0x00 + r + (char)0x00 + a + (char)0x00 + t + (char)0x00 + i + (char)0x00 + o + (char)0x00 + n + (char)0x00 +   + (char)0x00 + c + (char)0x00 + o + (char)0x00 + d + (char)0x00 + e + (char)0x00
            check = new byte[] { 0x52, 0x00, 0x65, 0x00, 0x67, 0x00, 0x69, 0x00, 0x73, 0x00, 0x74, 0x00, 0x72, 0x00, 0x61, 0x00, 0x74, 0x00, 0x69, 0x00, 0x6F, 0x00, 0x6E, 0x00, 0x20, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x65, 0x00 };
            if (fileContent.Contains(check, out position))
                return $"EA CdKey Registration Module {Utilities.GetFileVersion(file)}" + (includePosition ? $" (Index {position})" : string.Empty);

            // C + (char)0x00 + D + (char)0x00 + K + (char)0x00 + e + (char)0x00 + y + (char)0x00
            check = new byte[] { 0x43, 0x00, 0x44, 0x00, 0x4B, 0x00, 0x65, 0x00, 0x79, 0x00 };
            if (fileContent.Contains(check, out position))
                return $"EA CdKey Registration Module {Utilities.GetFileVersion(file)}" + (includePosition ? $" (Index {position})" : string.Empty);
            
            // ereg.ea-europe.com
            check = new byte[] { 0x65, 0x72, 0x65, 0x67, 0x2E, 0x65, 0x61, 0x2D, 0x65, 0x75, 0x72, 0x6F, 0x70, 0x65, 0x2E, 0x63, 0x6F, 0x6D };
            if (fileContent.Contains(check, out position))
                return $"EA CdKey Registration Module {Utilities.GetFileVersion(file)}" + (includePosition ? $" (Index {position})" : string.Empty);

            // GenericEA + (char)0x00 + (char)0x00 + (char)0x00 + Activation
            check = new byte[] { 0x47, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x45, 0x41, 0x00, 0x00, 0x00, 0x41, 0x63, 0x74, 0x69, 0x76, 0x61, 0x74, 0x69, 0x6F, 0x6E };
            if (fileContent.Contains(check, out position))
                return "EA DRM Protection" + (includePosition ? $" (Index {position})" : string.Empty);

            // E + (char)0x00 + A + (char)0x00 +   + (char)0x00 + D + (char)0x00 + R + (char)0x00 + M + (char)0x00 +   + (char)0x00 + H + (char)0x00 + e + (char)0x00 + l + (char)0x00 + p + (char)0x00 + e + (char)0x00 + r + (char)0x00
            check = new byte[] { 0x45, 0x00, 0x41, 0x00, 0x20, 0x00, 0x44, 0x00, 0x52, 0x00, 0x4D, 0x00, 0x20, 0x00, 0x48, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x70, 0x00, 0x65, 0x00, 0x72, 0x00 };
            if (fileContent.Contains(check, out position))
                return "EA DRM Protection" + (includePosition ? $" (Index {position})" : string.Empty);

            return null;
        }
    }
}
