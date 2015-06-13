using System;

namespace Json2Xml.Core
{
    public static class Wellknown
    {
        public enum ReturnCodes
        {
            Success = 0,
            PartialSuccess = 1,
            BadArguments = 2,
            SourceNotValid = 3,
            OutputNotValid = 4,

        }


        public const string Json2Xml = "Json2Xml";
        public const string Xml2Json = "Xml2Json";

        [Flags]
        public enum ConversionType
        {
            Json2Xml = 1,
            Xml2Json = 2,
        }
    }
}