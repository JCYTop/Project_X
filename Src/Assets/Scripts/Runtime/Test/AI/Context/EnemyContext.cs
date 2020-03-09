using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyContext : AIContextBase
    {
        #region variable

        private IAgent<ActionEnemyTag, GoalEnemyTag> agent;

        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public IAgent<ActionEnemyTag, GoalEnemyTag> Agent => agent;
        public EnemyAllActionConfig ActionConfig => actionConfig;
        public EnemyAllGoal GoalConfig => goalConfig;

        #endregion

        public override void Init()
        {
            base.Init();
            agent = new EnemyAgent(this);
        }

        private void OnEnable()
        {
            agent.RegiestEvent();
        }

        private void OnDisable()
        {
            agent.UnRegiestEvent();
        }

        protected override void StartFSM()
        {
            agent.StartFSM();
        }
    }
}