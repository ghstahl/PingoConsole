namespace Pingo.JsonConverters.Commands.Executables
{
    public abstract class FileSystemEventSource : EventSource<IFileSystemEventSink>
    {
        protected void FireOnNewDirectory(string fullPath)
        {
            foreach (var eventSink in EventSinks)
            {
                eventSink.OnNewDirectory(fullPath);
            }
        }
        protected void FireOnNewFile(string fullPath)
        {
            foreach (var eventSink in EventSinks)
            {
                eventSink.OnNewFile(fullPath);
            }
        }
    }
}