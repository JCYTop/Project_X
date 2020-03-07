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
            //TODO 这里处理各个子Action
            var list = EnemyContext.ActionConfig.Init();
            foreach (var unit in list)
            {
                LogTool.Log($"{unit}");
                //TODO 先生成一个具体的Action
                var action = new EnemyAction(unit.Key, unit.Value);
                //TODO 穿值之后构建Handle
                var handle = EnemyActionHandleMap.Instance().GetHandle(unit.Key);
            }
        }

        protected override void InitActionStateHandlers()
        {
            throw new System.NotImplementedException();
        }

        protected override void InitEffectsAndActionMap()
        {
            throw new System.NotImplementedException();
        }

        protected override void InitInterruptibleDic()
        {
            throw new System.NotImplementedException();
        }

        public override ActionEnemyTag GetDefaultActionLabel()
        {
            throw new System.NotImplementedException();
        }
    }
}