/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     UtilMgr
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/28 17:13:40
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine.Events;

public class UtilMgr : MonoSingleton<UtilMgr>
{
    private UnityAction fixedUpdate;

    private void FixedUpdate()
    {
        fixedUpdate();
    }

    public void AddFixedUpdate(UnityAction action)
    {
        fixedUpdate += action;
    }

    public void RemoveFixedUpdate(UnityAction action)
    {
        fixedUpdate -= action;
    }
}