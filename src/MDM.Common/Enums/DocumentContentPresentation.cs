using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid document completion status entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum DocumentContentPresentation
    {
        /// <summary>
        /// Undefined, this is the default value if the enum is left unset.
        /// 
        /// The validation engine uses this to test and assert that the enum has been set (if required)
        /// and is therefore valid.
        /// </summary>
        [EnumMember]
        Undefined,

        /// <summary>
        /// Application data - HL7 V2.3 and later
        /// </summary>
        [EnumMember]
        [Name(Code = "AP", Name = "Application data - HL7 V2.3 and later")]
        ApplicationData,

        /// <summary>
        /// Audio data - HL7 V2.3 and later
        /// </summary>
        [EnumMember]
        [Name(Code = "AU", Name = "Audio data - HL7 V2.3 and later")]
        AudioData,

        /// <summary>
        /// Formatted Text - HL7 V2.2 Only
        /// </summary>
        [EnumMember]
        [Name(Code = "FT", Name = "Formatted Text - HL7 V2.2 Only")]
        Documented,

        /// <summary>
        /// Image Data - HL7 V2.3 and later
        /// </summary>
        [EnumMember]
        [Name(Code = "IM", Name = "Image Data - HL7 V2.3 and later")]
        ImageData,

        /// <summary>
        /// Non-scanned image - HL7 V2.2 Only
        /// </summary>
        [EnumMember]
        [Name(Code = "NS", Name = "Non-scanned image - HL7 V2.2 Only")]
        NonScannedData,

        /// <summary>
        /// Scanned document - HL7 V2.2 Only
        /// </summary>
        [EnumMember]
        [Name(Code = "SD", Name = "Scanned document - HL7 V2.2 Only")]
        ScannedDocument,

        /// <summary>
        /// Scanned Immage HL7 V2.2 Only
        /// </summary>
        [EnumMember]
        [Name(Code = "SI", Name = "Scanned Immage HL7 V2.2 Only")]
        ScannedImmage,

        /// <summary>
        /// Machine readable text document - HL7 V2.3.1
        /// </summary>
        [EnumMember]
        [Name(Code = "TEXT", Name = "Machine readable text document - HL7 V2.3.1")]
        TEXT,

        /// <summary>
        /// Machine readable text document - HL7 V2.2 Only
        /// </summary>
        [EnumMember]
        [Name(Code = "TX", Name = "Machine readable text document - HL7 V2.2 Only")]
        TX,

        /// <summary>
        /// MIME Multipart package
        /// </summary>
        [EnumMember]
        [Name(Code = "multipart", Name = "MIME Multipart package")]
        Multipart,
    }
}