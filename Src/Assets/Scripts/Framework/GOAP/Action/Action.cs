/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Action
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/29 00:37:46
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace Framework.GOAP
{
    /// <summary>
    /// 每一个具体的Action
    /// 通过读取具体的配置文件信息生成一个具体的类
    /// 数据类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public abstract class Action<TAction> : IAction<TAction>
    {
        private ICollection<CondtionAssembly> conditions;
        private ICollection<CondtionAssembly> effects;

        public ActionConfigUnit ActionGroup { get; private set; }

        public ICollection<CondtionAssembly> Conditions
        {
            get
            {
                if (conditions == null)
                {
                    conditions = InitConditions();
                }

                return conditions;
            }
        }

        public ICollection<CondtionAssembly> Effects
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

        public int Cost
        {
            get
            {
                var element = ActionGroup.ConfigUnitSet.GetSortListValue(ActionElementTag.Cost.ToString());
                var intValue = element.CastType<int>();
                return intValue;
            }
        }

        public int Priority
        {
            get
            {
                var element = ActionGroup.ConfigUnitSet.GetSortListValue(ActionElementTag.Priority.ToString());
                var intValue = element.CastType<int>();
                return intValue;
            }
        }

        public bool CanInterruptiblePlan
        {
            get
            {
                var element = ActionGroup.ConfigUnitSet.GetSortListValue(ActionElementTag.Interruptible.ToString());
                var boolValue = element.CastType<bool>();
                return boolValue;
            }
        }

        public TAction Label { get; private set; }

        public Action(TAction tag, ActionConfigUnit actionGroup)
        {
            this.Label = tag;
            this.ActionGroup = actionGroup;
        }

        private ICollection<CondtionAssembly> InitConditions()
        {
            return (ICollection<CondtionAssembly>) ActionGroup.ConfigUnitSet.GetSortListValue(ActionElementTag.Preconditions.ToString());
        }

        private ICollection<CondtionAssembly> InitEffects()
        {
            return (ICollection<CondtionAssembly>) ActionGroup.ConfigUnitSet.GetSortListValue(ActionElementTag.Effects.ToString());
        }

        public virtual bool VerifyPreconditions()
        {
            throw new System.NotImplementedException();
        }
    }
}