/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IActionHandle
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/21 00:12:51
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    public interface IActionHandler<TAction> : IFSMState<TAction>
    {
        IAction<TAction> Action { get; }
        TAction Label { get; }
        bool IsComplete { get; }
        bool CanPerFormAction { get; }
        void AddFinishCallBack(Action onFinishAction);
    }
}