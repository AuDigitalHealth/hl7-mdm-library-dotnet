using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MDM.Common.Enums;
using Nehta.VendorLibrary.Common;

namespace MDM.Model.HL7Model
{
    /// <summary>
    /// Observation / Result
    /// </summary>
    public class OBX
    {
        #region Properties
        /// <summary>
        /// code
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public String Description { get; set; }
        
        /// <summary>
        /// Descriptor associated with the code.
        /// </summary>
        public String Descriptor { get; set; }

        /// <summary>
        /// Observation value
        /// </summary>
        public String FilePath { get; set; }

        /// <summary>
        /// Zip package as Base64 string
        /// </summary>
        public String ZipPackageAsBase64String { get; set; }

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

        internal String EncapsulatedData
        {
            get
            {
                return "ED";
            }
        }

        internal String SourceApplication { get; set; }

        private String _typeOfData;
        internal String TypeOfData
        {
            get
            {
                if (String.IsNullOrEmpty(_typeOfData))
                {
                    _typeOfData = "application";
                }
                return _typeOfData;
            }
            set
            {
                _typeOfData = value;
            }
        }

        private String _dataSubtype;
        internal String DataSubtype
        {
            get
            {
                if (String.IsNullOrEmpty(_dataSubtype))
                {
                    _dataSubtype = "zip";
                }
                return _dataSubtype;
            }
            set
            {
                _dataSubtype = value;
            }
        }

        private String _encoding;
        internal String Encoding
        {
            get
            {
                if(String.IsNullOrEmpty(_encoding))
                {
                    _encoding = "Base64";
                }
                return _encoding;
            }

            set
            {
                _encoding = value;
            }
        }

        private ObservationResultStatus? _observationResult;
        internal ObservationResultStatus? ObservationResult
        {
            get
            {
                if (_observationResult == null)
                {
                    _observationResult = ObservationResultStatus.Final;
                }
                return _observationResult;
            }

            set
            {
                _observationResult = value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads the zip packge into the ZipPackageAsBase64String property if the path to a zip package
        /// is supplied within the FilePath property
        /// </summary>
        /// <returns>The zip package as a base64 string</returns>
        public String LoadZipPackage()
        {
            String fileAsBase64String = null;

            if(!String.IsNullOrEmpty(FilePath))
            {
                var fileBytes = File.ReadAllBytes(FilePath);

                fileAsBase64String = Convert.ToBase64String(fileBytes);

                ZipPackageAsBase64String = fileAsBase64String;
            }

            return fileAsBase64String;
        }

        /// <summary>
        /// Save the content of the ZipPackageAsBase64String property to the path specified if one is provide, otherwise
        /// it will use the FilePath property if set.
        /// </summary>
        public void SaveZipPackage(String filePath)
        {
            String fileAsBase64String = null;

            String path = null;

            if (!String.IsNullOrEmpty(filePath))
            {
                path = filePath;
            }
            else if (!String.IsNullOrEmpty(FilePath))
            {
                path = FilePath;
            }

            if (!String.IsNullOrEmpty(path))
            {
                File.WriteAllBytes(path, Convert.FromBase64String(ZipPackageAsBase64String));
            }
        }
        #endregion

        #region Internal Methods
        internal void Validate(String path, List<ValidationMessage> messages)
        {
            var validationBuilder = new ValidationBuilder(path, messages);

            validationBuilder.ArgumentRequiredCheck(validationBuilder.PathName + "Descriptor", Descriptor);

            var collection = new List<Object> {ZipPackageAsBase64String, FilePath};
            validationBuilder.RangeCheck("FilePath / ZipPackageAsBase64String", collection, 1, 2);
        }
        #endregion
    }
}
