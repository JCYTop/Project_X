//=====================================================
// - FileName:      FEditorWindow.cs
// - Created:       @JCY
// - CreateTime:    2019/03/16 23:23:13
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class FrameworkToolsMenu
{
    public const string SourceWebsite = "Framework/Source Website"; //源文件的网址

    public enum FrameworkMenuPriorities
    {
        SourceWebsite,
    }

    public const string Packager = "Framework/Packager _F12";
    public const string OpenInFileBrowser = "Framework/OpenInFileBrowser";
    public const string OpenInPersistentDataPath = "Framework/OpenInPersistentDataPath";

    public enum FrameworkToolsMenuPriorities
    {
        Packager = 51,
        OpenInFileBrowser,
        OpenInPersistentDataPath
    }

    public static class ToolsList
    {
        public const string OpenScence_Start = "Framework/OpenScence/Start";
        public const string FindMissScriptInResource = "Framework/FindMissScriptInResource";
        public const string ShowExcelTools = "Framework/Excel工具";
        public const string FindConfig_ABInfo = "Framework/关于配置文件/配置文件/ABInfo";
        public const string FindConfig_AssetsConfig = "Framework/关于配置文件/配置文件/AssetsConfig";
        public const string FindConfig_AuthorInfo = "Framework/关于配置文件/配置文件/AuthorInfo";
        public const string FindConfig_FrameworkDefine = "Framework/关于配置文件/配置文件/FrameworkDefine";
        public const string FindConfig_LogConfig = "Framework/关于配置文件/配置文件/LogConfig";
        public const string CreateScriptableObject = "Framework/关于配置文件/创建配置文件";
        public const string RefreshConfig = "Framework/关于配置文件/刷新资源配置文件 _F11";
        public const string CleanRefreshConfig = "Framework/关于配置文件/清除资源配置文件 #_F11";
        public const string GetObjectPath = "Framework/快捷键/获取路径 %q";
    }

    public enum ToolsListPriorities
    {
        OpenScence_Start = 151,
        FindMissScriptInResource,
        ShowExcelTools,
        FindConfig_ABInfo,
        FindConfig_AssetsConfig,
        FindConfig_AuthorInfo,
        FindConfig_FrameworkDefine,
        FindConfig_LogConfig,
        CreateScriptableObject,
        RefreshConfig,
        CleanRefreshConfig,
        GetObjectPath
    }

    public class FEditorWindow : EditorWindow
    {
        #region FrameworkMenu

        /// <summary>
        /// 打开框架的网址地址
        /// </summary>
        [MenuItem(SourceWebsite, false, (int) FrameworkMenuPriorities.SourceWebsite)]
        private static void OpenCodeWebsite()
        {
            //直接打开网页
            Application.OpenURL(Define.FrameworkDefine.FrameworkWebsite);
        }

        private static void DownloadLatestVersion()
        {
            //TODO 搭建网络模块之后回来编写
        }

        #endregion

        #region FrameworkToolsMenu

        /// <summary>
        /// 打AB包操作
        /// </summary>
        [MenuItem(Packager, false, (int) FrameworkToolsMenuPriorities.Packager)]
        private static void ShowPackager()
        {
            BuildWindow.Instance().ShowMenu();
        }

        [MenuItem(FrameworkToolsMenu.OpenInFileBrowser, false, (int) FrameworkToolsMenuPriorities.OpenInFileBrowser)]
        private static void OpenInFileBrowser()
        {
            OpenInFileBrowserMenu.Instance().ShowMenu();
        }

        [MenuItem(OpenInPersistentDataPath, false, (int) FrameworkToolsMenuPriorities.OpenInPersistentDataPath)]
        private static void OpenInpersistentBrowser()
        {
            OpenInpersistentMenu.Instance().ShowMenu();
        }

        #endregion

        [MenuItem(ToolsList.OpenScence_Start, false, (int) ToolsListPriorities.OpenScence_Start)]
        private static void OpenScence_Start()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo() == true)
            {
                EditorSceneManager.OpenScene("AssetsTask/ABRes/Scenes/GameScenes/Start.unity");
            }
        }

        [MenuItem(ToolsList.FindMissScriptInResource, false, (int) ToolsListPriorities.FindMissScriptInResource)]
        public static void FindMissScriptInResource()
        {
            CheckResMenu.Instance().FindMissScriptInResource();
        }

        [MenuItem(ToolsList.ShowExcelTools, false, (int) ToolsListPriorities.ShowExcelTools)]
        public static void ShowExcelTools()
        {
            ExcelToolMenu.Instance().ShowMenu();
        }

        [MenuItem(ToolsList.CreateScriptableObject, false, (int) ToolsListPriorities.CreateScriptableObject)]
        public static void CreateScriptableObject()
        {
            ScriptableObjectMenu.Instance().ShowMenu();
        }

        [MenuItem(ToolsList.RefreshConfig, false, (int) ToolsListPriorities.RefreshConfig)]
        public static void ResGOConfig()
        {
            RefreshConfig.ResGOConfig();
        }

        [MenuItem(ToolsList.CleanRefreshConfig, false, (int) ToolsListPriorities.CleanRefreshConfig)]
        public static void CleanResGOConfig()
        {
            RefreshConfig.CleanResGOConfig();
        }

        [MenuItem(ToolsList.GetObjectPath, false, (int) ToolsListPriorities.GetObjectPath)]
        public static void GetPath()
        {
            GetObjectPath.GetAssetsPath();
        }

        [MenuItem(ToolsList.FindConfig_ABInfo, false, (int) ToolsListPriorities.FindConfig_ABInfo)]
        public static void FindConfig_ABInfo()
        {
            Selection.activeObject = Define.ABInfo;
        }

        [MenuItem(ToolsList.FindConfig_AssetsConfig, false, (int) ToolsListPriorities.FindConfig_AssetsConfig)]
        public static void FindConfig_AssetsConfig()
        {
            Selection.activeObject = Define.AssetsConfig;
        }

        [MenuItem(ToolsList.FindConfig_AuthorInfo, false, (int) ToolsListPriorities.FindConfig_AuthorInfo)]
        public static void FindConfig_AuthorInfo()
        {
            Selection.activeObject = Define.AuthorInfo;
        }

        [MenuItem(ToolsList.FindConfig_FrameworkDefine, false, (int) ToolsListPriorities.FindConfig_FrameworkDefine)]
        public static void FindConfig_FrameworkDefine()
        {
            Selection.activeObject = Define.FrameworkDefine;
        }

        [MenuItem(ToolsList.FindConfig_LogConfig, false, (int) ToolsListPriorities.FindConfig_LogConfig)]
        public static void FindConfig_LogConfig()
        {
            Selection.activeObject = Define.LogConfig;
        }

        [MenuItem("AssetsTask/开始游戏", false, 0)]
        public static void StartGame()
        {
            //TODO 换成通用接口
            if (!EditorApplication.isPlaying)
            {
                string currentSceneName = EditorApplication.currentScene;
                File.WriteAllText("_lastScene", currentSceneName);
                EditorApplication.SaveScene(EditorApplication.currentScene);
                //TODO
                EditorApplication.OpenScene("AssetsTask/ABRes/Scenes/GameScenes/Awake.unity");
                EditorApplication.isPlaying = true;
            }

            if (EditorApplication.isPlaying)
            {
                string lastScene = File.ReadAllText("lastScene");
                EditorApplication.isPlaying = false;
                EditorApplication.OpenScene(lastScene);
            }
        }
    }
}