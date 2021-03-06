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
    public class EnemyCondition : Condition
    {
        /// <summary>
        /// 本类的核心
        /// </summary>
        private Dictionary<CondtionTag, bool> conditionMap;

        private EnemyContext enemyContext;
        private EnemyGoalMgr goalMgr;
        private SortedList<CondtionTag, Func<IContext, bool>> updateData;
#if UNITY_EDITOR
        [SerializeField, Sirenix.OdinInspector.ReadOnly]
        private List<CondtionAssembly> panelInfo;
#endif
        public override Dictionary<CondtionTag, bool> ConditionMap
        {
            get { return conditionMap; }
        }

        public override void Init()
        {
            updateData = new SortedList<CondtionTag, Func<IContext, bool>>(1 << 4);
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

                foreach (var condtion in stateBase.Target)
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
            OnRegiestEvent(GOAPEventType.ChangeTarget, ChangeAttackTarget);
            OnRegiestEvent(GOAPEventType.StateChangeAlert, StateChangeAlert);
        }

        private void OnDisable()
        {
            OnUnRegiestEvent(GOAPEventType.ChangeTarget, ChangeAttackTarget);
            OnUnRegiestEvent(GOAPEventType.StateChangeAlert, StateChangeAlert);
        }

        private void StateChangeAlert(object[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (GoalbalID != Convert.ToInt32(args[0]))
                    return;
                var value = conditionMap.SetDictionaryValue(CondtionTag.Target, args[1] != null);
#if UNITY_EDITOR
                panelInfo.ForEach((panel) =>
                {
                    if (panel.ElementTag == CondtionTag.Alert_State)
                    {
                        panel.IsRight = value;
                    }
                });
#endif
                OnEmitEvent(GOAPEventType.ChangeCondition, new object[] {GoalbalID,});
            }
        }

        private void ChangeAttackTarget(object[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (GoalbalID != Convert.ToInt32(args[0]))
                    return;
                var go = (GameObject) args[1];
                var value = conditionMap.SetDictionaryValue(CondtionTag.Target, go != null);
                if (value)
                {
                    updateData.AddSortListElements(CondtionTag.Near_Target, (context) =>
                    {
                        var dis = Vector3.Distance(context.GameObject.transform.position, go.transform.position);
                        var near = context.Parameter.ParameterList.GetSortListValue(ParameterTag.Attack_Dis);
                        if (dis < near.Value)
                            return true;
                        return false;
                    });
                }
                else
                {
                    updateData.RemoveSortListElements(CondtionTag.Near_Target);
                }

                OnEmitEvent(GOAPEventType.ChangeCondition, new object[] {GoalbalID,});
#if UNITY_EDITOR
                panelInfo.ForEach((panel) =>
                {
                    if (panel.ElementTag == CondtionTag.Target)
                    {
                        panel.IsRight = value;
                    }
                });
#endif
            }
        }

        /// <summary>
        /// 需要实时更新的标签
        /// </summary>
        private void Update()
        {
            //遍历动态查找需要检测的标签
            if (updateData.Count <= 0) return;
            var sortList = updateData.GetEnumerator();
            while (sortList.MoveNext())
            {
                var preValue = conditionMap.GetDictionaryValue(sortList.Current.Key);
                var currValue = conditionMap.SetDictionaryValue(sortList.Current.Key, sortList.Current.Value(enemyContext));
                //updateData 中要实时跟新的数据发送，其他由事件改变的在事件接受处发送
                if (preValue != currValue)
                {
                    OnEmitEvent(GOAPEventType.ChangeCondition, new object[] {GoalbalID,});
                }
#if UNITY_EDITOR
                var list = panelInfo.GetEnumerator();
                while (list.MoveNext())
                {
                    if (list.Current.ElementTag == sortList.Current.Key)
                    {
                        list.Current.IsRight = currValue;
                    }
                }
#endif
            }
        }
    }
}