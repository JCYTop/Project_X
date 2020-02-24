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

namespace GOAP
{
    /// <summary>
    /// 存储每一个状态
    /// 如果不使用State就需要使用单独的数据关系表
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 清空数据
        /// </summary>
        void Clear();
    }
}