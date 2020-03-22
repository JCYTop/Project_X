/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     GOAP_AI_Test
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/21 13:25:05
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using Framework.GOAP;
using UnityEngine;
using UnityEngine.Assertions;

public class GOAP_AI_Test : UnityTest
{
    public void GOAP_Context_Agent_GoalMgr_FindGoal()
    {
        var list = GameObject.Find("GOAP_AI_1")
            .GetComponentInChildren<EnemyContext>()
            .Agent
            .AgentGoalMgr
            .FindGoals();
        Assert.IsTrue(list.Count > 0);
    }

    public void GOAP_Context_Agent_EnemyTreePlanner_BuildPlan()
    {
        var list = GameObject.Find("GOAP_AI_1")
            .GetComponentInChildren<EnemyContext>()
            .Agent
            .Performer
            .BuildPlan();
        Assert.IsTrue(list.Count > 0);
    }
}