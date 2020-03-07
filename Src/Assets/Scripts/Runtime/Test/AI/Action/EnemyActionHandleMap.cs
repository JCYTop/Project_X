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
    public class EnemyActionHandleMap : Singleton<EnemyActionHandleMap>, IActionHandleMap<ActionEnemyTag, IActionHandler<ActionEnemyTag>>
    {
        private SortedList<ActionEnemyTag, IActionHandler<ActionEnemyTag>> handleMap;

        public SortedList<ActionEnemyTag, IActionHandler<ActionEnemyTag>> HandleMap
        {
            get
            {
                if (handleMap == null)
                {
                    handleMap = new SortedList<ActionEnemyTag, IActionHandler<ActionEnemyTag>>()
                    {
                        //TODO 这是一个例子
                        {ActionEnemyTag.Default, new EmenyDefaultActionHandler()},
                        {ActionEnemyTag.Idle, new EmenyIdleActionHandler()},
                    };
                }

                return handleMap;
            }
        }

        public IActionHandler<ActionEnemyTag> GetHandle(ActionEnemyTag type)
        {
            return HandleMap.GetSortListValue(type);
        }
    }
}