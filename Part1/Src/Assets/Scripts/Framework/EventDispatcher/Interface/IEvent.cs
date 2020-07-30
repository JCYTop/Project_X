namespace Framework.Event
{
    public interface IEvent
    {
        void OnRegiestEvent(string eventName, EventMethod fn);
        void OnceRegiestEvent(string eventName, EventMethod fn);
        void OnUnRegiestEvent(string eventName, EventMethod fn);
        void OnEmitEvent(string eventName, params object[] args);
        void Clear(ClearEventType clearEventType = ClearEventType.ALL);
    }
}