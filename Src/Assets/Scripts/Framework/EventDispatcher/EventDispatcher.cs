/* 创建日期：2018/07/27
 * 创建作者：JCY
 * 描述：事件中转派发管理
 */

using System.Collections.Generic;

/// <summary>
/// 选择清理事件类型
/// </summary>
public enum ClearEventType
{
    ALL = 0,
    STANDING,
    ONCE,
}

public sealed class EventDispatcher : Singleton<EventDispatcher>, IEvent
{
    private Dictionary<string, EventItem> standingEvent = new Dictionary<string, EventItem>(); //常驻事件集合
    private Dictionary<string, EventItem> onceEvent = new Dictionary<string, EventItem>(); //单次事件集合

    /// <summary>
    /// 注册常驻事件
    /// </summary>
    /// <param name="eventName">事件名字</param>
    /// <param name="fn">回调方法</param>
    public void On(string eventName, EventMethod fn)
    {
        AddListener(eventName, fn, standingEvent);
    }

    /// <summary>
    /// 取消注册事件回调方法（常住事件）
    /// </summary>
    /// <param name="eventName">事件名字</param>
    public void Off(string eventName, EventMethod fn)
    {
        standingEvent.TryGetValue(eventName, out var eventItem);
        if (eventItem != null)
        {
            //这里只是清除常住事件的回调方法
            eventItem.Remove(fn);
        }

        onceEvent.TryGetValue(eventName, out eventItem);
        if (eventItem != null)
        {
            onceEvent.Remove(eventName);
        }
    }

    /// <summary>
    /// 注册单次事件
    /// </summary>
    /// <param name="eventName">事件名字</param>
    /// <param name="fn">回调方法</param>
    public void Once(string eventName, EventMethod fn)
    {
        AddListener(eventName, fn, onceEvent);
    }

    public void Emit(string eventName, params object[] args)
    {
        standingEvent.TryGetValue(eventName, out var eventItem);
        if (eventItem != null)
        {
            eventItem.Call(args);
        }

        onceEvent.TryGetValue(eventName, out eventItem);
        if (eventItem != null)
        {
            eventItem.Call(args);
            onceEvent.Remove(eventName);
        }
    }

    /// <summary>
    /// 添加事件核心方法
    /// </summary>
    /// <param name="eventName">事件名字</param>
    /// <param name="fn">事件方法</param>
    /// <param name="eventDic">事件字典</param>
    private void AddListener(string eventName, EventMethod fn, Dictionary<string, EventItem> eventDic)
    {
        eventDic.TryGetValue(eventName, out var eventItem);
        //如果发现字典里面没有，则首先在字典里面添加创建
        if (eventItem == null)
        {
            eventItem = new EventItem();
            eventDic.Add(eventName, eventItem);
        }

        //存在的eventItem再往里面添加事件回调方法fn
        eventItem.AddEvent(fn);
    }

    /// <summary>
    /// 清除事件集合
    /// </summary>
    public void Clear(ClearEventType clearEventType = ClearEventType.ALL)
    {
        switch (clearEventType)
        {
            case ClearEventType.STANDING:
                standingEvent.Clear();
                break;
            case ClearEventType.ONCE:
                onceEvent.Clear();
                break;
            default:
                standingEvent.Clear();
                onceEvent.Clear();
                break;
        }
    }
}