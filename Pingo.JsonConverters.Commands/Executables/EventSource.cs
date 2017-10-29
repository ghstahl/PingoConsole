using System.Collections.Generic;

namespace Pingo.JsonConverters.Commands.Executables
{
    public class EventSource<T> : IEventSource<T>
    {
        private List<T> _eventSinks;

        public List<T> EventSinks
        {
            get { return _eventSinks ?? (_eventSinks = new List<T>()); }
            set { _eventSinks = value; }
        }
        public void RegisterEventSink(T sink)
        {
            lock (EventSinks)
            {
                EventSinks.Add(sink);
            }
        }

        public void UnregisterEventSink(T sink)
        {
            lock (EventSinks)
            {
                EventSinks.Remove(sink);
            }
        }

        public void UnregisterAll()
        {
            lock (EventSinks)
            {
                EventSinks.Clear();
            }
        }
    }
}