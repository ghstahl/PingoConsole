using System.IO;

namespace Pingo.JsonConverters.Commands.Executables
{
    public class FileSystemEnumerator : FileSystemEventSource
    {
        private string _root;
        public FileSystemEnumerator(string root)
        {
            _root = root;
        }

        public void Start()
        {
            EnumDirectory(_root);
        }
        void EnumDirectory(string current)
        {
            FireOnNewDirectory(current);
            var files = Directory.EnumerateFiles(current);
            foreach (var file in files)
            {
                FireOnNewFile(file);
            }

            var dirs = Directory.EnumerateDirectories(current);
            foreach (var dir in dirs)
            {
                EnumDirectory(dir);
            }
        }
    }
}