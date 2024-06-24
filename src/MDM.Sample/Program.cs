using System;
using System.IO;
using System.Xml;
using MDM.Common.Enums;

namespace MDM.Sample
{
    class Program
    {
        /// <summary>
        /// Returns the directory that this programe is being exectured from.
        /// </summary>
       public static String CurrentDirectory
        {
            get
            {
                var currentPath = String.Empty;

                if (Directory.GetCurrentDirectory().LastIndexOf("MDM.Sample"+Path.DirectorySeparatorChar) != -1)
                {
                    currentPath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("MDM.Sample"+ Path.DirectorySeparatorChar) + 11);
                }

                if (String.IsNullOrEmpty(currentPath) && Directory.GetCurrentDirectory().LastIndexOf("MDM"+ Path.DirectorySeparatorChar) != -1)
                {
                    currentPath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("MDM"+ Path.DirectorySeparatorChar) + 4) + "MDM.Sample"+ Path.DirectorySeparatorChar;
                }

                return currentPath;
            }
        }

        static void Main(string[] args)
        {
            //Creates an MDM message
            var mdmSample = Sample.MDMSample();

            //Writes the MDM message to the path provided
            using (var outfile = new StreamWriter(CurrentDirectory + @"Output"+ Path.DirectorySeparatorChar + "hl7Message.hl7"))
            {
                outfile.Write(mdmSample);
            }

            //Loads the MDM message from the path provided
            using(var inputFile = new StreamReader(CurrentDirectory + @"Output" + Path.DirectorySeparatorChar + "hl7Message.hl7"))
            {
                var mdmMessage = inputFile.ReadToEnd();

                var xmlDocument = Sample.ExtractCDAdocumentFromMDM(mdmMessage);

                var hl7Model = Sample.UnwrapMDM(mdmMessage);

                //Extracts and saves the zip file payload
                Sample.ExtractAndSaveZipFileFromMDM(mdmMessage, CurrentDirectory + @"Output" + Path.DirectorySeparatorChar + "extractedFile.zip");

                //Extracts and saves the CDA document from within the payload of the MDM message
                //E.g. looks for the package.zip and extracts the CDA document from within this.
                Sample.ExtractCDAdocumentFromMDM(hl7Model);

                var hl7Ack = Sample.GenerateHl7AckMessage(mdmMessage, Guid.NewGuid().ToString(), AcknowledgmentCode.ApplicationAccept);

                string filename = CurrentDirectory + @"Output\hl7AckMessage.hl7";

                File.WriteAllText(filename, hl7Ack);


            }
        }
    }
}
