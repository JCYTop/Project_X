using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public static class StringExtention
{
    /// <summary>
    /// 检查字符串是否为空
    /// </summary>
    /// <param name="selfStr"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string selfStr)
    {
        return string.IsNullOrEmpty(selfStr);
    }

    /// <summary>
    /// 检查字符串是否不为空
    /// </summary>
    /// <param name="selfStr"></param>
    /// <returns></returns>
    public static bool IsNotNullAndEmpty(this string selfStr)
    {
        return !string.IsNullOrEmpty(selfStr);
    }

    /// <summary>
    /// 首字母大写
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string UppercaseFirst(this string str)
    {
        return char.ToUpper(str[0]) + str.Substring(1);
    }

    /// <summary>
    /// 首字母小写
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string LowercaseFirst(this string str)
    {
        return char.ToLower(str[0]) + str.Substring(1);
    }

    /// <summary>
    /// 解析颜色
    /// </summary>
    /// <param name="_inputString"></param>
    /// <param name="result"></param>
    /// <param name="colorSpriter"></param>
    /// <returns></returns>
    public static bool ParseColor(string _inputString, out Color result, char colorSpriter = ',')
    {
        string str = _inputString.Trim();
        str = str.Replace("(".ToString(), "");
        str = str.Replace(")".ToString(), "");
        result = Color.clear;
        if (str.Length < 9)
        {
            return false;
        }
        try
        {
            var strArray = str.Split(colorSpriter);
            if (strArray.Length != 4)
            {
                return false;
            }

            result = new Color(float.Parse(strArray[0]) / 255f, float.Parse(strArray[1]) / 255f, float.Parse(strArray[2]) / 255f, float.Parse(strArray[3]) / 255f);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// 解析词典
    /// </summary>
    /// <param name="strMap"></param>
    /// <param name="keyValueSpriter"></param>
    /// <param name="mapSpriter"></param>
    /// <returns></returns>
    public static Dictionary<string, string> ParseMap(this string strMap, char keyValueSpriter = ':', char mapSpriter = ',')
    {
        var dictionary = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(strMap))
        {
            var strArray = strMap.Split(mapSpriter);
            foreach (var str in strArray)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    var strArray2 = str.Split(keyValueSpriter);
                    if ((strArray2.Length == 2) && !dictionary.ContainsKey(strArray2[0]))
                    {
                        dictionary.Add(strArray2[0].Trim(), strArray2[1].Trim());
                    }
                }
            }
        }
        return dictionary;
    }

    /// <summary>
    /// 解析四维向量
    /// </summary>
    /// <param name="_inputString"></param>
    /// <param name="result"></param>
    /// <param name="vectorSpriter"></param>
    /// <returns></returns>
    public static bool ParseVector4(string _inputString, out Vector4 result, char vectorSpriter = ',')
    {
        var str = _inputString.Trim();
        str = str.Replace("(".ToString(), "");
        str = str.Replace(")".ToString(), "");
        result = new Vector4();
        try
        {
            var strArray = str.Split(vectorSpriter);
            if (strArray.Length != 4)
            {
                return false;
            }

            result.x = float.Parse(strArray[0]);
            result.y = float.Parse(strArray[1]);
            result.z = float.Parse(strArray[2]);
            result.w = float.Parse(strArray[3]);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
            return false;
        }
    }

    /// <summary>
    /// 解析四元数
    /// </summary>
    /// <param name="_inputString"></param>
    /// <param name="result"></param>
    /// <param name="spriter"></param>
    /// <returns></returns>
    public static bool ParseQuaternion(string _inputString, out Quaternion result, char spriter = ',')
    {
        var vec = new Vector4();
        var flag = ParseVector4(_inputString, out vec, spriter);
        result = new Quaternion(vec.x, vec.y, vec.z, vec.w);
        return flag;
    }

    /// <summary>
    /// 解析三维向量
    /// </summary>
    /// <param name="_inputString"></param>
    /// <param name="result"></param>
    /// <param name="spriter"></param>
    /// <returns></returns>
    public static bool ParseVector3(string _inputString, out Vector3 result, char spriter = ',')
    {
        var str = _inputString.Trim();
        str = str.Replace("(".ToString(), "");
        str = str.Replace(")".ToString(), "");
        result = new Vector3();
        try
        {
            var strArray = str.Split(spriter);
            if (strArray.Length != 3)
            {
                return false;
            }

            result.x = float.Parse(strArray[0]);
            result.y = float.Parse(strArray[1]);
            result.z = float.Parse(strArray[2]);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
            return false;
        }
    }

    /// <summary>
    /// 解析二维向量
    /// </summary>
    /// <param name="_inputString"></param>
    /// <param name="result"></param>
    /// <param name="spriter"></param>
    /// <returns></returns>
    public static bool ParseVector2(string _inputString, out Vector2 result, char spriter = ',')
    {
        var str = _inputString.Trim();
        str = str.Replace("(".ToString(), "");
        str = str.Replace(")".ToString(), "");
        result = new Vector2();
        try
        {
            var strArray = str.Split(spriter);
            if (strArray.Length != 2)
            {
                return false;
            }
            result.x = float.Parse(strArray[0]);
            result.y = float.Parse(strArray[1]);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
            return false;
        }
    }

    /// <summary>
    /// 是否存在中文字符
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool HasChinese(this string input)
    {
        return Regex.IsMatch(input, @"[\u4e00-\u9fa5]");
    }

    /// <summary>
    /// 是否存在空格
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool HasSpace(this string input)
    {
        return input.Contains(" ");
    }
}