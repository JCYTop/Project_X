using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 选择相应平台时候检测时候
/// </summary>
public class Platform
{
    public static bool IsAndroid
    {
        get
        {
            bool retValue = false;
#if UNITY_ANDROID
            retValue = true;    
#endif
            return retValue;
        }
    }

    public static bool IsEditor
    {
        get
        {
            bool retValue = false;
#if UNITY_EDITOR
            retValue = true;
#endif
            return retValue;
        }
    }

    public static bool IsIOS
    {
        get
        {
            bool retValue = false;
#if UNITY_IOS
            retValue = true;    
#endif
            return retValue;
        }
    }

    public static bool IsiPhone
    {
        get
        {
            bool retValue = false;
#if UNITY_IPHONE
            retValue = true;    
#endif
            return retValue;
        }
    }

    public static bool IsPC
    {
        get
        {
            bool retValue = false;
#if PLATFORM_STANDALONE
            retValue = true;
#endif
            return retValue;
        }
    }
}