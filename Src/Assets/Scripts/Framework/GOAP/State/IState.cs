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

namespace GOAP
{
    /// <summary>
    /// 存储每一个状态
    /// 如果不使用State就需要使用单独的数据关系表
    /// 先于Action初始化完成
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
        /// StateConfig序列化文件载入
        /// StateConfig进行一次实例化
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
        /// 通过配置文件类进行加载
        /// </summary>
        void SetData(IState data);

        /// <summary>
        /// 获取参数
        /// 获取的是State中的缓存数据
        /// 不是序列化文件了！！！
        /// </summary>
        IState GetData();

        /// <summary>
        /// 添加数据修改监听
        /// </summary>
        /// <param name="onChange"></param>
        void AddStateChangeListener(Action callback);

        /// <summary>
        /// 删除数据修改监听
        /// </summary>
        /// <param name="onChange"></param>
        void RemoveStateChangeListener(Action callback);

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
        IConfigElementBase GetSingleValue(AIStateConfigElementTag key);

        /// <summary>
        /// 根据AIConfigElement类型
        /// 比较值是否相同
        /// 单个Key比较
        /// </summary>
        /// <param name="key">AIConfigElement类型</param>
        /// <returns></returns>
        bool CompareKey(AIStateConfigElementTag key);

        /// <summary>
        /// 获取当前所有配置标签AIConfigElement
        /// </summary>
        /// <returns></returns>
        ICollection<AIStateConfigElementTag> GetKeys();

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
        SortedList<AIStateConfigElementTag, Dictionary<IState, IConfigElementBase>> GetSameData(IState otherState);

        /// <summary>
        /// 获取跟另外一个状态的差异键值集合
        /// </summary>
        /// <param name="otherState"></param>
        /// <returns></returns>
        ICollection<AIStateConfigElementTag> GetValueDifferences(IState otherState);

        /// <summary>
        /// 把所提供状态的所有键值进行筛选
        /// 当前状态不存在的就添加进
        /// 存在则忽略
        /// </summary>
        ICollection<AIStateConfigElementTag> GetNotExistKeys(IState otherState);
    }

    /// <summary>
    /// 标签用于状态在注册之后形成对应组注册表
    /// 方便查找对应关系
    /// </summary>
    public class StateBaseTag
    {
        #region  Common 0~199

        /// <summary>
        /// 默认
        /// </summary>
        public const string Default = "Default";

        #endregion
    }
}