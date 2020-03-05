/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IGoal
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 23:07:05
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    /// <summary>
    /// GOAL接口
    /// </summary>
    /// <typeparam name="TGoal">由类传入string</typeparam>
    public interface IGoal<TGoal>
    {
        /// <summary>
        /// 目标的标签
        /// </summary>
        TGoal Label { get; }

        /// <summary>
        /// 获取优先级
        /// </summary>
        /// <returns></returns>
        int GetPriority();

        /// <summary>
        /// 获取目标对状态的影响
        /// </summary>
        /// <returns></returns>
        IState GetEffects();

        /// <summary>
        /// 获取目标激活的条件
        /// </summary>
        /// <returns></returns>
        IState GetActiveCondition();

        /// <summary>
        /// 是否已经实现目标
        /// </summary>
        /// <returns></returns>
        bool IsGoalComplete();

        /// <summary>
        /// 添加目标激活的监听
        /// </summary>
        /// <param name="onActivate"></param>
        void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate);

        /// <summary>
        /// 添加目标未激活的监听
        /// </summary>
        /// <param name="onInactivate"></param>
        void AddGoalInactivateListener(Action<IGoal<TGoal>> onInactivate);

        /// <summary>
        /// 更新数据
        /// </summary>
        void UpdateData();
    }

    /// <summary>
    /// Goal标签
    /// 状态配置文件标签
    /// 每个标签对应这当前Goal的类
    /// 方便通过标签快速查找类
    /// </summary>
    public enum GoalCommonTag
    {
        #region Common 0~199

        /// <summary>
        /// 默认标签
        /// </summary>
        Default = 0,

        #endregion
    }

    public enum GoalEnemyTag
    {
        Default = GoalCommonTag.Default,
    }
}