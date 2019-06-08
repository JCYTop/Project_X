/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     BuildWindow
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/01 16:42:17
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEditor;
using UnityEngine;

public class BuildWindow : EditorMenu<BuildWindow>
{
    #region 字段

    /// <summary>
    /// 当前版本
    /// </summary>
    private string appVer;

    /// <summary>
    /// 版本选择
    /// </summary>
    public string[] verList = new string[3] {"开发版本", "测试版本", "正式版本"};

    /// <summary>
    /// 打包平台
    /// </summary>
    private BuildTargetGroup buildTarget;

    /// <summary>
    /// 打包选项
    /// </summary>
    private BuildOptions buildOptions;

    /// <summary>
    /// 发布版本
    /// </summary>
    private int selectChannelEnvIndex;

    /// <summary>
    /// 是否读取AB包
    /// </summary>
    private bool isReadAB;

    private static int curSelect = -1;

    #endregion

    public override void CreatWindow()
    {
        EditorWindow = GetWindow<BuildWindow>();
        EditorWindow.position = new Rect(250, 300, 400, 600);
        EditorWindow.Show();
        isReadAB = !AssetBundleManager.SimulateAssetBundleInEditor;
    }

    public override void OnEnable()
    {
        appVer = Application.version;
        selectChannelEnvIndex = 0;
        buildTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
    }

    public override void OnDisable()
    {
    }

    public override void OnGUI()
    {
        #region 发布版本

        //=========================== 发布版本 ================================
        //动态设置打包信息
        var curSymbol = string.Empty;
        if (curSelect == -1)
        {
            curSymbol = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTarget);
            //TODO 
        }

        selectChannelEnvIndex = EditorGUILayout.Popup("选择发布版本：", selectChannelEnvIndex, verList);
        //处理不同版本的一些 PlayerSetting 设置
        if (selectChannelEnvIndex != curSelect)
        {
            curSelect = selectChannelEnvIndex;
            var offset = 0;
            switch (curSelect)
            {
                case 0:
                    curSymbol = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTarget);

                    break;

                case 1:
                    curSymbol = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTarget);

                    break;

                case 2:
                    curSymbol = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTarget);

                    break;
            }

            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTarget, curSymbol);
            LogUtil.Log(string.Format(curSymbol), LogType.NormalLog);
        }

        GUILayout.Space(10);

        #endregion

        #region 打包选项

        //=========================== 打包选项 ================================
        buildOptions = (BuildOptions) EditorGUILayout.EnumMaskField("打包选项: ", buildOptions);
        if (Packager.BuildOptions != buildOptions)
        {
            Packager.BuildOptions = buildOptions;
        }

        GUILayout.Space(10);

        #endregion

        #region 选择平台

        //=========================== 选择平台 ================================
        buildTarget = (BuildTargetGroup) EditorGUILayout.EnumPopup(new GUIContent("平台："), buildTarget);
        if (Packager.CurrTarget != buildTarget)
        {
            // 重新判断当前版本设定
            Packager.CurrTarget = buildTarget;
        }

        GUILayout.Space(10);

        #endregion

        #region 版本号

        //=========================== 版本号 ================================
        appVer = EditorGUILayout.TextField("App Version：", appVer);
        if (!appVer.Equals(VersionEditorManager.Instance().CurrVersion))
        {
            VersionEditorManager.Instance().CurrVersion = appVer;
            PlayerSettings.bundleVersion = appVer;
        }

        GUILayout.Space(10);

        #endregion

        #region 是否读取直接读取AB

        GUILayout.Space(10);
        //=========================== 是否读取AB包 ===========================
        isReadAB = EditorGUILayout.Toggle(new GUIContent("读取AB包："), Packager.isReadAB);
        if (Packager.isReadAB != isReadAB)
        {
            Packager.isReadAB = isReadAB;
            AssetBundleManager.SimulateAssetBundleInEditor = !Packager.isReadAB;
        }

        #endregion

        #region 标记AB资源

        //=========================== 标记AB资源 ===========================
        if (GUILayout.Button("标记AB", GUILayout.Height(30)))
        {
            Packager.BuildAssetMarks();
            Packager.WritePreloadFile();
            Packager.CreateVersion();
        }

        GUILayout.Space(20);

        #endregion

        #region 生成AB资源

        //=========================== 生成AB资源 ===========================
        if (GUILayout.Button("生成AB", GUILayout.Height(30)))
        {
            Packager.ClearABFolder();
            Packager.GenerateAB();
        }

        GUILayout.Space(10);

        #endregion

        #region 生成安装包

        //=========================== 生成安装包 ===========================

        if (GUILayout.Button("生成安装包 ", GUILayout.Height(30)))
        {
            if (appVer.Length == 0 || appVer.Equals("0.0.0"))
            {
                EditorUtility.DisplayDialog(" Error ！！", " 请修改版本为有效数字", "确定");
            }
            else
            {
                switch (Packager.CurrTarget)
                {
                    case BuildTargetGroup.iOS:
                        Packager.BuildIOS();
                        break;
                    case BuildTargetGroup.Standalone:
                        Packager.BuildWindows();
                        break;
                    case BuildTargetGroup.Android:
                        Packager.BuildAndroid();
                        break;
                }
            }
        }

        GUILayout.Space(10);
        if (Packager.CurrTarget == BuildTargetGroup.iOS)
        {
            if (GUILayout.Button("生成IPA", GUILayout.Height(30)))
            {
//TODO 苹果IPA 生成大法？？？
            }

            GUILayout.Space(10);
        }

        GUILayout.Space(10);
        if (GUILayout.Button("生成版本更新包 ", GUILayout.Height(30)))
        {
            Packager.CopyFullABRes();
            var patch = PatchUtil.Instance();
            patch.Init();
            patch.BuildPatch();
        }

        GUILayout.Space(10);

        #endregion
    }
}