/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     LogConfig
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 01:01:54
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Framework.ScriptableObject
{
    public class LogConfig : UnityEngine.ScriptableObject
    {
        public bool All = true;
        public List<LogData> LogDatas;
    }

    [Serializable]
    public class LogData
    {
        [FormerlySerializedAs("LogType")] public LogEnum logEnum;
        public bool Show;
        public Color LogColor;

        public string GetLogColorStr
        {
            get
            {
                string color = ColorUtility.ToHtmlStringRGB(LogColor);
                return string.Format("<color=#{0}>[{1}] : </color>", color, logEnum);
            }
        }
    }
}