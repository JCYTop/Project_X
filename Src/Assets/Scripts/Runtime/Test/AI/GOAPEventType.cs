namespace Framework.GOAP
{
    public class GOAPEventType
    {
        #region Action 

        /// <summary>
        /// 动作管理器执行相应的动作事件
        /// </summary>
        public const string ActionMgrExcuteHandler = "ActionMgrExcuteHandler";

        /// <summary>
        /// 动作执行改变当前状态
        /// </summary>
        public const string ActionChangeState = "ActionChangeState";

        #endregion

        #region Condition

        /// <summary>
        /// 目标发生改变的事件
        /// </summary>
        public const string ChangeTarget = "ChangeTarget";

        /// <summary>
        /// 条件发生改变的事件
        /// </summary>
        public const string ChangeCondition = "ChangeCondition";

        #endregion

        #region State 

        /// <summary>
        /// 状态机状态发生变化
        /// </summary>
        public const string StateChange = "StateChange";

        #endregion
    }
}