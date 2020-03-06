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

        public override void InitActionConfig()
        {
            //TODO 等待对接
            //TODO 应该写个额外扩展类处理这个问题
            //TODO 应该直接处理Handle类
            agent.GetAgent<EnemyAgent>().InitActionManager();
            actionConfig.Init();
        }

        public override void InitGoalConfig()
        {
            //TODO 等待对接
            goalConfig.Init();
        }

        public override void InitStateConfig()
        {
            agent.GetAgent<EnemyAgent>().InitStateManager();
        }
    }
}