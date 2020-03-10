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
using Framework.EventDispatcher;
using UnityEngine;

namespace Framework.GOAP
{
    public abstract class AICondition : MonoEventEmitter
    {
        private void Start()
        {
            Init();
        }

        protected abstract void Init();
    }

    public static class AIConditionExtend
    {
        public static Dictionary<AIStateElementTag, Func<IContext, bool>> Map = new Dictionary<AIStateElementTag, Func<IContext, bool>>()
        {
            {
                AIStateElementTag.Normal_Target, (context) =>
                {
                    var normalTargets = context.Dynamic.PushDynamicData<GameObject>(DynamicObjTag.Normal_Target);
                    return normalTargets != null;
                }
            }
        };
    }
}