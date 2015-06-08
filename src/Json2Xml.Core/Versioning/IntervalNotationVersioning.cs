using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2Xml.Core.Versioning
{
    public class IntervalNotationVersioning
    {
        private NugetVersion LowerNugetVersion { get; set; }
        private NugetVersion UpperNugetVersion { get; set; }

        public RangeDisposition RangeDisposition { get; private set; }
        public IntervalNotationVersioning(string range)
        {
            var cleaned = range.Trim();
            var innerRange = range.Substring(1, cleaned.Count() - 2);
            var lowerBinding = cleaned[0];
            var upperBinding = cleaned[cleaned.Count() - 1];

            var lowerVersion = "";
            var upperVersion = "";

            var parts = innerRange.Split(',');
            lowerVersion = parts[0];
            upperVersion = parts.Count() < 2 ? lowerVersion : parts[1];

            this.RangeDisposition |= parts.Count() < 2 ? RangeDisposition.LowerAndUpperMatch : RangeDisposition.None;

            LowerNugetVersion = new NugetVersion()
            {
                Version = lowerVersion,
                VersionBinding =
                    ((lowerBinding == '[')
                        ? VersionBinding.VersionBindingIncluded
                        : VersionBinding.VersionBindingExcluded)

            };
            this.RangeDisposition |= (
                (LowerNugetVersion.VersionBinding == VersionBinding.VersionBindingExcluded)
                ? RangeDisposition.LowerVersionBindingExcluded
                : RangeDisposition.LowerVersionBindingIncluded);
            UpperNugetVersion = new NugetVersion()
            {
                Version = upperVersion,
                VersionBinding =
                    ((upperBinding == ']')
                        ? VersionBinding.VersionBindingIncluded
                        : VersionBinding.VersionBindingExcluded)

            };
            this.RangeDisposition |= (
                (UpperNugetVersion.VersionBinding == VersionBinding.VersionBindingExcluded)
                ? RangeDisposition.UpperVersionBindingExcluded
                : RangeDisposition.UpperVersionBindingIncluded);
        }

        public bool HasFlag(RangeDisposition rd)
        {
            return ((RangeDisposition & rd) == rd);

        }
        public int Compare(string version)
        {
            var targetVersion = new NugetVersion() { Version = version };

            int lowerComp = targetVersion.Compare(LowerNugetVersion);
            int upperComp = targetVersion.Compare(UpperNugetVersion);


            if (lowerComp < 0)
                return lowerComp;
            if (lowerComp == 0 && LowerNugetVersion.VersionBinding == VersionBinding.VersionBindingExcluded)
            {
                return -1;
            }


            if (upperComp > 0)
                return upperComp;
            if (upperComp == 0 && UpperNugetVersion.VersionBinding == VersionBinding.VersionBindingExcluded)
            {
                return 1;
            }

            return 0;
        }
    }

}
