# Change Log/Revision History

1.4.0
=====
Removed DotNetZip library. No longer required as using System.IO.Compression.

1.3.0
=====
Added support for netstandard2.0

1.2.0 
-----
* make PV1.9 Consulting Doctor optional

1.1.0 
-----
* Add functionality to generate the ACK^T02 for the MDM^T02
* MSH.16 change to AL

1.0.8.2
-------
No version change 1.0.8 (.2)
Updated DotNetZip from 1.9.1.8 to 1.11.0 due to a security vulnerability (High severity). 

1.0.8 
-----
* Update with latest libraries

1.0.7
-----
* OBX.cs updated 'base64' to 'Base64' as per spec

1.0.6
-----
* Changed unzipping function to use ZipFile instead of ZipStream, to address an unzip bug with zip files created with Java zip library.

1.0.5
-----
* Fixed issue with extra newline character.

1.0.4
-----
* Alignment with CDA package 1.0 - Pathname not fixed to IHE_XDM.

1.0.3
-----
* Fixed bug with the wrong segments being read during hydration.

1.0.2
-----
* Fixed bug with separators.

1.0.1
-----
* Added functionality to extract the root CDA document from a valid MDM / zip package

1.0.0 
-----
* Refactored the library so the object names align to the HL7 objects.


