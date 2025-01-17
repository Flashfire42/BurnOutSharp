using System;
using System.IO;

namespace BurnOutSharp.Wrappers
{
    public class CIA : WrapperBase
    {
        #region Pass-Through Properties

        #region Header

        /// <inheritdoc cref="Models.N3DS.CIAHeader.HeaderSize"/>
        public uint HeaderSize => _cia.Header.HeaderSize;

        /// <inheritdoc cref="Models.N3DS.CIAHeader.Type"/>
        public ushort Type => _cia.Header.Type;

        /// <inheritdoc cref="Models.N3DS.CIAHeader.Version"/>
        public ushort Version => _cia.Header.Version;

        /// <inheritdoc cref="Models.N3DS.CIAHeader.CertificateChainSize"/>
        public uint CertificateChainSize => _cia.Header.CertificateChainSize;

        /// <inheritdoc cref="Models.N3DS.CIAHeader.TicketSize"/>
        public uint TicketSize => _cia.Header.TicketSize;

        /// <inheritdoc cref="Models.N3DS.CIAHeader.TMDFileSize"/>
        public uint TMDFileSize => _cia.Header.TMDFileSize;

        /// <inheritdoc cref="Models.N3DS.CIAHeader.MetaSize"/>
        public uint MetaSize => _cia.Header.MetaSize;

        /// <inheritdoc cref="Models.N3DS.CIAHeader.ContentSize"/>
        public ulong ContentSize => _cia.Header.ContentSize;

        /// <inheritdoc cref="Models.N3DS.CIAHeader.ContentIndex"/>
        public byte[] ContentIndex => _cia.Header.ContentIndex;

        #endregion

        #region Certificate Chain

        /// <inheritdoc cref="Models.N3DS.CIA.CertificateChain"/>
        public Models.N3DS.Certificate[] CertificateChain => _cia.CertificateChain;

        #endregion

        #region Ticket

        /// <inheritdoc cref="Models.N3DS.Ticket.SignatureType"/>
        public Models.N3DS.SignatureType T_SignatureType => _cia.Ticket.SignatureType;

        /// <inheritdoc cref="Models.N3DS.Ticket.SignatureSize"/>
        public ushort T_SignatureSize => _cia.Ticket.SignatureSize;

        /// <inheritdoc cref="Models.N3DS.Ticket.PaddingSize"/>
        public byte T_PaddingSize => _cia.Ticket.PaddingSize;

        /// <inheritdoc cref="Models.N3DS.Ticket.Signature"/>
        public byte[] T_Signature => _cia.Ticket.Signature;

        /// <inheritdoc cref="Models.N3DS.Ticket.Padding"/>
        public byte[] T_Padding => _cia.Ticket.Padding;

        /// <inheritdoc cref="Models.N3DS.Ticket.Issuer"/>
        public string T_Issuer => _cia.Ticket.Issuer;

        /// <inheritdoc cref="Models.N3DS.Ticket.ECCPublicKey"/>
        public byte[] T_ECCPublicKey => _cia.Ticket.ECCPublicKey;

        /// <inheritdoc cref="Models.N3DS.Ticket.Version"/>
        public byte T_Version => _cia.Ticket.Version;

        /// <inheritdoc cref="Models.N3DS.Ticket.CaCrlVersion"/>
        public byte T_CaCrlVersion => _cia.Ticket.CaCrlVersion;

        /// <inheritdoc cref="Models.N3DS.Ticket.SignerCrlVersion"/>
        public byte T_SignerCrlVersion => _cia.Ticket.SignerCrlVersion;

        /// <inheritdoc cref="Models.N3DS.Ticket.TitleKey"/>
        public byte[] T_TitleKey => _cia.Ticket.TitleKey;

        /// <inheritdoc cref="Models.N3DS.Ticket.Reserved1"/>
        public byte T_Reserved1 => _cia.Ticket.Reserved1;

        /// <inheritdoc cref="Models.N3DS.Ticket.TicketID"/>
        public ulong T_TicketID => _cia.Ticket.TicketID;

        /// <inheritdoc cref="Models.N3DS.Ticket.ConsoleID"/>
        public uint T_ConsoleID => _cia.Ticket.ConsoleID;

        /// <inheritdoc cref="Models.N3DS.Ticket.TitleID"/>
        public ulong T_TitleID => _cia.Ticket.TitleID;

        /// <inheritdoc cref="Models.N3DS.Ticket.Reserved2"/>
        public byte[] T_Reserved2 => _cia.Ticket.Reserved2;

        /// <inheritdoc cref="Models.N3DS.Ticket.TicketTitleVersion"/>
        public ushort T_TicketTitleVersion => _cia.Ticket.TicketTitleVersion;

        /// <inheritdoc cref="Models.N3DS.Ticket.Reserved3"/>
        public byte[] T_Reserved3 => _cia.Ticket.Reserved3;

        /// <inheritdoc cref="Models.N3DS.Ticket.LicenseType"/>
        public byte T_LicenseType => _cia.Ticket.LicenseType;

        /// <inheritdoc cref="Models.N3DS.Ticket.CommonKeyYIndex"/>
        public byte T_CommonKeyYIndex => _cia.Ticket.CommonKeyYIndex;

        /// <inheritdoc cref="Models.N3DS.Ticket.Reserved4"/>
        public byte[] T_Reserved4 => _cia.Ticket.Reserved4;

        /// <inheritdoc cref="Models.N3DS.Ticket.eShopAccountID"/>
        public uint T_eShopAccountID => _cia.Ticket.eShopAccountID;

        /// <inheritdoc cref="Models.N3DS.Ticket.Reserved5"/>
        public byte T_Reserved5 => _cia.Ticket.Reserved5;

        /// <inheritdoc cref="Models.N3DS.Ticket.Audit"/>
        public byte T_Audit => _cia.Ticket.Audit;

        /// <inheritdoc cref="Models.N3DS.Ticket.Reserved6"/>
        public byte[] T_Reserved6 => _cia.Ticket.Reserved6;

        /// <inheritdoc cref="Models.N3DS.Ticket.Limits"/>
        public uint[] T_Limits => _cia.Ticket.Limits;

        /// <inheritdoc cref="Models.N3DS.Ticket.ContentIndexSize"/>
        public uint T_ContentIndexSize => _cia.Ticket.ContentIndexSize;

        /// <inheritdoc cref="Models.N3DS.Ticket.ContentIndex"/>
        public byte[] T_ContentIndex => _cia.Ticket.ContentIndex;

        /// <inheritdoc cref="Models.N3DS.Ticket.CertificateChain"/>
        public Models.N3DS.Certificate[] T_CertificateChain => _cia.Ticket.CertificateChain;

        #endregion

        #region Title Metadata

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.SignatureType"/>
        public Models.N3DS.SignatureType TMD_SignatureType => _cia.TMDFileData.SignatureType;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.SignatureSize"/>
        public ushort TMD_SignatureSize => _cia.TMDFileData.SignatureSize;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.PaddingSize"/>
        public byte TMD_PaddingSize => _cia.TMDFileData.PaddingSize;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.Signature"/>
        public byte[] TMD_Signature => _cia.TMDFileData.Signature;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.Padding1"/>
        public byte[] TMD_Padding1 => _cia.TMDFileData.Padding1;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.Issuer"/>
        public string TMD_Issuer => _cia.TMDFileData.Issuer;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.Version"/>
        public byte TMD_Version => _cia.TMDFileData.Version;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.CaCrlVersion"/>
        public byte TMD_CaCrlVersion => _cia.TMDFileData.CaCrlVersion;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.SignerCrlVersion"/>
        public byte TMD_SignerCrlVersion => _cia.TMDFileData.SignerCrlVersion;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.Reserved1"/>
        public byte TMD_Reserved1 => _cia.TMDFileData.Reserved1;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.SystemVersion"/>
        public ulong TMD_SystemVersion => _cia.TMDFileData.SystemVersion;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.TitleID"/>
        public ulong TMD_TitleID => _cia.TMDFileData.TitleID;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.TitleType"/>
        public uint TMD_TitleType => _cia.TMDFileData.TitleType;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.GroupID"/>
        public ushort TMD_GroupID => _cia.TMDFileData.GroupID;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.SaveDataSize"/>
        public uint TMD_SaveDataSize => _cia.TMDFileData.SaveDataSize;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.SRLPrivateSaveDataSize"/>
        public uint TMD_SRLPrivateSaveDataSize => _cia.TMDFileData.SRLPrivateSaveDataSize;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.Reserved2"/>
        public byte[] TMD_Reserved2 => _cia.TMDFileData.Reserved2;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.SRLFlag"/>
        public byte TMD_SRLFlag => _cia.TMDFileData.SRLFlag;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.Reserved3"/>
        public byte[] TMD_Reserved3 => _cia.TMDFileData.Reserved3;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.AccessRights"/>
        public uint TMD_AccessRights => _cia.TMDFileData.AccessRights;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.TitleVersion"/>
        public ushort TMD_TitleVersion => _cia.TMDFileData.TitleVersion;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.ContentCount"/>
        public ushort TMD_ContentCount => _cia.TMDFileData.ContentCount;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.BootContent"/>
        public ushort TMD_BootContent => _cia.TMDFileData.BootContent;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.Padding2"/>
        public byte[] TMD_Padding2 => _cia.TMDFileData.Padding2;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.SHA256HashContentInfoRecords"/>
        public byte[] TMD_SHA256HashContentInfoRecords => _cia.TMDFileData.SHA256HashContentInfoRecords;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.ContentInfoRecords"/>
        public Models.N3DS.ContentInfoRecord[] TMD_ContentInfoRecords => _cia.TMDFileData.ContentInfoRecords;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.ContentChunkRecords"/>
        public Models.N3DS.ContentChunkRecord[] TMD_ContentChunkRecords => _cia.TMDFileData.ContentChunkRecords;

        /// <inheritdoc cref="Models.N3DS.TitleMetadata.CertificateChain"/>
        public Models.N3DS.Certificate[] TMD_CertificateChain => _cia.TMDFileData.CertificateChain;

        #endregion

        #region Partitions

        /// <inheritdoc cref="Models.N3DS.CIA.Partitions"/>
        public Models.N3DS.NCCHHeader[] Partitions => _cia.Partitions;

        #endregion

        #region Meta Data

        /// <inheritdoc cref="Models.N3DS.MetaData.TitleIDDependencyList"/>
        public byte[] MD_TitleIDDependencyList => _cia.MetaData?.TitleIDDependencyList;

        /// <inheritdoc cref="Models.N3DS.MetaData.Reserved1"/>
        public byte[] MD_Reserved1 => _cia.MetaData?.Reserved1;

        /// <inheritdoc cref="Models.N3DS.MetaData.CoreVersion"/>
        public uint? MD_CoreVersion => _cia.MetaData?.CoreVersion;

        /// <inheritdoc cref="Models.N3DS.MetaData.Reserved2"/>
        public byte[] MD_Reserved2 => _cia.MetaData?.Reserved2;

        /// <inheritdoc cref="Models.N3DS.MetaData.IconData"/>
        public byte[] MD_IconData => _cia.MetaData?.IconData;

        #endregion

        #endregion

        #region Instance Variables

        /// <summary>
        /// Internal representation of the cart
        /// </summary>
        private Models.N3DS.CIA _cia;

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor
        /// </summary>
        private CIA() { }

        /// <summary>
        /// Create a CIA archive from a byte array and offset
        /// </summary>
        /// <param name="data">Byte array representing the archive</param>
        /// <param name="offset">Offset within the array to parse</param>
        /// <returns>A CIA archive wrapper on success, null on failure</returns>
        public static CIA Create(byte[] data, int offset)
        {
            // If the data is invalid
            if (data == null)
                return null;

            // If the offset is out of bounds
            if (offset < 0 || offset >= data.Length)
                return null;

            // Create a memory stream and use that
            MemoryStream dataStream = new MemoryStream(data, offset, data.Length - offset);
            return Create(dataStream);
        }

        /// <summary>
        /// Create a CIA archive from a Stream
        /// </summary>
        /// <param name="data">Stream representing the archive</param>
        /// <returns>A CIA archive wrapper on success, null on failure</returns>
        public static CIA Create(Stream data)
        {
            // If the data is invalid
            if (data == null || data.Length == 0 || !data.CanSeek || !data.CanRead)
                return null;

            var archive = Builders.N3DS.ParseCIA(data);
            if (archive == null)
                return null;

            var wrapper = new CIA
            {
                _cia = archive,
                _dataSource = DataSource.Stream,
                _streamData = data,
            };
            return wrapper;
        }

        #endregion

        #region Printing

        /// <inheritdoc/>
        public override void Print()
        {
            Console.WriteLine("CIA Archive Information:");
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            PrintHeader();
            PrintCertificateChain();
            PrintTicket();
            PrintTitleMetadata();
            PrintPartitions();
            PrintMetaData();
        }

        /// <summary>
        /// Print CIA header information
        /// </summary>
        private void PrintHeader()
        {
            Console.WriteLine("  CIA Header Information:");
            Console.WriteLine("  -------------------------");
            Console.WriteLine($"  Header size: {HeaderSize} (0x{HeaderSize:X})");
            Console.WriteLine($"  Type: {Type} (0x{Type:X})");
            Console.WriteLine($"  Version: {Version} (0x{Version:X})");
            Console.WriteLine($"  Certificate chain size: {CertificateChainSize} (0x{CertificateChainSize:X})");
            Console.WriteLine($"  Ticket size: {TicketSize} (0x{TicketSize:X})");
            Console.WriteLine($"  TMD file size: {TMDFileSize} (0x{TMDFileSize:X})");
            Console.WriteLine($"  Meta size: {MetaSize} (0x{MetaSize:X})");
            Console.WriteLine($"  Content size: {ContentSize} (0x{ContentSize:X})");
            Console.WriteLine($"  Content index: {BitConverter.ToString(ContentIndex).Replace('-', ' ')}");
            Console.WriteLine();
        }

        /// <summary>
        /// Print NCCH partition header information
        /// </summary>
        private void PrintCertificateChain()
        {
            Console.WriteLine("  Certificate Chain Information:");
            Console.WriteLine("  -------------------------");
            if (CertificateChain == null || CertificateChain.Length == 0)
            {
                Console.WriteLine("  No certificates, expected 3");
            }
            else
            {
                for (int i = 0; i < CertificateChain.Length; i++)
                {
                    var certificate = CertificateChain[i];

                    string certificateName = string.Empty;
                    switch (i)
                    {
                        case 0: certificateName = " (CA)"; break;
                        case 1: certificateName = " (Ticket)"; break;
                        case 2: certificateName = " (TMD)"; break;
                    }

                    Console.WriteLine($"  Certificate {i}{certificateName}");
                    Console.WriteLine($"    Signature type: {certificate.SignatureType} (0x{certificate.SignatureType:X})");
                    Console.WriteLine($"    Signature size: {certificate.SignatureSize} (0x{certificate.SignatureSize:X})");
                    Console.WriteLine($"    Padding size: {certificate.PaddingSize} (0x{certificate.PaddingSize:X})");
                    Console.WriteLine($"    Signature: {BitConverter.ToString(certificate.Signature).Replace('-', ' ')}");
                    Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.Padding).Replace('-', ' ')}");
                    Console.WriteLine($"    Issuer: {certificate.Issuer ?? "[NULL]"}");
                    Console.WriteLine($"    Key type: {certificate.KeyType} (0x{certificate.KeyType:X})");
                    Console.WriteLine($"    Name: {certificate.Name ?? "[NULL]"}");
                    Console.WriteLine($"    Expiration time: {certificate.ExpirationTime} (0x{certificate.ExpirationTime:X})");
                    switch (certificate.KeyType)
                    {
                        case Models.N3DS.PublicKeyType.RSA_4096:
                        case Models.N3DS.PublicKeyType.RSA_2048:
                            Console.WriteLine($"    Modulus: {BitConverter.ToString(certificate.RSAModulus).Replace('-', ' ')}");
                            Console.WriteLine($"    Public exponent: {certificate.RSAPublicExponent} (0x{certificate.RSAPublicExponent:X})");
                            Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.RSAPadding).Replace('-', ' ')}");
                            break;
                        case Models.N3DS.PublicKeyType.EllipticCurve:
                            Console.WriteLine($"    Public key: {BitConverter.ToString(certificate.ECCPublicKey).Replace('-', ' ')}");
                            Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.ECCPadding).Replace('-', ' ')}");
                            break;
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print ticket information
        /// </summary>
        private void PrintTicket()
        {
            Console.WriteLine("  Ticket Information:");
            Console.WriteLine("  -------------------------");
            Console.WriteLine($"  Signature type: {T_SignatureType} (0x{T_SignatureType:X})");
            Console.WriteLine($"  Signature size: {T_SignatureSize} (0x{T_SignatureSize:X})");
            Console.WriteLine($"  Padding size: {T_PaddingSize} (0x{T_PaddingSize:X})");
            Console.WriteLine($"  Signature: {BitConverter.ToString(T_Signature).Replace('-', ' ')}");
            Console.WriteLine($"  Padding: {BitConverter.ToString(T_Padding).Replace('-', ' ')}");
            Console.WriteLine($"  Issuer: {T_Issuer ?? "[NULL]"}");
            Console.WriteLine($"  ECC public key: {BitConverter.ToString(T_ECCPublicKey).Replace('-', ' ')}");
            Console.WriteLine($"  Version: {T_Version} (0x{T_Version:X})");
            Console.WriteLine($"  CaCrlVersion: {T_CaCrlVersion} (0x{T_CaCrlVersion:X})");
            Console.WriteLine($"  SignerCrlVersion: {T_SignerCrlVersion} (0x{T_SignerCrlVersion:X})");
            Console.WriteLine($"  Title key: {BitConverter.ToString(T_TitleKey).Replace('-', ' ')}");
            Console.WriteLine($"  Reserved 1: {T_Reserved1} (0x{T_Reserved1:X})");
            Console.WriteLine($"  Ticket ID: {T_TicketID} (0x{T_TicketID:X})");
            Console.WriteLine($"  Console ID: {T_ConsoleID} (0x{T_ConsoleID:X})");
            Console.WriteLine($"  Title ID {T_TitleID} (0x{T_TitleID:X})");
            Console.WriteLine($"  Reserved 2: {BitConverter.ToString(T_Reserved2).Replace('-', ' ')}");
            Console.WriteLine($"  Ticket title version: {T_TicketTitleVersion} (0x{T_TicketTitleVersion:X})");
            Console.WriteLine($"  Reserved 3: {BitConverter.ToString(T_Reserved3).Replace('-', ' ')}");
            Console.WriteLine($"  License type: {T_LicenseType} (0x{T_LicenseType:X})");
            Console.WriteLine($"  Common keY index: {T_CommonKeyYIndex} (0x{T_CommonKeyYIndex:X})");
            Console.WriteLine($"  Reserved 4: {BitConverter.ToString(T_Reserved4).Replace('-', ' ')}");
            Console.WriteLine($"  eShop Account ID?: {T_eShopAccountID} (0x{T_eShopAccountID:X})");
            Console.WriteLine($"  Reserved 5: {T_Reserved5} (0x{T_Reserved5:X})");
            Console.WriteLine($"  Audit: {T_Audit} (0x{T_Audit:X})");
            Console.WriteLine($"  Reserved 6: {BitConverter.ToString(T_Reserved6).Replace('-', ' ')}");
            Console.WriteLine($"  Limits:");
            for (int i = 0; i < T_Limits.Length; i++)
            {
                Console.WriteLine($"    Limit {i}: {T_Limits[i]} (0x{T_Limits[i]:X})");
            }
            Console.WriteLine($"  Content index size: {T_ContentIndexSize} (0x{T_ContentIndexSize:X})");
            Console.WriteLine($"  Content index: {BitConverter.ToString(T_ContentIndex).Replace('-', ' ')}");
            Console.WriteLine();

            Console.WriteLine("  Ticket Certificate Chain Information:");
            Console.WriteLine("  -------------------------");
            if (T_CertificateChain == null || T_CertificateChain.Length == 0)
            {
                Console.WriteLine("  No certificates, expected 2");
            }
            else
            {
                for (int i = 0; i < T_CertificateChain.Length; i++)
                {
                    var certificate = T_CertificateChain[i];

                    string certificateName = string.Empty;
                    switch (i)
                    {
                        case 0: certificateName = " (Ticket)"; break;
                        case 1: certificateName = " (CA)"; break;
                    }

                    Console.WriteLine($"  Certificate {i}{certificateName}");
                    Console.WriteLine($"    Signature type: {certificate.SignatureType} (0x{certificate.SignatureType:X})");
                    Console.WriteLine($"    Signature size: {certificate.SignatureSize} (0x{certificate.SignatureSize:X})");
                    Console.WriteLine($"    Padding size: {certificate.PaddingSize} (0x{certificate.PaddingSize:X})");
                    Console.WriteLine($"    Signature: {BitConverter.ToString(certificate.Signature).Replace('-', ' ')}");
                    Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.Padding).Replace('-', ' ')}");
                    Console.WriteLine($"    Issuer: {certificate.Issuer ?? "[NULL]"}");
                    Console.WriteLine($"    Key type: {certificate.KeyType} (0x{certificate.KeyType:X})");
                    Console.WriteLine($"    Name: {certificate.Name ?? "[NULL]"}");
                    Console.WriteLine($"    Expiration time: {certificate.ExpirationTime} (0x{certificate.ExpirationTime:X})");
                    switch (certificate.KeyType)
                    {
                        case Models.N3DS.PublicKeyType.RSA_4096:
                        case Models.N3DS.PublicKeyType.RSA_2048:
                            Console.WriteLine($"    Modulus: {BitConverter.ToString(certificate.RSAModulus).Replace('-', ' ')}");
                            Console.WriteLine($"    Public exponent: {certificate.RSAPublicExponent} (0x{certificate.RSAPublicExponent:X})");
                            Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.RSAPadding).Replace('-', ' ')}");
                            break;
                        case Models.N3DS.PublicKeyType.EllipticCurve:
                            Console.WriteLine($"    Public key: {BitConverter.ToString(certificate.ECCPublicKey).Replace('-', ' ')}");
                            Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.ECCPadding).Replace('-', ' ')}");
                            break;
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print title metadata information
        /// </summary>
        private void PrintTitleMetadata()
        {
            Console.WriteLine("  Title Metadata Information:");
            Console.WriteLine("  -------------------------");
            Console.WriteLine($"  Signature type: {TMD_SignatureType} (0x{TMD_SignatureType:X})");
            Console.WriteLine($"  Signature size: {TMD_SignatureSize} (0x{TMD_SignatureSize:X})");
            Console.WriteLine($"  Padding size: {TMD_PaddingSize} (0x{TMD_PaddingSize:X})");
            Console.WriteLine($"  Signature: {BitConverter.ToString(TMD_Signature).Replace('-', ' ')}");
            Console.WriteLine($"  Padding 1: {BitConverter.ToString(TMD_Padding1).Replace('-', ' ')}");
            Console.WriteLine($"  Issuer: {TMD_Issuer ?? "[NULL]"}");
            Console.WriteLine($"  Version: {TMD_Version} (0x{TMD_Version:X})");
            Console.WriteLine($"  CaCrlVersion: {TMD_CaCrlVersion} (0x{TMD_CaCrlVersion:X})");
            Console.WriteLine($"  SignerCrlVersion: {TMD_SignerCrlVersion} (0x{TMD_SignerCrlVersion:X})");
            Console.WriteLine($"  Reserved 1: {TMD_Reserved1} (0x{TMD_Reserved1:X})");
            Console.WriteLine($"  System version: {TMD_SystemVersion} (0x{TMD_SystemVersion:X})");
            Console.WriteLine($"  Title ID: {TMD_TitleID} (0x{TMD_TitleID:X})");
            Console.WriteLine($"  Title type: {TMD_TitleType} (0x{TMD_TitleType:X})");
            Console.WriteLine($"  Group ID: {TMD_GroupID} (0x{TMD_GroupID:X})");
            Console.WriteLine($"  Save data size: {TMD_SaveDataSize} (0x{TMD_SaveDataSize:X})");
            Console.WriteLine($"  SRL private save data size: {TMD_SRLPrivateSaveDataSize} (0x{TMD_SRLPrivateSaveDataSize:X})");
            Console.WriteLine($"  Reserved 2: {BitConverter.ToString(TMD_Reserved2).Replace('-', ' ')}");
            Console.WriteLine($"  SRL flag: {TMD_SRLFlag} (0x{TMD_SRLFlag:X})");
            Console.WriteLine($"  Reserved 3: {BitConverter.ToString(TMD_Reserved3).Replace('-', ' ')}");
            Console.WriteLine($"  Access rights: {TMD_AccessRights} (0x{TMD_AccessRights:X})");
            Console.WriteLine($"  Title version: {TMD_TitleVersion} (0x{TMD_TitleVersion:X})");
            Console.WriteLine($"  Content count: {TMD_ContentCount} (0x{TMD_ContentCount:X})");
            Console.WriteLine($"  Boot content: {TMD_BootContent} (0x{TMD_BootContent:X})");
            Console.WriteLine($"  Padding 2: {BitConverter.ToString(TMD_Padding2).Replace('-', ' ')}");
            Console.WriteLine($"  SHA-256 hash of the content info records: {BitConverter.ToString(TMD_SHA256HashContentInfoRecords).Replace('-', ' ')}");
            Console.WriteLine();

            Console.WriteLine("  Ticket Content Info Records Information:");
            Console.WriteLine("  -------------------------");
            if (TMD_ContentInfoRecords == null || TMD_ContentInfoRecords.Length == 0)
            {
                Console.WriteLine("  No content info records, expected 64");
            }
            else
            {
                for (int i = 0; i < TMD_ContentInfoRecords.Length; i++)
                {
                    var contentInfoRecord = TMD_ContentInfoRecords[i];
                    Console.WriteLine($"  Content Info Record {i}");
                    Console.WriteLine($"    Content index offset: {contentInfoRecord.ContentIndexOffset} (0x{contentInfoRecord.ContentIndexOffset:X})");
                    Console.WriteLine($"    Content command count: {contentInfoRecord.ContentCommandCount} (0x{contentInfoRecord.ContentCommandCount:X})");
                    Console.WriteLine($"    SHA-256 hash of the next {contentInfoRecord.ContentCommandCount} records not hashed: {BitConverter.ToString(contentInfoRecord.UnhashedContentRecordsSHA256Hash).Replace('-', ' ')}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("  Ticket Content Chunk Records Information:");
            Console.WriteLine("  -------------------------");
            if (TMD_ContentChunkRecords == null || TMD_ContentChunkRecords.Length == 0)
            {
                Console.WriteLine($"  No content chunk records, expected {TMD_ContentCount}");
            }
            else
            {
                for (int i = 0; i < TMD_ContentChunkRecords.Length; i++)
                {
                    var contentChunkRecord = TMD_ContentChunkRecords[i];
                    Console.WriteLine($"  Content Chunk Record {i}");
                    Console.WriteLine($"    Content ID: {contentChunkRecord.ContentId} (0x{contentChunkRecord.ContentId:X})");
                    Console.WriteLine($"    Content index: {contentChunkRecord.ContentIndex} (0x{contentChunkRecord.ContentIndex:X})");
                    Console.WriteLine($"    Content type: {contentChunkRecord.ContentType} (0x{contentChunkRecord.ContentType:X})");
                    Console.WriteLine($"    Content size: {contentChunkRecord.ContentSize} (0x{contentChunkRecord.ContentSize:X})");
                    Console.WriteLine($"    SHA-256 hash: {BitConverter.ToString(contentChunkRecord.SHA256Hash).Replace('-', ' ')}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("  Ticket Certificate Chain Information:");
            Console.WriteLine("  -------------------------");
            if (TMD_CertificateChain == null || TMD_CertificateChain.Length == 0)
            {
                Console.WriteLine("  No certificates, expected 2");
            }
            else
            {
                for (int i = 0; i < TMD_CertificateChain.Length; i++)
                {
                    var certificate = TMD_CertificateChain[i];

                    string certificateName = string.Empty;
                    switch (i)
                    {
                        case 0: certificateName = " (TMD)"; break;
                        case 1: certificateName = " (CA)"; break;
                    }

                    Console.WriteLine($"  Certificate {i}{certificateName}");
                    Console.WriteLine($"    Signature type: {certificate.SignatureType} (0x{certificate.SignatureType:X})");
                    Console.WriteLine($"    Signature size: {certificate.SignatureSize} (0x{certificate.SignatureSize:X})");
                    Console.WriteLine($"    Padding size: {certificate.PaddingSize} (0x{certificate.PaddingSize:X})");
                    Console.WriteLine($"    Signature: {BitConverter.ToString(certificate.Signature).Replace('-', ' ')}");
                    Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.Padding).Replace('-', ' ')}");
                    Console.WriteLine($"    Issuer: {certificate.Issuer ?? "[NULL]"}");
                    Console.WriteLine($"    Key type: {certificate.KeyType} (0x{certificate.KeyType:X})");
                    Console.WriteLine($"    Name: {certificate.Name ?? "[NULL]"}");
                    Console.WriteLine($"    Expiration time: {certificate.ExpirationTime} (0x{certificate.ExpirationTime:X})");
                    switch (certificate.KeyType)
                    {
                        case Models.N3DS.PublicKeyType.RSA_4096:
                        case Models.N3DS.PublicKeyType.RSA_2048:
                            Console.WriteLine($"    Modulus: {BitConverter.ToString(certificate.RSAModulus).Replace('-', ' ')}");
                            Console.WriteLine($"    Public exponent: {certificate.RSAPublicExponent} (0x{certificate.RSAPublicExponent:X})");
                            Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.RSAPadding).Replace('-', ' ')}");
                            break;
                        case Models.N3DS.PublicKeyType.EllipticCurve:
                            Console.WriteLine($"    Public key: {BitConverter.ToString(certificate.ECCPublicKey).Replace('-', ' ')}");
                            Console.WriteLine($"    Padding: {BitConverter.ToString(certificate.ECCPadding).Replace('-', ' ')}");
                            break;
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print NCCH partition header information
        /// </summary>
        private void PrintPartitions()
        {
            Console.WriteLine("  NCCH Partition Header Information:");
            Console.WriteLine("  -------------------------");
            if (Partitions == null || Partitions.Length == 0)
            {
                Console.WriteLine("  No NCCH partition headers");
            }
            else
            {
                for (int i = 0; i < Partitions.Length; i++)
                {
                    var partitionHeader = Partitions[i];
                    Console.WriteLine($"  NCCH Partition Header {i}");
                    if (partitionHeader.MagicID == string.Empty)
                    {
                        Console.WriteLine($"    Empty partition, no data can be parsed");
                    }
                    else if (partitionHeader.MagicID != Models.N3DS.Constants.NCCHMagicNumber)
                    {
                        Console.WriteLine($"    Unrecognized partition data, no data can be parsed");
                    }
                    else
                    {
                        Console.WriteLine($"    RSA-2048 SHA-256 signature: {BitConverter.ToString(partitionHeader.RSA2048Signature).Replace('-', ' ')}");
                        Console.WriteLine($"    Magic ID: {partitionHeader.MagicID} (0x{partitionHeader.MagicID:X})");
                        Console.WriteLine($"    Content size in media units: {partitionHeader.ContentSizeInMediaUnits} (0x{partitionHeader.ContentSizeInMediaUnits:X})");
                        Console.WriteLine($"    Partition ID: {partitionHeader.PartitionId} (0x{partitionHeader.PartitionId:X})");
                        Console.WriteLine($"    Maker code: {partitionHeader.MakerCode} (0x{partitionHeader.MakerCode:X})");
                        Console.WriteLine($"    Version: {partitionHeader.Version} (0x{partitionHeader.Version:X})");
                        Console.WriteLine($"    Verification hash: {partitionHeader.VerificationHash} (0x{partitionHeader.VerificationHash:X})");
                        Console.WriteLine($"    Program ID: {BitConverter.ToString(partitionHeader.ProgramId).Replace('-', ' ')}");
                        Console.WriteLine($"    Reserved 1: {BitConverter.ToString(partitionHeader.Reserved1).Replace('-', ' ')}");
                        Console.WriteLine($"    Logo region SHA-256 hash: {BitConverter.ToString(partitionHeader.LogoRegionHash).Replace('-', ' ')}");
                        Console.WriteLine($"    Product code: {partitionHeader.ProductCode} (0x{partitionHeader.ProductCode:X})");
                        Console.WriteLine($"    Extended header SHA-256 hash: {BitConverter.ToString(partitionHeader.ExtendedHeaderHash).Replace('-', ' ')}");
                        Console.WriteLine($"    Extended header size in bytes: {partitionHeader.ExtendedHeaderSizeInBytes} (0x{partitionHeader.ExtendedHeaderSizeInBytes:X})");
                        Console.WriteLine($"    Reserved 2: {BitConverter.ToString(partitionHeader.Reserved2).Replace('-', ' ')}");
                        Console.WriteLine("    Flags:");
                        Console.WriteLine($"      Reserved 0: {partitionHeader.Flags.Reserved0} (0x{partitionHeader.Flags.Reserved0:X})");
                        Console.WriteLine($"      Reserved 1: {partitionHeader.Flags.Reserved1} (0x{partitionHeader.Flags.Reserved1:X})");
                        Console.WriteLine($"      Reserved 2: {partitionHeader.Flags.Reserved2} (0x{partitionHeader.Flags.Reserved2:X})");
                        Console.WriteLine($"      Crypto method: {partitionHeader.Flags.CryptoMethod} (0x{partitionHeader.Flags.CryptoMethod:X})");
                        Console.WriteLine($"      Content platform: {partitionHeader.Flags.ContentPlatform} (0x{partitionHeader.Flags.ContentPlatform:X})");
                        Console.WriteLine($"      Content type: {partitionHeader.Flags.MediaPlatformIndex} (0x{partitionHeader.Flags.MediaPlatformIndex:X})");
                        Console.WriteLine($"      Content unit size: {partitionHeader.Flags.ContentUnitSize} (0x{partitionHeader.Flags.ContentUnitSize:X})");
                        Console.WriteLine($"      Bitmasks: {partitionHeader.Flags.BitMasks} (0x{partitionHeader.Flags.BitMasks:X})");
                        Console.WriteLine($"    Plain region offset, in media units: {partitionHeader.PlainRegionOffsetInMediaUnits} (0x{partitionHeader.PlainRegionOffsetInMediaUnits:X})");
                        Console.WriteLine($"    Plain region size, in media units: {partitionHeader.PlainRegionSizeInMediaUnits} (0x{partitionHeader.PlainRegionSizeInMediaUnits:X})");
                        Console.WriteLine($"    Logo region offset, in media units: {partitionHeader.LogoRegionOffsetInMediaUnits} (0x{partitionHeader.LogoRegionOffsetInMediaUnits:X})");
                        Console.WriteLine($"    Logo region size, in media units: {partitionHeader.LogoRegionSizeInMediaUnits} (0x{partitionHeader.LogoRegionSizeInMediaUnits:X})");
                        Console.WriteLine($"    ExeFS offset, in media units: {partitionHeader.ExeFSOffsetInMediaUnits} (0x{partitionHeader.ExeFSOffsetInMediaUnits:X})");
                        Console.WriteLine($"    ExeFS size, in media units: {partitionHeader.ExeFSSizeInMediaUnits} (0x{partitionHeader.ExeFSSizeInMediaUnits:X})");
                        Console.WriteLine($"    ExeFS hash region size, in media units: {partitionHeader.ExeFSHashRegionSizeInMediaUnits} (0x{partitionHeader.ExeFSHashRegionSizeInMediaUnits:X})");
                        Console.WriteLine($"    Reserved 3: {BitConverter.ToString(partitionHeader.Reserved3).Replace('-', ' ')}");
                        Console.WriteLine($"    RomFS offset, in media units: {partitionHeader.RomFSOffsetInMediaUnits} (0x{partitionHeader.RomFSOffsetInMediaUnits:X})");
                        Console.WriteLine($"    RomFS size, in media units: {partitionHeader.RomFSSizeInMediaUnits} (0x{partitionHeader.RomFSSizeInMediaUnits:X})");
                        Console.WriteLine($"    RomFS hash region size, in media units: {partitionHeader.RomFSHashRegionSizeInMediaUnits} (0x{partitionHeader.RomFSHashRegionSizeInMediaUnits:X})");
                        Console.WriteLine($"    Reserved 4: {BitConverter.ToString(partitionHeader.Reserved4).Replace('-', ' ')}");
                        Console.WriteLine($"    ExeFS superblock SHA-256 hash: {BitConverter.ToString(partitionHeader.ExeFSSuperblockHash).Replace('-', ' ')}");
                        Console.WriteLine($"    RomFS superblock SHA-256 hash: {BitConverter.ToString(partitionHeader.RomFSSuperblockHash).Replace('-', ' ')}");
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print metadata information
        /// </summary>
        private void PrintMetaData()
        {
            Console.WriteLine("  Meta Data Information:");
            Console.WriteLine("  -------------------------");
            if (_cia.MetaData == null || MetaSize == 0)
            {
                Console.WriteLine(value: "  No meta file data");
            }
            else
            {
                Console.WriteLine(value: $"  Title ID dependency list: {BitConverter.ToString(MD_TitleIDDependencyList).Replace('-', ' ')}");
                Console.WriteLine($"  Reserved 1: {BitConverter.ToString(MD_Reserved1).Replace('-', ' ')}");
                Console.WriteLine($"  Core version: {MD_CoreVersion} (0x{MD_CoreVersion:X})");
                Console.WriteLine($"  Reserved 2: {BitConverter.ToString(MD_Reserved2).Replace('-', ' ')}");
                Console.WriteLine($"  Icon data: {BitConverter.ToString(MD_IconData).Replace('-', ' ')}");
            }
            Console.WriteLine();
        }

        #endregion
    }
}