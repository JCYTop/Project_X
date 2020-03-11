namespace Framework.GOAP
{
    public class EnemyGoalMgr : GoalMgrBase<ActionTag, GoalEnemyTag>
    {
        public EnemyAgent EnemyAgent => agent.GetAgent<EnemyAgent>();
        public EnemyContext EnemyContext => EnemyAgent.Context.GetContext<EnemyContext>();

        public EnemyGoalMgr(IAgent<ActionTag, GoalEnemyTag> agent) : base(agent)
        {
        }

        protected override void InitGoals()
        {
            EnemyContext.GoalConfig.Init();
        }
    }
}