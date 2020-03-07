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
            EnemyContext.ActionConfig.Init();
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