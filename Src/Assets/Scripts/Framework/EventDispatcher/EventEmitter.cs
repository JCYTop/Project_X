/* 创建日期：2018/07/27
 * 创建作者：JCY
 * 描述：事件发射器类
 */

using UnityEngine;

namespace Framework.EventDispatcher
{
    /// <summary>
    /// 一般类，一般类中调用
    /// </summary>
    public abstract class EventEmitter : IEvent
    {
        public void On(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().On(eventName, fn);
        }

        public void Once(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().Once(eventName, fn);
        }

        public void Off(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().Off(eventName, fn);
        }

        public void Emit(string eventName, params object[] args)
        {
            EventDispatcher.Instance().Emit(eventName, args);
        }

        public void Clear(ClearEventType clearEventType = ClearEventType.ALL)
        {
            EventDispatcher.Instance().Clear(clearEventType);
        }
    }

    /// <summary>
    /// Mono基类,方便Mono中调用
    /// </summary>
    public abstract class MonoEventEmitter : MonoBehaviour, IEvent
    {
        public void On(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().On(eventName, fn);
        }

        public void Once(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().Once(eventName, fn);
        }

        public void Off(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().Off(eventName, fn);
        }

        public void Emit(string eventName, params object[] args)
        {
            EventDispatcher.Instance().Emit(eventName, args);
        }

        public void Clear(ClearEventType clearEventType = ClearEventType.ALL)
        {
            EventDispatcher.Instance().Clear(clearEventType);
        }
    }
}