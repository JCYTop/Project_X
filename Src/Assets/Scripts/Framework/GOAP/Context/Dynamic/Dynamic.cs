/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Dynamic
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/10 17:36:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using Framework.Base;
using Framework.EventDispatcher;

namespace Framework.GOAP
{
    /// <summary>
    /// 外部动态变量
    /// 外部关联
    /// 外部对其主要修改这里的数据
    /// 还可能有标签类信息(队伍标签)
    /// 应该由外部筛选器Filter选择最优解传送进来
    /// </summary>
    public abstract class Dynamic : MonoEventEmitter, IGoalbalID
    {
        private int goalbalID = 0;
        public Dictionary<DynamicObjTag, Func<object>> DynamicDic = new Dictionary<DynamicObjTag, Func<object>>(1 << 5);

        public int GoalbalID
        {
            get
            {
                if (goalbalID <= 0)
                {
                    goalbalID = this.GetComponentInParent<ObjectBase>().GlobalID;
                }

                return goalbalID;
            }
        }

        /// <summary>
        /// 就是初始化
        /// </summary>
        public abstract void Init();
    }

    public static class AIDynamicExtend
    {
        /// <summary>
        /// 直接获取数值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T PushDynamicData<T>(this Dynamic dynamic, DynamicObjTag tag)
        {
            return (T) dynamic.DynamicDic.GetDictionaryValue(tag).Invoke();
        }
    }

    /// <summary>
    /// 为了拿统一的数据
    /// </summary>
    public enum DynamicObjTag
    {
        Default,

        /// <summary>
        /// 攻击目标
        /// 返回GameObject
        /// </summary>
        Attack_Target,
    }
}