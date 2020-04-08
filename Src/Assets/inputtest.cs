/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     inputtest
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/07 15:30:32
 *Description:   
 *History:
 ----------------------------------
*/


using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputtest : MonoBehaviour
{ 
    public void OnMove(InputValue value)
    {
        // Read value from control. The type depends on what type of controls.
        // the action is bound to.
        var v = value.Get<Vector2>();
        Debug.Log(v);
    }
}