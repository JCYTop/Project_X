/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IContext
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/25 22:52:55
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 与Mono关联的环境接口
    /// 所有Mono数据从接口获取
    /// 主要是一些组件信息
    /// 提供给IAgent数据使用
    /// 属于数据类
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// 基础初始化
        /// </summary>
        void Init();

        /// <summary>
        /// 初始化动作配置信息 
        /// </summary>
        void InitActionConfig();

        /// <summary>
        /// 初始化目标配置信息
        /// </summary>
        void InitGoalConfig();

        /// <summary>
        /// 初始化状态信息
        /// </summary>
        void InitStateConfig();

        /// <summary>
        /// 获取环境指定类型
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        TContext GetContext<TContext>() where TContext : class, IContext;

        /// <summary>
        /// 获取环境所代理的Agent
        /// </summary>
        /// <typeparam name="TAction">Action标签</typeparam>
        /// <typeparam name="TGoal">Goal标签</typeparam>
        /// <returns></returns>
        IAgent<TAction, TGoal> Agent<TAction, TGoal>() where TAction : struct where TGoal : struct;
    }
}