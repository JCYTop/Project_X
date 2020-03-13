/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AICondition
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/09 23:20:43
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using Framework.Base;
using Framework.EventDispatcher;
using UnityEngine;

namespace Framework.GOAP
{
    public abstract class AICondition : MonoEventEmitter, IGoalbalID
    {
        private int goalbalID = 0;

        public int GoalbalID
        {
            get
            {
                if (goalbalID <= 0)
                {
                    goalbalID = this.GetComponentInParent<ObjectBase>().GlobalID;
                }

                return goalbalID;
            }
        }

        public abstract void Init();
    }

    public static class AIConditionExtend
    {
        public static Dictionary<CondtionTag, Func<IContext, bool>> ConditionMap = new Dictionary<CondtionTag, Func<IContext, bool>>()
        {
            {
                CondtionTag.Normal_Target, (context) =>
                {
                    var normalTarget = context.Dynamic.PushDynamicData<GameObject>(DynamicObjTag.Normal_Target);
                    return normalTarget != null;
                }
            },
            {
                CondtionTag.Near_Normal_Target, (context) =>
                {
                    var normalTarget = context.Dynamic.PushDynamicData<GameObject>(DynamicObjTag.Normal_Target);
                    if (normalTarget == null)
                    {
                        return false;
                    }

                    var dis = Vector3.Distance(normalTarget.transform.position, context.GameObject.transform.position);
                    var param = context.Parameter.ParameterList.GetSortListValue(ParameterTag.Near_Dis);
                    if (dis <= param.Value)
                    {
                        return true;
                    }

                    return false;
                }
            },
            {
                CondtionTag.Attack_Target, (context) =>
                {
                    var attackTarget = context.Dynamic.PushDynamicData<GameObject>(DynamicObjTag.Attack_Target);
                    return attackTarget != null;
                }
            },
            {
                CondtionTag.Near_Attack_Target, (context) =>
                {
                    var attackTarget = context.Dynamic.PushDynamicData<GameObject>(DynamicObjTag.Attack_Target);
                    if (attackTarget == null)
                    {
                        return false;
                    }

                    var dis = Vector3.Distance(attackTarget.transform.position, context.GameObject.transform.position);
                    var param = context.Parameter.ParameterList.GetSortListValue(ParameterTag.Attack_Dis);
                    if (dis <= param.Value)
                    {
                        return true;
                    }

                    return false;
                }
            },
        };
    }
}