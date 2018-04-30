using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid patient class entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum PatientClass
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
        /// Inpatient/Overnight patient
        /// </summary>
        [EnumMember]
        [Name(Code = "I", Name = "Inpatient")]
        Inpatient,

        /// <summary>
        /// Same Day Patient
        /// </summary>
        [EnumMember]
        [Name(Code = "S", Name = "Same Day Patient")]
        SameDayPatient,

        /// <summary>
        /// Outpatient
        /// </summary>
        [EnumMember]
        [Name(Code = "O", Name = "Outpatient")]
        Outpatient,

        /// <summary>
        /// Emergency Patient
        /// </summary>
        [EnumMember]
        [Name(Code = "E", Name = "Emergency Patient")]
        EmergencyPatient,

        /// <summary>
        /// CommunityClient
        /// </summary>
        [EnumMember]
        [Name(Code = "Y", Name = "Community Client")]
        CommunityClient,

        /// <summary>
        /// Pre-admit
        /// </summary>
        [EnumMember]
        [Name(Code = "P", Name = "Pre-admit")]
        Preadmit,

        /// <summary>
        /// Commercial Account
        /// </summary>
        [EnumMember]
        [Name(Code = "C", Name = "Commercial Account")]
        CommercialAccount,

        /// <summary>
        /// NotApplicable
        /// </summary>
        [EnumMember]
        [Name(Code = "N", Name = "Not Applicable")]
        NotApplicable,

        /// <summary>
        /// Unknown
        /// </summary>
        [EnumMember]
        [Name(Code = "U", Name = "Unknown")]
        Unknown


    }
}