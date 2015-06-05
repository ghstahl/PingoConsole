using System;

namespace Json2Xml.Core
{
    public class Wellknown
    {
        public const int ERROR_BAD_ARGUMENTS = 0xA0;
        public const int ERROR_ARITHMETIC_OVERFLOW = 0x216;
        public const int ERROR_INVALID_COMMAND_LINE = 0x667;

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