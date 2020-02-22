/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IGoal
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 22:11:01
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;

namespace GOAP
{
    public interface IGoal<TGoal>
    {
        TGoal Label { get; }
        float GetPriority();
        IState GetEffects();
        bool IsGoalComplete();
        void AddGoalActivateListener(Action<IGoal<TGoal>> onActivate);
        void AddGoalInActivateListener(Action<IGoal<TGoal>> onActivate);
        void UpdateData();
    }
}