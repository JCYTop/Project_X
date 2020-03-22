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

using System.Collections.Generic;

namespace Framework.GOAP
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
        /// 获得权重值
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 进入条件
        /// </summary>
        ICollection<CondtionAssembly> Condition { get; }

        /// <summary>
        /// 是否已经实现目标
        /// </summary>
        /// <returns></returns>
        bool IsGoalComplete();

        /// <summary>
        /// 添加目标激活的监听
        /// </summary>
        /// <param name="onActivate"></param>
        void AddGoalActivateListener(System.Action<IGoal<TGoal>> onActivate);

        /// <summary>
        /// 添加目标未激活的监听
        /// </summary>
        /// <param name="onInactivate"></param>
        void AddGoalInactivateListener(System.Action<IGoal<TGoal>> onInactivate);
    }

    /// <summary>
    /// Goal标签
    /// 状态配置文件标签
    /// 每个标签对应这当前Goal的类
    /// 方便通过标签快速查找类
    /// </summary>
    public enum GoalTag
    {
        #region Common 0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 正常状态
        /// </summary>
        Idle = 1,

        /// <summary>
        /// 正常状态
        /// 到达目标周围
        /// </summary>
        Idle_To_Target,

        #endregion

        #region 敌人 200~399

        /// <summary>
        /// 警戒
        /// </summary>
        Alert = 200,

        /// <summary>
        /// 攻击
        /// </summary>
        Attack = 201,

        /// <summary>
        /// 逃跑
        /// </summary>
        Runaway = 202,

        #endregion
    }
}