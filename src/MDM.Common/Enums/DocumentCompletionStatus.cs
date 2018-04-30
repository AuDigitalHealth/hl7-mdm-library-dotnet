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
    public enum DocumentCompletionStatus
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
        /// Authenticated
        /// </summary>
        [EnumMember]
        [Name(Code = "AU", Name = "Authenticated")]
        Authenticated,

        /// <summary>
        /// Dictated
        /// </summary>
        [EnumMember]
        [Name(Code = "DI", Name = "Dictated")]
        Dictated,

        /// <summary>
        /// Documented
        /// </summary>
        [EnumMember]
        [Name(Code = "DO", Name = "Documented")]
        Documented,

        /// <summary>
        /// Incomplete
        /// </summary>
        [EnumMember]
        [Name(Code = "IN", Name = "Incomplete")]
        Incomplete,

        /// <summary>
        /// In Progress
        /// </summary>
        [EnumMember]
        [Name(Code = "IP", Name = "In Progress")]
        InProgress,

        /// <summary>
        /// Legally authenticated
        /// </summary>
        [EnumMember]
        [Name(Code = "LA", Name = "Legally authenticated")]
        LegallyAuthenticated,

        /// <summary>
        /// Pre-authenticated
        /// </summary>
        [EnumMember]
        [Name(Code = "PA", Name = "Pre-authenticated")]
        PreAuthenticated
    }
}