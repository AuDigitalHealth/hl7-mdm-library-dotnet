using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDM.Common.Enums;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// Patient Visit
    /// </summary>
    public class PV1
    {
        #region Properties
        /// <summary>
        /// Consulting Doctor
        /// </summary>
        public XCN ConsultingDoctor { get; set; }

        private PatientClass? _patientClass;
        internal PatientClass? PatientClass
        {
            get
            {
                if (_patientClass == null)
                {
                    _patientClass = Common.Enums.PatientClass.NotApplicable;
                }
                return _patientClass;
            }
            set
            {
                _patientClass = value;
            }
        }

        private String _setID;
        internal String SetID
        {
            get
            {
                if (String.IsNullOrEmpty(_setID))
                {
                    _setID = "1";
                }
                return _setID;
            }
            set
            {
                _setID = value;
            }
        }

        #endregion

        #region Constructors
        public PV1()
        {
            ConsultingDoctor = new XCN();
        }
        #endregion

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "ConsultingDoctor", ConsultingDoctor))
            {
                ConsultingDoctor.Validate(validationBuilder.Path, validationBuilder.Messages);
            }
        }
        #endregion
    }
}
