namespace GOAP
{
    public class EnemyActionManager : ActionManagerBase<ActionEnemyTag, GoalEnemyTag>
    {
        public EnemyAgent EnemyAgent => agent.GetAgent<EnemyAgent>();
        public EnemyContext EnemyContext => EnemyAgent.Context.GetContext<EnemyContext>();

        public EnemyActionManager(IAgent<ActionEnemyTag, GoalEnemyTag> agent) : base(agent)
        {
        }

        protected override void InitActionHandlers()
        {
            var list = EnemyContext.ActionConfig.Init();
            foreach (var unit in list)
            {
                var action = new EnemyAction(unit.Key, unit.Value);
                var handle = EnemyActionHandleMap.Instance().GetHandle(unit.Key);
                handle.Init(action);
                handle.AddFinishCallBack(() =>
                {
                    LogTool.Log($"动作执行完成开始执行回调 {handle.Label}", LogEnum.NormalLog);
                    onActionComplete(handle.Label);
                });
                handlersSort.Add(handle.Label, handle);
            }
        }

        public override ActionEnemyTag GetDefaultActionLabel()
        {
            throw new System.NotImplementedException();
        }
    }
}