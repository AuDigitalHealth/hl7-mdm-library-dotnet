using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using MDM.Common.Attributes;
using MDM.Common.Enums;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// Transcription Document Header
    /// </summary>
    public class MSA
    {
        #region Public Properties

        /// <summary>
        /// Acknowledgment Code
        /// 
        /// MSH.3
        /// </summary>
        public AcknowledgmentCode SendingApplication { get; set; }

        /// <summary>
        /// Message Control ID
        /// 
        /// MSH.4
        /// </summary>
        public string MessageControlID { get; set; }

        #endregion Public Properties

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "SendingApplication", SendingApplication);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "MessageControlID", MessageControlID);
        }
        #endregion
    }
}
