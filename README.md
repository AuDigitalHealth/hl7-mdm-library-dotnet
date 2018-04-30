# HL7 MDM Library

This is a dotNet software library that aims to make the generation of HL7 Medical Document Messages (MDM)
easy and encapsulates validation logic to ensure that the HL7 MDM message is valid

This software library contains HL77 MDM objects (Eg. PV1, OBX, MSH etc); these objects are wrapped up 
within a HL7Model object. 


Setup
=====
- To build the distributable package, Visual Studio 2008 must be installed.
- Start up MedicalDocumentManagement.sln
- For documentation on the MDM library, refer to Help/Index.html.


Solution
========
The solution consists of several projects, however the main project is the MDM.Generator project. 
This project contains the code to generate and return an HL7 MDM message.

MDM:
The 'MDM.Sample' project contains sample code for the MDM library, and is designed as an introduction 
to the NEHTA HL7 MDM library
     
MDM.Sample: Sample code for the MDMlibrary.

Common: The 'Nehta.VendorLibrary.Common' project contains helper libraries common across all NEHTA 
vendor library components.


Building and using the library
==============================

The solution can be built using 'ctrl-shift-b'. The compiled assembly can then be referenced where ever 
a CDA document is required to be conStructured or referenced.


Library Usage
============

Detailed class documentation can be found in "Help/Index.html".

  
Licensing
=========
See [LICENSE](LICENSE.txt) file.
