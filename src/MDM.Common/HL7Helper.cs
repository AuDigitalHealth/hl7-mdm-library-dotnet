using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace MDM.Common
{
    /// <summary>
    /// This helper class encapsualtes all the common functionaly that is required by the MDM Generator
    /// </summary>
    public static class HL7Helper
    {
        /// <summary>
        /// The short date format to be used within the HL7 MDM messages
        /// </summary>
        public static String ShortDateFormat = "yyyyMMdd";

        /// <summary>
        /// Provides the curlture information for the date time format that is to be used within the MDM messages
        /// </summary>
        public static CultureInfo CultureInfo
        {
            get
            {
                var dateTimeFormatInfo = new DateTimeFormatInfo
                {
                    ShortDatePattern = ShortDateFormat
                };
                var cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name)
                {
                    DateTimeFormat = dateTimeFormatInfo
                };

                cultureInfo.DateTimeFormat.LongTimePattern = String.Empty;

                return cultureInfo;
            }
        }

        /// <summary>
        /// The long date format to be used within the HL7 MDM messages
        /// </summary>
        public static String LongDateFormat = "yyyyMMddHHmmss";

        /// <summary>
        /// The field seperator to be used within an HL7 message
        /// </summary>
        public static char FieldSeperator
        {
            get
            {
                return '|';
            }
        }

        /// <summary>
        /// The component seperator to be used within an HL7 message
        /// </summary>
        public static char ValueSeperator
        {
            get
            {
                return EncodingCharacters[0]; //^
            }
        }

        /// <summary>
        /// The Value seperator to be used within an HL7 message
        /// </summary>
        public static char ComponentSeperator
        {
            get
            {
                return EncodingCharacters[3];  //&
            }
        }

        /// <summary>
        /// The component repeator to be used within an HL7 message
        /// </summary>
        public static char ComponentRepeator
        {
            get
            {
                return EncodingCharacters[1]; //~
            }
        }

        /// <summary>
        /// A collection of encoding characters that are used with an HL7 message
        /// 
        /// the first character is the component seperator
        /// the second character is the componet repeator etc.
        /// </summary>
        public static String EncodingCharacters
        {
            get
            {
                return @"^~\&";
            }
        }

        /// <summary>
        /// The new line character to be used within the HL7 message
        /// </summary>
        public static String NewLine
        {
            get
            {
                return "\r";
            }
        }

        private static DateTime? _dateTime;

        /// <summary>
        /// The message Date / Time to be used with the HL7 message
        /// </summary>
        public static String MessageDateTime
        {
            get
            {
                if (
                        !_dateTime.HasValue ||
                        _dateTime.Value.ToShortDateString() != DateTime.Now.ToShortDateString() ||
                        (
                            _dateTime.Value.ToShortDateString() != DateTime.Now.ToShortDateString() &&
                            _dateTime.Value.Minute != DateTime.Now.Minute
                        )
                    )
                {
                    _dateTime = DateTime.Now;
                }

                return _dateTime.Value.ToString(LongDateFormat);
            }
        }

        ///<summary>
        /// This method takes in a byte array representation of a .zip packing specification zip
        /// and returns the root CDA document contained within the zip.
        ///</summary>
        ///<param name="zipBytes">zipBytes</param>
        public static XmlDocument GetCDADocumentFromZip(byte[] zipBytes)
        {
            Dictionary<string, byte[]> entries = GetZipEntriesFromZipStream(zipBytes);

            // Get root document
            var rootDoc = entries.FirstOrDefault(a => Regex.IsMatch(a.Key.ToUpper(), @"CDA_ROOT.XML"));
            var cdaDocument = new XmlDocument();

            using (var cdaDocumentStream = new MemoryStream(rootDoc.Value))
            {
                cdaDocument.Load(cdaDocumentStream); 
            }

            return cdaDocument;
        }

        /// <summary>
        /// Obtain all the zip file entries and their content.
        /// </summary>
        /// <param name="zipFile">The zip file.</param>
        /// <returns>Zip file entries and their content.</returns>
        internal static Dictionary<string, byte[]> GetZipEntriesFromZipStream(byte[] zipFile)
        {
            var contentByFileName = new Dictionary<string, byte[]>();
            var inputStream = new MemoryStream(zipFile);

            if (zipFile.Length > 0)
            {
                using (ZipArchive zipArchive = new ZipArchive(inputStream, ZipArchiveMode.Read))
                {
                    foreach (var entry in zipArchive.Entries)
                    {
                        // Ony process files.
                        if (entry.Length > 0)
                        {
                            var output = new MemoryStream();
                            entry.Open().CopyTo(output);
                            contentByFileName.Add(entry.FullName, output.ToArray());
                        }
                    }
                }
            }

            return contentByFileName;
        }
    }
}
