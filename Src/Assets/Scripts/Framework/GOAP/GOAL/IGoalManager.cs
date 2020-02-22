/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GoalManager
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 22:28:13
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    public interface IGoalManager<TGoal>
    {
        IGoal<TGoal> Current { get; }
        void AddGoal(TGoal label);
        void RemoveGoal(TGoal label);
        IGoal<TGoal> GetGoal(TGoal label);
        IGoal<TGoal> FindGoal();
        void UpdateData();
    }
}