/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Goal
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/02/29 19:55:22
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace Framework.GOAP
{
    /// <summary>
    /// 加载配置文件
    /// 生成每一个具体的GoalBase类
    /// GoalBase 生成一个具体的Goal类
    /// </summary>
    /// <typeparam name="TGoal"></typeparam>
    public abstract class Goal<TGoal> : IGoal<TGoal>
    {
        private ICollection<CondtionAssembly> condition;
        private ICollection<CondtionAssembly> target;
        private System.Action<IGoal<TGoal>> onActivate;
        private System.Action<IGoal<TGoal>> onInactivate;
        public TGoal Label { get; }
        public GoalConfigUnit goalGroup { get; }

        public int Priority
        {
            get
            {
                var element = goalGroup.ConfigUnitSet.GetSortListValue(GoalElementTag.Priority);
                var intValue = element.CastType<int>();
                return intValue;
            }
        }

        public ICollection<CondtionAssembly> Condition
        {
            get
            {
                if (condition == null)
                {
                    condition = InitCondition();
                }

                return condition;
            }
        }

        public ICollection<CondtionAssembly> Target
        {
            get
            {
                if (target == null)
                {
                    target = InitTarget();
                }

                return target;
            }
        }

        public Goal(TGoal tag, GoalConfigUnit goalGroup)
        {
            this.Label = tag;
            this.goalGroup = goalGroup;
        }

        private ICollection<CondtionAssembly> InitCondition()
        {
            return (ICollection<CondtionAssembly>) goalGroup.ConfigUnitSet.GetSortListValue(GoalElementTag.Conditon);
        }

        private ICollection<CondtionAssembly> InitTarget()
        {
            return (ICollection<CondtionAssembly>) goalGroup.ConfigUnitSet.GetSortListValue(GoalElementTag.Target);
        }

        public bool IsGoalComplete()
        {
            throw new NotImplementedException();
        }

        public void AddGoalActivateListener(System.Action<IGoal<TGoal>> onActivate)
        {
            this.onActivate = onActivate;
        }

        public void AddGoalInactivateListener(System.Action<IGoal<TGoal>> onInactivate)
        {
            this.onInactivate = onInactivate;
        }
    }
}