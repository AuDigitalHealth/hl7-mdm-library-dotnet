using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// This class encapsulates the properties for the identifiers; for a
    /// patient identifier.
    /// </summary>
    public class CX
    {
        #region Properties
        /// <summary>
        /// ID
        /// </summary>
        public String ID { get; set; }

        /// <summary>
        /// Assigining authority
        /// </summary>
        public HD AssiginingAuthority { get; set; }

        /// <summary>
        /// Identifier type code
        /// </summary>
        public String IdentifierTypeCode { get; set; }
        
        internal String CheckDigit { get; set; }
        internal String CheckDigitSchemeCode { get; set; }
        internal String AssigningFacility { get; set; }
        internal DateTime? EffectiveDate { get; set; }
        internal DateTime? ExpirationDate { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CX()
        {
            AssiginingAuthority = new HD();
        }
        #endregion
        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "ID", ID);
        }
        #endregion
    }
}
