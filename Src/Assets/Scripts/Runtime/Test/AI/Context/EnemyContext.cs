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
        [SerializeField] private FsmTemplate fsmTemplate;
        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public IAgent<ActionTag, GoalTag> Agent => agent;
        public EnemyAllActionConfig ActionConfig => actionConfig;
        public EnemyAllGoal GoalConfig => goalConfig;

        #endregion

        public override void Init()
        {
            base.Init();
            agent = new EnemyAgent(this);
            StateFsm.SetFsmTemplate(fsmTemplate);
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