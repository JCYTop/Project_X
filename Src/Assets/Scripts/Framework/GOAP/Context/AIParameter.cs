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

using System.Collections.Generic;
using Framework.EventDispatcher;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GOAP
{
    /// <summary>
    /// 参数类
    /// 所用通用
    /// 可以动态添加或者删除（可能因为不同装备的增加或删除而改变）
    /// </summary>
    public class AIParameter : MonoEventEmitter
    {
        private SortedList<ParameterTag, ParameterUnit> parameterList;

        /// <summary>
        /// 这里只是一个基础数值
        /// 初始化读取用的
        /// </summary>
        [SerializeField] private ParameterConfig baseParameter;

        [SerializeField, ReadOnly] private int Bleed;
        [SerializeField, ReadOnly] private int Energy;

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

                return parameterList;
            }
        }
    }
}