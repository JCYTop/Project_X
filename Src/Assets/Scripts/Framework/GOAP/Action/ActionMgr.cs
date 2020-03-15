/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionMgr
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
    public abstract class ActionMgr<TAction, TGoal> : IActionMgr<TAction>
    {
        /// <summary>
        /// 动作完成的回调
        /// </summary>
        protected System.Action<TAction> onActionComplete;

        protected IAgent<TAction, TGoal> agent;

        /// <summary>
        /// 动作字典列表
        /// </summary>
        protected SortedList<TAction, IActionHandler<TAction>> handlersSort;

        /// <summary>
        /// 能够打断计划的动作
        /// </summary>
        private List<IActionHandler<TAction>> interruptibleHandlers;

        public List<IActionHandler<TAction>> InterruptibleHandlers => interruptibleHandlers;
        private Dictionary<CondtionTag, HashSet<IActionHandler<TAction>>> effectActionMap;
        public Dictionary<CondtionTag, HashSet<IActionHandler<TAction>>> EffectActionMap => effectActionMap;
        public bool IsPerformAction { get; set; }

        public ActionMgr(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
            handlersSort = new SortedList<TAction, IActionHandler<TAction>>();
            interruptibleHandlers = new List<IActionHandler<TAction>>();
            InitActionHandlers();
            InitInterruptiblers();
            Init_Effect_Action_Map();
        }

        /// <summary>
        /// 初始化当前代理的动作处理器
        /// </summary>
        protected abstract void InitActionHandlers();

        /// <summary>
        /// 获得默认标签值
        /// </summary>
        /// <returns></returns>
        public abstract TAction GetDefaultActionLabel();

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
        private void Init_Effect_Action_Map()
        {
            effectActionMap = new Dictionary<CondtionTag, HashSet<IActionHandler<TAction>>>();
            foreach (var handler in handlersSort)
            {
                var effects = handler.Value.Action.Effects;
                if (effects.Count <= 0)
                    continue;
                foreach (var assembly in effects)
                {
                    if (!effectActionMap.ContainsKey(assembly.ElementTag) || effectActionMap[assembly.ElementTag] == null)
                    {
                        effectActionMap.Add(assembly.ElementTag, new HashSet<IActionHandler<TAction>>());
                    }

                    effectActionMap[assembly.ElementTag].Add(handler.Value);
                }
            }
        }

        public IActionHandler<TAction> GetHandler(TAction actionLabel)
        {
            return handlersSort.GetSortListValue(actionLabel);
        }

        /// <summary>
        /// 执行新动作
        /// </summary>
        /// <param name="actionLabel"></param>
        public void ExcuteHandler(TAction actionLabel)
        {
            //TODO next step
        }

        /// <summary>
        /// Planner计划中使用
        /// </summary>
        /// <param name="actionComplete"></param>
        public void AddActionCompleteListener(System.Action<TAction> actionComplete)
        {
            this.onActionComplete = actionComplete;
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