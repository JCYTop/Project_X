/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionHandlerMap
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/03 22:36:13
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace Framework.GOAP
{
    /// <summary>
    /// 静态类直接返回数据
    /// 手动注册ActionHandle类
    /// 没办法只能手动注册！！！
    /// </summary>
    public static class ActionHandlerMap
    {
        private static SortedList<ActionHanderTag, ActionHandler> handleMap;

        public static SortedList<ActionHanderTag, ActionHandler> HandleMap
        {
            get
            {
                if (handleMap == null)
                {
                    handleMap = new SortedList<ActionHanderTag, ActionHandler>()
                    {
                        //TODO 这是一个例子
                        {ActionHanderTag.Default, new DefaultActionHandler()},
                        {ActionHanderTag.Idle_Handle, new IdleActionHandler()},
                    };
                }

                return handleMap;
            }
        }
    }

    public enum ActionHanderTag
    {
        Default = 0,
        Idle_Handle,
    }
}