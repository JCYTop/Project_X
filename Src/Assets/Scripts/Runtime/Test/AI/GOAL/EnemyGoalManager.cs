namespace GOAP
{
    public class EnemyGoalManager : GoalManagerBase<ActionEnemyTag, GoalEnemyTag>
    {
        public EnemyAgent EnemyAgent => agent.GetAgent<EnemyAgent>();
        public EnemyContext EnemyContext => EnemyAgent.Context.GetContext<EnemyContext>();

        public EnemyGoalManager(IAgent<ActionEnemyTag, GoalEnemyTag> agent) : base(agent)
        {
        }

        protected override void InitGoals()
        {
            EnemyContext.GoalConfig.Init();
        }
    }
}