//=====================================================
// - FileName:      LoadScenceTask.cs
// - Created:       @JCY
// - CreateTime:    2019/08/22 22:56:57
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using Framework.Singleton;
using UnityEngine;

public class ExcelDataMgr : MonoSingleton<ExcelDataMgr>
{
    [SerializeField, Header("语言配置表")] private LanguageSheet language;
    [SerializeField, Header("机器配置表")] private MachineSheet machine;

    public LanguageSheet Language
    {
        get => language;
    }

    public MachineSheet Machine
    {
        get => machine;
    }
}