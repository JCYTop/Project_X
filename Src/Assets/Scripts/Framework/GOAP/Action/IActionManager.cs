/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IActionManager
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 14:32:41
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    public interface IActionManager<TAction>
    {
        void AddHandler(TAction label);
        void RemoveHandle(TAction label);
        IActionHandler<TAction> GetHandler(TAction label);
        void UpdateData();
        void FrameFun();
        void ChangeCurrentAction(TAction label);
        void AddActionCompleteListener(Action complete);
    }
}