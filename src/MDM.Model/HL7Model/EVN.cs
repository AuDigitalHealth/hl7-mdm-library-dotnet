using System;
using System.Collections.Generic;

using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// Event Type
    /// </summary>
    public class EVN
    {
        #region Internal Properties

        private String _eventTypeCode;
        internal String EventTypeCode
        {
            get
            {
                if (String.IsNullOrEmpty(_eventTypeCode))
                {
                    _eventTypeCode ="T02";

                }

                return _eventTypeCode;
            }
            set
            {
                _eventTypeCode = value;
            }
        }

        /// <summary>
        /// The message Date / Time to be used with the HL7 message
        /// </summary>
        public DateTime? MessageDateTime { get; set; }
        #endregion

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "EventTypeCode", EventTypeCode);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "MessageDateTime", MessageDateTime);
        }
        #endregion
    }
}