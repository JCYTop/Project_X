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

namespace Framework.GOAP
{
    /// <summary>
    /// 执行动作
    /// 加载配置文件信息
    /// 由类传入string
    /// 有标记作用
    /// 指代不同动作类型
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public interface IAction<TAction>
    {
        /// <summary>
        /// 当前动作的标签
        /// Enum
        /// </summary>
        TAction Label { get; }

        /// <summary>
        /// 权重等级，优先使用
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 动作花费
        /// </summary>
        int Cost { get; }

        /// <summary>
        /// 获取配置信息中的标签信息
        /// </summary>
        /// <param name="tag"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetActionData<T>(string tag);

        /// <summary>
        /// 当前动作是否能够中断
        /// </summary>
        bool CanInterruptiblePlan { get; }

        /// <summary>
        /// 执行动作
        /// 先决条件
        /// 
        /// </summary>
        IState PreConditions { get; }

        /// <summary>
        /// 动作执行后
        /// 影响状态结果
        /// 
        /// </summary>
        IState Effects { get; }

        /// <summary>
        /// 验证先决条件
        /// 主要使用在是否可以进行打断的上面判断
        /// </summary>
        /// <returns></returns>
        bool VerifyPreconditions();
    }

    /// <summary>
    /// 执行动作标签
    /// 用在 IAction<TAction>
    /// </summary>i
    public enum ActionTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认标签
        /// </summary>
        Default = 0,

        /// <summary>
        /// 待机
        /// </summary>
        Idle = 1,

        #endregion
    }
}