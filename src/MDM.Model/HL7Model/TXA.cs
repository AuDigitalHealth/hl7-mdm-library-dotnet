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
    public class TXA
    {
        #region Properties

        /// <summary>
        /// Document conent presentation
        /// </summary>
        private DocumentContentPresentation? _documentContentPresentation;
        public DocumentContentPresentation? DocumentContentPresentation
        {
            get
            {
                if (_documentContentPresentation == null)
                {
                    _documentContentPresentation = Common.Enums.DocumentContentPresentation.ApplicationData;
                }
                return _documentContentPresentation;
            }
            set
            {
                _documentContentPresentation = value;
            }
        }

        /// <summary>
        /// Activity date/time
        /// </summary>
        public DateTime? ActivityDateTime { get; set; }

        /// <summary>
        /// Unique document number, this should be the unique ID that is within the root of the CDA document.
        /// </summary>
        public String UniqueDocumentNumber { get; set;}

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

        private String _documentType;
        internal String DocumentType
        {
            get
            {
                if (String.IsNullOrEmpty(_documentType))
                {
                    _documentType = "NEHTA";
                }
                return _documentType;
            }
            set
            {
                _documentType = value;
            }
        }

        private String _uniqueDocumentFileName;
        internal String UniqueDocumentFileName
        {
            get
            {
                if (String.IsNullOrEmpty(_uniqueDocumentFileName))
                {
                    _uniqueDocumentFileName = "PACKAGE.ZIP";
                }
                return _uniqueDocumentFileName;
            }
            set
            {
                _uniqueDocumentFileName = value;
            }
        }

        private DocumentCompletionStatus? _completionStatus;
        internal DocumentCompletionStatus? CompletionStatus
        {
            get
            {
                if (_completionStatus == null)
                {
                    _completionStatus = DocumentCompletionStatus.LegallyAuthenticated;
                }
                return _completionStatus;
            }
            set
            {
                _completionStatus = value;
            }
        }
        #endregion Properties

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "SetID", SetID);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "UniqueDocumentNumber", UniqueDocumentNumber);
        }
        #endregion
    }
}
