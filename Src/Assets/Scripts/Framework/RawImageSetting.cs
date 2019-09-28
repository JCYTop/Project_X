/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     RawImageScalc
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/28 15:06:45
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;
using UnityEngine.UI;

public class RawImageSetting : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;

    private void Start()
    {
        rawImage.texture = MachineUtil.RenderTexture;
        var scale = MachineUtil.RawImageScale();
        this.transform.localScale = new Vector3(scale.x, scale.y, 1);
    }
}