using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDM.Common.Enums;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// Patient Identification
    /// </summary>
    public class PID
    {
        #region Properties
        internal String SetID
        {
            get
            {
                return "1";
            }
        }

        /// <summary>
        /// PatientID
        /// </summary>
        public List<CX> PatientIdentifiers { get; set; }

        /// <summary>
        /// PatientName
        /// </summary>
        public XPN PatientName { get; set; }

        /// <summary>
        /// BirthDateTime
        /// </summary>
        public DateTime? BirthDateTime { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public XAD AddressLines { get; set; }
        #endregion

        #region Constructors
        public PID()
        {
            AddressLines = new XAD();
            PatientName = new XPN();
            PatientIdentifiers = new List<CX>();
        }
        #endregion
        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "PatientIdentifiers", PatientIdentifiers);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "PatientName", PatientName);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "AddressLines", AddressLines);
        }
        #endregion
    }
}
