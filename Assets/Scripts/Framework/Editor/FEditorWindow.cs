//=====================================================
// - FileName:      FEditorWindow.cs
// - Created:       @JCY
// - CreateTime:    2019/03/16 23:23:13
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

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
        public const string ShowExcelTools = "Framework/ShowExcelTools";
        public const string CreateScriptableObject = "Framework/AboutConfig/CreateScriptableObject";
        public const string RefreshUIConfig = "Framework/AboutConfig/RefreshUIConfig";
        public const string GetObjectPath = "Framework/快捷键/获取路径 %q";
    }

    public enum ToolsListPriorities
    {
        OpenScence_Start = 151,
        FindMissScriptInResource,
        ShowExcelTools,
        CreateScriptableObject,
        RefreshUIConfig,
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
            var webSite = Resources.Load<FrameworkDefine>("Configuation/FrameworkDefine");
            Application.OpenURL(webSite.FrameworkWebsite);
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
            //Packager.Instance().ShowMenu();
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
                EditorSceneManager.OpenScene("Assets/ABRes/Scenes/GameScenes/Start.unity");
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

        [MenuItem(ToolsList.RefreshUIConfig, false, (int) ToolsListPriorities.RefreshUIConfig)]
        public static void ResGOConfig()
        {
            RefreshConfig.ResGOConfig();
        }
        
        [MenuItem(ToolsList.GetObjectPath, false, (int) ToolsListPriorities.GetObjectPath)]
        public static void GetPath()
        {
            GetObjectPath.GetAssetsPath();
        }
    }
}