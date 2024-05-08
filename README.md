# Introduction
For Provider to Provider [P2P] messaging, the current market of secure messaging vendors typically delivers HL7 v2 messages using defined fields within the message to identify the recipient.

Introduction of CDA documents complicates the situation in that the source system would generally create the document and ZIP it up using the CDA Packaging specification. This leaves secure messaging vendors with the task of trying to identify the recipient, having been handed a ZIP file to deliver.

A NEHTA FAQ, NEHTA-1270-2013 Clarification on Messaging and CDA Packaging, explains how to wrap up the ZIP file into an HL7 v2 MDM message, thus allowing the same approach as before, limiting the impact on secure messaging vendors.

# Content

The HL7 MDM Client Library simplifies the development process by providing vendors with a sample implementation of how to create and populate an HL7 v2 MDM message using the information within a CDA package as the input.

The library also works in reverse, allowing the CDA package to be extracted out of the message.

# Project
This is a dotNet software library that aims to make the generation of HL7 Medical Document Messages (MDM) easy and encapsulates validation logic to ensure that the HL7 MDM message is valid

This software library contains HL7 MDM objects (Eg. PV1, OBX, MSH etc); these objects are wrapped up within a HL7Model object. 

# Setup
- To build the distributable package, Visual Studio must be installed.
- Start up MedicalDocumentManagement.sln
- For documentation on the MDM library, refer to Help/Index.html.

# Solution
The solution consists of several projects, however the main project is the MDM.Generator project.  This project contains the code to generate and return an HL7 MDM message.

MDM:
The 'MDM.Sample' project contains sample code for the MDM library, and is designed as an introduction 
to the NEHTA HL7 MDM library
     
MDM.Sample: Sample code for the MDMlibrary.

Common: The 'Nehta.VendorLibrary.Common' project contains helper libraries common across all NEHTA 
vendor library components.

# Building and using the library
The solution can be built using 'F6'. 

# Library Usage
Detailed class documentation can be found in "Help/Index.html".

# Licensing
See [LICENSE](LICENSE.txt) file.