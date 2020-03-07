/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionManagerBase
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 22:33:46
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace GOAP
{
    /// <summary>
    /// Action管理类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public abstract class ActionManagerBase<TAction, TGoal> : IActionManager<TAction>
    {
        protected IAgent<TAction, TGoal> agent;

        /// <summary>
        /// 动作字典
        /// </summary>
        private Dictionary<TAction, IActionHandler<TAction>> actionHandlerDic;

        /// <summary>
        /// 能够打断计划的动作
        /// </summary>
        private List<IActionHandler<TAction>> interruptibleHandlers;

        public bool IsPerformAction { get; set; }
        public Dictionary<TAction, HashSet<IActionHandler<TAction>>> EffectsAndActionMap { get; }

        public ActionManagerBase(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
            actionHandlerDic = new Dictionary<TAction, IActionHandler<TAction>>();
            interruptibleHandlers = new List<IActionHandler<TAction>>();
            InitActionHandlers();
//            InitActionStateHandlers();
//            InitEffectsAndActionMap();
//            InitInterruptibleDic();
        }

        /// <summary>
        /// 初始化当前代理的动作处理器
        /// </summary>
        protected abstract void InitActionHandlers();

        /// <summary>
        /// 初始化当前可叠加执行动作处理器
        /// </summary>
        protected abstract void InitActionStateHandlers();

        /// <summary>
        /// 初始化动作和动作影响的映射
        /// </summary>
        protected abstract void InitEffectsAndActionMap();

        /// <summary>
        /// 初始化能够打断计划的动作缓存
        /// </summary>
        protected abstract void InitInterruptibleDic();

        public abstract TAction GetDefaultActionLabel();

        public void AddActionHandler(TAction actionLabel)
        {
            AddHandler(actionLabel, actionHandlerDic);
        }

        private void AddHandler(TAction actionLabel, Dictionary<TAction, IActionHandler<TAction>> actionHandlers)
        {
//            agent
        }

        public void RemoveHandler(TAction actionLabel)
        {
            actionHandlerDic.Remove(actionLabel);
        }

        public IActionHandler<TAction> GetHandler(TAction actionLabel)
        {
            return actionHandlerDic.GetDictionaryValue(actionLabel);
        }

        public void ExcuteNewState(TAction actionLabel)
        {
            throw new NotImplementedException();
        }

        public void AddActionCompleteListener(Action<TAction> actionComplete)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void UpdateData()
        {
            throw new NotImplementedException();
        }
    }
}