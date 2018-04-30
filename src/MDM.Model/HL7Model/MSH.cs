using System;
using System.Collections.Generic;
using MDM.Common;
using MDM.Common.Enums;

using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// Message Header
    /// </summary>
    public class MSH
    {
        #region Public Properties
        /// <summary>
        /// Sending Application / Facility
        /// 
        /// MSH.3
        /// </summary>
        public HD SendingApplication { get; set; }

        /// <summary>
        /// Sending HPIO
        /// 
        /// MSH.4
        /// </summary>
        public HD SendingFacility { get; set; }

        /// <summary>
        /// Receiving Application / Facility
        /// 
        /// MSH.5
        /// </summary>
        public HD ReceivingApplication { get; set; }

        /// <summary>
        /// Receiving HPIO
        /// 
        /// MSH.6
        /// </summary>
        public HD ReceivingFacility { get; set; }

        private Country? _countyCode;
        internal Country? CountyCode
        {
            get
            {
                if (!_countyCode.HasValue)
                {
                    _countyCode = Country.Australia;
                }
                return _countyCode;
            }
            set
            {
                _countyCode = value;
            }
        }

        /// <summary>
        /// Accept Acknowledgement Type
        /// 
        /// MSH.15
        /// </summary>
        private AcceptAcknowlegement? _acceptAcknowledgementType;
        internal AcceptAcknowlegement? AcceptAcknowledgementType
        {
            get
            {
                if (!_acceptAcknowledgementType.HasValue)
                {
                    _acceptAcknowledgementType = AcceptAcknowlegement.Never;
                }
                return _acceptAcknowledgementType;
            }
            set
            {
                _acceptAcknowledgementType = value;
            }
        }

        private AcceptAcknowlegement? _applicationAcknowledgementType;
        internal AcceptAcknowlegement? ApplicationAcknowledgementType
        {
            get
            {
                if (!_applicationAcknowledgementType.HasValue)
                {
                    _applicationAcknowledgementType = AcceptAcknowlegement.Never;
                }
                return _applicationAcknowledgementType;
            }
            set
            {
                _applicationAcknowledgementType = value;
            }
        }

        private String _messageDateTime;
        internal String MessageDateTime
        {
            get
            {
                if (String.IsNullOrEmpty(_messageDateTime))
                {
                    _messageDateTime = HL7Helper.MessageDateTime;
                }

                return _messageDateTime;
            }
            set
            {
                _messageDateTime = value;
            }
        }
        #endregion

        #region Internal Properties
        /// <summary>
        /// Message Control Id
        /// </summary>
        public String MessageControlId
        {
            get
            {
                if (String.IsNullOrEmpty(_messageControlId))
                {
                    _messageControlId = new Random().Next().ToString();
                }
                return _messageControlId;
            }

            set
            {
                _messageControlId = value;
            }
        }

        internal String MessageSecurity { get; set; }

        private String _messageType;
        internal String MessageType
        {
            get
            {
                if (String.IsNullOrEmpty(_messageType))
                {
                    _messageType = @"MDM^T02^MDM_T02";
                }

                return _messageType;
            }
            set
            {
                _messageType = value;
            }
        }

        private string _messageControlId;

        private ProcessingId? _processingID;
        internal ProcessingId? ProcessingID
        {
            get
            {
                if (!_processingID.HasValue)
                {
                    _processingID = ProcessingId.Production;
                }
                return _processingID;
            }
            set
            {
                _processingID = value;
            }
        }

        private String _versionId;
        internal String VersionId
        {
            get
            {
                if (String.IsNullOrEmpty(_versionId))
                {
                    _versionId = "2.3.1";
                }
                return _versionId;
            }
            set
            {
                _versionId = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MSH()
        {
            SendingApplication = new HD();
            SendingFacility = new HD();

            ReceivingApplication = new HD();
            ReceivingFacility = new HD();
        }

        #endregion

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "SendingFacility", SendingFacility);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "SendingApplication", SendingApplication);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "ReceivingFacility", ReceivingFacility);
            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "ReceivingApplication", ReceivingApplication);
        }
        #endregion
    }
}
