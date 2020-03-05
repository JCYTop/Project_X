using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class EnemyContext : AIContextBase
    {
        #region variable

        private IAgent<ActionEnemyTag, GoalEnemyTag> agent;
        private SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> stateDic;
        [SerializeField] private PlayMakerFSM stateFsm;
        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>> StateDic => stateDic;
        public override PlayMakerFSM StateFsm => stateFsm;

        #endregion

        public override void Init()
        {
            agent = new EnemyAgent(this);
            stateDic = new SortedList<EnemyStateTag, AIStateBase<EnemyContext, EnemyStateConfig>>();
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
            actionConfig.Init();
        }

        public override void InitGoalConfig()
        {
            //TODO 等待对接
            goalConfig.Init();
        }

        public override void InitStateConfig()
        {
            //TODO 等待对接
        }

        public override IAgent<TAction, TGoal> Agent<TAction, TGoal>()
        {
            return agent as IAgent<TAction, TGoal>;
        }
    }
}