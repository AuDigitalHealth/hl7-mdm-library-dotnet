using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid Accept Acknowledgement entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum AcceptAcknowledgement
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
        /// Always
        /// </summary>
        [EnumMember]
        [Name(Code = "AL", Name = "Always")]
        Always,

        /// <summary>
        /// Never
        /// </summary>
        [EnumMember]
        [Name(Code = "NE", Name = "Never")]
        Never,

        /// <summary>
        /// Error / Reject
        /// </summary>
        [EnumMember]
        [Name(Code = "ER", Name = "Error / Reject")]
        Error,

        /// <summary>
        /// Sucessful completion only
        /// </summary>
        [EnumMember]
        [Name(Code = "SU", Name = "Sucessfull completion only")]
        SucessfulCompletionOnly
    }
}