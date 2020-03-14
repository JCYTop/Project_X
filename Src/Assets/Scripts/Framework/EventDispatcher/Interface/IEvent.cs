namespace Framework.EventDispatcher
{
    public interface IEvent
    {
        void RegiestEvent(string eventName, EventMethod fn);
        void OnceRegiestEvent(string eventName, EventMethod fn);
        void UnRegiestEvent(string eventName, EventMethod fn);
        void EmitEvent(string eventName, params object[] args);
        void Clear(ClearEventType clearEventType = ClearEventType.ALL);
    }
}