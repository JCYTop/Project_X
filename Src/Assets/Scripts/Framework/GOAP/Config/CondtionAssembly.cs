/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     CondtionAssembly
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/13 18:40:38
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace Framework.GOAP
{
    [Serializable]
    public class CondtionAssembly
    {
        [Rename("标签")] public CondtionTag ElementTag;
        [Rename("标志位")] public bool IsRight = true;

        public CondtionAssembly()
        {
        }

        public CondtionAssembly(CondtionTag elementTag, bool right)
        {
            this.ElementTag = elementTag;
            this.IsRight = right;
        }
    }

    public enum CondtionTag
    {
        #region Common  0~199

        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,

        #endregion

        #region Target目标 200~399

        /// <summary>
        /// 是否存在战斗目标
        /// </summary>
        Target = 200,

        /// <summary>
        /// 是否离目标过远
        /// </summary>
        Near_Target,

        #endregion
        
        #region StateGoal 400~599

        /// <summary>
        /// 进入Alert
        /// State状态
        /// </summary>
        Into_Alert_State = 400,

        #endregion
    }
}