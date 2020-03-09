/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AIParameter
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 16:46:42
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using Framework.EventDispatcher;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Framework.GOAP
{
    /// <summary>
    /// 参数类
    /// 所用通用
    /// 可以动态添加或者删除（可能因为不同装备的增加或删除而改变）
    /// </summary>
    public class AIParameter : MonoEventEmitter
    {
        /// <summary>
        /// 这里只是一个基础数值
        /// 初始化读取用的
        /// </summary>
        [SerializeField] private ParameterConfig baseParameter;

        private SortedList<ParameterTag, ParameterUnit> parameterList;

#if UNITY_EDITOR
        /// <summary>
        /// 用于界面显示
        /// </summary>
        [SerializeField, ReadOnly] private List<ParameterPanel> panelList = new List<ParameterPanel>(1 << 4);
#endif

        /// <summary>
        /// 获取相对应的参数
        /// 值
        /// </summary>
        public SortedList<ParameterTag, ParameterUnit> ParameterList
        {
            get
            {
                if (parameterList == null)
                {
                    //初始化
                    parameterList = new SortedList<ParameterTag, ParameterUnit>();
                    for (int i = 0; i < baseParameter.Array.Length; i++)
                    {
                        parameterList.AddSortListElement(baseParameter.Array[i].Tag, baseParameter.Array[i]);
                    }
                }

                RefreshPanelInfo();
                return parameterList;
            }
        }

        /// <summary>
        /// 刷新面板信息
        /// </summary>
        private void RefreshPanelInfo()
        {
#if UNITY_EDITOR

            panelList.Clear();
            if (parameterList == null) return;
            foreach (var unit in parameterList)
            {
                panelList.Add(new ParameterPanel(unit.Key, unit.Value.Value));
            }
#endif
        }

        /// <summary>
        /// 添加一个新的参数
        /// 可能因为装备的或者属性的改变而添加
        /// </summary>
        /// <param name="unit"></param>
        public void AppendParameter(ParameterUnit unit)
        {
            ParameterList.AddSortListElement(unit.Tag, unit);
            RefreshPanelInfo();
        }

        /// <summary>
        /// 删除一个参数信
        /// 可能因为装备的或者属性的改变而删除
        /// </summary>
        /// <param name="unit"></param>
        public void DeleteParameter(ParameterUnit unit)
        {
            ParameterList.DeleteSortListElement(unit.Tag);
            RefreshPanelInfo();
        }

        /// <summary>
        /// 设置一个相对的数值
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        public void SetParameter(ParameterTag tag, int value)
        {
            ParameterList.SetSortListElementValue(tag, new ParameterUnit(tag, value));
            RefreshPanelInfo();
        }

        /// <summary>
        /// 特别的功能使其直接回复到默认数据
        /// </summary>
        public void Default()
        {
            parameterList = null;
            RefreshPanelInfo();
        }

        [Serializable]
        struct ParameterPanel
        {
            public ParameterTag Tag;
            public int Value;

            public ParameterPanel(ParameterTag tag, int value)
            {
                Tag = tag;
                Value = value;
            }
        }
    }
}