using System;

namespace Json2Xml.Core.Versioning
{
    [Flags]
    public enum RangeDisposition
    {
        None = 0,
        LowerVersionBindingIncluded = 1,
        LowerVersionBindingExcluded = 2,
        UpperVersionBindingIncluded = 4,
        UpperVersionBindingExcluded = 8,
        LowerAndUpperMatch = 16
    }
}