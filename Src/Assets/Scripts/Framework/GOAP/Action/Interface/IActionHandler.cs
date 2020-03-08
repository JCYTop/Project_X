/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IActionHandle
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/03 22:44:24
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    /// <summary>
    /// 执行处理Action类
    /// 需要手动填写继承类
    /// 都在一个单例Mono中进行注册
    /// 每个AI在拿到当前的Action数据之后并且初始化之后
    /// 再去单例Mono中查找相应配置好的label进行查找并且完成最终Action数据和Handle的合并
    /// Handle比较特使会关联其他系统所以代码注册
    /// Handle设计最好的目标可以让不同种类的AI公用一种Handle，增加通用性
    /// </summary>
    public interface IActionHandler<TAction>
    {
        TAction Label { get; }
        IAction<TAction> Action { get; }

        /// <summary>
        /// 手动添加注册信息
        /// </summary>
        /// <param name="action"></param>
        /// <typeparam name="TAction"></typeparam>
        void Init(IAction<TAction> action);

        /// <summary>
        /// 动作执行状态
        /// </summary>
        ActionExcuteState ExcuteState { get; }

        /// <summary>
        /// 添加动作完成回调
        /// </summary>
        /// <param name="onFinishAction"></param>
        void AddFinishCallBack(Action onFinishAction);

        /// <summary>
        /// 进入动作
        /// 可以由动画事件进入
        /// 也可以由Playable进入设置
        /// Playable可控制
        /// </summary>
        void Enter();

        /// <summary>
        /// 更新动作
        /// 也可以由Playable进入设置
        /// Playable可控制
        /// </summary>
        void Execute();

        /// <summary>
        /// 退出动作
        /// 可以由动画事件进入
        /// 也可以由Playable进入设置
        /// Playable可控制
        /// </summary>
        void Exit();
    }

    /// <summary>
    /// 动作执行状态枚举
    /// </summary>
    public enum ActionExcuteState
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 初始化
        /// </summary>
        INIT = Default,

        /// <summary>
        /// 进入
        /// </summary>
        ENTER,

        /// <summary>
        /// 执行
        /// </summary>
        EXCUTE,

        /// <summary>
        /// 退出
        /// </summary>
        EXIT
    }

    public static class IActionHandlerExtend
    {
        public static void GetActionHand<TAction>(this IActionHandler<TAction> handler)
        {
        }
    }
}