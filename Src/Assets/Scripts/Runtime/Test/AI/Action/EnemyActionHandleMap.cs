/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     EnemyActionHandleMap
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
using Framework.Singleton;

namespace GOAP
{
    /// <summary>
    /// 静态类直接返回数据
    /// 手动注册ActionHandle类
    /// </summary>
    public class EnemyActionHandleMap : Singleton<EnemyActionHandleMap>, IActionHandleMap<ActionEnemyTag, IActionHandler>
    {
        private SortedList<ActionEnemyTag, IActionHandler> handleMap;

        public SortedList<ActionEnemyTag, IActionHandler> HandleMap
        {
            get
            {
                if (handleMap == null)
                {
                    handleMap = new SortedList<ActionEnemyTag, IActionHandler>()
                    {
                        //TODO 这是一个例子
                        {ActionEnemyTag.Default, new EmenyIdleActionHandler()},
                    };
                }

                return handleMap;
            }
        }

        public IActionHandler GetHandle(ActionEnemyTag type)
        {
            return HandleMap.GetSortListValue(type);
        }


//        TODO 举例使用
//        public static void 调用方法()
//        {
//            var handle = ActionHandleMap.GetHandle<ActionTag>(ActionTag.Default);
//            handle.Init<ActionTag, GoalTag>();
//        }
    }
}