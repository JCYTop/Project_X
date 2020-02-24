/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IAction
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 22:10:25
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 执行动作
    /// 加载配置文件信息
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// 权重等级，优先使用
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 花费使用，
        /// </summary>
        int Cost { get; }

        /// <summary>
        /// 当前动作是否能够中断
        /// </summary>
        bool CanInterruptiblePlan { get; }

        /// <summary>
        /// 执行动作
        /// 先决条件
        /// </summary>
        IState Preconditions { get; }

        /// <summary>
        /// 动作执行后
        /// 影响状态结果
        /// </summary>
        IState Effects { get; }
    }
}