/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IAction
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/20 23:53:24
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 相当于存储数据
    /// </summary>
    public interface IAction<TAction>
    {
        TAction Label { get; }

        /// <summary>
        /// 动作花费
        /// </summary>
        int Cost { get; }

        /// <summary>
        /// 权重等级
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 标记当前动作是否可以打断
        /// </summary>
        bool CanInterruptiblePlan { get; }

        /// <summary>
        /// 是否满足当前条件
        /// </summary>
        IState Preconditions { get; }

        /// <summary>
        /// 对当前状态可以产生的影响
        /// </summary>
        IState Effects { get; }

        /// <summary>
        /// 确认前置条件是否可行
        /// </summary>
        bool VerifyPrecondition();
    }
}