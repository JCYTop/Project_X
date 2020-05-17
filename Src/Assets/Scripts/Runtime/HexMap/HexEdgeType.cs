/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     HexEdgeType
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/05/17 14:20:57
 *Description:   
 *History:
 ----------------------------------
*/

namespace Runtime.HexMap
{
    /// <summary>
    /// 俩姐
    /// </summary>
    public enum HexEdgeType
    {
        /// <summary>
        /// 平面
        /// </summary>
        Flat,

        /// <summary>
        /// 坡
        /// </summary>
        Slope,

        /// <summary>
        /// 悬崖
        /// </summary>
        Cliff
    }
}