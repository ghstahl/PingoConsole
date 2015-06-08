using System;
using System.Collections.Generic;
using System.Linq;

namespace Json2Xml.Core.Versioning
{
    public class NugetVersion
    {
        private List<int> _versionList;


        public NugetVersion()
        {
            _versionList = new List<int>(4);
        }

        // <major version>.<minor version>.<build number>.<revision>
        private string _version;

        public string Version
        {
            get { return _version; }
            set
            {
                _version = value;
                var parts = value.Split('.');

                _versionList = new List<int>();

                foreach (var part in parts)
                {
                    _versionList.Add(Convert.ToInt32(part));
                }
                while (_versionList.Count() < 4)
                {
                    _versionList.Add(0);
                }

            }
        }

        public int Major
        {
            get { return _versionList[0]; }
        }

        public int Minor
        {
            get { return _versionList[1]; }
        }

        public int BuildNumber
        {
            get { return _versionList[2]; }
        }

        public int Revision
        {
            get { return _versionList[3]; }
        }

        public VersionBinding VersionBinding { get; set; }

        public int Compare(NugetVersion targetVersion)
        {
            if (Major > targetVersion.Major)
                return 1;
            if (Major < targetVersion.Major)
                return -1;

            if (Minor > targetVersion.Minor)
                return 1;
            if (Minor < targetVersion.Minor)
                return -1;

            if (BuildNumber > targetVersion.BuildNumber)
                return 1;
            if (BuildNumber < targetVersion.BuildNumber)
                return -1;

            if (Revision > targetVersion.Revision)
                return 1;
            if (Revision < targetVersion.Revision)
                return -1;

            return 0;
        }

        public int Compare(string version)
        {
            var targetVersion = new NugetVersion() { Version = version };
            return Compare(targetVersion);
        }
    }
}