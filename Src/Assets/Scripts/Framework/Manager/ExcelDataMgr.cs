//=====================================================
// - FileName:      LoadScenceTask.cs
// - Created:       @JCY
// - CreateTime:    2019/08/22 22:56:57
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using UnityEngine;

public class ExcelDataMgr : MonoSingleton<ExcelDataMgr>
{
    [SerializeField, Header("语言配置表")] private LanguageSheet language;

    public LanguageSheet Language
    {
        get { return language; }
    }
}