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

        private IAgent<ActionTag, GoalTag> agent;
        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public IAgent<ActionTag, GoalTag> Agent => agent;
        public EnemyAllActionConfig ActionConfig => actionConfig;
        public EnemyAllGoal GoalConfig => goalConfig;

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
            StartFSM();
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