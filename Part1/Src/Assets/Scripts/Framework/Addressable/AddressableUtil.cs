/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AddressableUtil
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/04/06 00:26:00
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEngine;

namespace Framework.Singleton
{
    public class AddressableUtil
    {
        /// <summary>
        /// 实例化物体
        /// </summary>
        /// <param name="go"></param>
        /// <param name="IsDotDestory"></param>
        /// <returns></returns>
        public static GameObject InstantiateGo(GameObject asset, bool IsDotDestory = false)
        {
            var go = Object.Instantiate(asset);
            if (IsDotDestory)
                Object.DontDestroyOnLoad(go);
            return go;
        }
    }
}