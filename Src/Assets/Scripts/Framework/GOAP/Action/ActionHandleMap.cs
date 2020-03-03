/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionHandleMap
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/03 22:36:13
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace GOAP
{
    /// <summary>
    /// 静态类直接返回数据
    /// 手动注册ActionHandle类
    /// </summary>
    public static class ActionHandleMap
    {
        public static SortedList<string, IActionHandle> handleMap = new SortedList<string, IActionHandle>()
        {
            //TODO 这是一个例子
            {ActionTag.Default.ToString(), new EmenyIdleActionHandle()},
        };

        /// <summary>
        /// 获取Handle
        /// </summary>
        /// <param name="type">参数</param>
        /// <typeparam name="T">TAction的类型</typeparam>
        /// <returns>IActionHandle类型</returns>
        public static IActionHandle GetHandle<T>(T type)
            where T : struct
        {
            return handleMap.GetDictionaryValue(type.ToString());
        }

        /// <summary>
        /// 获取Handle
        /// </summary>
        /// <param name="type">参数</param>
        /// <typeparam name="TKey">TAction的类型</typeparam>
        /// <typeparam name="TValue">IActionHandle类型</typeparam>
        /// <returns>IActionHandle类型</returns>
        public static TValue GetHandle<TKey, TValue>(TKey type)
            where TKey : struct
            where TValue : IActionHandle
        {
            return (TValue) handleMap.GetDictionaryValue(type.ToString());
        }

//        public static void 调用方法()
//        {
//            var handle = ActionHandleMap.GetHandle<ActionTag>(ActionTag.Default);
//            handle.Init<ActionTag, GoalTag>();
//        }
    }
}