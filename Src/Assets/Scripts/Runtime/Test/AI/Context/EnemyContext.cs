using UnityEngine;

namespace Framework.GOAP
{
    /// <summary>
    /// 三个相关联的数据要填写
    /// </summary>
    [RequireComponent(typeof(EnemyParameter))]
    [RequireComponent(typeof(EnemyDynamic))]
    [RequireComponent(typeof(EnemyCondition))]
    public class EnemyContext : AIContextBase
    {
        #region variable

        private IAgent<ActionTag, GoalEnemyTag> agent;

        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public IAgent<ActionTag, GoalEnemyTag> Agent => agent;
        public EnemyAllActionConfig ActionConfig => actionConfig;
        public EnemyAllGoal GoalConfig => goalConfig;

        #endregion

        public override void InitAwake()
        {
            base.InitAwake();
            agent = new EnemyAgent(this);
    
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

        protected override void StartFSM()
        {
            agent.StartFSM();
        }
    }
}