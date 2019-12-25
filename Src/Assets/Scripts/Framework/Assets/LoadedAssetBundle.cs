/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     LoadedAssetBundle
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 17:23:47
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/


using UnityEngine;

namespace Framework.Assets
{
    /// <summary>
    /// 加载的资源包记录信息
    /// </summary>
    public class LoadedAssetBundle
    {
        public AssetBundle AssetBundle;

        /// <summary>
        /// 相关引用
        /// </summary>
        public int ReferencedCount;

        public LoadedAssetBundle(AssetBundle assetBundle)
        {
            AssetBundle = assetBundle;
            ReferencedCount = 1;
        }
    }
}