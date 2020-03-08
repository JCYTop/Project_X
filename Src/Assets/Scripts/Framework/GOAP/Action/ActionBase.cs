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

namespace GOAP
{
    /// <summary>
    /// 每一个具体的Action
    /// 通过读取具体的配置文件信息生成一个具体的类
    /// 数据类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public abstract class ActionBase<TAction, TConfigElementTag> : IAction<TAction>
    {
        public ActionConfigUnit<TConfigElementTag> ActionGroup { get; private set; }
        public TAction Label { get; private set; }
        public int Priority { get; }
        public int Cost { get; }
        public abstract bool CanInterruptiblePlan { get; }
        public IState PreConditions { get; }
        public IState Effects { get; }

        public ActionBase(TAction tag, ActionConfigUnit<TConfigElementTag> actionGroup)
        {
            this.Label = tag;
            this.ActionGroup = actionGroup;
//            this.Effects = InitEffects();
//            this.PreConditions = InitPreConditions();
        }

        protected abstract IState InitEffects();
        protected abstract IState InitPreConditions();

        public virtual bool VerifyPreconditions()
        {
            throw new System.NotImplementedException();
        }
    }
}