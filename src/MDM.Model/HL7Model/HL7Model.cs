using System;
using System.Collections.Generic;

using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// This class encapsulates the properties that are required to generate an HL7 message
    /// </summary>
    public class HL7Model
    {
        #region Properties
        /// <summary>
        /// MSH
        /// </summary>
        public MSH MSH { get; set; }

        /// <summary>
        /// MSA - Only for Acknowledgements
        /// </summary>
        public MSA MSA { get; set; }

        /// <summary>
        /// Event Type
        /// </summary>
        public EVN EVN { get; set; }

        /// <summary>
        /// Patient Identification
        /// </summary>
        public PID PID { get; set; }
        
        /// <summary>
        /// Patient Visit
        /// </summary>
        public PV1 PV1 { get; set; }

        /// <summary>
        /// Transcription Document Header
        /// </summary>
        public TXA TXA { get; set; }

        /// <summary>
        /// Observation / Result
        /// </summary>
        public OBX OBX { get; set; }
        #endregion

        #region Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.Path + "EVN", EVN))
            {
                EVN.Validate(validationBuilder.PathName, validationBuilder.Messages);
            }

            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.Path + "MSH", MSH))
            {
                MSH.Validate(validationBuilder.PathName, validationBuilder.Messages);
            }

            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.Path + "OBX", OBX))
            {
                OBX.Validate(validationBuilder.PathName, validationBuilder.Messages);
            }

            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.Path + "PID", PID))
            {
                PID.Validate(validationBuilder.PathName, validationBuilder.Messages);
            }
            
            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.Path + "PV1", PV1))
            {
                PV1.Validate(validationBuilder.PathName, validationBuilder.Messages);
            }

            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.Path + "TXA", TXA))
            {
                TXA.Validate(validationBuilder.PathName, validationBuilder.Messages);
            }

            if (validationBuilder.Messages.Count > 0)
            {
                throw new ValidationException(validationBuilder.Messages, "Please cast this exception back to a ValidationException to see the collection of validation errors");
            }
        }

        internal void ValidateAck(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.Path + "MSH", MSH))
            {
                MSH.Validate(validationBuilder.PathName, validationBuilder.Messages);
            }

            if (validationBuilder.ArgumentRequiredCheck(validationBuilder.Path + "MSA", MSA))
            {
                MSA.Validate(validationBuilder.PathName, validationBuilder.Messages);
            }

            if (validationBuilder.Messages.Count > 0)
            {
                throw new ValidationException(validationBuilder.Messages, "Please cast this exception back to a ValidationException to see the collection of validation errors");
            }
        }

        #endregion
    }
}
