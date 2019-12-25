/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Packager
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/01 16:43:07
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Framework.Assets;
using UnityEditor;
using UnityEngine;

public class Packager
{
    public static BuildTargetGroup CurrTarget = BuildTargetGroup.Android;
    private static BuildTarget BuildTarget = BuildTarget.Android;
    public static BuildOptions BuildOptions = BuildOptions.ShowBuiltPlayer;
    public static bool isReadAB = false;

    /// <summary>
    /// 标记AB资源
    /// </summary>
    public static void BuildAssetMarks()
    {
        var sourcePath = Application.dataPath + "/" + GlobalDefine.AssetsConfig.GameResourceRootDir;
        var fileSystemEntries = new List<string>();
        fileSystemEntries.AddRange(Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories).Select(d => d + "\\"));
        fileSystemEntries.AddRange(Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories));
        for (int i = 0; i < fileSystemEntries.Count; i++)
        {
            var filePath = fileSystemEntries[i];
            var ext = Path.GetExtension(filePath).ToLower();
            var assetPath = filePath.Replace(Application.dataPath, "Assets");
            var import = AssetImporter.GetAtPath(assetPath);
            if (import != null)
            {
                if (ext.Equals(".prefab") || ext.Equals(".png") || ext.Equals(".mat") || ext.Equals(".unity"))
                {
                    if (!ext.Equals(".png"))
                    {
                        assetPath = assetPath.Replace(ext, "");
                    }
                    else
                    {
                        assetPath = assetPath.Replace(ext, ".img");
                    }

                    import.assetBundleName = assetPath;
                }
                else
                {
                    import.assetBundleName = "";
                }

                UpdateProgress(i, fileSystemEntries.Count, assetPath);
            }
        }

        EditorUtility.ClearProgressBar();
    }

    public static void UpdateProgress(int progress, int progressMax, string desc)
    {
        var title = string.Format("Processing...[{0} - {1}]", progress, progressMax);
        var value = progress / progressMax;
        EditorUtility.DisplayProgressBar(title, desc, value);
    }

    /// <summary>
    /// 输出提前加载文件
    /// </summary>
    public static void WritePreloadFile()
    {
        var sourcePath = Application.dataPath + "/" + GlobalDefine.AssetsConfig.GameResourceRootDir;
        var fileSystemEntries = new List<string>();
        fileSystemEntries.AddRange(Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories).Select(d => d + "\\"));
        fileSystemEntries.AddRange(Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories));
        var fileList = new PreloadFileModel();
        for (int i = 0; i < fileSystemEntries.Count; i++)
        {
            var filePath = fileSystemEntries[i];
            var ext = Path.GetExtension(filePath).ToLower();
            var assetPath = filePath.Replace(Application.dataPath, "Assets");
            var import = AssetImporter.GetAtPath(assetPath);
            if (import != null)
            {
                assetPath = assetPath.Replace(ext, "").Replace("\\", "/");
                //Common文件夹标记提前加载
                if (ext.Equals(".prefab") && assetPath.Contains("Common"))
                {
                    fileList.Add(assetPath);
                }

                UpdateProgress(i, fileSystemEntries.Count, assetPath);
            }
        }

        FileUtils.JsonWrite<PreloadFileModel>(fileList, Application.streamingAssetsPath + "/Config/PreloadAB.json");
        EditorUtility.ClearProgressBar();
    }

    /// <summary>
    /// 清除AB包
    /// </summary>
    public static void ClearABFolder()
    {
        string resPath = GetABPath();
        if (Directory.Exists(resPath))
        {
            Directory.Delete(resPath, true);
        }
    }

    private static string GetABPath()
    {
        return Application.dataPath + "/../AssetBundles/" + GetPlatformFolderForAssetBundles(CurrTarget);
    }

    /// <summary>
    /// 返回文件夹头
    /// </summary>
    /// <param name="currTarget"></param>
    /// <returns></returns>
    private static string GetPlatformFolderForAssetBundles(BuildTargetGroup currTarget)
    {
        switch (currTarget)
        {
            case BuildTargetGroup.Android:
                BuildTarget = BuildTarget.Android;
                return "Android";
            case BuildTargetGroup.iOS:
                BuildTarget = BuildTarget.iOS;
                return "IOS";
            case BuildTargetGroup.Standalone:
                BuildTarget = BuildTarget.StandaloneWindows64;
                return "Standalone";
            default:
                return "UnKnow";
        }
    }

    /// <summary>
    /// 生成AB包
    /// </summary>
    public static void GenerateAB()
    {
        string resPath = GetABPath();
        if (!Directory.Exists(resPath))
            Directory.CreateDirectory(resPath);
        //Core Logic
        BuildPipeline.BuildAssetBundles(resPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget);
    }

    /// <summary>
    /// 生成打包文件信息列表
    /// </summary>
    public static void CreateVersion()
    {
        var fi = new FileInfo(Application.streamingAssetsPath + "/StreamPath.txt");
        using (StreamWriter sw = fi.CreateText())
        {
            GetFilePath(Application.streamingAssetsPath, sw);
        }

        AssetDatabase.Refresh();
        LogUtil.Log(string.Format("新版本生成成功"), LogType.NormalLog);
    }

    private static void GetFilePath(string streamPath, StreamWriter sw)
    {
        var info = new DirectoryInfo(streamPath);
        foreach (var fsi in info.GetFileSystemInfos())
        {
            if (fsi.Extension != ".meta" && fsi.Name != "StreamPath.txt")
            {
                var path = fsi.FullName.Split(new string[] {"StreamingAssets"}, System.StringSplitOptions.None); //得到相对路径
                path[1] = path[1].Replace('\\', '/'); //安卓上只能识别"/"
                if (fsi is DirectoryInfo)
                {
                    //是文件夹则迭代
                    sw.WriteLine(path[1] + " | 0"); //按行写入
                    var ignored = fsi.FullName.EndsWith("AssetBundles");
                    if (!ignored)
                    {
                        GetFilePath(fsi.FullName, sw);
                    }
                }
                else
                {
                    sw.WriteLine(path[1] + " | 1" + "|" + string.Format("{0:F}", ((FileInfo) fsi).Length / 1024.0f)); //按行写入
                }
            }
        }
    }

    public static void BuildIOS()
    {
        var type = BuildTargetGroup.iOS;
        CopyABRes(type);
        //TODO 打包信息设置
        //只打包第一个场景
        AssetDatabase.Refresh();
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, GetPath() + "/Proj_IOS", BuildTarget.iOS, BuildOptions);
    }

    public static void BuildWindows()
    {
        var type = BuildTargetGroup.Standalone;
        CopyABRes(type);
        //TODO 打包信息设置
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, GetPath() + "/Proj.apk", BuildTarget.Android, BuildOptions);
    }

    public static void BuildAndroid()
    {
        var type = BuildTargetGroup.Android;
        CopyABRes(type);
        //TODO 打包信息设置
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, GetPath() + "/Proj_Win/Game.exe", BuildTarget.StandaloneWindows, BuildOptions);
    }

    private static void CopyABRes(BuildTargetGroup type)
    {
        CleanABPath();
        var osPath = GetPlatformFolderForAssetBundles(type);
        CopyDirectory(Application.dataPath + "/../AssetBundles/" + osPath, Application.streamingAssetsPath + "/AssetBundles/" + osPath,
            new string[] {".manifest", ".meta"}, new string[] {osPath + ".manifest"});
    }

    private static void CleanABPath()
    {
        var dirName = Application.streamingAssetsPath + "/AssetBundles";
        var dic = new DirectoryInfo(dirName);
        if (dic.Exists)
        {
            Directory.Delete(dirName, true);
        }
    }

    private static void CopyDirectory(string fromDir, string toDir, string[] ignoreExts = null, string[] needFiles = null)
    {
        if (Directory.Exists(fromDir))
        {
            if (!Directory.Exists(toDir))
            {
                Directory.CreateDirectory(toDir);
            }

            var files = Directory.GetFiles(fromDir, "*", SearchOption.AllDirectories);
            var dirs = Directory.GetDirectories(fromDir, "*", SearchOption.AllDirectories);
            foreach (var soureDir in dirs)
            {
                var desDir = soureDir.Replace(fromDir, toDir);
                LogUtil.Log(string.Format("path: {0}", desDir), LogType.NormalLog);
                if (!Directory.Exists(desDir))
                {
                    Directory.CreateDirectory(desDir);
                }
            }

            foreach (var soureFile in files)
            {
                var extName = Path.GetExtension(soureFile);
                var fileName = Path.GetFileName(soureFile);
                if (needFiles != null && needFiles.Contains<string>(fileName))
                {
                    File.Copy(soureFile, soureFile.Replace(fromDir, toDir), true);
                }
                else if (!string.IsNullOrEmpty(extName) && ignoreExts != null && ignoreExts.Contains<string>(extName))
                {
                    LogUtil.Log(string.Format("ignoreFile: {0}", soureFile), LogType.NormalLog);
                }
                else
                {
                    File.Copy(soureFile, soureFile.Replace(fromDir, toDir), true);
                }
            }
        }
    }

    public static string GetPath()
    {
        var tmp = Application.dataPath.LastIndexOf("/");
        var path = Application.dataPath.Substring(0, tmp);
        return path;
    }

    public static void CopyFullABRes()
    {
        CleanABPath();
        CopyDirectory(Application.dataPath + "/../AssetBundles", Application.streamingAssetsPath + "/AssetBundles");
    }

    public static string GetPlatformManifest()
    {
        return GetPlatformFolderForAssetBundles(CurrTarget) + ".manifest";
    }
}