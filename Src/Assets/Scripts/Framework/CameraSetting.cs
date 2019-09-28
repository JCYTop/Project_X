/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     CameraSetting
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/28 18:29:40
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] private Camera camera;

    private void Start()
    {
       camera.targetTexture = MachineUtil.RenderTexture;
    }

    private void OnEnable()
    {
        ScenesCenter.MainCamera = this.camera;
    }

    private void OnDisable()
    {
        ScenesCenter.MainCamera = null;
    }
}