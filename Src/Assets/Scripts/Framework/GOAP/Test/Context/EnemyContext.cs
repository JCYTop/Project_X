using UnityEngine;

namespace GOAP
{
    public class EnemyContext : AIContextBase
    {
        #region variable

        private PlayMakerFSM stateFsm;
        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public PlayMakerFSM StateFsm => stateFsm;
        public override AIContextBase GetReturnContext { get; }

        #endregion

        public override void InitActionConfig()
        {
            actionConfig.Init();
        }

        public override void InitGoalConfig()
        {
            goalConfig.Init();
        }

        public override void InitStateConfig()
        {
//            throw new System.NotImplementedException();
        }
    }
}