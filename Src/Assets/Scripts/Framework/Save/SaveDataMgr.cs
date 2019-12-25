/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     SaveDataMgr
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/28 16:15:16
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;

namespace Framework.Save
{
    /// <summary>
    /// 一些基础数据存储使用
    /// </summary>
    public class SaveDataMgr : MonoSingleton<SaveDataMgr>
    {
        //TODO 不同的存储文件
        public T GetSaveData<T>(SaveEnum key)
        {
            if (ES3.KeyExists(key.ToString()))
                return ES3.Load<T>(key.ToString());
            return ES3.Load<T>(key.ToString(), default(T));
        }

        public void GetSaveData<T>(SaveEnum key, T obj) where T : Transform
        {
            if (ES3.KeyExists(key.ToString()))
                ES3.LoadInto<T>(key.ToString(), obj);
        }

        public T SetSaveData<T>(SaveEnum key, T value)
        {
            ES3.Save<T>(key.ToString(), value);
            return value;
        }

        void OnApplicationQuit()
        {
        }

        void OnApplicationPause(bool paused)
        {
            if (paused)
                OnApplicationQuit();
        }
    }

    public enum SaveEnum
    {
        ResolutionWidth,
        ResolutionHeight,
        FrameRate,
        Fullscreen,
    }
}