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
        /// 添加数据修改监听
        /// </summary>
        /// <param name="onChange"></param>
        void AddStateChangeListener(Action callback);

        /// <summary>
        /// 反转当前state所有的value值
        /// 能反转的进行反转
        /// 不能反转的不进行
        /// 具体方法实现
        /// </summary>
        IState InversionValue();

        /// <summary>
        /// 根据键值获取内部存在的Key对应的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object GetSingleValue(AIStateElementTag key);

        /// <summary>
        /// 根据AIConfigElement类型
        /// 比较值是否相同
        /// 单个Key比较
        /// </summary>
        /// <param name="key">AIConfigElement类型</param>
        /// <returns></returns>
        bool CompareKey(AIStateElementTag key);

        /// <summary>
        /// 获取当前所有配置标签AIConfigElement
        /// </summary>
        /// <returns></returns>
        ICollection<AIStateElementTag> GetKeys();

        /// <summary>
        /// 完全复制另一个状态的值
        /// </summary>
        /// <param name="otherState"></param>
        void Copy(IState otherState);

        /// <summary>
        /// 若当前State包含otherState所有的键值对
        /// 且对应值都相等
        /// 返回true，反之返回false
        /// </summary>
        /// <returns></returns>
        bool ContainState(IState otherState);

        /// <summary>
        /// 获取两个State
        /// 同时包含的键值及当前状态键值对应的数据
        /// </summary>
        SortedList<AIStateElementTag, Dictionary<IState, object>> GetSameData(IState otherState);

        /// <summary>
        /// 获取跟另外一个状态的差异键值集合
        /// </summary>
        /// <param name="otherState"></param>
        /// <returns></returns>
        ICollection<AIStateElementTag> GetValueDifferences(IState otherState);

        /// <summary>
        /// 把所提供状态的所有键值进行筛选
        /// 当前状态不存在的就添加进
        /// 存在则忽略
        /// </summary>
        ICollection<AIStateElementTag> GetNotExistKeys(IState otherState);
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

        #endregion
    }
}