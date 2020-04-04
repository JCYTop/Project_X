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
        private string[] versionList = new string[3] {"正式版本", "开发版本", "测试版本"};

        private string DevDefineSymbols =
            "Dev;GM;COMMON_DEV;UNITY_POST_PROCESSING_STACK_V2;CROSS_PLATFORM_INPUT;PLAYMAKER;PLAYMAKER_1_9;PLAYMAKER_1_9_0;PLAYMAKER_1_8_OR_NEWER;PLAYMAKER_1_8_5_OR_NEWER;PLAYMAKER_1_9_OR_NEWER;ODIN_INSPECTOR;UNITY_CCU";

        private string DevIdentifier = $"com.{CompanyName}.{ProductName}";

        private string DebugDefineSymbols =
            "Debug;Dev;GM;COMMON_DEV;UNITY_POST_PROCESSING_STACK_V2;CROSS_PLATFORM_INPUT;PLAYMAKER;PLAYMAKER_1_9;PLAYMAKER_1_9_0;PLAYMAKER_1_8_OR_NEWER;PLAYMAKER_1_8_5_OR_NEWER;PLAYMAKER_1_9_OR_NEWER;ODIN_INSPECTOR;UNITY_CCU";

        private string DebugIdentifier = $"com.{CompanyName}.{ProductName}";

        private string ReleaseDefineSymbols =
            "Release;COMMON_DEV;UNITY_POST_PROCESSING_STACK_V2;CROSS_PLATFORM_INPUT;PLAYMAKER;PLAYMAKER_1_9;PLAYMAKER_1_9_0;PLAYMAKER_1_8_OR_NEWER;PLAYMAKER_1_8_5_OR_NEWER;PLAYMAKER_1_9_OR_NEWER;ODIN_INSPECTOR;UNITY_CCU";

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
        }

        public override void OnDisable()
        {
        }

        public override void OnGUI()
        {
            #region 版本号 

            version = EditorGUILayout.TextField("App Version：", version);
            GUILayout.Space(15);

            #endregion

            #region 版本设置

            DevDefineSymbols = EditorGUILayout.TextField("DevDefineSymbols", DevDefineSymbols);
            DevIdentifier = EditorGUILayout.TextField("DevIdentifier", DevIdentifier);
            GUILayout.Space(5);
            DebugDefineSymbols = EditorGUILayout.TextField("TestDefineSymbols", DebugDefineSymbols);
            DebugIdentifier = EditorGUILayout.TextField("TestIdentifier", DebugIdentifier);
            GUILayout.Space(5);
            ReleaseDefineSymbols = EditorGUILayout.TextField("ReleaseDefineSymbols", ReleaseDefineSymbols);
            ReleaseIdentifier = EditorGUILayout.TextField("ReleaseIdentifier", ReleaseIdentifier);
            GUILayout.Space(5);
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
                        curSymbol = ReleaseDefineSymbols;
#if UNITY_EDITOR_OSX
						PlayerSettings.bundleIdentifier = ReleaseIdentifier;
#else
                        PlayerSettings.applicationIdentifier = ReleaseIdentifier;
#endif
                        break;
                    case 1:
                        curSymbol = DevDefineSymbols;
                        break;
                    case 2:
                        curSymbol = DebugDefineSymbols;
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