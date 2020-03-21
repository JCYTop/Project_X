/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     UnityTest
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/21 14:04:40
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;
using UnityEngine.Events;

public abstract class UnityTest : MonoBehaviour
{
    public UnityEvent Uevent;
    private bool once = true;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Space) && once)
        {
            once = false;
            Uevent.Invoke();
            Invoke("ResetOnce", 1f);
        }
    }

    private void ResetOnce()
    {
        once = true;
    }
}