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

namespace Framework.GOAP
{
    public class EnemyCondition : AICondition
    {
        private EnemyContext enemyContext;
        private EnemyGoalMgr goalMgr;
        private Dictionary<CondtionTag, bool> conditionMap;

#if UNITY_EDITOR
        [SerializeField, Sirenix.OdinInspector.ReadOnly]
        private List<CondtionAssembly> panelInfo;
#endif

        public override void Init()
        {
            conditionMap = new Dictionary<CondtionTag, bool>(1 << 4);
            enemyContext = this.GetComponent<EnemyContext>();
            goalMgr = enemyContext.Agent.AgentGoalMgr.GetGoalMgr<EnemyGoalMgr>();
            foreach (var stateBase in goalMgr.GoalsDic.Values)
            {
                foreach (var condtion in stateBase.Condition)
                {
                    //获取配置文件中所有的 Tag 标签
                    if (!conditionMap.ContainsKey(condtion.ElementTag))
                    {
                        conditionMap.Add(condtion.ElementTag, default(bool));
                    }
                }

                foreach (var condtion in stateBase.Effects)
                {
                    //获取配置文件中所有的 Tag 标签
                    if (!conditionMap.ContainsKey(condtion.ElementTag))
                    {
                        conditionMap.Add(condtion.ElementTag, default(bool));
                    }
                }
            }
#if UNITY_EDITOR
            panelInfo = new List<CondtionAssembly>(1 << 4);
            foreach (var elementTag in conditionMap)
            {
                panelInfo.Add(new CondtionAssembly(elementTag.Key, default(bool)));
            }
#endif
        }

        private void OnEnable()
        {
            RegiestEvent(GOAPEventType.Change_Normal_Target, Change_Normal_Target);
        }

        private void OnDisable()
        {
            UnRegiestEvent(GOAPEventType.Change_Normal_Target, Change_Normal_Target);
        }

        private void Change_Normal_Target(object[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (GoalbalID != Convert.ToInt32(args[0])) return;
                var value = conditionMap.GetDictionaryValue(CondtionTag.Normal_Target);
                var go = (GameObject) args[1];
                value = go != null;
#if UNITY_EDITOR
                panelInfo.ForEach((panel) =>
                {
                    if (panel.ElementTag == CondtionTag.Normal_Target)
                    {
                        panel.IsRight = value;
                    }
                });
#endif
            }
        }

        private void Update()
        {
//            if (conditionMap.Count <= 0) return;
//            foreach (var stateAssembly in conditionMap)
//            {
//                var currFlag = stateAssembly.Value(enemyContext);
//#if UNITY_EDITOR
//                panelInfo.ForEach((panel) =>
//                {
//                    if (panel.ElementTag == stateAssembly.Key)
//                    {
//                        panel.IsRight = currFlag;
//                    }
//                });
//#endif
//            }
        }
    }
}