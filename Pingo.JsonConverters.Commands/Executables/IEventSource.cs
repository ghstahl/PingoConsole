namespace Pingo.JsonConverters.Commands.Executables
{
    public interface IEventSource<T>
    {
        void RegisterEventSink(T sink);
        void UnregisterEventSink(T sink);
        void UnregisterAll();
    }
}