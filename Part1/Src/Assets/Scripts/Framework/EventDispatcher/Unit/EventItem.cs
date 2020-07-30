using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Event
{
    #region 事件单位

    /// <summary>
    /// 事件回调
    /// </summary>
    /// <param name="args"></param>
    public delegate void EventMethod(params object[] args);

    /// <summary>
    /// 一个事件对应的多个方法回调集合的事件单位
    /// </summary>
    public sealed class EventItem : IEquatable<EventItem>
    {
        private event EventMethod eventArr;

        /// <summary>
        /// 添加事件回调
        /// </summary>
        /// <param name="fn"></param>
        public void AddEvent(EventMethod fn)
        {
            //检查是否重复
            if (eventArr != fn)
                eventArr += fn;
        }

        /// <summary>
        /// 删除回调事件
        /// </summary>
        /// <param name="fn"></param>
        public void Remove(EventMethod fn)
        {
            if (eventArr == fn)
                eventArr -= fn;
        }

        /// <summary>
        /// 调用所有回调方法
        /// </summary>
        /// <param name="args"></param>
        public void Call(params object[] args)
        {
            if (eventArr != null)
            {
                eventArr(args);
            }
        }

        public bool Equals(EventItem other)
        {
            return this == other;
        }
    }

    #endregion
}