using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using MDM.Common.Attributes;
using MDM.Common.Enums;
using MDM.Model.HL7Model;
using MDM.Common;
using Nehta.VendorLibrary.Common;
using Extensions=MDM.Common.Extension.Extensions;

namespace MDM.Generator
{
    /// <summary>
    /// This class encapsulates the generation of HL7 MDM messages
    /// </summary>
    public static class MDMGenerator
    {
        /// <summary>
        /// This method takes creates an HL7 MDM message
        /// </summary>
        /// <param name="model">The model containing the parameters required to create the message</param>
        /// <returns>An HL7 message as a string</returns>
        public static String CreateHL7Message(HL7Model model)
        {
            String hl7MessageString = null;

            var validationMessages = new List<ValidationMessage>();

            try
            {
                model.Validate("Model", validationMessages);

                var messageHeader = PopulateMessageHeader(model.MSH);
                var eventType = PopulateEventType(model.EVN);
                var patientId = PopulatePatientId(model.PID);
                var patientVisit = PopulatePatientVisit(model.PV1);
                var documentTranscriptionHeader = PopulateDocumentTranscriptionHeader(model.TXA);
                var observation = PopulateObservation(model.OBX);

                hl7MessageString = messageHeader
                    + eventType
                    + patientId
                    + patientVisit
                    + documentTranscriptionHeader
                    + observation;
            }
            catch (ValidationException valEx)
            {
                var messages = valEx.Messages;

                //handle the exception here
                throw;
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                //handle the exception here
                throw;
            }

            return hl7MessageString;
        }

        /// <summary>
        /// This method takes in an MDM message and hydrates the HL7 object model
        /// </summary>
        /// <param name="mdmMessage">mdmMessage</param>
        /// <returns>HL7Model</returns>
        public static HL7Model UnwrapHL7Message(String mdmMessage)
        {
            //Split the message up, extracting the MSH, OBX etc into an array
            var components = SplitHL7MessageIntoComponentParts(mdmMessage);

            return UnwrapHL7Message(components);
        }

        /// <summary>
        /// This method takes in a list of strings that make up an MDM message
        /// </summary>
        /// <param name="mdmMessageComponents">mdmMessageComponents</param>
        /// <returns>HL7Model</returns>
        public static HL7Model UnwrapHL7Message(List<String> mdmMessageComponents)
        {
            var hl7Model = new HL7Model();

            //Parse each of the components and hydrate the model

            //MSH
            var mshString = mdmMessageComponents.Where(componentString => componentString.StartsWith("MSH")).FirstOrDefault();

            hl7Model.MSH = HydrateMSH(mshString);

            //OBX
            var obxString = mdmMessageComponents.Where(componentString => componentString.StartsWith("OBX")).FirstOrDefault();
            hl7Model.OBX = HydrateOBX(obxString);

            //EVN
            var evnString = mdmMessageComponents.Where(componentString => componentString.StartsWith("EVN")).FirstOrDefault();
            hl7Model.EVN = HydrateEVN(evnString);

            //PID
            var pidString = mdmMessageComponents.Where(componentString => componentString.StartsWith("PID")).FirstOrDefault();
            hl7Model.PID = HydratePID(pidString);

            //PV1
            var pv1String = mdmMessageComponents.Where(componentString => componentString.StartsWith("PV1")).FirstOrDefault();
            hl7Model.PV1 = HydratePV1(pv1String);

            //TXA
            var txaString = mdmMessageComponents.Where(componentString => componentString.StartsWith("TXA")).FirstOrDefault();
            hl7Model.TXA = HydrateTXA(txaString);

            return hl7Model;
        }

        /// <summary>
        /// Extracts and returns the Root XML document from an MDM message
        /// </summary>
        /// <param name="mdmMessage">MDM Message</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument ExtractRootXmlDocument(String mdmMessage)
        {
            XmlDocument returnDocument = null;
            var hl7Model = UnwrapHL7Message(mdmMessage);

            if (!String.IsNullOrEmpty(hl7Model.OBX.ZipPackageAsBase64String))
            {
                returnDocument = HL7Helper.GetCDADocumentFromZip(Convert.FromBase64String(hl7Model.OBX.ZipPackageAsBase64String));
            }

            return returnDocument;
        }

        /// <summary>
        /// Extracts and returns the Root XML document from an MDM message that has been broken down
        /// into its component parts e.g. OBX, PID etc
        /// </summary>
        /// <param name="mdmMessageComponents">MDM Message as a list of component strings</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument ExtractRootXmlDocument(List<String> mdmMessageComponents)
        {
            XmlDocument returnDocument = null;
            var hl7Model = UnwrapHL7Message(mdmMessageComponents);

            if (!String.IsNullOrEmpty(hl7Model.OBX.ZipPackageAsBase64String))
            {
                returnDocument = HL7Helper.GetCDADocumentFromZip(Convert.FromBase64String(hl7Model.OBX.ZipPackageAsBase64String));
            }

            return returnDocument;
        }

        /// <summary>
        /// Extracts and returns the XmlDocument from within the model
        /// </summary>
        /// <param name="model">The HL7 model containing a CDA document</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument ExtractRootXmlDocument(HL7Model model)
        {
            XmlDocument returnDocument = null;

            if(
                model != null && 
                model.OBX != null && 
                !String.IsNullOrEmpty(model.OBX.ZipPackageAsBase64String)
               )
            {
                //Attempt to extract the base 64String as an XmlDocument
                returnDocument = HL7Helper.GetCDADocumentFromZip(Convert.FromBase64String(model.OBX.ZipPackageAsBase64String));
            }

            return returnDocument;
        }

        /// <summary>
        /// Extracts a zip file as a byte array from an MDM message
        /// </summary>
        /// <param name="mdmMessage">MDM Message</param>
        /// <returns>The zip file as a byte array</returns>
        public static byte[] ExtractZipFile(String mdmMessage)
        {
            byte[] returnArray = null;

            var hl7Model = UnwrapHL7Message(mdmMessage);

            if (!String.IsNullOrEmpty(hl7Model.OBX.ZipPackageAsBase64String))
            {
               returnArray  = Convert.FromBase64String(hl7Model.OBX.ZipPackageAsBase64String);
            }

            return returnArray;
        }

        /// <summary>
        /// Extracts a zip file as a byte array from an MDM message that has been broken down into 
        /// its component parts (e.g. PID, OBX etc)
        /// </summary>
        /// <param name="mdmMessageComponents">MDM Message as a list of component strings</param>
        /// <returns>The zip file as a byte array</returns>
        public static byte[] ExtractZipFile(List<String> mdmMessageComponents)
        {
            byte[] returnArray = null;
            
            var hl7Model = UnwrapHL7Message(mdmMessageComponents);

            if (!String.IsNullOrEmpty(hl7Model.OBX.ZipPackageAsBase64String))
            {
                returnArray = Convert.FromBase64String(hl7Model.OBX.ZipPackageAsBase64String);
            }

            return returnArray;
        }


        /// <summary>
        /// This method takes in a list of strings that make up an MDM message
        /// </summary>
        /// <param name="mdmMessageComponents">mdmMessageComponents</param>
        /// <returns>HL7Model</returns>
        public static String CreateHL7AckFromMdm(String mdmMessage, String newMessageControlId, AcknowledgmentCode acknowledgmentCode)
        {
            //Split the message up, extracting the MSH, OBX etc into an array
            var components = SplitHL7MessageIntoComponentParts(mdmMessage);

            // MDM^T02 Message
            HL7Model message = UnwrapHL7Message(components);

            // Make copies
            var mdmMessageControlId = message.MSH.MessageControlId;
            var mdmSendingApplication = message.MSH.SendingApplication;
            var mdmSendingFacility = message.MSH.SendingFacility;
            var mdmReceivingApplication = message.MSH.ReceivingApplication;
            var mdmReceivingFacility = message.MSH.ReceivingFacility;

            // Prepare message for ACK^T02
            // MSA
            var msa = new MSA();
            msa.MessageControlID = mdmMessageControlId;
            msa.SendingApplication = acknowledgmentCode;
            message.MSA = msa;

            // MSH - Swap 3,4 and 5,6 around, Create new messageId, update message type and datetime stamp
            message.MSH.SendingApplication = mdmReceivingApplication;
            message.MSH.SendingFacility = mdmReceivingFacility;
            message.MSH.ReceivingApplication = mdmSendingApplication;
            message.MSH.ReceivingFacility = mdmSendingFacility;
            message.MSH.MessageType = "ACK^T02^ACK_T02";
            message.MSH.MessageControlId = newMessageControlId;
            message.MSH.MessageDateTime = HL7Helper.MessageDateTime;
            
            return CreateHL7AckMessage(message);
        }

        /// <summary>
        /// This method takes creates an HL7 ACK^T02 message
        /// </summary>
        /// <param name="model">The model containing the parameters required to create the message</param>
        /// <returns>An HL7 message as a string</returns>
        public static String CreateHL7AckMessage(HL7Model model)
        {
            String hl7MessageString = null;

            var validationMessages = new List<ValidationMessage>();

            try
            {
                model.ValidateAck("Model", validationMessages);

                var messageHeader = PopulateMessageHeader(model.MSH);
                var ackType = PopulateMsaType(model.MSA);

                hl7MessageString = messageHeader + ackType;

            }
            catch (ValidationException valEx)
            {
                var messages = valEx.Messages;

                //handle the exception here
                throw;
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                //handle the exception here
                throw;
            }

            return hl7MessageString;
        }

        #region Private Methods
        private static String PopulateMessageHeader(MSH msh)
        {
            //MSH
            var messageHeader = "MSH";
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += HL7Helper.EncodingCharacters;

            //Sending application
            messageHeader += HL7Helper.FieldSeperator;
            if (msh.SendingApplication != null)
            {
                messageHeader += msh.SendingApplication.NamespaceID;
            }

            //Sending HPIO
            messageHeader += HL7Helper.FieldSeperator;
            if (msh.SendingFacility != null)
            {
                messageHeader += msh.SendingFacility.NamespaceID;
            }
            messageHeader += HL7Helper.ValueSeperator;
            if (msh.SendingFacility != null)
            {
                messageHeader += msh.SendingFacility.UniversalID;
                
            }
            messageHeader += HL7Helper.ValueSeperator;
            if (msh.SendingFacility != null)
            {
                messageHeader += msh.SendingFacility.UniversalIDType;
            }

            //Receiving application
            messageHeader += HL7Helper.FieldSeperator;
            if (msh.ReceivingApplication != null)
            {
                messageHeader += msh.ReceivingApplication.NamespaceID;
            }
            messageHeader += HL7Helper.FieldSeperator;

            //Receiving HPIO
            if (msh.ReceivingFacility != null)
            {
                messageHeader += msh.ReceivingFacility.NamespaceID;
            }
            messageHeader += HL7Helper.ValueSeperator;
            if (msh.ReceivingFacility != null)
            {
                messageHeader += msh.ReceivingFacility.UniversalID;
            }
            messageHeader += HL7Helper.ValueSeperator;
            if (msh.ReceivingFacility != null)
            {
                messageHeader += msh.ReceivingFacility.UniversalIDType;
            }
                                

            //Date / Time
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += msh.MessageDateTime;

            //Field seperator
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += msh.MessageSecurity;

            //Message Type
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += msh.MessageType;

            //Message control ID
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += msh.MessageControlId;

            //Processing ID
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += (msh.ProcessingID.HasValue ? Extensions.GetAttributeValue<NameAttribute, String>(msh.ProcessingID.Value, x => x.Code) : null);

            //Version ID
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += msh.VersionId;

            //Spacers
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += HL7Helper.FieldSeperator;

            //Accept acknowledgement type
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += (msh.AcceptAcknowledgementType.HasValue ? Extensions.GetAttributeValue<NameAttribute, String>(msh.AcceptAcknowledgementType.Value, x => x.Code) : null);

            //Application acknowledgement type
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += (msh.ApplicationAcknowledgementType.HasValue ? Extensions.GetAttributeValue<NameAttribute, String>(msh.ApplicationAcknowledgementType.Value, x => x.Code) : null); ;

            //County code
            messageHeader += HL7Helper.FieldSeperator;
            messageHeader += (msh.CountyCode.HasValue ? Extensions.GetAttributeValue<NameAttribute, String>(msh.CountyCode.Value, x => x.AlternateCode) : null);

            messageHeader += HL7Helper.NewLine;

            return messageHeader;
        }

        private static String PopulateMsaType(MSA msa)
        {
            //Msa type code
            var msaType = "MSA" + HL7Helper.FieldSeperator;
            msaType += msa.SendingApplication.GetAttributeValue<NameAttribute, String>(x => x.Code);
                       msaType += HL7Helper.FieldSeperator + msa.MessageControlID + HL7Helper.NewLine;

            return msaType;
        }

        private static String PopulateEventType(EVN evn)
        {
            //if the event type is null, create a new event and use the internal defaults
            if(evn == null)
            {
                evn = new EVN();
            }

            //EVN

            //Event type code
            var eventType = "EVN" + HL7Helper.FieldSeperator + evn.EventTypeCode;

            //Message Date/Time
            eventType += HL7Helper.FieldSeperator;
            eventType += (evn.MessageDateTime.HasValue ? evn.MessageDateTime.Value.ToString(HL7Helper.LongDateFormat) : null);

            eventType += HL7Helper.NewLine;

            return eventType;
        }

        private static String PopulatePatientId(PID pid)
        {
            //PID

            //Set ID
            var patientId = "PID" + HL7Helper.FieldSeperator;
            patientId += pid.SetID;

            //Spacers
            patientId += HL7Helper.FieldSeperator;

            //Patient Identifiers
            patientId += HL7Helper.FieldSeperator;
            if (pid.PatientIdentifiers != null)
            {
                pid.PatientIdentifiers.ForEach
                    (
                        identifier =>
                        {
                            if (identifier != null)
                            {
                                patientId += identifier.ID;
                                patientId += HL7Helper.ValueSeperator;
                                patientId += HL7Helper.ValueSeperator;
                                patientId += HL7Helper.ValueSeperator; 
                                if (identifier.AssiginingAuthority != null)
                                {
                                    patientId += identifier.AssiginingAuthority.NamespaceID;    
                                }
                                patientId += HL7Helper.ValueSeperator;
                                patientId += identifier.IdentifierTypeCode;
                                patientId += HL7Helper.ComponentRepeator;    
                            }
                        }
                    );
                patientId = patientId.TrimEnd(HL7Helper.ComponentRepeator);                
            }

            //Spacer
            patientId += HL7Helper.FieldSeperator;


            //Patient Name
            patientId += HL7Helper.FieldSeperator; 
            if (pid.PatientName != null)
            {
                patientId += pid.PatientName.FamilyName;

                patientId += HL7Helper.ValueSeperator;
                patientId += pid.PatientName.GivenName;
                
                patientId += HL7Helper.ValueSeperator;
                patientId += pid.PatientName.MiddleName;
                
                patientId += HL7Helper.ValueSeperator;
                patientId += pid.PatientName.Suffix;
                
                patientId += HL7Helper.ValueSeperator;
                patientId += pid.PatientName.Prefix;
            }

            //Spacers
            patientId += HL7Helper.FieldSeperator;

            //Date / Time of birth
            patientId += HL7Helper.FieldSeperator;

            patientId += (pid.BirthDateTime.HasValue ? pid.BirthDateTime.Value.ToString(HL7Helper.CultureInfo) : null);
            patientId = patientId.Trim();

            //Gender
            patientId += HL7Helper.FieldSeperator;
            patientId += (pid.Gender.HasValue ? Extensions.GetAttributeValue<NameAttribute, String>(pid.Gender.Value, x => x.Code) : null);

            //Spacers
            patientId += HL7Helper.FieldSeperator;
            patientId += HL7Helper.FieldSeperator;

            //Address
            patientId += HL7Helper.FieldSeperator;
            if (pid.AddressLines != null)
            {
                patientId += pid.AddressLines.StreetAddress;
                patientId += HL7Helper.ValueSeperator;
                patientId += pid.AddressLines.SecondStreetAddressLine;
                patientId += HL7Helper.ValueSeperator;
                patientId += pid.AddressLines.City;
                patientId += HL7Helper.ValueSeperator;
                patientId += pid.AddressLines.State;
                patientId += HL7Helper.ValueSeperator;
                patientId += pid.AddressLines.PostCode;
                patientId += HL7Helper.ValueSeperator;
                patientId += (pid.AddressLines.Country.HasValue ? Extensions.GetAttributeValue<NameAttribute, String>(pid.AddressLines.Country.Value, x => x.AlternateCode) : null);
            }
            
            patientId += HL7Helper.NewLine;

            return patientId;
        }

        private static String PopulatePatientVisit(PV1 pv1)
        {
            //PV1

            //SetID
            var patientVisit = "PV1" + HL7Helper.FieldSeperator;
            patientVisit += pv1.SetID;
            
            //Patient Class
            patientVisit += HL7Helper.FieldSeperator + (pv1.PatientClass.HasValue ? pv1.PatientClass.Value.GetAttributeValue<NameAttribute, String>(x => x.Code) : null);

            //Spacers
            patientVisit += HL7Helper.FieldSeperator;
            patientVisit += HL7Helper.FieldSeperator;
            patientVisit += HL7Helper.FieldSeperator;
            patientVisit += HL7Helper.FieldSeperator;
            patientVisit += HL7Helper.FieldSeperator;
            patientVisit += HL7Helper.FieldSeperator;
            patientVisit += HL7Helper.FieldSeperator;
            
            //Consulting Doctor
            if (pv1.ConsultingDoctor != null)
            {


                patientVisit += pv1.ConsultingDoctor.ID;

                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += pv1.ConsultingDoctor.FamilyName;

                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += pv1.ConsultingDoctor.GivenName;

                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += pv1.ConsultingDoctor.MiddleName;

                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += pv1.ConsultingDoctor.Suffix;

                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += pv1.ConsultingDoctor.Prefix;

                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += pv1.ConsultingDoctor.Degree;

                patientVisit += HL7Helper.ValueSeperator;
                //Source table

                patientVisit += HL7Helper.ValueSeperator;
                if (pv1.ConsultingDoctor.AssigningAuthority != null)
                {
                    patientVisit += pv1.ConsultingDoctor.AssigningAuthority.NamespaceID;
                }

                //Spacers
                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += HL7Helper.ValueSeperator;
                patientVisit += HL7Helper.ValueSeperator;

                patientVisit += pv1.ConsultingDoctor.IdentifierTypeCode;
            }

            patientVisit += HL7Helper.NewLine;

            return patientVisit;
        }

        private static String PopulateDocumentTranscriptionHeader(TXA txa)
        {
            //TXA

            //SetID
            var documentTranscriptionHeader = "TXA" + HL7Helper.FieldSeperator;
            documentTranscriptionHeader += txa.SetID;
            
            //Document Type
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += txa.DocumentType;

            //Document content presentation
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += (txa.DocumentContentPresentation.HasValue ? txa.DocumentContentPresentation.Value.GetAttributeValue<NameAttribute, String>(x => x.Code) : null);

            //Activity Date / Time
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += (txa.ActivityDateTime.HasValue ? txa.ActivityDateTime.Value.ToString(HL7Helper.LongDateFormat) : null);

            //Spacers
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;

            //Unique document number (GUID)
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += txa.UniqueDocumentNumber;

            //Spacers
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;

            //Unique document file name
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += txa.UniqueDocumentFileName;

            //Unique document file name
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += (txa.CompletionStatus.HasValue ? Extensions.GetAttributeValue<NameAttribute, String>(txa.CompletionStatus.Value, x => x.Code) : null);

            documentTranscriptionHeader += HL7Helper.NewLine;

            return documentTranscriptionHeader;
        }

        private static String PopulateObservation(OBX obx)
        {
            //OBX

            if(!String.IsNullOrEmpty(obx.FilePath) && String.IsNullOrEmpty(obx.ZipPackageAsBase64String))
            {
                obx.LoadZipPackage();
            }

            //SetID
            var documentTranscriptionHeader = "OBX" + HL7Helper.FieldSeperator + obx.SetID;

            //Encapsulat data
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += obx.EncapsulatedData;

            //LONIC code
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += obx.Code;
            
            //LONIC desciption
            documentTranscriptionHeader += HL7Helper.ValueSeperator;
            documentTranscriptionHeader += obx.Description;

            //LONIC desciptor
            documentTranscriptionHeader += HL7Helper.ValueSeperator;
            documentTranscriptionHeader += obx.Descriptor;

            //Seperator
            documentTranscriptionHeader += HL7Helper.FieldSeperator;

            //Source Application
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += obx.SourceApplication;
            
            //Type of data
            documentTranscriptionHeader += HL7Helper.ValueSeperator;
            documentTranscriptionHeader += obx.TypeOfData;

            //Data subtype
            documentTranscriptionHeader += HL7Helper.ValueSeperator;
            documentTranscriptionHeader += obx.DataSubtype;

            //Encoding
            documentTranscriptionHeader += HL7Helper.ValueSeperator;
            documentTranscriptionHeader += obx.Encoding;

            //Zip package as Base64 string
            documentTranscriptionHeader += HL7Helper.ValueSeperator;
            documentTranscriptionHeader += obx.ZipPackageAsBase64String;

            //Seperators
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += HL7Helper.FieldSeperator;

            //Observation result
            documentTranscriptionHeader += HL7Helper.FieldSeperator;
            documentTranscriptionHeader += (obx.ObservationResult.HasValue ? Extensions.GetAttributeValue<NameAttribute, String>(obx.ObservationResult.Value, x => x.Code) : null);

            documentTranscriptionHeader += HL7Helper.NewLine;

            return documentTranscriptionHeader;
        }

        private static List<String> SplitHL7MessageIntoComponentParts(String hl7Message)
        {
            var newLineCharacter = '\n';

            Char.TryParse(HL7Helper.NewLine, out newLineCharacter);

            return hl7Message.Split(newLineCharacter).ToList();
        }

        private static MSH HydrateMSH(String mshString)
        {
            var msh = new MSH();

            if (!String.IsNullOrEmpty(mshString))
            {
                var mshFields = mshString.Split(HL7Helper.FieldSeperator);

                if (mshFields.Length > 0)
                {
                    //Sending application
                    if (mshFields.Length >= 3)
                    {
                        msh.SendingApplication.NamespaceID = mshFields[2];
                    }

                    //Sending Facility
                    if (mshFields.Length >= 4)
                    {
                        var mshValues = mshFields[3].Split(HL7Helper.ValueSeperator);

                        if (mshValues.Length >= 1)
                        {
                            msh.SendingFacility.NamespaceID = mshValues[0];
                        }

                        if (mshValues.Length >= 2)
                        {
                            msh.SendingFacility.UniversalID = mshValues[1];
                        }

                        if (mshValues.Length >= 3)
                        {
                            msh.SendingFacility.UniversalIDType = mshValues[2];
                        }
                    }

                    //Receiving application
                    if (mshFields.Length >= 5)
                    {
                        msh.ReceivingApplication.NamespaceID = mshFields[4];
                    }

                    //Receiving Facility
                    if (mshFields.Length >= 6)
                    {
                        var mshValues = mshFields[5].Split(HL7Helper.ValueSeperator);

                        if (mshValues.Length >= 1)
                        {
                            msh.ReceivingFacility.NamespaceID = mshValues[0];
                        }

                        if (mshValues.Length >= 2)
                        {
                            msh.ReceivingFacility.UniversalID = mshValues[1];
                        }

                        if (mshValues.Length >= 3)
                        {
                            msh.ReceivingFacility.UniversalIDType = mshValues[2];
                        }
                    }

                    //Date / Time
                    if (mshFields.Length >= 7)
                    {
                        msh.MessageDateTime = mshFields[6];

                    }

                    //MessageSecurity
                    if (mshFields.Length >= 8)
                    {
                        msh.MessageSecurity = mshFields[7];

                    }

                    //MessageType
                    if (mshFields.Length >= 9)
                    {
                        msh.MessageType = mshFields[8];

                    }

                    //MessageControlId
                    if (mshFields.Length >= 10)
                    {
                        msh.MessageControlId = mshFields[9];
                    }

                    //ProcessingID
                    if (mshFields.Length >= 11)
                    {
                        msh.ProcessingID = Extensions.GetEnumByAttributeValue<NameAttribute, ProcessingId>(typeof(ProcessingId), x => { if (x != null) { return x.Code == mshFields[10]; } return false; });
                    }
                    
                    //Version ID
                    if (mshFields.Length >= 12)
                    {
                        msh.VersionId = mshFields[11];
                    }

                    //Accept acknowledgement type
                    if (mshFields.Length >= 15)
                    {
                        msh.AcceptAcknowledgementType = Extensions.GetEnumByAttributeValue<NameAttribute, AcceptAcknowledgement>(typeof(AcceptAcknowledgement), x => { if (x != null) { return x.Code == mshFields[14]; } return false; });
                    }

                    //Accept acknowledgement type
                    if (mshFields.Length >= 16)
                    {
                        msh.ApplicationAcknowledgementType = Extensions.GetEnumByAttributeValue<NameAttribute, AcceptAcknowledgement>(typeof(AcceptAcknowledgement), x => { if (x != null) { return x.Code == mshFields[15]; } return false; });
                    }

                    //Accept acknowledgement type
                    if (mshFields.Length >= 17)
                    {
                        msh.CountyCode = Extensions.GetEnumByAttributeValue<NameAttribute, Country>(typeof(Country), x => { if (x != null) { return x.Code == mshFields[16]; } return false; });
                    }
                }
            }

            return msh;
        }

        private static OBX HydrateOBX(String obxString)
        {
            var obx = new OBX();

            if (!String.IsNullOrEmpty(obxString))
            {
                var obxFields = obxString.Split(HL7Helper.FieldSeperator);

                if (obxFields.Length > 0)
                {
                    //Set ID
                    if (obxFields.Length >= 2)
                    {
                        obx.SetID = obxFields[1];
                    }

                    //Code
                    if (obxFields.Length >= 4)
                    {
                        var codeFields = obxFields[3].Split(HL7Helper.ValueSeperator);

                        if(codeFields.Length > 0)
                        {
                            //Code
                            if(codeFields.Length >= 1)
                            {
                                obx.Code = codeFields[0];
                            }

                            //Description
                            if (codeFields.Length >= 2)
                            {
                                obx.Description = codeFields[1];
                            }

                            //Descriptor
                            if (codeFields.Length >= 3)
                            {
                                obx.Descriptor = codeFields[2];
                            }
                        }
                        
                    }

                    //Package
                    if (obxFields.Length >= 5)
                    {
                        var obxValues = obxFields[5].Split(HL7Helper.ValueSeperator);
                        
                        //SourceApplication
                        if (obxValues.Length >= 1)
                        {
                            obx.SourceApplication = obxValues[0];
                        }


                        //TypeOfData
                        if (obxValues.Length >= 2)
                        {
                            obx.TypeOfData = obxValues[1];
                        }

                        //DataSubtype
                        if (obxValues.Length >= 3)
                        {
                            obx.DataSubtype = obxValues[2];
                        }

                        //Encoding
                        if (obxValues.Length >= 4)
                        {
                            obx.Encoding = obxValues[3];
                        }

                        //Base64
                        if (obxValues.Length >= 5)
                        {
                            obx.ZipPackageAsBase64String = obxValues[4];
                        }
                    }

                    if (obxFields.Length >= 12)
                    {
                        obx.ObservationResult = Extensions.GetEnumByAttributeValue<NameAttribute, ObservationResultStatus>(typeof(ObservationResultStatus), x => { if (x != null) { return x.Code == obxFields[11]; } return false; }); ;
                    }
                }
            }

            return obx;
        }

        private static EVN HydrateEVN(String evnString)
        {
            var evn = new EVN();

            if (!String.IsNullOrEmpty(evnString))
            {
                var evnFields = evnString.Split(HL7Helper.FieldSeperator);

                if (evnFields.Length > 0)
                {
                    //EventTypeCode
                    if (evnFields.Length >= 0)
                    {
                        evn.EventTypeCode = evnFields[1];
                    }

                    //Message Date Time
                    if (evnFields.Length >= 1)
                    {
                        DateTime parsedDateTime;
                        if (DateTime.TryParseExact(evnFields[2], HL7Helper.LongDateFormat, HL7Helper.CultureInfo, DateTimeStyles.None, out parsedDateTime))
                        {
                            evn.MessageDateTime = parsedDateTime;
                        }
                        else if (DateTime.TryParseExact(evnFields[2], HL7Helper.ShortDateFormat, HL7Helper.CultureInfo, DateTimeStyles.None, out parsedDateTime))
                        {
                            evn.MessageDateTime = parsedDateTime;
                        }
                    }
                }
            }

            return evn;
            
        }

        private static PID HydratePID(String pidString)
        {
            var pid = new PID();

            if (!String.IsNullOrEmpty(pidString))
            {
                var pidFields = pidString.Split(HL7Helper.FieldSeperator);

                if (pidFields.Length > 0)
                {
                    //EventTypeCode
                    if (pidFields.Length >= 4)
                    {
                        //Identifiers
                        pid.PatientIdentifiers = new List<CX>();

                        var identifiers = pidFields[3].Split(HL7Helper.ComponentRepeator).ToList();

                        //Extract each identifier and add it into the collection
                        identifiers.ForEach
                            (
                                identifier =>
                                    {
                                        var identifierValues = identifier.Split(HL7Helper.ValueSeperator);

                                        var patientIdentifer = new CX();

                                        //ID
                                        if (identifierValues.Length >= 1)
                                        {
                                            patientIdentifer.ID = identifierValues[0];
                                        }

                                        //Check Digit
                                        if (identifierValues.Length >= 2)
                                        {
                                            patientIdentifer.CheckDigit = identifierValues[1];
                                        }

                                        //CheckDigit Scheme Code
                                        if (identifierValues.Length >= 3)
                                        {
                                            patientIdentifer.CheckDigitSchemeCode = identifierValues[2];
                                        }

                                        //Assigining Authority
                                        //Assigining Authority - NamespaceID
                                        if (identifierValues.Length >= 4)
                                        {
                                            var assigningAuthorityValues =
                                                identifierValues[3].Split(HL7Helper.ComponentSeperator);

                                            patientIdentifer.AssiginingAuthority = new HD();

                                            if (assigningAuthorityValues.Length > 0)
                                            {
                                                if (assigningAuthorityValues.Length >= 1)
                                                {
                                                    patientIdentifer.AssiginingAuthority.NamespaceID =
                                                        assigningAuthorityValues[0];
                                                }
                                            }
                                        }

                                        //Identifier Type Code
                                        if (identifierValues.Length >= 5)
                                        {
                                            patientIdentifer.IdentifierTypeCode = identifierValues[4];
                                        }

                                        //AssigningFacility
                                        if (identifierValues.Length >= 6)
                                        {
                                            patientIdentifer.AssigningFacility = identifierValues[5];
                                        }

                                        //Finally add the identifier, then go through this loop again as necessary
                                        //for each identifier
                                        pid.PatientIdentifiers.Add(patientIdentifer);
                                    }
                             );
                        
                    }
                    //ValueSeperator

                    //Patient name
                    if(pidFields.Length >= 6)
                    {
                        var nameFields = pidFields[5].Split(HL7Helper.ValueSeperator);

                        //FamilyName
                        if (nameFields.Length >= 1)
                        {
                            pid.PatientName.FamilyName = nameFields[0];
                        }

                        //GivenName
                        if (nameFields.Length >= 2)
                        {
                            pid.PatientName.GivenName = nameFields[1];
                        }

                        //MiddleName
                        if (nameFields.Length >= 3)
                        {
                            pid.PatientName.MiddleName = nameFields[2];
                        }

                        //Suffix
                        if (nameFields.Length >= 4)
                        {
                            pid.PatientName.Suffix = nameFields[3];
                        }

                        //Prefix
                        if (nameFields.Length >= 5)
                        {
                            pid.PatientName.Prefix = nameFields[4];
                        }
                    }

                    //BirthDateTime
                    if (pidFields.Length >= 8)
                    {
                        DateTime parsedDateTime;

                        if (DateTime.TryParseExact(pidFields[7], HL7Helper.ShortDateFormat, HL7Helper.CultureInfo, DateTimeStyles.None, out parsedDateTime))
                        {
                            pid.BirthDateTime = parsedDateTime;
                        }
                        else if (DateTime.TryParseExact(pidFields[7], HL7Helper.LongDateFormat, HL7Helper.CultureInfo, DateTimeStyles.None, out parsedDateTime))
                        {
                            pid.BirthDateTime = parsedDateTime;
                        }
                    }

                    //Gender 
                    if (pidFields.Length >= 9)
                    {
                        pid.Gender = Extensions.GetEnumByAttributeValue<NameAttribute, Gender>(typeof(Gender), x => { if (x != null) { return x.Code == pidFields[8]; } return false; });
                    }

                    //Address Lines 
                    if (pidFields.Length >= 12)
                    {
                        var addressValues = pidFields[11].Split(HL7Helper.ValueSeperator);

                        if (addressValues.Length > 0)
                        {
                            pid.AddressLines = new XAD();

                            //StreetAddress
                            if (addressValues.Length >= 1)
                            {
                                pid.AddressLines.StreetAddress = addressValues[0];
                            }

                            //SecondStreetAddressLine
                            if (addressValues.Length >= 2)
                            {
                                pid.AddressLines.SecondStreetAddressLine = addressValues[1];
                            }

                            //City
                            if (addressValues.Length >= 3)
                            {
                                pid.AddressLines.City = addressValues[2];
                            }

                            //State
                            if (addressValues.Length >= 4)
                            {
                                pid.AddressLines.State = addressValues[3];
                            }

                            //PostCode
                            if (addressValues.Length >= 5)
                            {
                                pid.AddressLines.PostCode = addressValues[4];
                            }
                            
                            //Country
                            if (addressValues.Length >= 6)
                            {
                                pid.AddressLines.Country = Extensions.GetEnumByAttributeValue<NameAttribute, Country>(typeof(Country), x => { if (x != null) { return x.Name == addressValues[5]; } return false; });
                            }
                        }
                    }
                }
            }

            return pid;

        }

        private static PV1 HydratePV1(String pv1String)
        {
            var pv1 = new PV1();

            if (!String.IsNullOrEmpty(pv1String))
            {

                var patientVisitValues = pv1String.Split(HL7Helper.FieldSeperator);

                if(patientVisitValues.Length > 0)
                {
                    //Set ID
                    if(patientVisitValues.Length >= 2)
                    {
                        pv1.SetID = patientVisitValues[1];
                    }

                    //Patient Class
                    if (patientVisitValues.Length >= 3)
                    {
                        pv1.PatientClass = Extensions.GetEnumByAttributeValue<NameAttribute, PatientClass>(typeof(PatientClass), x => { if (x != null) { return x.Code == patientVisitValues[2]; } return false; }); ;
                    }

                    //Consulting Doctor
                    if (patientVisitValues.Length >= 10)
                    {
                        var consultingDoctorValues = patientVisitValues[9].Split(HL7Helper.ValueSeperator);
                        
                        if (!string.IsNullOrWhiteSpace(patientVisitValues[9]) && consultingDoctorValues.Length > 0)
                        {
                            //ID
                            if (consultingDoctorValues.Length >= 1)
                            {
                                pv1.ConsultingDoctor.ID = consultingDoctorValues[0];
                            }

                            //FamilyName
                            if (consultingDoctorValues.Length >= 2)
                            {
                                pv1.ConsultingDoctor.FamilyName = consultingDoctorValues[1];
                            }

                            //GivenName
                            if (consultingDoctorValues.Length >= 3)
                            {
                                pv1.ConsultingDoctor.GivenName = consultingDoctorValues[2];
                            }

                            //MiddleName
                            if (consultingDoctorValues.Length >= 4)
                            {
                                pv1.ConsultingDoctor.MiddleName = consultingDoctorValues[3];
                            }

                            //Prefix
                            if (consultingDoctorValues.Length >= 5)
                            {
                                pv1.ConsultingDoctor.Prefix = consultingDoctorValues[4];
                            }

                            //Suffix
                            if (consultingDoctorValues.Length >= 6)
                            {
                                pv1.ConsultingDoctor.Suffix = consultingDoctorValues[5];
                            }

                            //Degree
                            if (consultingDoctorValues.Length >= 7)
                            {
                                pv1.ConsultingDoctor.Degree = consultingDoctorValues[6];
                            }

                            //Source Table

                            //Assigning Authority
                            if (consultingDoctorValues.Length >= 9)
                            {
                                pv1.ConsultingDoctor.AssigningAuthority = 
                                    new HD
                                          {
                                              NamespaceID = consultingDoctorValues[8]
                                          };
                            }

                            // Identifier type
                            if (consultingDoctorValues.Length >= 13)
                            {
                                pv1.ConsultingDoctor.IdentifierTypeCode = consultingDoctorValues[12];
                            }
                        }
                        else
                        {
                            pv1.ConsultingDoctor = null;
                        }
                        
                    }
                }
            }

            return pv1;

        }

        private static TXA HydrateTXA(String txaString)
        {
            var txa = new TXA();

            if (!String.IsNullOrEmpty(txaString))
            {
                var txaFields = txaString.Split(HL7Helper.FieldSeperator);

                if(txaFields.Length > 0)
                {
                    //SetID
                    if(txaFields.Length >= 2)
                    {
                        txa.SetID = txaFields[1];
                    }

                    //DocumentType
                    if (txaFields.Length >= 3)
                    {
                        txa.DocumentType = txaFields[2];
                    }

                    //DocumentContentPresentation
                    if (txaFields.Length >= 4)
                    {
                        txa.DocumentContentPresentation = Extensions.GetEnumByAttributeValue<NameAttribute, DocumentContentPresentation>(typeof(DocumentContentPresentation), x => { if (x != null) { return x.Code == txaFields[3]; } return false; }); ;
                    }

                    //ActivityDateTime
                    if (txaFields.Length >= 5)
                    {
                        DateTime parsedDateTime;

                        if(DateTime.TryParseExact(txaFields[4], HL7Helper.LongDateFormat, HL7Helper.CultureInfo, DateTimeStyles.None, out parsedDateTime))
                        {
                            txa.ActivityDateTime = parsedDateTime;
                        }
                        else if (DateTime.TryParseExact(txaFields[4], HL7Helper.ShortDateFormat, HL7Helper.CultureInfo, DateTimeStyles.None, out parsedDateTime))
                        {
                            txa.ActivityDateTime = parsedDateTime;
                        }
                    }

                    //UniqueDocumentNumber
                    if (txaFields.Length >= 13)
                    {
                        txa.UniqueDocumentNumber = txaFields[12];
                    }

                    //UniqueDocumentFileName
                    if (txaFields.Length >= 17)
                    {
                        txa.UniqueDocumentFileName = txaFields[16];
                    }

                    //CompletionStatus
                    if (txaFields.Length >= 18)
                    {
                        txa.CompletionStatus = Extensions.GetEnumByAttributeValue<NameAttribute, DocumentCompletionStatus>(typeof(DocumentCompletionStatus), x => { if (x != null) { return x.Code == txaFields[17]; } return false; });
                    }
                }
            }

            return txa;
        }
        #endregion

    }
}
