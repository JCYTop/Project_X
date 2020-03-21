/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Condition
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 23:20:43
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
    public abstract class Condition : MonoEventEmitter, IGoalbalID
    {
        private int goalbalID = 0;
        public abstract Dictionary<CondtionTag, bool> ConditionMap { get; }

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

        public abstract void Init();
    }

    public static class AIConditionExtend
    {
        /// <summary>
        /// 获取不同类型
        /// </summary>
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetCondition<T>(this Condition context) where T : class
        {
            try
            {
                return context as T;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 获取和目标不相同的条件的CondtionTag标签
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="goal"></param>
        /// <typeparam name="TGoal"></typeparam>
        /// <returns></returns>
        public static ICollection<CondtionTag> GetDiffecentCondition<TGoal>(this Condition condition, IGoal<TGoal> goal)
        {
            var list = new List<CondtionTag>();
            foreach (var cond in goal.Condition)
            {
                var value = condition.ConditionMap.GetDictionaryValue(cond.ElementTag);
                if (!value)
                {
                    list.Add(cond.ElementTag);
                }
            }

            return list;
        }

        /// <summary>
        /// 根据条件队列
        /// 提供标签返回相应的值
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="tag"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static CondtionAssembly GetDiffecentCondition(this ICollection<CondtionAssembly> collection, CondtionTag tag)
        {
            foreach (var unit in collection)
            {
                if (unit.ElementTag == tag)
                {
                    return unit;
                }
            }

            return null;
        }
    }
}