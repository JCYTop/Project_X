/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AssetPoolItem
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/22 23:28:20
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPoolItem : MonoBehaviour
{
    private string assetName;

    public string AssetName
    {
        set { assetName = value; }
        get { return assetName; }
    }

    public void Drop()
    {
        gameObject.SetActive(false);
        AssetsManager.Instance.PutGoToPool(this);
    }
}
