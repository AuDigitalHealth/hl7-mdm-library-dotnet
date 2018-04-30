using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    public class XPN
    {
        #region Properties
        /// <summary>
        /// Family name
        /// </summary>
        public String FamilyName { get; set; }

        /// <summary>
        /// Given name
        /// </summary>
        public String GivenName { get; set; }

        /// <summary>
        /// Middle name
        /// </summary>
        public String MiddleName { get; set; }

        /// <summary>
        /// Suffix
        /// </summary>
        public String Suffix { get; set; }

        /// <summary>
        /// Prefix
        /// </summary>
        public String Prefix { get; set; }

        internal String NameTypeCode { get; set; }
        internal String NameRepresentationCode { get; set; }
        internal String NameContextIdentifier { get; set; }
        internal String NameContextText { get; set; }
        internal String NameContextCodingSystemName { get; set; }
        internal String NameValidityRangeStart { get; set; }
        internal String NameValidityRangeEnd{ get; set; }
        #endregion

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "FamilyName", FamilyName);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "GivenName", GivenName);
        }
        #endregion
    }
}
