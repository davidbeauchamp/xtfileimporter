xtfileimporter
==============

File Importer for xTuple ERP
Copyright 2014-2015 David Beauchamp 
xtuple@davidbeauchamp.com

Uses the wonderful [Npgsql -- PostgreSQL provider for .NET](http://npgsql.projects.pgfoundry.org/)

Written for Windows in C#, using .NET 4.0. Tested fine under mono and Arch Linux. 

#Features#
-- Preview Matching allows you to see results before attempting import.  

-- Includes support for importing, attaching and extracting files from:
   * Items
   * CRM Accounts
   * Sales Order
   * Lot/Serial
   * Work Order
   * Purchase Order
   * Vendors
   * Contacts 
   * Invoice
   * Project
   * Quote
   * ~~BOM~~ Coming again soon
   * Incident

#Version 1.0.0.30 / 2014-Nov-17#
-- [Download link](https://github.com/davidbeauchamp/xtfileimporter/releases/tag/v1.0.0.30)

-- Includes support for matching the beginning of a filename instead of just the whole filename. 

-- Includes support for overriding the column matched against

#Version 1.0.0.31+ Roadmap#
-- Include headless mode

#Older Releases#

#Version 1.0.0.29 / 2014-Nov-17#
-- [Download link](https://github.com/davidbeauchamp/xtfileimporter/releases/tag/v1.0.0.29)
-- Runs import process and matching on background thread, displaying progress while doing so.

#Version 1.0.0.28 / 2014-Nov-15

-- First binary release. You can download the binaries [from here](https://github.com/davidbeauchamp/xtfileimporter/releases/tag/v1.0.0.28)

-- Bummed out the enum containing the document types, instead using index of first dimentsion from types array
   to build selectable types lists and to map back to the other columns in the array. 

#Version 1.0.0.27#

-- Replaced redundant code with multidimentional array and enum map

-- Includes support for importing, attaching and extracting files from:
   * Contacts 
   * Invoice
   * Project
   * Quote
   * BOM 
   * Incident

#Version 1.0.0.26#

-- Includes support for importing, attaching and extracting files from:
   * Items
   * CRM Accounts
   * Sales Order
   * Lot/Serial
   * Work Order
   * Purchase Order
   * Vendors

#Version 1.0.0.25 Initial Release#

-- Includes support for Importing and Attaching files to xTuple ERP Items. 
   Filename has to be the item number exactly. 
   
-- Includes support for Exporting files from xTuple ERP Items. 

Released to you under the Common Public Attribution License. This basically means you can do
what you want with it as long as you retain attribution in the source and leave it as an open
source project. Closed source derivatives available upon request. 
