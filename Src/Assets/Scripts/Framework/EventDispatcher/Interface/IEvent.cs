namespace Framework.EventDispatcher
{
    public interface IEvent
    {
        void OnEvent(string eventName, EventMethod fn);
        void OnceEvent(string eventName, EventMethod fn);
        void OffEvent(string eventName, EventMethod fn);
        void EmitEvent(string eventName, params object[] args);
        void Clear(ClearEventType clearEventType = ClearEventType.ALL);
    }
}