/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalBase
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
    public abstract class GoalBase<TGoal, TGoalElementTag> : IGoal<TGoal>
    {
        private ICollection<StateAssembly> conditions;
        private ICollection<StateAssembly> effects;
        private Action<IGoal<TGoal>> onActivate;
        private Action<IGoal<TGoal>> onInactivate;
        public TGoal Label { get; }
        public GoalConfigUnit<TGoalElementTag> goalGroup { get; private set; }

        public int Priority
        {
            get
            {
                var element = goalGroup.goalConfigUnitSet.GetSortListValue(ActionElementTag.Priority.ToString());
                var intValue = element.CastType<int>();
                return intValue;
            }
        }

        public ICollection<StateAssembly> Effects
        {
            get
            {
                if (effects == null)
                {
                    effects = InitEffects();
                }

                return effects;
            }
        }

        public ICollection<StateAssembly> Condition
        {
            get
            {
                if (conditions == null)
                {
                    conditions = InitCondition();
                }

                return conditions;
            }
        }

        public GoalBase(TGoal tag, GoalConfigUnit<TGoalElementTag> goalGroup)
        {
            this.Label = tag;
            this.goalGroup = goalGroup;
        }

        private ICollection<StateAssembly> InitCondition()
        {
            return (ICollection<StateAssembly>) goalGroup.goalConfigUnitSet.GetSortListValue(GoalElementTag.Conditon.ToString());
        }

        private ICollection<StateAssembly> InitEffects()
        {
            return (ICollection<StateAssembly>) goalGroup.goalConfigUnitSet.GetSortListValue(GoalElementTag.Effects.ToString());
        }

        public bool IsGoalComplete()
        {
            throw new NotImplementedException();
        }

        public void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate)
        {
            this.onActivate = onActivate;
        }

        public void AddGoalInactivateListener(Action<IGoal<TGoal>> onInactivate)
        {
            this.onInactivate = onInactivate;
        }

        public void UpdateData()
        {
            throw new NotImplementedException();
        }
    }
}