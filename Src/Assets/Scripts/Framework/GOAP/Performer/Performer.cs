/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Performer
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/15 21:59:18
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace Framework.GOAP
{
    public abstract class Performer<TAction, TGoal> : IPerformer<TAction, TGoal>
    {
        protected IAgent<TAction, TGoal> agent;
        protected IPlanHandler<TAction, TGoal> planHandler;
        public IPlanHandler<TAction, TGoal> PlanHandler => planHandler;

        public Performer(IAgent<TAction, TGoal> agent)
        {
            this.agent = agent;
        }

        /// <summary>
        /// 更新数据函数
        /// 更新新的数据
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public abstract void UpdateData();

        /// <summary>
        /// 中断计划
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public abstract void Interruptible();

        public abstract void BuildPlan();
    }
}