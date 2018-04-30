using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid gender entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum Gender
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
        /// Male
        /// </summary>
        [EnumMember]
        [Name(Code = "M", Name = "Male")]
        Male,

        /// <summary>
        /// Female
        /// </summary>
        [EnumMember]
        [Name(Code = "F", Name = "Female")]
        Female,

        /// <summary>
        /// Other
        /// </summary>
        [EnumMember]
        [Name(Code = "O", Name = "Other")]
        Other,

        /// <summary>
        /// Ambiguous
        /// </summary>
        [EnumMember]
        [Name(Code = "A", Name = "Ambiguous")]
        Ambiguous,

        /// <summary>
        /// Unknown
        /// </summary>
        [EnumMember]
        [Name(Code = "U", Name = "Unknown")]
        Unknown,

        /// <summary>
        /// Not Applicable
        /// </summary>
        [EnumMember]
        [Name(Code = "N", Name = "NotApplicable")]
        NotApplicable
    }
}