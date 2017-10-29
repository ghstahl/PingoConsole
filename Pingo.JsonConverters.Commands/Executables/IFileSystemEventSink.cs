namespace Pingo.JsonConverters.Commands.Executables
{
    public interface IFileSystemEventSink
    {
        void OnNewDirectory(string fullPath);
        void OnNewFile(string fullPath);
    }
}