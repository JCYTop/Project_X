/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IActionHandleMap
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/07 16:17:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace GOAP
{
    public interface IActionHandleMap<TAction, IHandle>
    {
        SortedList<TAction, IHandle> HandleMap { get; }

        /// <summary>
        /// 获取Handle
        /// </summary>
        /// <param name="type">参数</param>
        /// <typeparam name="TAction">TAction的类型</typeparam>
        /// <returns>IActionHandle类型</returns>
        IHandle GetHandle(TAction type);
    }
}