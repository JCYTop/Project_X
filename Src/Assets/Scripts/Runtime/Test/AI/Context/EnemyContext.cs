using System;
using UnityEngine;

namespace Framework.GOAP
{
    /// <summary>
    /// 三个相关联的数据要填写
    /// </summary>
    [RequireComponent(typeof(EnemyParameter))]
    [RequireComponent(typeof(EnemyDynamic))]
    [RequireComponent(typeof(EnemyCondition))]
    public class EnemyContext : AIContext<EnemyAllActionConfig, EnemyAllGoal>
    {
        #region variable

        private EnemyAgent agent;
        public EnemyAgent Agent => agent;

        #endregion

        protected override void Awake()
        {
            base.Awake();
            agent = new EnemyAgent(this);
        }

        protected override void Start()
        {
            base.Start();
            var ssss = Parameter.ParameterList;
        }

        private void OnEnable()
        {
            agent.RegiestEvent();
        }

        private void OnDisable()
        {
            agent.UnRegiestEvent();
        }

        private void Update()
        {
//            //测试
//            agent.AgentGoalMgr.FindGoal();
        }
    }
}