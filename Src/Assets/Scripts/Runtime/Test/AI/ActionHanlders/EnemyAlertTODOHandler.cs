using System;
using UnityEngine;

namespace Framework.GOAP
{
    public class EnemyAlertTODOHandler : ActionHandler
    {
        public override void AddFinishCallBack(Action onFinishAction)
        {
            this.onFinishAction = onFinishAction;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("---");
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}