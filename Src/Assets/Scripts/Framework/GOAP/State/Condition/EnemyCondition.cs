/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     EnemyCondition
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 23:33:28
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;

namespace Framework.GOAP
{
    public class EnemyCondition : AICondition
    {
        private EnemyContext enemyContext;
        private EnemyStateMgr stateMgr;
        private HashSet<(StateAssembly, Action)> tmp = new HashSet<(StateAssembly, Action)>();

        protected override void Init()
        {
            enemyContext = this.GetComponent<EnemyContext>();
            stateMgr = enemyContext.Agent.AgentStateMgr.GetStateMgr<EnemyStateMgr>();
            foreach (var stateBase in stateMgr.StateSortList.Values)
            {
                foreach (var state in stateBase.GetData().StateElement)
                {
                    //TODO 
                }
            }

            //TODO 试验
            var data = AIConditionExtend.Map[AIStateElementTag.Normal_Targets];
            data(enemyContext);
        }
    }
}