using System;
using System.Collections.Generic;
using MDM.Common.Enums;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// This class encapsulates the properties for the address; for a
    /// patient identifier.
    /// </summary>
    public class XAD
    {
        #region Properties
        /// <summary>
        /// Street address
        /// </summary>
        public String StreetAddress { get; set; }

        /// <summary>
        /// Second street address line
        /// </summary>
        public String SecondStreetAddressLine { get; set; }
        
        /// <summary>
        /// City
        /// </summary>
        public String City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public String State { get; set; }

        /// <summary>
        /// Post code
        /// </summary>
        public String PostCode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public Country? Country { get; set; }
        #endregion

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            //var validationBuilder = new ValidationBuilder(path, messages);

            //validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "StreetAddress", StreetAddress);
            //validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "City", City); 
            //validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "State", State);
            //validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "PostCode", PostCode);
            
        }
        #endregion
    }
}
