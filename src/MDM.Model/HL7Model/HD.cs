using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// This class encapsulates the properties for an identifier
    /// </summary>
    public class HD
    {
        #region Properties
        /// <summary>
        /// Namespace ID
        /// </summary>
        public String NamespaceID { get; set; }

        /// <summary>
        /// Universal ID
        /// </summary>
        public String UniversalID { get; set; }

        /// <summary>
        /// Universal ID type
        /// </summary>
        public String UniversalIDType { get; set; }
        #endregion

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "UniversalID", UniversalID);
        }
        #endregion
    }
}
