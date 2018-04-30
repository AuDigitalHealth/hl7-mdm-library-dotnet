using System;
using System.Runtime.Serialization;
using MDM.Common.Attributes;

namespace MDM.Common.Enums
{
    /// <summary>
    /// This enum contains the valid country entries
    /// </summary>
    [Serializable]
    [DataContract]
    public enum Country
    {
        /// <summary>
        /// Undefined, this is the default value if the enum is left unset.
        /// 
        /// The validation engine uses this to test and assert that the enum has been set (if required)
        /// and is therefore valid.
        /// </summary>
        [EnumMember]
        Undefined,


        /// <summary>
        /// Australia
        /// </summary>
        [EnumMember]
        [Name(Code = "1101", Name = "Australia", AlternateCode="AUS")]
        Australia,


        /// <summary>
        /// NorfolkIsland
        /// </summary>
        [EnumMember]
        [Name(Code = "1102", Name = "Norfolk Island")]
        NorfolkIsland,


        /// <summary>
        /// AustralianExternalTerritoriesNec
        /// </summary>
        [EnumMember]
        [Name(Code = "1199", Name = "Australian External Territories, Nec")]
        AustralianExternalTerritoriesNec,


        /// <summary>
        /// NewZealand
        /// </summary>
        [EnumMember]
        [Name(Code = "1201", Name = "New Zealand", AlternateCode="NZ")]
        NewZealand,


        /// <summary>
        /// NewCaledonia
        /// </summary>
        [EnumMember]
        [Name(Code = "1301", Name = "New Caledonia")]
        NewCaledonia,


        /// <summary>
        /// PapuaNewGuinea
        /// </summary>
        [EnumMember]
        [Name(Code = "1302", Name = "Papua New Guinea")]
        PapuaNewGuinea,


        /// <summary>
        /// SolomonIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "1303", Name = "Solomon Islands")]
        SolomonIslands,


        /// <summary>
        /// Vanuatu
        /// </summary>
        [EnumMember]
        [Name(Code = "1304", Name = "Vanuatu")]
        Vanuatu,


        /// <summary>
        /// Guam
        /// </summary>
        [EnumMember]
        [Name(Code = "1401", Name = "Guam")]
        Guam,


        /// <summary>
        /// Kiribati
        /// </summary>
        [EnumMember]
        [Name(Code = "1402", Name = "Kiribati")]
        Kiribati,


        /// <summary>
        /// MarshallIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "1403", Name = "Marshall Islands")]
        MarshallIslands,


        /// <summary>
        /// MicronesiaFederatedStatesOf
        /// </summary>
        [EnumMember]
        [Name(Code = "1404", Name = "Micronesia, Federated States Of")]
        MicronesiaFederatedStatesOf,


        /// <summary>
        /// Nauru
        /// </summary>
        [EnumMember]
        [Name(Code = "1405", Name = "Nauru")]
        Nauru,


        /// <summary>
        /// NorthernMarianaIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "1406", Name = "Northern Mariana Islands")]
        NorthernMarianaIslands,


        /// <summary>
        /// Palau
        /// </summary>
        [EnumMember]
        [Name(Code = "1407", Name = "Palau")]
        Palau,


        /// <summary>
        /// CookIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "1501", Name = "Cook Islands")]
        CookIslands,


        /// <summary>
        /// Fiji
        /// </summary>
        [EnumMember]
        [Name(Code = "1502", Name = "Fiji")]
        Fiji,


        /// <summary>
        /// FrenchPolynesia
        /// </summary>
        [EnumMember]
        [Name(Code = "1503", Name = "French Polynesia")]
        FrenchPolynesia,


        /// <summary>
        /// Niue
        /// </summary>
        [EnumMember]
        [Name(Code = "1504", Name = "Niue")]
        Niue,


        /// <summary>
        /// Samoa
        /// </summary>
        [EnumMember]
        [Name(Code = "1505", Name = "Samoa")]
        Samoa,


        /// <summary>
        /// SamoaAmerican
        /// </summary>
        [EnumMember]
        [Name(Code = "1506", Name = "Samoa, American")]
        SamoaAmerican,


        /// <summary>
        /// Tokelau
        /// </summary>
        [EnumMember]
        [Name(Code = "1507", Name = "Tokelau")]
        Tokelau,


        /// <summary>
        /// Tonga
        /// </summary>
        [EnumMember]
        [Name(Code = "1508", Name = "Tonga")]
        Tonga,


        /// <summary>
        /// Tuvalu
        /// </summary>
        [EnumMember]
        [Name(Code = "1511", Name = "Tuvalu")]
        Tuvalu,


        /// <summary>
        /// WallisAndFutuna
        /// </summary>
        [EnumMember]
        [Name(Code = "1512", Name = "Wallis And Futuna")]
        WallisAndFutuna,


        /// <summary>
        /// PitcairnIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "1513", Name = "Pitcairn Islands")]
        PitcairnIslands,


        /// <summary>
        /// PolynesiaExcludesHawaiiNec
        /// </summary>
        [EnumMember]
        [Name(Code = "1599", Name = "Polynesia (Excludes Hawaii), Nec")]
        PolynesiaExcludesHawaiiNec,


        /// <summary>
        /// AdelieLandFrance
        /// </summary>
        [EnumMember]
        [Name(Code = "1601", Name = "Adélie Land (France)")]
        AdelieLandFrance,


        /// <summary>
        /// ArgentinianAntarcticTerritory
        /// </summary>
        [EnumMember]
        [Name(Code = "1602", Name = "Argentinian Antarctic Territory")]
        ArgentinianAntarcticTerritory,


        /// <summary>
        /// AustralianAntarcticTerritory
        /// </summary>
        [EnumMember]
        [Name(Code = "1603", Name = "Australian Antarctic Territory")]
        AustralianAntarcticTerritory,


        /// <summary>
        /// BritishAntarcticTerritory
        /// </summary>
        [EnumMember]
        [Name(Code = "1604", Name = "British Antarctic Territory")]
        BritishAntarcticTerritory,


        /// <summary>
        /// ChileanAntarcticTerritory
        /// </summary>
        [EnumMember]
        [Name(Code = "1605", Name = "Chilean Antarctic Territory")]
        ChileanAntarcticTerritory,


        /// <summary>
        /// QueenMaudLandNorway
        /// </summary>
        [EnumMember]
        [Name(Code = "1606", Name = "Queen Maud Land (Norway)")]
        QueenMaudLandNorway,


        /// <summary>
        /// RossDependencyNewZealand
        /// </summary>
        [EnumMember]
        [Name(Code = "1607", Name = "Ross Dependency (New Zealand)")]
        RossDependencyNewZealand,


        /// <summary>
        /// England
        /// </summary>
        [EnumMember]
        [Name(Code = "2102", Name = "England")]
        England,


        /// <summary>
        /// IsleOfMan
        /// </summary>
        [EnumMember]
        [Name(Code = "2103", Name = "Isle Of Man")]
        IsleOfMan,


        /// <summary>
        /// NorthernIreland
        /// </summary>
        [EnumMember]
        [Name(Code = "2104", Name = "Northern Ireland")]
        NorthernIreland,


        /// <summary>
        /// Scotland
        /// </summary>
        [EnumMember]
        [Name(Code = "2105", Name = "Scotland")]
        Scotland,


        /// <summary>
        /// Wales
        /// </summary>
        [EnumMember]
        [Name(Code = "2106", Name = "Wales")]
        Wales,


        /// <summary>
        /// Guernsey
        /// </summary>
        [EnumMember]
        [Name(Code = "2107", Name = "Guernsey")]
        Guernsey,


        /// <summary>
        /// Jersey
        /// </summary>
        [EnumMember]
        [Name(Code = "2108", Name = "Jersey")]
        Jersey,


        /// <summary>
        /// Ireland
        /// </summary>
        [EnumMember]
        [Name(Code = "2201", Name = "Ireland")]
        Ireland,


        /// <summary>
        /// Austria
        /// </summary>
        [EnumMember]
        [Name(Code = "2301", Name = "Austria")]
        Austria,


        /// <summary>
        /// Belgium
        /// </summary>
        [EnumMember]
        [Name(Code = "2302", Name = "Belgium")]
        Belgium,


        /// <summary>
        /// France
        /// </summary>
        [EnumMember]
        [Name(Code = "2303", Name = "France")]
        France,


        /// <summary>
        /// Germany
        /// </summary>
        [EnumMember]
        [Name(Code = "2304", Name = "Germany")]
        Germany,


        /// <summary>
        /// Liechtenstein
        /// </summary>
        [EnumMember]
        [Name(Code = "2305", Name = "Liechtenstein")]
        Liechtenstein,


        /// <summary>
        /// Luxembourg
        /// </summary>
        [EnumMember]
        [Name(Code = "2306", Name = "Luxembourg")]
        Luxembourg,


        /// <summary>
        /// Monaco
        /// </summary>
        [EnumMember]
        [Name(Code = "2307", Name = "Monaco")]
        Monaco,


        /// <summary>
        /// Netherlands
        /// </summary>
        [EnumMember]
        [Name(Code = "2308", Name = "Netherlands")]
        Netherlands,


        /// <summary>
        /// Switzerland
        /// </summary>
        [EnumMember]
        [Name(Code = "2311", Name = "Switzerland")]
        Switzerland,


        /// <summary>
        /// NorthernEurope
        /// </summary>
        [EnumMember]
        [Name(Code = "24", Name = "Northern Europe")]
        NorthernEurope,


        /// <summary>
        /// Denmark
        /// </summary>
        [EnumMember]
        [Name(Code = "2401", Name = "Denmark")]
        Denmark,


        /// <summary>
        /// FaroeIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "2402", Name = "Faroe Islands")]
        FaroeIslands,


        /// <summary>
        /// Finland
        /// </summary>
        [EnumMember]
        [Name(Code = "2403", Name = "Finland")]
        Finland,


        /// <summary>
        /// Greenland
        /// </summary>
        [EnumMember]
        [Name(Code = "2404", Name = "Greenland")]
        Greenland,


        /// <summary>
        /// Iceland
        /// </summary>
        [EnumMember]
        [Name(Code = "2405", Name = "Iceland")]
        Iceland,


        /// <summary>
        /// Norway
        /// </summary>
        [EnumMember]
        [Name(Code = "2406", Name = "Norway")]
        Norway,


        /// <summary>
        /// Sweden
        /// </summary>
        [EnumMember]
        [Name(Code = "2407", Name = "Sweden")]
        Sweden,


        /// <summary>
        /// AlandIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "2408", Name = "Aland Islands")]
        AlandIslands,


        /// <summary>
        /// Andorra
        /// </summary>
        [EnumMember]
        [Name(Code = "3101", Name = "Andorra")]
        Andorra,


        /// <summary>
        /// Gibraltar
        /// </summary>
        [EnumMember]
        [Name(Code = "3102", Name = "Gibraltar")]
        Gibraltar,


        /// <summary>
        /// HolySee
        /// </summary>
        [EnumMember]
        [Name(Code = "3103", Name = "Holy See")]
        HolySee,


        /// <summary>
        /// Italy
        /// </summary>
        [EnumMember]
        [Name(Code = "3104", Name = "Italy")]
        Italy,


        /// <summary>
        /// Malta
        /// </summary>
        [EnumMember]
        [Name(Code = "3105", Name = "Malta")]
        Malta,


        /// <summary>
        /// Portugal
        /// </summary>
        [EnumMember]
        [Name(Code = "3106", Name = "Portugal")]
        Portugal,


        /// <summary>
        /// SanMarino
        /// </summary>
        [EnumMember]
        [Name(Code = "3107", Name = "San Marino")]
        SanMarino,


        /// <summary>
        /// Spain
        /// </summary>
        [EnumMember]
        [Name(Code = "3108", Name = "Spain")]
        Spain,


        /// <summary>
        /// SouthEasternEurope
        /// </summary>
        [EnumMember]
        [Name(Code = "32", Name = "South Eastern Europe")]
        SouthEasternEurope,


        /// <summary>
        /// Albania
        /// </summary>
        [EnumMember]
        [Name(Code = "3201", Name = "Albania")]
        Albania,


        /// <summary>
        /// BosniaAndHerzegovina
        /// </summary>
        [EnumMember]
        [Name(Code = "3202", Name = "Bosnia And Herzegovina")]
        BosniaAndHerzegovina,


        /// <summary>
        /// Bulgaria
        /// </summary>
        [EnumMember]
        [Name(Code = "3203", Name = "Bulgaria")]
        Bulgaria,


        /// <summary>
        /// Croatia
        /// </summary>
        [EnumMember]
        [Name(Code = "3204", Name = "Croatia")]
        Croatia,


        /// <summary>
        /// Cyprus
        /// </summary>
        [EnumMember]
        [Name(Code = "3205", Name = "Cyprus")]
        Cyprus,

        /// <summary>
        /// ,
        /// </summary>
        [EnumMember]
        [Name(Code = "3206", Name = "Former Yugoslav Republic Of  FormerYugoslavRepublicOfMacedoniaFyrom")]
        Macedonia,


        /// <summary>
        /// Greece
        /// </summary>
        [EnumMember]
        [Name(Code = "3207", Name = "Greece")]
        Greece,


        /// <summary>
        /// Moldova
        /// </summary>
        [EnumMember]
        [Name(Code = "3208", Name = "Moldova")]
        Moldova,


        /// <summary>
        /// Romania
        /// </summary>
        [EnumMember]
        [Name(Code = "3211", Name = "Romania")]
        Romania,


        /// <summary>
        /// Slovenia
        /// </summary>
        [EnumMember]
        [Name(Code = "3212", Name = "Slovenia")]
        Slovenia,


        /// <summary>
        /// Montenegro
        /// </summary>
        [EnumMember]
        [Name(Code = "3214", Name = "Montenegro")]
        Montenegro,


        /// <summary>
        /// Serbia
        /// </summary>
        [EnumMember]
        [Name(Code = "3215", Name = "Serbia")]
        Serbia,


        /// <summary>
        /// Kosovo
        /// </summary>
        [EnumMember]
        [Name(Code = "3216", Name = "Kosovo")]
        Kosovo,


        /// <summary>
        /// Belarus
        /// </summary>
        [EnumMember]
        [Name(Code = "3301", Name = "Belarus")]
        Belarus,


        /// <summary>
        /// CzechRepublic
        /// </summary>
        [EnumMember]
        [Name(Code = "3302", Name = "Czech Republic")]
        CzechRepublic,


        /// <summary>
        /// Estonia
        /// </summary>
        [EnumMember]
        [Name(Code = "3303", Name = "Estonia")]
        Estonia,


        /// <summary>
        /// Hungary
        /// </summary>
        [EnumMember]
        [Name(Code = "3304", Name = "Hungary")]
        Hungary,


        /// <summary>
        /// Latvia
        /// </summary>
        [EnumMember]
        [Name(Code = "3305", Name = "Latvia")]
        Latvia,


        /// <summary>
        /// Lithuania
        /// </summary>
        [EnumMember]
        [Name(Code = "3306", Name = "Lithuania")]
        Lithuania,


        /// <summary>
        /// Poland
        /// </summary>
        [EnumMember]
        [Name(Code = "3307", Name = "Poland")]
        Poland,


        /// <summary>
        /// RussianFederation
        /// </summary>
        [EnumMember]
        [Name(Code = "3308", Name = "Russian Federation")]
        RussianFederation,


        /// <summary>
        /// Slovakia
        /// </summary>
        [EnumMember]
        [Name(Code = "3311", Name = "Slovakia")]
        Slovakia,


        /// <summary>
        /// Ukraine
        /// </summary>
        [EnumMember]
        [Name(Code = "3312", Name = "Ukraine")]
        Ukraine,


        /// <summary>
        /// NorthAfrica
        /// </summary>
        [EnumMember]
        [Name(Code = "41", Name = "North Africa")]
        NorthAfrica,


        /// <summary>
        /// Algeria
        /// </summary>
        [EnumMember]
        [Name(Code = "4101", Name = "Algeria")]
        Algeria,


        /// <summary>
        /// Egypt
        /// </summary>
        [EnumMember]
        [Name(Code = "4102", Name = "Egypt")]
        Egypt,


        /// <summary>
        /// Libya
        /// </summary>
        [EnumMember]
        [Name(Code = "4103", Name = "Libya")]
        Libya,


        /// <summary>
        /// Morocco
        /// </summary>
        [EnumMember]
        [Name(Code = "4104", Name = "Morocco")]
        Morocco,


        /// <summary>
        /// Sudan
        /// </summary>
        [EnumMember]
        [Name(Code = "4105", Name = "Sudan")]
        Sudan,


        /// <summary>
        /// Tunisia
        /// </summary>
        [EnumMember]
        [Name(Code = "4106", Name = "Tunisia")]
        Tunisia,


        /// <summary>
        /// WesternSahara
        /// </summary>
        [EnumMember]
        [Name(Code = "4107", Name = "Western Sahara")]
        WesternSahara,


        /// <summary>
        /// SpanishNorthAfrica
        /// </summary>
        [EnumMember]
        [Name(Code = "4108", Name = "Spanish North Africa")]
        SpanishNorthAfrica,


        /// <summary>
        /// Bahrain
        /// </summary>
        [EnumMember]
        [Name(Code = "4201", Name = "Bahrain")]
        Bahrain,


        /// <summary>
        /// GazaStripAndWestBank
        /// </summary>
        [EnumMember]
        [Name(Code = "4202", Name = "Gaza Strip And West Bank")]
        GazaStripAndWestBank,


        /// <summary>
        /// Iran
        /// </summary>
        [EnumMember]
        [Name(Code = "4203", Name = "Iran")]
        Iran,


        /// <summary>
        /// Iraq
        /// </summary>
        [EnumMember]
        [Name(Code = "4204", Name = "Iraq")]
        Iraq,


        /// <summary>
        /// Israel
        /// </summary>
        [EnumMember]
        [Name(Code = "4205", Name = "Israel")]
        Israel,


        /// <summary>
        /// Jordan
        /// </summary>
        [EnumMember]
        [Name(Code = "4206", Name = "Jordan")]
        Jordan,


        /// <summary>
        /// Kuwait
        /// </summary>
        [EnumMember]
        [Name(Code = "4207", Name = "Kuwait")]
        Kuwait,


        /// <summary>
        /// Lebanon
        /// </summary>
        [EnumMember]
        [Name(Code = "4208", Name = "Lebanon")]
        Lebanon,


        /// <summary>
        /// Oman
        /// </summary>
        [EnumMember]
        [Name(Code = "4211", Name = "Oman")]
        Oman,


        /// <summary>
        /// Qatar
        /// </summary>
        [EnumMember]
        [Name(Code = "4212", Name = "Qatar")]
        Qatar,


        /// <summary>
        /// SaudiArabia
        /// </summary>
        [EnumMember]
        [Name(Code = "4213", Name = "Saudi Arabia")]
        SaudiArabia,


        /// <summary>
        /// Syria
        /// </summary>
        [EnumMember]
        [Name(Code = "4214", Name = "Syria")]
        Syria,


        /// <summary>
        /// Turkey
        /// </summary>
        [EnumMember]
        [Name(Code = "4215", Name = "Turkey")]
        Turkey,


        /// <summary>
        /// UnitedArabEmirates
        /// </summary>
        [EnumMember]
        [Name(Code = "4216", Name = "United Arab Emirates")]
        UnitedArabEmirates,


        /// <summary>
        /// Yemen
        /// </summary>
        [EnumMember]
        [Name(Code = "4217", Name = "Yemen")]
        Yemen,


        /// <summary>
        /// BurmaMyanmar
        /// </summary>
        [EnumMember]
        [Name(Code = "5101", Name = "Burma (Myanmar)")]
        BurmaMyanmar,


        /// <summary>
        /// Cambodia
        /// </summary>
        [EnumMember]
        [Name(Code = "5102", Name = "Cambodia")]
        Cambodia,


        /// <summary>
        /// Laos
        /// </summary>
        [EnumMember]
        [Name(Code = "5103", Name = "Laos")]
        Laos,


        /// <summary>
        /// Thailand
        /// </summary>
        [EnumMember]
        [Name(Code = "5104", Name = "Thailand")]
        Thailand,


        /// <summary>
        /// Vietnam
        /// </summary>
        [EnumMember]
        [Name(Code = "5105", Name = "Vietnam")]
        Vietnam,


        /// <summary>
        /// BruneiDarussalam
        /// </summary>
        [EnumMember]
        [Name(Code = "5201", Name = "Brunei Darussalam")]
        BruneiDarussalam,


        /// <summary>
        /// Indonesia
        /// </summary>
        [EnumMember]
        [Name(Code = "5202", Name = "Indonesia")]
        Indonesia,


        /// <summary>
        /// Malaysia
        /// </summary>
        [EnumMember]
        [Name(Code = "5203", Name = "Malaysia")]
        Malaysia,


        /// <summary>
        /// Philippines
        /// </summary>
        [EnumMember]
        [Name(Code = "5204", Name = "Philippines")]
        Philippines,


        /// <summary>
        /// Singapore
        /// </summary>
        [EnumMember]
        [Name(Code = "5205", Name = "Singapore")]
        Singapore,


        /// <summary>
        /// EastTimor
        /// </summary>
        [EnumMember]
        [Name(Code = "5206", Name = "East Timor")]
        EastTimor,


        /// <summary>
        /// ChineseAsiaIncludesMongolia
        /// </summary>
        [EnumMember]
        [Name(Code = "61", Name = "Chinese Asia (Includes Mongolia)")]
        ChineseAsiaIncludesMongolia,


        /// <summary>
        /// ChinaExcludesSarsAndTaiwan
        /// </summary>
        [EnumMember]
        [Name(Code = "6101", Name = "China (Excludes Sars And Taiwan) ")]
        ChinaExcludesSarsAndTaiwan,


        /// <summary>
        /// HongKongSarOfChina
        /// </summary>
        [EnumMember]
        [Name(Code = "6102", Name = "Hong Kong (Sar Of China)")]
        HongKongSarOfChina,


        /// <summary>
        /// MacauSarOfChina
        /// </summary>
        [EnumMember]
        [Name(Code = "6103", Name = "Macau (Sar Of China)")]
        MacauSarOfChina,


        /// <summary>
        /// Mongolia")
        /// </summary>

        [EnumMember]
        [Name(Code = "6104", Name = "Mongolia")]
        Mongolia,

        /// <summary>
        /// Taiwan ")
        /// </summary>

        [EnumMember]
        [Name(Code = "6105", Name = "Taiwan ")]
        Taiwan,

        /// <summary>
        /// Japan")
        /// </summary>

        [EnumMember]
        [Name(Code = "6201", Name = "Japan")]
        Japan,

        /// <summary>
        /// Northkorea
        /// </summary>        [
        [EnumMember]
        [Name(Code = "6202", Name = "Korea, Democratic People'S Republic Of KoreaDemocraticPeoplesRepublicOfNorth Korea")]
        Northkorea,


        /// <summary>
        /// KoreaRepublicOfSouth
        /// </summary>
        [EnumMember]
        [Name(Code = "6203", Name = "Korea, Republic Of (South)")]
        KoreaRepublicOfSouth,


        /// <summary>
        /// Bangladesh
        /// </summary>
        [EnumMember]
        [Name(Code = "7101", Name = "Bangladesh")]
        Bangladesh,


        /// <summary>
        /// Bhutan
        /// </summary>
        [EnumMember]
        [Name(Code = "7102", Name = "Bhutan")]
        Bhutan,


        /// <summary>
        /// India
        /// </summary>
        [EnumMember]
        [Name(Code = "7103", Name = "India")]
        India,


        /// <summary>
        /// Maldives
        /// </summary>
        [EnumMember]
        [Name(Code = "7104", Name = "Maldives")]
        Maldives,


        /// <summary>
        /// Nepal
        /// </summary>
        [EnumMember]
        [Name(Code = "7105", Name = "Nepal")]
        Nepal,


        /// <summary>
        /// Pakistan
        /// </summary>
        [EnumMember]
        [Name(Code = "7106", Name = "Pakistan")]
        Pakistan,


        /// <summary>
        /// SriLanka
        /// </summary>
        [EnumMember]
        [Name(Code = "7107", Name = "Sri Lanka")]
        SriLanka,


        /// <summary>
        /// Afghanistan
        /// </summary>
        [EnumMember]
        [Name(Code = "7201", Name = "Afghanistan")]
        Afghanistan,


        /// <summary>
        /// Armenia
        /// </summary>
        [EnumMember]
        [Name(Code = "7202", Name = "Armenia")]
        Armenia,


        /// <summary>
        /// Azerbaijan
        /// </summary>
        [EnumMember]
        [Name(Code = "7203", Name = "Azerbaijan")]
        Azerbaijan,


        /// <summary>
        /// Georgia
        /// </summary>
        [EnumMember]
        [Name(Code = "7204", Name = "Georgia")]
        Georgia,


        /// <summary>
        /// Kazakhstan
        /// </summary>
        [EnumMember]
        [Name(Code = "7205", Name = "Kazakhstan")]
        Kazakhstan,


        /// <summary>
        /// Kyrgyzstan
        /// </summary>
        [EnumMember]
        [Name(Code = "7206", Name = "Kyrgyzstan")]
        Kyrgyzstan,


        /// <summary>
        /// Tajikistan
        /// </summary>
        [EnumMember]
        [Name(Code = "7207", Name = "Tajikistan")]
        Tajikistan,


        /// <summary>
        /// Turkmenistan
        /// </summary>
        [EnumMember]
        [Name(Code = "7208", Name = "Turkmenistan")]
        Turkmenistan,


        /// <summary>
        /// Uzbekistan
        /// </summary>
        [EnumMember]
        [Name(Code = "7211", Name = "Uzbekistan")]
        Uzbekistan,


        /// <summary>
        /// Bermuda
        /// </summary>
        [EnumMember]
        [Name(Code = "8101", Name = "Bermuda")]
        Bermuda,


        /// <summary>
        /// Canada
        /// </summary>
        [EnumMember]
        [Name(Code = "8102", Name = "Canada")]
        Canada,


        /// <summary>
        /// StPierreAndMiquelon
        /// </summary>
        [EnumMember]
        [Name(Code = "8103", Name = "St Pierre And Miquelon")]
        StPierreAndMiquelon,


        /// <summary>
        /// UnitedStatesOfAmerica
        /// </summary>
        [EnumMember]
        [Name(Code = "8104", Name = "United States Of America")]
        UnitedStatesOfAmerica,


        /// <summary>
        /// Argentina
        /// </summary>
        [EnumMember]
        [Name(Code = "8201", Name = "Argentina")]
        Argentina,


        /// <summary>
        /// Bolivia
        /// </summary>
        [EnumMember]
        [Name(Code = "8202", Name = "Bolivia")]
        Bolivia,


        /// <summary>
        /// Brazil
        /// </summary>
        [EnumMember]
        [Name(Code = "8203", Name = "Brazil")]
        Brazil,


        /// <summary>
        /// Chile
        /// </summary>
        [EnumMember]
        [Name(Code = "8204", Name = "Chile")]
        Chile,


        /// <summary>
        /// Colombia
        /// </summary>
        [EnumMember]
        [Name(Code = "8205", Name = "Colombia")]
        Colombia,


        /// <summary>
        /// Ecuador
        /// </summary>
        [EnumMember]
        [Name(Code = "8206", Name = "Ecuador")]
        Ecuador,


        /// <summary>
        /// FalklandIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "8207", Name = "Falkland Islands")]
        FalklandIslands,


        /// <summary>
        /// FrenchGuiana
        /// </summary>
        [EnumMember]
        [Name(Code = "8208", Name = "French Guiana")]
        FrenchGuiana,


        /// <summary>
        /// Guyana
        /// </summary>
        [EnumMember]
        [Name(Code = "8211", Name = "Guyana")]
        Guyana,


        /// <summary>
        /// Paraguay
        /// </summary>
        [EnumMember]
        [Name(Code = "8212", Name = "Paraguay")]
        Paraguay,


        /// <summary>
        /// Peru
        /// </summary>
        [EnumMember]
        [Name(Code = "8213", Name = "Peru")]
        Peru,


        /// <summary>
        /// Suriname
        /// </summary>
        [EnumMember]
        [Name(Code = "8214", Name = "Suriname")]
        Suriname,


        /// <summary>
        /// Uruguay
        /// </summary>
        [EnumMember]
        [Name(Code = "8215", Name = "Uruguay")]
        Uruguay,


        /// <summary>
        /// Venezuela
        /// </summary>
        [EnumMember]
        [Name(Code = "8216", Name = "Venezuela")]
        Venezuela,


        /// <summary>
        /// SouthAmericaNec
        /// </summary>
        [EnumMember]
        [Name(Code = "8299", Name = "South America, Nec")]
        SouthAmericaNec,


        /// <summary>
        /// Belize
        /// </summary>
        [EnumMember]
        [Name(Code = "8301", Name = "Belize")]
        Belize,


        /// <summary>
        /// CostaRica
        /// </summary>
        [EnumMember]
        [Name(Code = "8302", Name = "Costa Rica")]
        CostaRica,


        /// <summary>
        /// ElSalvador
        /// </summary>
        [EnumMember]
        [Name(Code = "8303", Name = "El Salvador")]
        ElSalvador,


        /// <summary>
        /// Guatemala
        /// </summary>
        [EnumMember]
        [Name(Code = "8304", Name = "Guatemala")]
        Guatemala,


        /// <summary>
        /// Honduras
        /// </summary>
        [EnumMember]
        [Name(Code = "8305", Name = "Honduras")]
        Honduras,


        /// <summary>
        /// Mexico
        /// </summary>
        [EnumMember]
        [Name(Code = "8306", Name = "Mexico")]
        Mexico,


        /// <summary>
        /// Nicaragua
        /// </summary>
        [EnumMember]
        [Name(Code = "8307", Name = "Nicaragua")]
        Nicaragua,


        /// <summary>
        /// Panama
        /// </summary>
        [EnumMember]
        [Name(Code = "8308", Name = "Panama")]
        Panama,


        /// <summary>
        /// Anguilla
        /// </summary>
        [EnumMember]
        [Name(Code = "8401", Name = "Anguilla")]
        Anguilla,


        /// <summary>
        /// AntiguaAndBarbuda
        /// </summary>
        [EnumMember]
        [Name(Code = "8402", Name = "Antigua And Barbuda")]
        AntiguaAndBarbuda,


        /// <summary>
        /// Aruba
        /// </summary>
        [EnumMember]
        [Name(Code = "8403", Name = "Aruba")]
        Aruba,


        /// <summary>
        /// Bahamas
        /// </summary>
        [EnumMember]
        [Name(Code = "8404", Name = "Bahamas")]
        Bahamas,


        /// <summary>
        /// Barbados
        /// </summary>
        [EnumMember]
        [Name(Code = "8405", Name = "Barbados")]
        Barbados,


        /// <summary>
        /// CaymanIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "8406", Name = "Cayman Islands")]
        CaymanIslands,


        /// <summary>
        /// Cuba
        /// </summary>
        [EnumMember]
        [Name(Code = "8407", Name = "Cuba")]
        Cuba,


        /// <summary>
        /// Dominica
        /// </summary>
        [EnumMember]
        [Name(Code = "8408", Name = "Dominica")]
        Dominica,


        /// <summary>
        /// DominicanRepublic
        /// </summary>
        [EnumMember]
        [Name(Code = "8411", Name = "Dominican Republic")]
        DominicanRepublic,


        /// <summary>
        /// Grenada
        /// </summary>
        [EnumMember]
        [Name(Code = "8412", Name = "Grenada")]
        Grenada,


        /// <summary>
        /// Guadeloupe
        /// </summary>
        [EnumMember]
        [Name(Code = "8413", Name = "Guadeloupe")]
        Guadeloupe,


        /// <summary>
        /// Haiti
        /// </summary>
        [EnumMember]
        [Name(Code = "8414", Name = "Haiti")]
        Haiti,


        /// <summary>
        /// Jamaica
        /// </summary>
        [EnumMember]
        [Name(Code = "8415", Name = "Jamaica")]
        Jamaica,


        /// <summary>
        /// Martinique
        /// </summary>
        [EnumMember]
        [Name(Code = "8416", Name = "Martinique")]
        Martinique,


        /// <summary>
        /// Montserrat
        /// </summary>
        [EnumMember]
        [Name(Code = "8417", Name = "Montserrat")]
        Montserrat,


        /// <summary>
        /// NetherlandsAntilles
        /// </summary>
        [EnumMember]
        [Name(Code = "8418", Name = "Netherlands Antilles")]
        NetherlandsAntilles,


        /// <summary>
        /// PuertoRico
        /// </summary>
        [EnumMember]
        [Name(Code = "8421", Name = "Puerto Rico")]
        PuertoRico,


        /// <summary>
        /// StKittsAndNevis
        /// </summary>
        [EnumMember]
        [Name(Code = "8422", Name = "St Kitts And Nevis")]
        StKittsAndNevis,


        /// <summary>
        /// StLucia
        /// </summary>
        [EnumMember]
        [Name(Code = "8423", Name = "St Lucia")]
        StLucia,


        /// <summary>
        /// StVincentAndTheGrenadines
        /// </summary>
        [EnumMember]
        [Name(Code = "8424", Name = "St Vincent And The Grenadines")]
        StVincentAndTheGrenadines,


        /// <summary>
        /// TrinidadAndTobago
        /// </summary>
        [EnumMember]
        [Name(Code = "8425", Name = "Trinidad And Tobago")]
        TrinidadAndTobago,


        /// <summary>
        /// TurksAndCaicosIslands
        /// </summary>
        [EnumMember]
        [Name(Code = "8426", Name = "Turks And Caicos Islands")]
        TurksAndCaicosIslands,


        /// <summary>
        /// VirginIslandsBritish
        /// </summary>
        [EnumMember]
        [Name(Code = "8427", Name = "Virgin Islands, British ")]
        VirginIslandsBritish,


        /// <summary>
        /// VirginIslandsUnitedStates
        /// </summary>
        [EnumMember]
        [Name(Code = "8428", Name = "Virgin Islands, United States")]
        VirginIslandsUnitedStates,


        /// <summary>
        /// StBarthelemy
        /// </summary>
        [EnumMember]
        [Name(Code = "8431", Name = "St Barthelemy")]
        StBarthelemy,


        /// <summary>
        /// StMartinFrenchPart
        /// </summary>
        [EnumMember]
        [Name(Code = "8432", Name = "St Martin (French Part)")]
        StMartinFrenchPart,


        /// <summary>
        /// Benin
        /// </summary>
        [EnumMember]
        [Name(Code = "9101", Name = "Benin")]
        Benin,


        /// <summary>
        /// BurkinaFaso
        /// </summary>
        [EnumMember]
        [Name(Code = "9102", Name = "Burkina Faso")]
        BurkinaFaso,


        /// <summary>
        /// Cameroon
        /// </summary>
        [EnumMember]
        [Name(Code = "9103", Name = "Cameroon")]
        Cameroon,


        /// <summary>
        /// CapeVerde
        /// </summary>
        [EnumMember]
        [Name(Code = "9104", Name = "Cape Verde")]
        CapeVerde,


        /// <summary>
        /// CentralAfricanRepublic
        /// </summary>
        [EnumMember]
        [Name(Code = "9105", Name = "Central African Republic")]
        CentralAfricanRepublic,


        /// <summary>
        /// Chad
        /// </summary>
        [EnumMember]
        [Name(Code = "9106", Name = "Chad")]
        Chad,


        /// <summary>
        /// Congo
        /// </summary>
        [EnumMember]
        [Name(Code = "9107", Name = "Congo")]
        Congo,


        /// <summary>
        /// CongoDemocraticRepublicOf
        /// </summary>
        [EnumMember]
        [Name(Code = "9108", Name = "Congo, Democratic Republic Of")]
        CongoDemocraticRepublicOf,


        /// <summary>
        /// CoteDIvoire
        /// </summary>
        [EnumMember]
        [Name(Code = "9111", Name = "Côte D'Ivoire")]
        CoteDIvoire,


        /// <summary>
        /// EquatorialGuinea
        /// </summary>
        [EnumMember]
        [Name(Code = "9112", Name = "Equatorial Guinea")]
        EquatorialGuinea,


        /// <summary>
        /// Gabon
        /// </summary>
        [EnumMember]
        [Name(Code = "9113", Name = "Gabon")]
        Gabon,


        /// <summary>
        /// Gambia
        /// </summary>
        [EnumMember]
        [Name(Code = "9114", Name = "Gambia")]
        Gambia,


        /// <summary>
        /// Ghana
        /// </summary>
        [EnumMember]
        [Name(Code = "9115", Name = "Ghana")]
        Ghana,


        /// <summary>
        /// Guinea
        /// </summary>
        [EnumMember]
        [Name(Code = "9116", Name = "Guinea")]
        Guinea,


        /// <summary>
        /// GuineaBissau
        /// </summary>
        [EnumMember]
        [Name(Code = "9117", Name = "Guinea-Bissau")]
        GuineaBissau,


        /// <summary>
        /// Liberia
        /// </summary>
        [EnumMember]
        [Name(Code = "9118", Name = "Liberia")]
        Liberia,


        /// <summary>
        /// Mali
        /// </summary>
        [EnumMember]
        [Name(Code = "9121", Name = "Mali")]
        Mali,


        /// <summary>
        /// Mauritania
        /// </summary>
        [EnumMember]
        [Name(Code = "9122", Name = "Mauritania")]
        Mauritania,


        /// <summary>
        /// Niger
        /// </summary>
        [EnumMember]
        [Name(Code = "9123", Name = "Niger")]
        Niger,


        /// <summary>
        /// Nigeria
        /// </summary>
        [EnumMember]
        [Name(Code = "9124", Name = "Nigeria")]
        Nigeria,


        /// <summary>
        /// SaoTomeAndPrincipe
        /// </summary>
        [EnumMember]
        [Name(Code = "9125", Name = "Sao Tomé And Principe")]
        SaoTomeAndPrincipe,


        /// <summary>
        /// Senegal
        /// </summary>
        [EnumMember]
        [Name(Code = "9126", Name = "Senegal")]
        Senegal,


        /// <summary>
        /// SierraLeone
        /// </summary>
        [EnumMember]
        [Name(Code = "9127", Name = "Sierra Leone")]
        SierraLeone,


        /// <summary>
        /// Togo
        /// </summary>
        [EnumMember]
        [Name(Code = "9128", Name = "Togo")]
        Togo,


        /// <summary>
        /// Angola
        /// </summary>
        [EnumMember]
        [Name(Code = "9201", Name = "Angola")]
        Angola,


        /// <summary>
        /// Botswana
        /// </summary>
        [EnumMember]
        [Name(Code = "9202", Name = "Botswana")]
        Botswana,


        /// <summary>
        /// Burundi
        /// </summary>
        [EnumMember]
        [Name(Code = "9203", Name = "Burundi")]
        Burundi,


        /// <summary>
        /// Comoros
        /// </summary>
        [EnumMember]
        [Name(Code = "9204", Name = "Comoros")]
        Comoros,


        /// <summary>
        /// Djibouti
        /// </summary>
        [EnumMember]
        [Name(Code = "9205", Name = "Djibouti")]
        Djibouti,


        /// <summary>
        /// Eritrea
        /// </summary>
        [EnumMember]
        [Name(Code = "9206", Name = "Eritrea")]
        Eritrea,


        /// <summary>
        /// Ethiopia
        /// </summary>
        [EnumMember]
        [Name(Code = "9207", Name = "Ethiopia")]
        Ethiopia,


        /// <summary>
        /// Kenya
        /// </summary>
        [EnumMember]
        [Name(Code = "9208", Name = "Kenya")]
        Kenya,


        /// <summary>
        /// Lesotho
        /// </summary>
        [EnumMember]
        [Name(Code = "9211", Name = "Lesotho")]
        Lesotho,


        /// <summary>
        /// Madagascar
        /// </summary>
        [EnumMember]
        [Name(Code = "9212", Name = "Madagascar")]
        Madagascar,


        /// <summary>
        /// Malawi
        /// </summary>
        [EnumMember]
        [Name(Code = "9213", Name = "Malawi")]
        Malawi,


        /// <summary>
        /// Mauritius
        /// </summary>
        [EnumMember]
        [Name(Code = "9214", Name = "Mauritius")]
        Mauritius,


        /// <summary>
        /// Mayotte
        /// </summary>
        [EnumMember]
        [Name(Code = "9215", Name = "Mayotte")]
        Mayotte,


        /// <summary>
        /// Mozambique
        /// </summary>
        [EnumMember]
        [Name(Code = "9216", Name = "Mozambique")]
        Mozambique,


        /// <summary>
        /// Namibia
        /// </summary>
        [EnumMember]
        [Name(Code = "9217", Name = "Namibia")]
        Namibia,


        /// <summary>
        /// Reunion
        /// </summary>
        [EnumMember]
        [Name(Code = "9218", Name = "Réunion")]
        Reunion,


        /// <summary>
        /// Rwanda
        /// </summary>
        [EnumMember]
        [Name(Code = "9221", Name = "Rwanda")]
        Rwanda,


        /// <summary>
        /// StHelena
        /// </summary>
        [EnumMember]
        [Name(Code = "9222", Name = "St Helena")]
        StHelena,


        /// <summary>
        /// Seychelles
        /// </summary>
        [EnumMember]
        [Name(Code = "9223", Name = "Seychelles")]
        Seychelles,


        /// <summary>
        /// Somalia
        /// </summary>
        [EnumMember]
        [Name(Code = "9224", Name = "Somalia")]
        Somalia,


        /// <summary>
        /// SouthAfrica
        /// </summary>
        [EnumMember]
        [Name(Code = "9225", Name = "South Africa")]
        SouthAfrica,


        /// <summary>
        /// Swaziland
        /// </summary>
        [EnumMember]
        [Name(Code = "9226", Name = "Swaziland")]
        Swaziland,


        /// <summary>
        /// Tanzania
        /// </summary>
        [EnumMember]
        [Name(Code = "9227", Name = "Tanzania")]
        Tanzania,


        /// <summary>
        /// Uganda
        /// </summary>
        [EnumMember]
        [Name(Code = "9228", Name = "Uganda")]
        Uganda,


        /// <summary>
        /// Zambia
        /// </summary>
        [EnumMember]
        [Name(Code = "9231", Name = "Zambia")]
        Zambia,


        /// <summary>
        /// Zimbabwe
        /// </summary>
        [EnumMember]
        [Name(Code = "9232", Name = "Zimbabwe")]
        Zimbabwe,


        /// <summary>
        ///        SouthernAndEastAfricaNec
        /// </summary>
        [EnumMember]
        [Name(Code = "9299", Name = "Southern And East Africa, Nec")]
        SouthernAndEastAfricaNec
    }
}