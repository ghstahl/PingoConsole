using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2Xml.Core.IO
{
    static class FileSystem
    {
        public static bool CanCreate(string path)
        {
            string file = path + Guid.NewGuid().ToString() + ".tmp";
            // perhaps check File.Exists(file), but it would be a long-shot...
            bool canCreate;
            try
            {
                using (File.Create(file)) { }
                File.Delete(file);
                canCreate = true;
            }
            catch
            {
                canCreate = false;
            }
            return canCreate;
        }


    }
}
