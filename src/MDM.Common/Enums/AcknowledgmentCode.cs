using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid Acknowledgment Code entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum AcknowledgmentCode
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
        /// Application Accept
        /// </summary>
        [EnumMember]
        [Name(Code = "AA", Name = "Application Accept")]
        ApplicationAccept,

        /// <summary>
        /// Application Error
        /// </summary>
        [EnumMember]
        [Name(Code = "AE", Name = "Application Error")]
        ApplicationError,

        /// <summary>
        /// Application Reject
        /// </summary>
        [EnumMember]
        [Name(Code = "AR", Name = "Application Reject")]
        ApplicationReject,

        /// <summary>
        /// Commit Accept
        /// </summary>
        [EnumMember]
        [Name(Code = "CA", Name = "Commit Accept")]
        CommitAccept,

        /// <summary>
        /// Commit Error
        /// </summary>
        [EnumMember]
        [Name(Code = "CE", Name = "Commit Error")]
        CommitError,

        /// <summary>
        /// Commit Reject
        /// </summary>
        [EnumMember]
        [Name(Code = "CR", Name = "Commit Reject")]
        CommitReject,
    }
}