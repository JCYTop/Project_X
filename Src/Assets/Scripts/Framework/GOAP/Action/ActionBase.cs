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
    /// <summary>
    /// 每一个具体的Action
    /// 通过读取具体的配置文件信息生成一个具体的类
    /// </summary>
    /// <typeparam name="TAction">由类传入string</typeparam>
    [Serializable]
    public abstract class ActionBase<TAction, TGoal> : IAction<TAction>
    {
        private IAgent<TAction, TGoal> agent;
        public ActionUnityGroup ActionUnityGroup { get; }
        public abstract TAction Label { get; }
        public int Priority { get; }
        public int Cost { get; }
        public bool CanInterruptiblePlan { get; }
        public IState PreConditions { get; }
        public IState Effects { get; }

        public ActionBase(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
            Effects = InitEffects();
            PreConditions = InitPreConditions();
        }

        protected abstract IState InitEffects();
        protected abstract IState InitPreConditions();

        public virtual bool VerifyPreconditions()
        {
            throw new System.NotImplementedException();
        }
    }
}