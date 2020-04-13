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

using System.Collections.Generic;
using System.Linq;
using Framework.Event;

namespace Framework.GOAP
{
    /// <summary>
    /// Action管理类
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public abstract class ActionMgr<TAction, TGoal> : IActionMgr<TAction>
    {
        protected IAgent<TAction, TGoal> agent;

        /// <summary>
        /// 正在使用的动作
        /// </summary>
        public IActionHandler<TAction> CurrHandle { get; private set; }

        /// <summary>
        /// 动作完成的回调
        /// </summary>
        protected System.Action<TAction> onActionComplete;

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

            //初始化能够打断计划的动作缓存
            void InitInterruptiblers()
            {
                foreach (var handler in handlersSort.Values)
                {
                    if (handler.Action.IsInterruptiblePlan)
                    {
                        interruptibleHandlers.Add(handler);
                    }
                }

                interruptibleHandlers = interruptibleHandlers.OrderByDescending(u => u.Action.Priority).ToList();
            }

            //初始化动作和动作影响的映射
            void Init_Effect_Action_Map()
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

        public IActionHandler<TAction> GetHandler(TAction actionLabel)
        {
            return handlersSort.GetSortListValue(actionLabel);
        }

        /// <summary>
        /// 执行新动作
        /// </summary>
        /// <param name="action"></param>
        public void ExcuteHandler(IActionHandler<TAction> action)
        {
            CurrHandle = action;
            EventDispatcher.Instance().OnEmitEvent(GOAPEventType.ActionMgrExcuteHandler, new object[] {agent.Context.GoalbalID, CurrHandle});
        }

        /// <summary>
        /// Planner计划中使用
        /// </summary>
        /// <param name="actionComplete"></param>
        public void AddActionCompleteListener(System.Action<TAction> actionComplete)
        {
            this.onActionComplete = actionComplete;
        }
    }
}