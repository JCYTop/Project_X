using System;
using Framework.Event;
using HutongGames.PlayMaker;

namespace Framework.GOAP
{
    /// <summary>
    /// 测试类
    /// Fsm子状态
    /// </summary>
    [ActionCategory("AI.Enemy")]
    public class EnemyBattleState : AIState<EnemyContext, EnemyStateConfig>
    {
        private bool isExecuteState = false;
        private IActionHandler<ActionTag> currAction;
        private IActionHandler<ActionTag> preAction;
        private EnemyStateMgr EnemyStateMgr => GetContext.Agent.AgentStateMgr.GetStateMgr<EnemyStateMgr>();

        public override void AwakeState()
        {
            EnemyStateMgr.StateSortList.AddSortListElements(StateConfig.Tag, this);
        }

        public override void RegiestEvent()
        {
            base.RegiestEvent();
            EventDispatcher.Instance().OnceRegiestEvent(GOAPEventType.ActionMgrExcuteHandler, ActionMgrExcuteHandler);
        }

        public override void UnRegiestEvent()
        {
            base.UnRegiestEvent();
            EventDispatcher.Instance().OnUnRegiestEvent(GOAPEventType.ActionMgrExcuteHandler, ActionMgrExcuteHandler);
        }

        public override void EnterState()
        {
            base.EnterState();
            EnemyStateMgr.SetCurrActivity(StateConfig.Tag);
        }

        private void ActionMgrExcuteHandler(object[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (GetContext.GoalbalID != Convert.ToInt32(args[0]))
                    return;
                isExecuteState = false;
                currAction = args[1] as IActionHandler<ActionTag>;
                if (preAction == null)
                {
                    //直接执行CurrAction内容
                    if (currAction != null)
                        currAction.Enter(GetContext, () => { isExecuteState = true; });
                }
                else
                {
                    //有之前执行的动作不能直接执行
                    //需要先进行退出之前的Handle
                    //在载入之后的新Handle
                    preAction.Exit(GetContext, () =>
                    {
                        currAction.Enter(GetContext, () =>
                        {
                            preAction = currAction;
                            isExecuteState = true;
                        });
                    });
                }
            }
        }

        public override void ExecuteState()
        {
            base.ExecuteState();
            if (!isExecuteState)
                return;
            if (currAction == null)
                return;
            currAction.Execute(GetContext, () => { });
        }
    }
}