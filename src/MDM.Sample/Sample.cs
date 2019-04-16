using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using MDM.Common.Enums;
using MDM.Generator;
using MDM.Model.HL7Model;

namespace MDM.Sample
{
    /// <summary>
    /// This class contains the sample code for the MDM generator
    /// </summary>
    public class Sample
    {
        #region Properties
        private static String CurrentDirectory
        {
            get
            {
                var currentPath = String.Empty;

                if (Directory.GetCurrentDirectory().LastIndexOf("MDM.Sample" + Path.DirectorySeparatorChar, StringComparison.CurrentCulture) != -1)
                {
                    currentPath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("MDM.Sample" + Path.DirectorySeparatorChar, StringComparison.CurrentCulture) + 11);
                }

                if (String.IsNullOrEmpty(currentPath) && Directory.GetCurrentDirectory().LastIndexOf("MDM" + Path.DirectorySeparatorChar, StringComparison.CurrentCulture) != -1)
                {
                    currentPath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("MDM" + Path.DirectorySeparatorChar, StringComparison.CurrentCulture) + 4) + "MDM.Sample"+Path.DirectorySeparatorChar;
                }

                return currentPath;
            }
        }
        #endregion

        /// <summary>
        /// A sample HL7 MDM message generated via the MDMGenerator
        /// </summary>
        /// <returns></returns>
        public static String MDMSample()
        {
            //Populate the HL7 object model
            var hl7Model = PopulateModel();

            //Generate the HL7 message
            var generatedMessage = MDMGenerator.CreateHL7Message(hl7Model);

            return generatedMessage;
        }

        /// <summary>
        /// Unwraps and MDM message, and hydrates the supporting HL7 model
        /// </summary>
        /// <param name="message">MDM message to unwrap</param>
        /// <returns>HL7Model</returns>
        public static HL7Model UnwrapMDM(String message)
        {
            var hl7Model = MDMGenerator.UnwrapHL7Message(message);

            return hl7Model;
        }

        /// <summary>
        /// Extracts and returns the CDA document that is the payload of the packing contained with the message
        /// </summary>
        /// <param name="message">The MDM message containing the package, which in turn contains the CDA document</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument ExtractCDAdocumentFromMDM(String message)
        {
            var xmlDocument = MDMGenerator.ExtractRootXmlDocument(message);

            return xmlDocument;
        }

        /// <summary>
        /// Extracts and returns the CDA document that is the payload of the packing contained with the model.
        /// </summary>
        /// <param name="model">the model containing the package / CDA document</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument ExtractCDAdocumentFromMDM(HL7Model model)
        {
            var xmlDocument = MDMGenerator.ExtractRootXmlDocument(model);

            return xmlDocument;
        }

        /// <summary>
        /// Extracts the Zip file as a byte arrary from the MDM message
        /// </summary>
        /// <param name="message">MDM Message</param>
        /// <returns>Byte[]</returns>
        public static Byte[] ExtractZipFileFromMDM(String message)
        {
            return MDMGenerator.ExtractZipFile(message);
        }

        /// <summary>
        /// Extracts and save the zip file from within the MDM message
        /// </summary>
        /// <param name="message">MDM message</param>
        /// <param name="filePath">file path where the zip file is to be saved</param>
        public static void ExtractAndSaveZipFileFromMDM(String message, String filePath)
        {
            var zipFile = MDMGenerator.ExtractZipFile(message);

            File.WriteAllBytes(filePath, zipFile);
        }

        #region methods
        private static HL7Model PopulateModel()
        {
            //Create the message header (MSH)
            var messageHeader = new MSH
            {
                ReceivingApplication = new HD { NamespaceID = "GP Centre" },
                ReceivingFacility = new HD { NamespaceID = "800362000022222", UniversalID = "1.2.36.1.2001.1003.0.800362000022222", UniversalIDType = "ISO" },
                SendingApplication = new HD { NamespaceID = "Good Hospital" },
                SendingFacility = new HD { NamespaceID = "8003620833333783", UniversalID = "1.2.36.1.2001.1003.0.8003620833333783", UniversalIDType = "ISO" },
                MessageControlId = new UniqueId().ToString().Replace("urn:uuid:", "")
            };

            //Create the event EVN
            var evn = new EVN
            {
                MessageDateTime = DateTime.Now
            };

            //Create the patient information (PID)
            var patientInformation = new PID
            {
                AddressLines = new XAD
                {
                    StreetAddress = "1 Australia Lane",
                    City = "North Adelaide",
                    State = "SA",
                    PostCode = "5006"
                },
                BirthDateTime = Convert.ToDateTime("01 Jan 1977"),
                Gender = Gender.Female,
                PatientIdentifiers = new List<CX>
                                          {
                                                new CX {ID="8921319895", AssiginingAuthority = new HD {NamespaceID =  "AUSHIC"}, IdentifierTypeCode = "MC"}, 
                                                new CX {ID="8003605679672853", AssiginingAuthority = new HD { NamespaceID = "AUSHIC"}, IdentifierTypeCode = "NI"},
                                          },
                PatientName = new XPN
                {
                    FamilyName = "Atwood",
                    GivenName = "Abbi",
                    Prefix = "Mrs"
                }
            };


            //Create the patient visit information (PV1)
            var patientVisit = new PV1
            {
                ConsultingDoctor = new XCN
                {
                    ID = "0302523B",
                    FamilyName = "Button",
                    GivenName = "Henry",
                    MiddleName = "",
                    Prefix = "Dr",
                    AssigningAuthority = new HD
                    {
                        NamespaceID = "AUSHICPR"
                    },
                }
            };


            //Create the Transcription Document Header (TXA)
            var transcriptionDocumentHeader = new TXA
            {
                ActivityDateTime = DateTime.Now,
                UniqueDocumentNumber = "8a58f026-b51a-4946-be44-ac770407448f" //This unique ID should be taken from the root element withn the CDA document that is the payload for this message
            };


            //Create the Observation / Result (OBX)
            var observation = new OBX
            {
                Code = "18842-5",
                Description = "Discharge Summarization Note",
                Descriptor = "LN",
                FilePath = CurrentDirectory + @"Output"+Path.DirectorySeparatorChar+"package.zip"
                //ZipPackageAsBase64String = "This is the base64 string representing the package; and can be set manually if you dont have a file / file path"
            };


            //Populate the HL7Model object with the previously crated / populated objects
            var Hl7Model = new HL7Model
            {
                EVN = evn,
                MSH = messageHeader,
                PID = patientInformation,
                PV1 = patientVisit,
                TXA = transcriptionDocumentHeader,
                OBX = observation
            };

            return Hl7Model;
        }
        #endregion
    }
}
