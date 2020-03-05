using System;
using UnityEngine;

namespace GOAP
{
    public class EnemyContext : AIContextBase<EnemyContext>
    {
        #region variable

        [SerializeField] private PlayMakerFSM stateFsm;
        [SerializeField] private FsmTemplate fsmTemplateConfig;
        [SerializeField] private EnemyAllActionConfig actionConfig;
        [SerializeField] private EnemyAllGoal goalConfig;
        public override PlayMakerFSM StateFsm => stateFsm;
        public override FsmTemplate FsmTemplateConfig => fsmTemplateConfig;
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

        public override void InitFSM()
        {
            try
            {
                stateFsm.SetFsmTemplate(fsmTemplateConfig);
            }
            catch (Exception e)
            {
                LogTool.LogException(e);
                throw;
            }
        }

        public override void InitStateConfig()
        {
//            throw new System.NotImplementedException();
        }
    }
}