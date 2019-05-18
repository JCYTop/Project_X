//=====================================================
// - FileName:      LangSetting.cs
// - Created:       @JCY
// - CreateTime:    2019/03/17 21:41:33
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangSetting : MonoBehaviour
{
    [SerializeField] private TextAsset wordText; //语言配置
    private static LangSetting instance;
    private Dictionary<string, Hashtable> wordMap = new Dictionary<string, Hashtable>(); //语言索引表
    private string currLanguage = string.Empty;

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

    #region Private

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
        if (wordText != null)
        {
            string json = wordText.text;
            List<LangItem> datas = FileUtils.ReadJsonData<List<LangItem>>(json, JSonUtilType.JsonConvert);
            foreach (LangItem langItem in datas)
            {
                Hashtable tmp = new Hashtable();
                tmp.Add("ChineseSimplified", langItem.ChineseSimplified);
                tmp.Add("ChineseTraditional", langItem.ChineseTraditional);
                tmp.Add("English", langItem.English);
                wordMap.Add(langItem.LanguageKey, tmp);
            }
        }
    }

    private string GetCurLang()
    {
        //TODO 更换存储方式
        currLanguage = PlayerPrefs.GetString("language");
        if (string.IsNullOrEmpty(currLanguage))
        {
            //currLanguage = Application.systemLanguage.ToString();
            currLanguage = "ChineseSimplified";
            SetCurLang(currLanguage);
        }

        return currLanguage;
    }

    private void SetCurLang(string language)
    {
        //TODO 更换存储方式
        PlayerPrefs.SetString("language", language);
    }

    private string _GetWord(string key)
    {
        if (key != null)
        {
            string word = wordMap[key][currLanguage] as string;
            if (string.IsNullOrEmpty(word))
            {
                word = key;
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
    public string GetWord(string key)
    {
        return instance._GetWord(key);
    }

    #endregion
}