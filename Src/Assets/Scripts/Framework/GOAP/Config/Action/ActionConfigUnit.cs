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
    public abstract class ActionConfigUnit : UnityEngine.ScriptableObject, IConfigUnit<ActionConfigUnit, ActionElementTag>
    {
        private SortedList<ActionElementTag, object> ActionConfigUnitSet;
        [SerializeField] private ActionUnityGroup ActionUnityGroups;
        [Rename("权重"), SerializeField] private int Priority;
        [Rename("是否可打断"), SerializeField] private bool IsInterruptible = false;
        [SerializeField] private List<CostParameter> Cost;
        [SerializeField] private List<CondtionAssembly> Preconditions;
        [SerializeField] private List<CondtionAssembly> Effects;
        public ActionConfigUnit GetConfigUnit => this;

        public SortedList<ActionElementTag, object> ConfigUnitSet
        {
            get
            {
                if (ActionConfigUnitSet == null)
                {
                    ActionConfigUnitSet = new SortedList<ActionElementTag, object>();
                }

                return ActionConfigUnitSet;
            }
        }

        /// <summary>
        /// 初始化数据
        /// 必须手动填写已经添加的数据
        /// </summary>
        public void Init()
        {
            ConfigUnitSet.Add(ActionElementTag.Priority, Priority);
            ConfigUnitSet.Add(ActionElementTag.Interruptible, IsInterruptible);
            ConfigUnitSet.Add(ActionElementTag.Cost, Cost);
            ConfigUnitSet.Add(ActionElementTag.ActionUnityGroups, ActionUnityGroups);
            ConfigUnitSet.Add(ActionElementTag.Preconditions, Preconditions);
            ConfigUnitSet.Add(ActionElementTag.Effects, Effects);
            LogTool.Log($"{this.name} , ActionConfigUnit数据已经加载完成", LogEnum.AssetLog);
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

    /// <summary>
    /// 消耗类参数
    /// </summary>
    [Serializable]
    public class CostParameter
    {
        [Rename("类型")] public ParameterTag CostTag;
        [Rename("权重"), Range(-100f, 100f)] public int CostPriority;
        [Rename("消耗")] public float value;
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