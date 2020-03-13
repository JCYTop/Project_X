/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ActionConfigUnit
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/01 18:51:07
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.GOAP
{
    /// <summary>
    /// 配置文件元素基类
    /// </summary>
    /// <typeparam name="T">ActionConfigElementTag 标签</typeparam>
    [Serializable]
    public abstract class ActionConfigUnit<T> : UnityEngine.ScriptableObject
    {
        [Rename("权重")] public int Priority;
        [Rename("是否可打断")] public bool IsInterruptible = false;
        [Rename("消耗")] public int Cost;
        public ActionUnityGroup ActionUnityGroups;

        /// <summary>
        /// 先决条件
        /// </summary>
        public List<StateAssembly> Preconditions;

        /// <summary>
        /// 影响条件
        /// </summary>
        public List<StateAssembly> Effects;

        public SortedList<T, object> ActionConfigUnitSet = new SortedList<T, object>();

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public abstract ActionConfigUnit<T> Init();

        protected void ADD(T tag, object obj)
        {
            ActionConfigUnitSet.AddSortListElement(tag, obj);
        }
    }

    /// <summary>
    /// 关联Unity中的信息
    /// Playable重要类
    /// 以后重要扩展
    /// </summary>
    [Serializable]
    public class ActionUnityGroup
    {
        public AnimationClip[] Animation;
        public AudioClip[] AudioClip;
        public GameObject[] ParticleEffects;
    }

    public enum ActionElementTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        /// <summary>
        /// 权重
        /// </summary>
        Priority = 1,

        /// <summary>
        /// 是否可打断
        /// </summary>
        Interruptible = 2,

        /// <summary>
        /// 动作花费
        /// </summary>
        Cost = 3,

        /// <summary>
        /// 动画相关簇
        /// </summary>
        ActionUnityGroups = 4,

        /// <summary>
        /// 先决条件
        /// </summary>
        Preconditions = 5,

        /// <summary>
        /// 影响条件
        /// </summary>
        Effects = 6,

        #endregion
    }
}