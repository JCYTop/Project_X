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

namespace Framework.Editor
{
    public static class FrameworkToolsMenu
    {
        public const string SourceWebsite = "Framework/Source Website"; //源文件的网址

        public enum FrameworkMenuPriorities
        {
            SourceWebsite,
        }

        public const string OpenInFileBrowser = "Framework/OpenInFileBrowser";
        public const string OpenInPersistentDataPath = "Framework/OpenInPersistentDataPath";
        public const string OpenAddressableBuild = "Framework/寻址系统打包工具";

        public enum FrameworkToolsMenuPriorities
        {
            OpenInFileBrowser = 51,
            OpenInPersistentDataPath,
            AddressableBuild,
        }

        public class ToolsList
        {
            public const string FindMissScriptInResource = "Framework/FindMissScriptInResource";
            public const string ShowExcelTools = "Framework/Excel工具";
            public const string FindConfig_AssetsConfig = "Framework/关于配置文件/配置文件/AssetsConfig";
            public const string FindConfig_FrameworkDefine = "Framework/关于配置文件/配置文件/FrameworkDefine";
            public const string FindConfig_LogConfig = "Framework/关于配置文件/配置文件/LogConfig";
            public const string CreateScriptableObject = "Framework/关于配置文件/创建配置文件";
            public const string RefreshConfig = "Framework/关于配置文件/刷新资源配置文件 _F11";
            public const string CleanRefreshConfig = "Framework/关于配置文件/清除资源配置文件 #_F11";
            public const string GetObjectPath = "Framework/快捷键/获取路径 %q";
        }

        public enum ToolsListPriorities
        {
            FindMissScriptInResource = 151,
            ShowExcelTools,
            FindConfig_AssetsConfig,
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
                Application.OpenURL(GlobalDefine.FrameworkDefine.FrameworkWebsite);
            }

            #endregion

            #region FrameworkToolsMenu

            [MenuItem(FrameworkToolsMenu.OpenAddressableBuild, false, (int) FrameworkToolsMenuPriorities.AddressableBuild)]
            private static void OpenAddressableBuild()
            {
                PackagerAddressable.Instance().ShowMenu();
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

            [MenuItem(ToolsList.FindConfig_AssetsConfig, false, (int) ToolsListPriorities.FindConfig_AssetsConfig)]
            public static void FindConfig_AssetsConfig()
            {
                Selection.activeObject = GlobalDefine.AssetsConfig;
            }

            [MenuItem(ToolsList.FindConfig_FrameworkDefine, false, (int) ToolsListPriorities.FindConfig_FrameworkDefine)]
            public static void FindConfig_FrameworkDefine()
            {
                Selection.activeObject = GlobalDefine.FrameworkDefine;
            }

            [MenuItem(ToolsList.FindConfig_LogConfig, false, (int) ToolsListPriorities.FindConfig_LogConfig)]
            public static void FindConfig_LogConfig()
            {
                Selection.activeObject = GlobalDefine.LogConfig;
            }

            [MenuItem("Assets/开始游戏", false, 0)]
            public static void StartGame()
            {
                if (!EditorApplication.isPlaying)
                {
                    string currentSceneName = EditorApplication.currentScene;
                    File.WriteAllText("_lastScene", currentSceneName);
                    EditorApplication.SaveScene(EditorApplication.currentScene);
                    EditorApplication.OpenScene("Assets/Addressable Asset/Scenes/GameScenes/Awake_Scene.unity");
                    EditorApplication.isPlaying = true;
                }
                else
                {
                    string lastScene = File.ReadAllText("lastScene");
                    EditorApplication.isPlaying = false;
                    EditorApplication.OpenScene(lastScene);
                }
            }

            [MenuItem("Assets/场景列表/Awake_Scene", false, 0)]
            public static void Open_Awake_Scene()
            {
                if (!EditorApplication.isPlaying)
                {
                    EditorApplication.OpenScene("Assets/Addressable Asset/Scenes/GameScenes/Awake_Scene.unity");
                }
                else
                {
                    LogTool.Log($"需要关闭场景");
                }
            }

            [MenuItem("Assets/场景列表/Start_Scene", false, 0)]
            public static void Open_Start_Scene()
            {
                if (!EditorApplication.isPlaying)
                {
                    EditorApplication.OpenScene("Assets/Addressable Asset/Scenes/GameScenes/Start_Scene.unity");
                }
                else
                {
                    LogTool.Log($"需要关闭场景");
                }
            }

            [MenuItem("Assets/场景列表/Test_GOAP_AI_Scene", false, 0)]
            public static void Open_Test_GOAP_AI_Scene()
            {
                if (!EditorApplication.isPlaying)
                {
                    EditorApplication.OpenScene("Assets/Addressable Asset/Scenes/GameScenes/TestScene/Test_GOAP_AI_Scene.unity");
                }
                else
                {
                    LogTool.Log($"需要关闭场景");
                }
            }
        }
    }
}