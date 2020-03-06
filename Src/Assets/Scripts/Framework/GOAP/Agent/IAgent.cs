/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IAgent
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 23:09:13
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 集合类
    /// Mono数据从这里拿取
    /// State数据从这里拿取
    /// </summary>
    /// <typeparam name="TAction">由类传入string</typeparam>
    public interface IAgent<TAction, TGoal>
    {
        /// <summary>
        /// 环境接口
        /// </summary>
        IContext Context { get; }

        /// <summary>
        /// 当前代理是否结束
        /// </summary>
        bool IsAgentOver { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        IState AgentState { get; }

        /// <summary>
        /// 获取映射数据对象
        /// </summary>
        /// <returns></returns>
//        IMaps<TAction, TGoal> Maps { get; }

        /// <summary>
        /// StateMgr管理器
        /// </summary>
        IStateManager AgentStateManager { get; }

        /// <summary>
        /// 获取动作管理类对象
        /// </summary>
        /// <returns></returns>
        IActionManager<TAction> AgentActionManager { get; }

        /// <summary>
        /// 获取目标管理类对象
        /// </summary>
        /// <returns></returns>
        IGoalManager<TGoal> AgentGoalManager { get; }

        /// <summary>
        /// 注册事件
        /// 用于Agent事件
        /// </summary>
        void RegiestEvent();

        /// <summary>
        /// 注销事件
        /// 用于Agent事件
        /// </summary>
        void UnRegiestEvent();

        /// <summary>
        /// 更新数据函数
        /// </summary>
        void UpdateData();

        /// <summary>
        /// 帧函数
        /// </summary>
        void Update();

        /// <summary>
        /// 获取相对应的Agent类型
        /// </summary>
        /// <typeparam name="TAgent">Agent类型</typeparam>
        /// <returns>Agent类型</returns>
        TAgent GetAgent<TAgent>() where TAgent : class, IAgent<TAction, TGoal>;
    }

    public static class IAgentExtend
    {
    }
}