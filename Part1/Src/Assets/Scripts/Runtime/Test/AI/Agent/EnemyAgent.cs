/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     EnemyAgent
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/05 22:31:22
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using Framework.Event;

namespace Framework.GOAP
{
    public class EnemyAgent : Agent<ActionTag, GoalTag>
    {
        private EnemyContext EnemyContext => Context.GetContext<EnemyContext>();
        public override bool IsAgentOver { get; set; } = false;

        public EnemyAgent(IContext context) : base(context)
        {
            //初始化到指定 --->>> Context 方便全局调用
            AgentStateMgr = new EnemyStateMgr();
            AgentActionMgr = new EnemyActionMgr(this);
            AgentGoalMgr = new EnemyGoalMgr(this);
            Performer = new EnemyPerformer(this);
        }

        public override void RegiestEvent()
        {
            EventDispatcher.Instance().OnRegiestEvent(GOAPEventType.ChangeCondition, ChangeCondition);
            EventDispatcher.Instance().OnRegiestEvent(GOAPEventType.ActionChangeState, ActionChangeState);
        }

        public override void UnRegiestEvent()
        {
            EventDispatcher.Instance().OnUnRegiestEvent(GOAPEventType.ChangeCondition, ChangeCondition);
            EventDispatcher.Instance().OnUnRegiestEvent(GOAPEventType.ActionChangeState, ActionChangeState);
        }

        private void ActionChangeState(object[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (EnemyContext.GoalbalID != Convert.ToInt32(args[0]))
                    return;
                TargetEvent(args[1].ToString());
            }
        }

        /// <summary>
        /// 改变判断条件通知设定计划
        /// </summary>
        /// <param name="args"></param>
        private void ChangeCondition(object[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (EnemyContext.GoalbalID != Convert.ToInt32(args[0]))
                    return;
                Performer.UpdateData();
            }
        }

        public override void TargetEvent(string eventName)
        {
            EnemyContext.StateFsm.Fsm.Event(eventName);
        }
    }
}