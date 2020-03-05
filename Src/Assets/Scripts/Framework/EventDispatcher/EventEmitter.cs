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
        public void OnEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnEvent(eventName, fn);
        }

        public void OnceEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnceEvent(eventName, fn);
        }

        public void OffEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OffEvent(eventName, fn);
        }

        public void EmitEvent(string eventName, params object[] args)
        {
            EventDispatcher.Instance().EmitEvent(eventName, args);
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
        public void OnEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnEvent(eventName, fn);
        }

        public void OnceEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OnceEvent(eventName, fn);
        }

        public void OffEvent(string eventName, EventMethod fn)
        {
            EventDispatcher.Instance().OffEvent(eventName, fn);
        }

        public void EmitEvent(string eventName, params object[] args)
        {
            EventDispatcher.Instance().EmitEvent(eventName, args);
        }

        public void Clear(ClearEventType clearEventType = ClearEventType.ALL)
        {
            EventDispatcher.Instance().Clear(clearEventType);
        }
    }
}