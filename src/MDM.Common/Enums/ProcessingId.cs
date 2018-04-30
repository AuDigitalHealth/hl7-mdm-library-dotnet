using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid processing ID entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum ProcessingId
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
        /// Production
        /// </summary>
        [EnumMember]
        [Name(Code = "P", Name = "Production")]
        Production,

        /// <summary>
        /// Development
        /// </summary>
        [EnumMember]
        [Name(Code = "D", Name = "Debugging")]
        Debugging,

        /// <summary>
        /// Test
        /// </summary>
        [EnumMember]
        [Name(Code = "T", Name = "Training")]
        Training
    }
}