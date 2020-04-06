/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     PackagerAddressable
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.1f1
 *CreateTime:   2020/04/04 13:57:50
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/


using System;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Framework.Editor
{
    public class PackagerAddressable : EditorMenu<PackagerAddressable>
    {
        private string defaultDevDefineSymbols =
            @"Dev;GM;COMMON_DEV;UNITY_POST_PROCESSING_STACK_V2;CROSS_PLATFORM_INPUT;PLAYMAKER;PLAYMAKER_1_9;PLAYMAKER_1_9_0;PLAYMAKER_1_8_OR_NEWER;PLAYMAKER_1_8_5_OR_NEWER;PLAYMAKER_1_9_OR_NEWER;ODIN_INSPECTOR;UNITY_CCU";

        private string defaultDebugDefineSymbols =
            @"Debug;Dev;GM;COMMON_DEV;UNITY_POST_PROCESSING_STACK_V2;CROSS_PLATFORM_INPUT;PLAYMAKER;PLAYMAKER_1_9;PLAYMAKER_1_9_0;PLAYMAKER_1_8_OR_NEWER;PLAYMAKER_1_8_5_OR_NEWER;PLAYMAKER_1_9_OR_NEWER;ODIN_INSPECTOR;UNITY_CCU";

        private string defaultReleaseDefineSymbols =
            @"Release;COMMON_DEV;UNITY_POST_PROCESSING_STACK_V2;CROSS_PLATFORM_INPUT;PLAYMAKER;PLAYMAKER_1_9;PLAYMAKER_1_9_0;PLAYMAKER_1_8_OR_NEWER;PLAYMAKER_1_8_5_OR_NEWER;PLAYMAKER_1_9_OR_NEWER;ODIN_INSPECTOR;UNITY_CCU";

        private string devDefineSymbols { set; get; }
        private string debugDefineSymbols { set; get; }
        private string releaseDefineSymbols { set; get; }
        private string[] versionList = new string[3] {"正式版本", "开发版本", "测试版本"};
        private string DevIdentifier = $"com.{CompanyName}.{ProductName}";
        private string DebugIdentifier = $"com.{CompanyName}.{ProductName}";
        private string ReleaseIdentifier = $"com.{CompanyName}.{ProductName}";
        private const string CompanyName = "Single";
        private const string ProductName = "ProjectX";
        private string appName = string.Empty;
        private string[] levels = {"Assets/Addressable Asset/Scenes/GameScenes/Awake_Scene.unity"};
        private string version;
        private BuildTargetGroup buildTarget;
        private static int curSelect = -1;
        private int selectChannelEnvIndex;
        private int currTarget;
        private bool isReadly = false;

        public override void CreatWindow()
        {
            EditorWindow = GetWindow<PackagerAddressable>();
            EditorWindow.position = new Rect(250, 300, 800, 500);
            EditorWindow.Show();
        }

        public override void OnEnable()
        {
            version = Application.version;
            buildTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
            curSelect = -1;
            if (ES3.KeyExists("DevDefineSymbols"))
                devDefineSymbols = ES3.Load<string>("DevDefineSymbols");
            else
            {
                ES3.Save<string>("DevDefineSymbols", defaultDevDefineSymbols);
                devDefineSymbols = ES3.Load<string>("DevDefineSymbols");
            }

            if (ES3.KeyExists("DebugDefineSymbols"))
                debugDefineSymbols = ES3.Load<string>("DebugDefineSymbols");
            else
            {
                ES3.Save<string>("DebugDefineSymbols", defaultDebugDefineSymbols);
                debugDefineSymbols = ES3.Load<string>("DebugDefineSymbols");
            }

            if (ES3.KeyExists("ReleaseDefineSymbols"))
                releaseDefineSymbols = ES3.Load<string>("ReleaseDefineSymbols");
            else
            {
                ES3.Save<string>("ReleaseDefineSymbols", defaultReleaseDefineSymbols);
                releaseDefineSymbols = ES3.Load<string>("ReleaseDefineSymbols");
            }

            isReadly = true;
        }

        public override void OnDisable()
        {
            isReadly = false;
        }

        public override void OnGUI()
        {
            if (!isReadly) return;

            #region 版本号 

            version = EditorGUILayout.TextField("App Version：", version);
            GUILayout.Space(15);

            #endregion

            #region 版本设置

            devDefineSymbols = EditorGUILayout.TextField("DevDefineSymbols", devDefineSymbols);
            DevIdentifier = EditorGUILayout.TextField("DevIdentifier", DevIdentifier);
            GUILayout.Space(5);
            debugDefineSymbols = EditorGUILayout.TextField("TestDefineSymbols", debugDefineSymbols);
            DebugIdentifier = EditorGUILayout.TextField("TestIdentifier", DebugIdentifier);
            GUILayout.Space(5);
            releaseDefineSymbols = EditorGUILayout.TextField("ReleaseDefineSymbols", releaseDefineSymbols);
            ReleaseIdentifier = EditorGUILayout.TextField("ReleaseIdentifier", ReleaseIdentifier);
            GUILayout.Space(5);
            if (GUILayout.Button("保存信息", GUILayout.Height(30)))
            {
                if (!ES3.Load<string>("DevDefineSymbols").Equals(devDefineSymbols))
                {
                    ES3.Save<string>("DevDefineSymbols", devDefineSymbols);
                }

                if (!ES3.Load<string>("DebugDefineSymbols").Equals(debugDefineSymbols))
                {
                    ES3.Save<string>("DebugDefineSymbols", debugDefineSymbols);
                }

                if (!ES3.Load<string>("ReleaseDefineSymbols").Equals(releaseDefineSymbols))
                {
                    ES3.Save<string>("ReleaseDefineSymbols", releaseDefineSymbols);
                }
            }

            GUILayout.Space(15);
            var curSymbol = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTarget);
            if (curSelect == -1)
            {
                if (curSymbol.IndexOf("Dev", 0, curSymbol.Length, StringComparison.Ordinal) == -1
                    && curSymbol.IndexOf("Debug", 0, curSymbol.Length, StringComparison.Ordinal) == -1)
                {
                    //正式版本
                    curSelect = 0;
#if UNITY_EDITOR_OSX
						PlayerSettings.bundleIdentifier = ReleaseIdentifier;
#else
                    PlayerSettings.applicationIdentifier = ReleaseIdentifier;
#endif
                }
                else
                {
                    if (curSymbol.IndexOf("Debug", 0, curSymbol.Length, StringComparison.Ordinal) == -1)
                    {
                        //开发版本
                        curSelect = 1;
                        PlayerSettings.applicationIdentifier = DevIdentifier;
                    }
                    else
                    {
                        //测试版本
                        curSelect = 2;
#if UNITY_EDITOR_OSX
						PlayerSettings.bundleIdentifier = DebugIdentifier;
#else
                        PlayerSettings.applicationIdentifier = DebugIdentifier;
#endif
                    }
                }
            }

            selectChannelEnvIndex = GUILayout.SelectionGrid(curSelect, versionList, 10);
            if (selectChannelEnvIndex != curSelect)
            {
                curSelect = selectChannelEnvIndex;
                switch (curSelect)
                {
                    case 0:
                        //TODO 可以根据平台添加东西
                        curSymbol = releaseDefineSymbols;
#if UNITY_EDITOR_OSX
						PlayerSettings.bundleIdentifier = ReleaseIdentifier;
#else
                        PlayerSettings.applicationIdentifier = ReleaseIdentifier;
#endif
                        break;
                    case 1:
                        curSymbol = devDefineSymbols;
                        break;
                    case 2:
                        curSymbol = debugDefineSymbols;
#if UNITY_EDITOR_OSX
						PlayerSettings.bundleIdentifier = DebugIdentifier;
#else
                        PlayerSettings.applicationIdentifier = DebugIdentifier;
#endif
                        break;
                }
            }

            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTarget, curSymbol);
            GUILayout.Space(10);

            #endregion

            #region 资源包模式设定

            #endregion

            #region 生成完整资源包

            if (GUILayout.Button("生成完整资源包 ", GUILayout.Height(30)))
            {
                AssetDatabase.Refresh();
                AddressableAssetSettings.CleanPlayerContent();
                AddressableAssetSettings.CleanPlayerContent(AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilder);
                if (version.Length == 0 || version.Equals("0.0.0"))
                    EditorUtility.DisplayDialog(" Error ！！", " 请修改版本为有效数字", "确定");
                else
                    AddressableAssetSettings.BuildPlayerContent();
            }

            GUILayout.Space(15);

            #endregion

            #region 生成补丁包

            if (GUILayout.Button("生成补丁包 ", GUILayout.Height(30)))
            {
                AssetDatabase.Refresh();
                //TODO 
            }

            GUILayout.Space(15);

            #endregion

            #region 生成安装包

            if (GUILayout.Button("生成安装包 ", GUILayout.Height(30)))
            {
                switch (EditorUserBuildSettings.activeBuildTarget)
                {
                    case BuildTarget.StandaloneWindows:
                        appName = $"RunGameWin32.exe";
                        BuildPipeline.BuildPlayer(
                            levels,
                            ParentPath(),
                            BuildTarget.StandaloneWindows,
                            BuildOptions.ShowBuiltPlayer | BuildOptions.Development);
                        break;
                    case BuildTarget.StandaloneWindows64:
                        appName = $"RunGameWin64.exe";
                        BuildPipeline.BuildPlayer(
                            levels,
                            ParentPath(),
                            BuildTarget.StandaloneWindows64,
                            BuildOptions.ShowBuiltPlayer | BuildOptions.Development);
                        break;
                    case BuildTarget.Android:
                        appName = $"RunGameAndroid.apk";
                        BuildPipeline.BuildPlayer(
                            levels,
                            ParentPath(),
                            BuildTarget.Android,
                            BuildOptions.ShowBuiltPlayer);
                        break;
                    case BuildTarget.iOS:
#if UNITY_EDITOR_OSX
                        appName = $"RunGameAndroid.apk";?
                        BuildPipeline.BuildPlayer(levels, GetPath() + $"{GetPath()}/Win64/", BuildTarget.iOS,
                            BuildOptions.CompressWithLz4 | BuildOptions.ShowBuiltPlayer);
#endif
                        break;
                }
            }

            GUILayout.Space(15);

            #endregion

            string ParentPath()
            {
                var tmp = Application.dataPath.LastIndexOf("/Src", StringComparison.Ordinal);
                var path = Application.dataPath.Substring(0, tmp);
                switch (EditorUserBuildSettings.activeBuildTarget)
                {
                    case BuildTarget.StandaloneWindows:
                        return $"{Handle($"{path}/Build/Win32")}" + $"/{appName}";
                    case BuildTarget.StandaloneWindows64:
                        return $"{Handle($"{path}/Build/Win64")}" + $"/{appName}";
                    case BuildTarget.Android:
                        return $"{Handle($"{path}/Build/Win64")}" + $"/{appName}";
                    case BuildTarget.iOS:
#if UNITY_EDITOR_OSX
                        return  String.Empty;
#endif
                        break;
                }

                return String.Empty;

                string Handle(string tmpPath)
                {
                    if (Directory.Exists(tmpPath))
                    {
                        var dir = new DirectoryInfo(tmpPath);
                        var fileinfo = dir.GetFileSystemInfos(); //返回目录中所有文件和子目录
                        foreach (FileSystemInfo i in fileinfo)
                        {
                            if (i is DirectoryInfo) //判断是否文件夹
                            {
                                var subdir = new DirectoryInfo(i.FullName);
                                subdir.Delete(true); //删除子目录和文件
                            }
                            else
                                File.Delete(i.FullName); //删除指定文件
                        }
                    }

                    Directory.CreateDirectory(tmpPath);
                    return tmpPath;
                }
            }
        }
    }
}