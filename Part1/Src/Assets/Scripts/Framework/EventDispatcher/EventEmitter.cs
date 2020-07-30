/* 创建日期：2018/07/27
 * 创建作者：JCY
 * 描述：事件发射器类
 */

using UnityEngine;

namespace Framework.Event
{
    /// <summary>
    /// 一般类，一般类中调用
    /// </summary>
    public abstract class EventEmitter : IEvent
    {
        public void OnRegiestEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnRegiestEvent(eventName, fn);
        }

        public void OnceRegiestEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnceRegiestEvent(eventName, fn);
        }

        public void OnUnRegiestEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnUnRegiestEvent(eventName, fn);
        }

        public void OnEmitEvent(string eventName, params object[] args)
        {
            EventDispatcher.Instance().OnEmitEvent(eventName, args);
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
        public void OnRegiestEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnRegiestEvent(eventName, fn);
        }

        public void OnceRegiestEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnceRegiestEvent(eventName, fn);
        }

        public void OnUnRegiestEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnUnRegiestEvent(eventName, fn);
        }

        public void OnEmitEvent(string eventName, params object[] args)
        {
            EventDispatcher.Instance().OnEmitEvent(eventName, args);
        }

        public void Clear(ClearEventType clearEventType = ClearEventType.ALL)
        {
            EventDispatcher.Instance().Clear(clearEventType);
        }
    }
}