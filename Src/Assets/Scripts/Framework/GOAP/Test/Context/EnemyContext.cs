using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class EnemyContext : AIContextBase<EnemyContext>
    {
        #region variable

        private SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> stateDic;
        [SerializeField] private PlayMakerFSM stateFsm;
        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> StateDic => stateDic;
        public override PlayMakerFSM StateFsm => stateFsm;
        public override EnemyContext GetReturnContext { get; }

        #endregion

        public override void Init()
        {
            stateDic = new SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>>();
        }

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
        }
    }
}