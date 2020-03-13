/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionBase
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
    //TODO 添加一个通用提取API

    /// <summary>
    /// 每一个具体的Action
    /// 通过读取具体的配置文件信息生成一个具体的类
    /// 数据类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public abstract class ActionBase<TAction> : IAction<TAction>
    {
        private ICollection<StateConfigUnitsss> conditions;
        private ICollection<StateConfigUnitsss> effects;

        public ActionConfigUnit ActionGroup { get; private set; }

        public ICollection<StateConfigUnitsss> Conditions
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

        public ICollection<StateConfigUnitsss> Effects
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

        public ActionBase(TAction tag, ActionConfigUnit actionGroup)
        {
            this.Label = tag;
            this.ActionGroup = actionGroup;
        }

        private ICollection<StateConfigUnitsss> InitConditions()
        {
            return (ICollection<StateConfigUnitsss>) ActionGroup.ConfigUnitSet.GetSortListValue(ActionElementTag.Preconditions.ToString());
        }

        private ICollection<StateConfigUnitsss> InitEffects()
        {
            return (ICollection<StateConfigUnitsss>) ActionGroup.ConfigUnitSet.GetSortListValue(ActionElementTag.Effects.ToString());
        }

        public virtual bool VerifyPreconditions()
        {
            throw new System.NotImplementedException();
        }
    }
}