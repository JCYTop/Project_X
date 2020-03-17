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
    public interface IPlanHandler<TAction>
    {
        /// <summary>
        /// 当前计划是否完成
        /// </summary>
        bool IsComplete { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="plan"></param>
        void Init();

        /// <summary>
        /// 完成回调
        /// </summary>
        /// <param name="onComplete"></param>
        void AddCompleteCallBack(Action onComplete);

        /// <summary>
        /// 开始执行计划
        /// </summary>
        void StartPlan();

        /// <summary>
        /// 执行下一个动作
        /// </summary>
        void NextAction();

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