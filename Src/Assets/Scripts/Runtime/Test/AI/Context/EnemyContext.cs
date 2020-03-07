using UnityEngine;

namespace GOAP
{
    public class EnemyContext : AIContextBase
    {
        #region variable

        private IAgent<ActionEnemyTag, GoalEnemyTag> agent;
        [SerializeField] private PlayMakerFSM stateFsm;
        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public IAgent<ActionEnemyTag, GoalEnemyTag> Agent => agent;
        public override PlayMakerFSM StateFsm => stateFsm;
        public EnemyAllActionConfig ActionConfig => actionConfig;
        public EnemyAllGoal GoalConfig => goalConfig;

        #endregion

        public override void Init()
        {
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

//        public override void InitGoalConfig()
//        {
////            goalConfig.Init();
//        }

        public override void InitStateConfig()
        {
            agent.GetAgent<EnemyAgent>().StartFSM();
        }
    }
}