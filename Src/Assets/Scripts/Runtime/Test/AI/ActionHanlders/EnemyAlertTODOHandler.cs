using System;
using Framework.Event;

namespace Framework.GOAP
{
    public class EnemyAlertTODOHandler : ActionHandler
    {
        public override void AddFinishCallBack(Action onFinishAction)
        {
            this.onFinishAction = onFinishAction;
        }

        public override void Enter(IContext context, Action callback)
        {
            LogTool.Log($"进入AlertLog通知");
            base.Enter(context, callback);
            EventDispatcher.Instance().OnEmitEvent(GOAPEventType.ActionChangeState, new object[] {context.GoalbalID, "Alert"});
            if (callback != null)
                callback();
        }

        public override void Execute(IContext context, Action callback)
        {
            base.Execute(context, callback);
            LogTool.Log($"进入ExecuteLog通知");
            if (callback != null)
                callback();
        }

        public override void Exit(IContext context, Action callback)
        {
            LogTool.Log($"进入ExitLog通知");
            if (callback != null)
                callback();
            base.Exit(context, callback);
        }
    }
}