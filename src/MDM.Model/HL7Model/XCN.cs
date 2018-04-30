using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// This class encapsulates the properties for the doctor; for a
    /// patient visit.
    /// </summary>
    public class XCN
    {
        #region Properties
        /// <summary>
        /// ID
        /// </summary>
        public String ID { get; set; }

        /// <summary>
        /// IdentifierTypeCode
        /// </summary>
        public String IdentifierTypeCode { get; set; }

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

        /// <summary>
        /// Degree
        /// </summary>
        public String Degree { get; set; }
        
        /// <summary>
        /// Assigning authority
        /// </summary>
        public HD AssigningAuthority { get; set; }

        internal String NameTypeCode { get; set; }
        internal String NameRepresentationCode { get; set; }
        internal String NameContextIdentifier { get; set; }
        internal String NameContextText { get; set; }
        internal String NameContextCodingSystemName { get; set; }
        internal String NameValidityRangeStart { get; set; }
        internal String NameValidityRangeEnd{ get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public XCN()
        {
            AssigningAuthority = new HD();
        }
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
