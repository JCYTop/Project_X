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
using System.Linq;

namespace Framework.GOAP
{
    /// <summary>
    /// Action管理类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public abstract class ActionManagerBase<TAction, TGoal> : IActionManager<TAction>
    {
        /// <summary>
        /// 动作完成的回调
        /// </summary>
        protected Action<TAction> onActionComplete;

        protected IAgent<TAction, TGoal> agent;

        /// <summary>
        /// 动作字典
        /// </summary>
        protected SortedList<TAction, IActionHandler<TAction>> handlersSort;

        /// <summary>
        /// 能够打断计划的动作
        /// </summary>
        private List<IActionHandler<TAction>> interruptibleHandlers;

        public bool IsPerformAction { get; set; }
        public List<IActionHandler<TAction>> InterruptibleHandlers => interruptibleHandlers;
        public Dictionary<TAction, HashSet<IActionHandler<TAction>>> Effect_Action_Map { get; }

        public ActionManagerBase(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
            handlersSort = new SortedList<TAction, IActionHandler<TAction>>();
            interruptibleHandlers = new List<IActionHandler<TAction>>();
            InitActionHandlers();
            InitInterruptiblers();
            InitEffect_Action_Map();
        }

        /// <summary>
        /// 初始化当前代理的动作处理器
        /// </summary>
        protected abstract void InitActionHandlers();

        /// <summary>
        /// 初始化能够打断计划的动作缓存
        /// </summary>
        private void InitInterruptiblers()
        {
            foreach (var handler in handlersSort.Values)
            {
                if (handler.Action.CanInterruptiblePlan)
                {
                    interruptibleHandlers.Add(handler);
                }
            }

            interruptibleHandlers = interruptibleHandlers.OrderByDescending(u => u.Action.Priority).ToList();
        }

        /// <summary>
        /// 初始化动作和动作影响的映射
        /// </summary>
        private void InitEffect_Action_Map()
        {
            //TODO next step 处理这里
        }

        public abstract TAction GetDefaultActionLabel();

        public IActionHandler<TAction> GetHandler(TAction actionLabel)
        {
            return handlersSort.GetSortListValue(actionLabel);
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