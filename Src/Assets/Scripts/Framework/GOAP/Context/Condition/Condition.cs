/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Condition
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
using Framework.Base;
using Framework.EventDispatcher;

namespace Framework.GOAP
{
    public abstract class Condition : MonoEventEmitter, IGoalbalID
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
        public static T GetCondition<T>(this Condition context) where T : class
        {
            try
            {
                return context as T;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}