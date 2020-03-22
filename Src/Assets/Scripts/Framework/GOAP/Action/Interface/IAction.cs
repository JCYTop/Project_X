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

using System.Collections.Generic;

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
        /// 当前动作是否能够中断
        /// </summary>
        bool CanInterruptiblePlan { get; }

        /// <summary>
        /// 执行动作
        /// 先决条件
        /// </summary>
        ICollection<CondtionAssembly> Conditions { get; }

        /// <summary>
        /// 动作执行后
        /// 影响状态结果
        /// </summary>
        ICollection<CondtionAssembly> Effects { get; }
     
    }

    /// <summary>
    /// IAction扩展方法
    /// </summary>
    public static class IActionExtend
    {
        /// <summary>
        /// 获取Action中配置的Effects值
        /// </summary>
        /// <param name="action"></param>
        /// <param name="tag"></param>
        /// <typeparam name="TAction"></typeparam>
        /// <returns></returns>
        public static CondtionAssembly GetEffectsValue<TAction>(this IAction<TAction> action, CondtionTag tag)
        {
            foreach (var effect in action.Effects)
            {
                if (effect.ElementTag == tag)
                {
                    return effect;
                }
            }

            return default;
        }

        /// <summary>
        /// 获取Action中配置的Conditions值
        /// </summary>
        /// <param name="action"></param>
        /// <param name="tag"></param>
        /// <typeparam name="TAction"></typeparam>
        /// <returns></returns>
        public static CondtionAssembly GetConditionsValue<TAction>(this IAction<TAction> action, CondtionTag tag)
        {
            foreach (var effect in action.Conditions)
            {
                if (effect.ElementTag == tag)
                {
                    return effect;
                }
            }

            return default;
        }
    }

    /// <summary>
    /// 执行动作标签
    /// 用在 IAction
    /// ActionHandler也有关联
    /// </summary>i
    public enum ActionTag
    {
        #region Common通用各个AI的动作处理器  0~199

        /// <summary>
        /// 默认标签
        /// </summary>
        Default = 0,

        /// <summary>
        /// 待机
        /// 动作标签
        /// </summary>
        Idle = 1,

        /// <summary>
        /// 行走
        /// 动作标签
        /// </summary>
        Walk = 2

        #endregion
    }
}