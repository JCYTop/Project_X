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
using UnityEngine;
using UnityEngine.Rendering;

namespace Framework.GOAP
{
    public class EnemyCondition : AICondition
    {
        private EnemyContext enemyContext;
        private EnemyStateMgr stateMgr;
        private HashSet<AIStateElementTag> existTag;
        private Dictionary<AIStateElementTag, Func<IContext, bool>> conditionMap;
#if UNITY_EDITOR
        [SerializeField] private List<StateAssembly> panelInfo = new List<StateAssembly>();
#endif

        protected override void Init()
        {
            existTag = new HashSet<AIStateElementTag>();
            conditionMap = new Dictionary<AIStateElementTag, Func<IContext, bool>>(1 << 4);
            enemyContext = this.GetComponent<EnemyContext>();
            stateMgr = enemyContext.Agent.AgentStateMgr.GetStateMgr<EnemyStateMgr>();
            foreach (var stateBase in stateMgr.StateSortList.Values)
            {
                foreach (var state in stateBase.GetData().StateElement)
                {
                    //获取配置文件中所有的 Tag 标签
                    existTag.Add(state.ElementTag);
                }
            }

            foreach (var elementTag in existTag)
            {
                var action = AIConditionExtend.ConditionMap[elementTag];
                conditionMap.Add(elementTag, action);
#if UNITY_EDITOR
                panelInfo.Add(new StateAssembly(elementTag, action(enemyContext)));
#endif
            }
        }

        private void Update()
        {
            foreach (var stateAssembly in conditionMap)
            {
            }
        }
    }
}