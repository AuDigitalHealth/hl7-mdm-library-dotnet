using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid Processing Mode entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum ProcessingMode
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
        /// Archive
        /// </summary>
        [EnumMember]
        [Name(Code = "A", Name = "Archive")]
        Archive,

        /// <summary>
        /// Restore From Archive
        /// </summary>
        [EnumMember]
        [Name(Code = "R", Name = "Restore From Archive")]
        RestoreFromArchive,

        /// <summary>
        /// Initial Load
        /// </summary>
        [EnumMember]
        [Name(Code = "I", Name = "Initial Load")]
        InitialLoad,

        /// <summary>
        /// NotPresent
        /// </summary>
        [EnumMember]
        [Name(Code = "NotPresent", Name = "Not Present")]
        NotPresent
    }
}