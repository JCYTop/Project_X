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

namespace Framework.GOAP
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
                var element = ActionGroup.ActionConfigUnitSet.GetSortListValue(ActionElementTag.Cost.ToString());
                var intValue = element.CastStateConfigEle<int>();
                return intValue;
            }
        }

        public int Priority
        {
            get
            {
                var element = ActionGroup.ActionConfigUnitSet.GetSortListValue(ActionElementTag.Priority.ToString());
                var intValue = element.CastStateConfigEle<int>();
                return intValue;
            }
        }

        public bool CanInterruptiblePlan
        {
            get
            {
                var element = ActionGroup.ActionConfigUnitSet.GetSortListValue(ActionElementTag.Interruptible.ToString());
                var boolValue = element.CastStateConfigEle<bool>();
                return boolValue;
            }
        }

        public TAction Label { get; private set; }

        public ActionBase(TAction tag, ActionConfigUnit<TConfigElementTag> actionGroup)
        {
            this.Label = tag;
            this.ActionGroup = actionGroup;
        }

        public T GetActionData<T>(string tag)
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