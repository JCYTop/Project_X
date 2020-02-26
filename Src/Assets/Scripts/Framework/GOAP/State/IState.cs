/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IState
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/24 23:42:12
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 存储每一个状态
    /// 如果不使用State就需要使用单独的数据关系表
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 环境数据
        /// 调用环境中的基础参数来进行状态参数的基准设定
        /// 此处使用仅此以上使用情况
        /// </summary>
        IContext Context { get; }

        /// <summary>
        /// 清空数据
        /// </summary>
        void Clear();

        /// <summary>
        /// 注册事件
        /// 用于State事件
        /// </summary>
        void RegiestEvent();

        /// <summary>
        /// 注销事件
        /// 用于State事件
        /// </summary>
        void UnRegiestEvent();

        /// <summary>
        /// 初始化信息
        /// </summary>
        void Init();

        /// <summary>
        /// 进入动作
        /// </summary>
        void Enter();

        /// <summary>
        /// 更新动作
        /// </summary>
        void Execute();

        /// <summary>
        /// 退出动作
        /// </summary>
        void Exit();

        /// <summary>
        /// 设置参数
        /// </summary>
        void SetData();

        /// <summary>
        /// 获取参数
        /// </summary>
        StateConfig GetData();
    }

    /// <summary>
    /// 状态参数
    /// AIStateBase中用于键值查找
    /// 一个键值对应一个“功能类”或一个“Editor”类
    /// </summary>
    public enum StateElement
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0, 
    }
}