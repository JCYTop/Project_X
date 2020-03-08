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

using System;

namespace GOAP
{
    //TODO 添加一个通用提取API

    /// <summary>
    /// 每一个具体的Action
    /// 通过读取具体的配置文件信息生成一个具体的类
    /// 数据类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public abstract class ActionBase<TAction, TConfigElementTag> : IAction<TAction>
    {
        public ActionConfigUnit<TConfigElementTag> ActionGroup { get; private set; }
        public IState PreConditions => InitPreConditions();
        public IState Effects => InitEffects();

        public int Cost
        {
            get
            {
                var interruptible = ActionGroup.ActionConfigUnitSet.GetSortListValue(ActionCommonElementTag.Cost.ToString());
                var intValue = interruptible.CastStateConfigEle<ValueAggregation>();
                return intValue.Data;
            }
        }

        public int Priority
        {
            get
            {
                var interruptible = ActionGroup.ActionConfigUnitSet.GetSortListValue(ActionCommonElementTag.Priority.ToString());
                var intValue = interruptible.CastStateConfigEle<ValueAggregation>();
                return intValue.Data;
            }
        }

        public bool CanInterruptiblePlan
        {
            get
            {
                var interruptible = ActionGroup.ActionConfigUnitSet.GetSortListValue(ActionCommonElementTag.Interruptible.ToString());
                var boolValue = interruptible.CastStateConfigEle<BoolAggregation>();
                return boolValue.Data;
            }
        }

        public TAction Label { get; private set; }

        public ActionBase(TAction tag, ActionConfigUnit<TConfigElementTag> actionGroup)
        {
            this.Label = tag;
            this.ActionGroup = actionGroup;
        }

        public T GetActionData<T>(string tag) where T : IConfigElement
        {
            try
            {
                return (T) ActionGroup.ActionConfigUnitSet.GetSortListValue(tag);
            }
            catch (Exception e)
            {
                LogTool.LogException(e);
                throw;
            }
        }

        protected IState InitEffects()
        {
            throw new System.NotImplementedException();
        }

        protected IState InitPreConditions()
        {
            throw new System.NotImplementedException();
        }

        public virtual bool VerifyPreconditions()
        {
            throw new System.NotImplementedException();
        }
    }
}