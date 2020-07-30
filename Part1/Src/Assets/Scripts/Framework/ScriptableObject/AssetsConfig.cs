//=====================================================
// - FileName:      AssetsConfig.cs
// - Created:       @JCY
// - CreateTime:    2019/03/31 00:52:02
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

namespace Framework.ScriptableObject
{
    public class AssetsConfig : UnityEngine.ScriptableObject
    {
        [Rename("资源根目录")] public string GameResourceRootDir = "Addressable Asset/";
        [Rename("AuthorInfo路径")] public string AuthorInfoPath = string.Empty;
        [Rename("FrameworkDefine路径")] public string FrameworkDefinePath = string.Empty;
        [Rename("LogConfig路径")] public string LogConfigPath = string.Empty;
        [Rename("ABInfo路径")] public string ABInfoPath = string.Empty;
    }
}