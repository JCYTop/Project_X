/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IPlanHandler
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/17 22:15:29
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace Framework.GOAP
{
    public interface IPlanHandler<TAction, TGoal>
    {
        /// <summary>
        /// 不同的计划可以随时改变
        /// </summary>
        IPlanner<TAction, TGoal> Planner { get; set; }

        /// <summary>
        /// 当前计划是否完成
        /// </summary>
        bool IsComplete { get; }

        /// <summary>
        /// 完成回调
        /// </summary>
        /// <param name="onComplete"></param>
        void AddCompleteCallBack(Action onComplete);

        /// <summary>
        /// 执行下一个动作
        /// </summary>
        void HandlerAction();

        /// <summary>
        /// 中断计划
        /// </summary>
        void Interruptible();

        /// <summary>
        /// 获取当前动作处理器
        /// </summary>
        /// <returns></returns>
        IActionHandler<TAction> GetCurrentHandler();
    }
}