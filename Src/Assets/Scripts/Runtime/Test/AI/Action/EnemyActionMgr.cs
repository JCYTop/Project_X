namespace Framework.GOAP
{
    public class EnemyActionMgr : ActionMgrBase<ActionTag, GoalTag>
    {
        public EnemyAgent EnemyAgent => agent.GetAgent<EnemyAgent>();
        public EnemyContext EnemyContext => EnemyAgent.Context.GetContext<EnemyContext>();

        public EnemyActionMgr(IAgent<ActionTag, GoalTag> agent) : base(agent)
        {
        }

        protected override void InitActionHandlers()
        {
            var list = EnemyContext.ActionConfig.Init();
            foreach (var unit in list)
            {
                var action = new EnemyAction(unit.Key, unit.Value);
                var handle = ActionHandlerMap.HandleMap.GetSortListValue(unit.Key);
                handle.Init(action);
                handle.AddFinishCallBack(() =>
                {
                    LogTool.Log($"动作执行完成开始执行回调 === {handle.Action.Label}", LogEnum.NormalLog);
                    onActionComplete(handle.Action.Label);
                });
                handlersSort.Add(handle.Action.Label, handle);
            }
        }

        public override ActionTag GetDefaultActionLabel()
        {
            throw new System.NotImplementedException();
        }
    }
}