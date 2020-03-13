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

namespace Framework.GOAP
{
    public class CondtionAssembly
    {
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
        /// 是否存在目标
        /// 非战斗目标
        /// </summary>
        Normal_Target = 200,

        /// <summary>
        /// 是否离目标过远
        /// 是否离非战斗目标过远
        /// </summary>
        Far_Normal_Target,

        #endregion
    }
}