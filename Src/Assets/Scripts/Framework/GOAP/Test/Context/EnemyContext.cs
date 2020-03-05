using System;
using UnityEngine;

namespace GOAP
{
    public class EnemyContext : AIContextBase<EnemyContext>
    {
        #region variable

        [SerializeField] private PlayMakerFSM stateFsm;
        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public override PlayMakerFSM StateFsm => stateFsm;
        public override EnemyContext GetReturnContext { get; }

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