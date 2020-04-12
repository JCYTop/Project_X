/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     CameraFollowLookAt
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/12 14:49:36
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEngine;

public class CameraFollowLookAt : MonoBehaviour
{
    [SerializeField] private Transform follow;
    [SerializeField] private Transform lookAt;

    private void Awake()
    {
        CameraSetting();
    }

    public void CameraSetting()
    {
        CameraSettings.Follow = follow;
        CameraSettings.LookAt = lookAt;
    }
}