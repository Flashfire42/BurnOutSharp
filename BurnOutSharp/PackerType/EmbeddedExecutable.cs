using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using BurnOutSharp.Interfaces;
using BurnOutSharp.Matching;
using BurnOutSharp.Wrappers;

namespace BurnOutSharp.PackerType
{
    /// <summary>
    /// Though not technically a packer, this detection is for any executables that include
    /// others in their resources in some uncompressed manner to be used at runtime.
    /// </summary>
    public class EmbeddedExecutable : IPortableExecutableCheck, IScannable
    {
        /// <inheritdoc/>
        public string CheckPortableExecutable(string file, PortableExecutable pex, bool includeDebug)
        {
            // Get the sections from the executable, if possible
            var sections = pex?.SectionTable;
            if (sections == null)
                return null;

            // Get the resources that have an executable signature
            if (pex.ResourceData?.Any(kvp => kvp.Value is byte[] ba && ba.StartsWith(Models.MSDOS.Constants.SignatureBytes)) == true)
                return "Embedded Executable";

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
            // Parse into an executable again for easier extraction
            PortableExecutable pex = PortableExecutable.Create(stream);
            if (pex?.ResourceData == null)
                return null;

            // Get the resources that have an executable signature
            var resources = pex.ResourceData
                .Where(kvp => kvp.Value != null && kvp.Value is byte[])
                .Where(kvp => (kvp.Value as byte[]).StartsWith(Models.MSDOS.Constants.SignatureBytes))
                .ToList();

            // If any of the individual extractions fail
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempPath);

                for (int i = 0; i < resources.Count; i++)
                {
                    // Get the resource data
                    var resource = resources[i];
                    byte[] data = resource.Value as byte[];

                    // Create the temp filename
                    string tempFile = $"embedded_resource_{i}.bin";
                    tempFile = Path.Combine(tempPath, tempFile);

                    // Write the resource data to a temp file
                    using (Stream tempStream = File.Open(tempFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        tempStream.Write(data, 0, data.Length);
                    }
                }

                // Collect and format all found protections
                var protections = scanner.GetProtections(tempPath);

                // If temp directory cleanup fails
                try
                {
                    Directory.Delete(tempPath, true);
                }
                catch (Exception ex)
                {
                    if (scanner.IncludeDebug) Console.WriteLine(ex);
                }

                // Remove temporary path references
                Utilities.Dictionary.StripFromKeys(protections, tempPath);

                return protections;
            }
            catch (Exception ex)
            {
                if (scanner.IncludeDebug) Console.WriteLine(ex);
            }

            return null;
        }
    }
}
