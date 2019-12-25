namespace Framework.EventDispatcher
{
    public interface IEvent
    {
        void On(string eventName, EventMethod fn);
        void Once(string eventName, EventMethod fn);
        void Off(string eventName, EventMethod fn);
        void Emit(string eventName, params object[] args);
        void Clear(ClearEventType clearEventType = ClearEventType.ALL);
    }
}