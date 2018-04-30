using System;
using System.Runtime.Serialization;

using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid Admission Message entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum AdmissionMessage
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
        /// A01
        /// </summary>
        [EnumMember]
        [Name(Code = "A01", Name = "Admit Patient")]
        A01,

        /// <summary>
        /// A02
        /// </summary>
        [EnumMember]
        [Name(Code = "A02", Name = "Transfer a Patient")]
        A02,

        /// <summary>
        /// A03
        /// </summary>
        [EnumMember]
        [Name(Code = "A03", Name = "Discharge/End Visit")]
        A03,

        /// <summary>
        /// A04
        /// </summary>
        [EnumMember]
        [Name(Code = "A04", Name = "Register an Outpatient/ER Patient")]
        A04,

        /// <summary>
        /// A05
        /// </summary>
        [EnumMember]
        [Name(Code = "A05", Name = "Pre-admit a Patient")]
        A05,

        /// <summary>
        /// A06
        /// </summary>
        [EnumMember]
        [Name(Code = "A06", Name = "Change an Outpatient to an Inpatient")]
        A06,

        /// <summary>
        /// A07
        /// </summary>
        [EnumMember]
        [Name(Code = "A07", Name = "Change an Inpatient to an Outpatient")]
        A07,

        /// <summary>
        /// A08
        /// </summary>
        [EnumMember]
        [Name(Code = "A08", Name = "Update Patient Information")]
        A08,

        /// <summary>
        /// A11
        /// </summary>
        [EnumMember]
        [Name(Code = "A11", Name = "Cancel Admission")]
        A11,

        /// <summary>
        /// A12
        /// </summary>
        [EnumMember]
        [Name(Code = "A12", Name = "Cancel transfer")]
        A12,

        /// <summary>
        /// A13
        /// </summary>
        [EnumMember]
        [Name(Code = "A13", Name = "Cancel discharge")]
        A13,

        /// <summary>
        /// A14
        /// </summary>
        [EnumMember]
        [Name(Code = "A14", Name = "Pending admit")]
        A14,

        /// <summary>
        /// A15
        /// </summary>
        [EnumMember]
        [Name(Code = "A15", Name = "Pending transfer")]
        A15,

        /// <summary>
        /// A16
        /// </summary>
        [EnumMember]
        [Name(Code = "A16", Name = "Pending discharge")]
        A16,

        /// <summary>
        /// A17
        /// </summary>
        [EnumMember]
        [Name(Code = "A17", Name = "Swap Patients")]
        A17,

        /// <summary>
        /// A18
        /// </summary>
        [EnumMember]
        [Name(Code = "A18", Name = "Merge Records")]
        A18,

        /// <summary>
        /// A21
        /// </summary>
        [EnumMember]
        [Name(Code = "A21", Name = "Go on leave of absence")]
        A21,

        /// <summary>
        /// A22
        /// </summary>
        [EnumMember]
        [Name(Code = "A22", Name = "Return from Leave")]
        A22,

        /// <summary>
        /// A23
        /// </summary>
        [EnumMember]
        [Name(Code = "A23", Name = "Delete Patient encounter")]
        A23,

        /// <summary>
        /// A25
        /// </summary>
        [EnumMember]
        [Name(Code = "A25", Name = "Cancel pending discharge")]
        A25,

        /// <summary>
        /// A26
        /// </summary>
        [EnumMember]
        [Name(Code = "A26", Name = "Cancel pending transfer")]
        A26,

        /// <summary>
        /// A27
        /// </summary>
        [EnumMember]
        [Name(Code = "A27", Name = "Cancel pending admit")]
        A27,

        /// <summary>
        /// A28
        /// </summary>
        [EnumMember]
        [Name(Code = "A28", Name = "Add person Information")]
        A28,

        /// <summary>
        /// A31
        /// </summary>
        [EnumMember]
        [Name(Code = "A31", Name = "Update person Information")]
        A31,

        /// <summary>
        /// A34
        /// </summary>
        [EnumMember]
        [Name(Code = "A34", Name = "Merge Patient Information")]
        A34,

        /// <summary>
        /// A35
        /// </summary>
        [EnumMember]
        [Name(Code = "A35", Name = "Merge  Patient Account number")]
        A35,

        /// <summary>
        /// A38
        /// </summary>
        [EnumMember]
        [Name(Code = "A38", Name = "Cancel pre-admit")]
        A38,

        /// <summary>
        /// A44
        /// </summary>
        [EnumMember]
        [Name(Code = "A44", Name = "Move account number")]
        A44
    }
}