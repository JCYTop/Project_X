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
using Framework.Event;

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
        public static (ICollection<CondtionTag>, ICollection<CondtionAssembly>) GetDiffecentTargetTags<TGoal>(this Condition condition,
            IGoal<TGoal> goal)
        {
            var condtionTag = new List<CondtionTag>();
            var condtionAssembly = new List<CondtionAssembly>();
            foreach (var item in goal.Target)
            {
                var value = condition.ConditionMap.GetDictionaryValue(item.ElementTag);
                if (!value)
                {
                    condtionTag.Add(item.ElementTag);
                    condtionAssembly.Add(item);
                }
            }

            return (condtionTag, condtionAssembly);
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

        /// <summary>
        /// 获取和目标不相同的条件
        /// </summary>
        /// <param name="curr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static (List<CondtionTag>, ICollection<CondtionAssembly>) GetDiffecentCondition(ICollection<CondtionAssembly> curr,
            ICollection<CondtionAssembly> target)
        {
            var condtionTag = new List<CondtionTag>();
            var condtionAssembly = new HashSet<CondtionAssembly>();
            foreach (var item in curr)
            {
                condtionAssembly.Add(item);
                foreach (var subAssembly in target)
                {
                    if (item.ElementTag == subAssembly.ElementTag && item.IsRight == subAssembly.IsRight)
                    {
                        condtionAssembly.Remove(item);
                    }
                }
            }

            foreach (var assembly in condtionAssembly)
            {
                condtionTag.Add(assembly.ElementTag);
            }

            return (condtionTag, condtionAssembly);
        }
    }
}