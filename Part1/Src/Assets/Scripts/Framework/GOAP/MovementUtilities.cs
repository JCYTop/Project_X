/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     MovementUtilities
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/16 19:05:12
 *Description:   
 *History:
 ----------------------------------
*/

using JetBrains.Annotations;
using Pathfinding;
using UnityEngine;

public static class MovementUtilities
{
    public static Path SeekerGetPath(this Seeker seeker, [CanBeNull] GameObject self, [CanBeNull] GameObject target, OnPathDelegate callback = null)
    {
        //TODO 可以进行一些检测
        if (callback != null)
            return seeker.StartPath(self.transform.position, target.transform.position, callback);
        else
            return seeker.StartPath(self.transform.position, target.transform.position, null);
    }
}