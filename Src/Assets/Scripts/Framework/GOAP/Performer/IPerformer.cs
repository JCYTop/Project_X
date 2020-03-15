/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IPerformer
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/15 21:49:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace Framework.GOAP
{
    public interface IPerformer
    {
        /// <summary>
        /// 更新数据函数
        /// </summary>
        void UpdateData();

        /// <summary>
        /// 中断计划
        /// </summary>
        void Interruptible();
    }
}