using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid document observation result status entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum ObservationResultStatus
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
        /// Delete
        /// </summary>
        [EnumMember]
        [Name(Code = "D", Name = "Delete")]
        Delete,

        /// <summary>
        /// Final
        /// </summary>
        [EnumMember]
        [Name(Code = "F", Name = "Final")]
        Final,

        /// <summary>
        /// Not asked
        /// </summary>
        [EnumMember]
        [Name(Code = "N", Name = "Not asked")]
        NotAsked,

        /// <summary>
        /// Order detail description
        /// </summary>
        [EnumMember]
        [Name(Code = "O", Name = "Order detail description")]
        OrderDetailDescription,

        /// <summary>
        /// Partial results
        /// </summary>
        [EnumMember]
        [Name(Code = "S", Name = "Partial results")]
        PartialResults,

        /// <summary>
        /// Post origin is wrong
        /// </summary>
        [EnumMember]
        [Name(Code = "W", Name = "wrong")]
        Wrong,

        /// <summary>
        /// Preliminary results
        /// </summary>
        [EnumMember]
        [Name(Code = "P", Name = "Preliminary results")]
        PreliminaryResults,

        /// <summary>
        /// Correction
        /// </summary>
        [EnumMember]
        [Name(Code = "C", Name = "Correction")]
        Correction,

        /// <summary>
        /// Unable to obtain
        /// </summary>
        [EnumMember]
        [Name(Code = "X", Name = "Unable to obtain")]
        UnableToObtain,
        
        /// <summary>
        /// Results entered, not verified
        /// </summary>
        [EnumMember]
        [Name(Code = "R", Name = "Results entered, not verified")]
        ResultsEnteredNotVerified,

        /// <summary>
        /// Change without retransmitting
        /// </summary>
        [EnumMember]
        [Name(Code = "U", Name = "Change without retransmitting")]
        ChangeWithoutRetransmitting,

        /// <summary>
        /// In lab
        /// </summary>
        [EnumMember]
        [Name(Code = "I", Name = "In lab")]
        InLab
    }
}