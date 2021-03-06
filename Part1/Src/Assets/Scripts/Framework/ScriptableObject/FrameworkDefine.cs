//=====================================================
// - FileName:      Define.cs
// - Created:       @JCY
// - CreateTime:    2019/03/16 23:37:12
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;

namespace Framework.ScriptableObject
{
    /// <summary>
    /// 框架声明定义
    /// </summary>
    public class FrameworkDefine : UnityEngine.ScriptableObject
    {
        [Rename("源码网址")] public string FrameworkWebsite = String.Empty;
    }
}