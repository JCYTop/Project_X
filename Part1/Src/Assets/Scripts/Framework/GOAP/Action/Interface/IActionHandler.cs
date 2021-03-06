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

namespace Framework.GOAP
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
        /// 进入动作逻辑
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        void Enter(IContext context, Action callback);

        /// <summary>
        /// 更新动作逻辑
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        void Execute(IContext context, Action callback);

        /// <summary>
        /// 退出动作逻辑
        /// </summary>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        void Exit(IContext context, Action callback);
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
        Init,

        /// <summary>
        /// 进入
        /// </summary>
        Enter,

        /// <summary>
        /// 执行
        /// </summary>
        Excute,

        /// <summary>
        /// 退出
        /// </summary>
        Exit
    }
}