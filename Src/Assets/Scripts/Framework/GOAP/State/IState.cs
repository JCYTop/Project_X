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

using System;
using System.Collections.Generic;

namespace Framework.GOAP
{
    /// <summary>
    /// 存储每一个状态
    /// 如果不使用State就需要使用单独的数据关系表
    /// 先于Action初始化完成
    /// </summary>
    public interface IState
    {
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
        /// 初始化数据使用
        /// </summary>
        void AwakeState();

        /// <summary>
        /// 进入动作
        /// </summary>
        void EnterState();

        /// <summary>
        /// 更新动作
        /// </summary>
        void ExecuteState();

        /// <summary>
        /// 退出动作
        /// </summary>
        void ExitState();

        /// <summary>
        /// 添加数据修改监听
        /// </summary>
        /// <param name="onChange"></param>
        void AddStateChangeListener(Action callback);
    }

    /// <summary>
    /// 标签用于状态在注册之后形成对应组注册表
    /// 方便查找对应关系
    /// 要与State中的状态机全局标签相对应
    /// </summary>
    public enum StateTag
    {
        #region Common 0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 待机
        /// 初始化
        /// </summary>
        Idle,

        /// <summary>
        /// 战斗
        /// </summary>
        Battle,

        /// <summary>
        /// 警戒状态
        /// </summary>
        Alert,

        #endregion
    }
}