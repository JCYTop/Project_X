//=====================================================
// - FileName:      LangSetting.cs
// - Created:       @JCY
// - CreateTime:    2019/03/17 21:41:33
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangSetting : MonoBehaviour
{
    private static LangSetting instance;
    private Dictionary<int, Hashtable> wordMap = new Dictionary<int, Hashtable>(); //语言索引表
    private LanguageType currLanguage = LanguageType.ChineseSimplified;

    #region Private

    public static LangSetting Instance()
    {
        if (instance == null)
        {
            instance = MonoSingletonProperty<LangSetting>.Instance();
            instance.Init();
        }

        return instance;
    }

    void Awake()
    {
        Instance();
    }

    /// <summary>
    /// 初始化操作
    /// </summary>
    private void Init()
    {
        GetCurLang();
        ParseWord();
    }

    private void ParseWord()
    {
        if (ExcelDataMgr.Instance().Language != null)
        {
            var datas = ExcelDataMgr.Instance().Language.dataArray;
            foreach (var item in datas)
            {
                var tmp = new Hashtable();
                tmp.Add(LanguageType.ChineseSimplified, item.Chinesesimplified);
                tmp.Add(LanguageType.ChineseTraditional, item.Chinesetraditional);
                tmp.Add(LanguageType.English, item.English);
                wordMap.Add(item.Languagekey, tmp);
            }
        }
    }

    private LanguageType GetCurLang()
    {
        //TODO 更换存储方式
        var language = PlayerPrefs.GetString("Language");
        if (string.IsNullOrEmpty(language))
        {
            currLanguage = LanguageType.ChineseSimplified;
            SetCurLang(currLanguage);
        }
        else
        {
            currLanguage = (LanguageType) Enum.Parse(typeof(LanguageType), language);
        }

        return currLanguage;
    }

    private void SetCurLang(LanguageType Language)
    {
        //TODO 更换存储方式
        PlayerPrefs.SetString("Language", Enum.GetName(typeof(LanguageType), Language));
    }

    private string _GetWord(int key)
    {
        if (key != null)
        {
            var word = wordMap[key][currLanguage] as string;
            if (string.IsNullOrEmpty(word))
            {
                word = key.ToString();
            }

            return word;
        }

        return string.Empty;
    }

    #endregion

    #region Public 

    /// <summary>
    /// 主方法
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetWord(int key)
    {
        return instance._GetWord(key);
    }

    #endregion
}

public enum LanguageType
{
    ChineseSimplified,
    ChineseTraditional,
    English,
}