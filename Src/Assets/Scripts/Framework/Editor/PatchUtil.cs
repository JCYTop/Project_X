/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     PatchUtil
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/01 22:38:52
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Framework.Assets;
using ICSharpCode.SharpZipLib.Zip;
using UnityEditor;
using UnityEngine;
using Framework.Singleton;

namespace Framework.Editor
{
    public class PatchUtil : Singleton<PatchUtil>
    {
        private string sourcePath = Application.streamingAssetsPath; //源文件路径
        private string targetPath = Application.dataPath + "/../Patch/"; //补丁存放路径
        private List<PatchInfo> patchList = new List<PatchInfo>();

        public void Init()
        {
            patchList.Clear();
            UpdatePatchList();
        }

        private void UpdatePatchList()
        {
            var foldList = Directory.GetDirectories(targetPath);
            for (int i = 0; i < foldList.Length; i++)
            {
                var folderName = foldList[i];
                var vername = Path.GetFileName(folderName).Replace("_", ".");
                var info = new PatchInfo(vername);
                info.LoadContent(folderName);
                if (info.isVaild)
                {
                    patchList.Add(info);
                }
            }
        }

        /// <summary>
        /// 构建补丁包
        /// </summary>
        public void BuildPatch()
        {
            //1. 创建当前版本目录
            var folderName = VersionEditorManager.Instance().CurrVersion.Replace(".", "_");
            folderName = targetPath + folderName;
            if (Directory.Exists(folderName)) return;
            var patchInfo = new PatchInfo(VersionEditorManager.Instance().CurrVersion);
            Directory.CreateDirectory(folderName);

            //2. 统计当前版本所有文件信息，保存至文本文件
            var fileSystemEntries = new List<string>();
            fileSystemEntries.AddRange(Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories));
            var fs = new FileStream(folderName + "/files.txt", FileMode.CreateNew);
            var sw = new StreamWriter(fs);
            for (int i = 0; i < fileSystemEntries.Count; i++)
            {
                var file = fileSystemEntries[i];
                file = file.Replace("\\", "/");
                if (file.EndsWith(".meta") || file.Contains(".DS_Store") ||
                    (file.Contains(".manifest") && !(file.Contains(Packager.GetPlatformManifest())))) continue;
                var fileStream = new FileStream(file, FileMode.Open);
                var size = (int) fileStream.Length;
                var md5 = FileTools.FSToMD5(fileStream);
                var value = file.Replace(sourcePath, string.Empty).Substring(1);
                var content = value + "|" + md5 + "|" + size;
                patchInfo.AddFileInfo(content);
                sw.WriteLine(content);
                fileStream.Close();
                Packager.UpdateProgress(i, fileSystemEntries.Count, "Generating file list..");
            }

            sw.Close();
            fs.Close();
            //3.与历史版本对比压缩所有差异文件
            foreach (var pInfo in patchList)
            {
                var diffFiles = pInfo.GetDiffFiles(patchInfo);
                if (diffFiles.Count == 0) continue;
                var commonStream = new FileStream(pInfo.GetPatchPath() + "/Common.zip", FileMode.Create);
                var commonZipper = new ZipOutputStream(commonStream);
                commonZipper.SetLevel(5);
                var iosStream = new FileStream(pInfo.GetPatchPath() + "/iOS.zip", FileMode.Create);
                var iosZipper = new ZipOutputStream(iosStream);
                iosZipper.SetLevel(5);
                var androidZipper = new ZipOutputStream(new FileStream(pInfo.GetPatchPath() + "/Android.zip", FileMode.Create));
                androidZipper.SetLevel(5);
                var winZipper = new ZipOutputStream(new FileStream(pInfo.GetPatchPath() + "/Windows.zip", FileMode.Create));
                winZipper.SetLevel(5);
                var versionNum = pInfo.Ver;
                for (int i = 0; i < diffFiles.Count; i++)
                {
                    var fileName = diffFiles[i] as string;
                    var compressor = commonZipper;
                    if (fileName.Contains("AssetBundles/iOS/") || fileName.Contains("Audio/GeneratedSoundBanks/iOS/"))
                    {
                        compressor = iosZipper;
                    }
                    else if (fileName.Contains("AssetBundles/Windows/") || fileName.Contains("Audio/GeneratedSoundBanks/Windows/"))
                    {
                        compressor = winZipper;
                    }
                    else if (fileName.Contains("AssetBundles/Android/") || fileName.Contains("Audio/GeneratedSoundBanks/Android/"))
                    {
                        compressor = androidZipper;
                    }

                    compressor.PutNextEntry(new ZipEntry(fileName));
                    var fullPath = sourcePath + "/" + fileName;
                    Packager.UpdateProgress(i, diffFiles.Count, " Compress version: " + versionNum + " on file: " + fileName);
                    var data = new byte[2048];
                    using (FileStream input = File.OpenRead(fullPath))
                    {
                        var bytesRead = 0;
                        while ((bytesRead = input.Read(data, 0, data.Length)) > 0)
                        {
                            compressor.Write(data, 0, bytesRead);
                        }
                    }
                }

                commonZipper.Finish();
                iosZipper.Finish();
                androidZipper.Finish();
                winZipper.Finish();
            }

            //4.记录当前版本号
            VersionEditorManager.Instance().SaveVersion(targetPath + "version.txt");
            fs = new FileStream(folderName + "/mark.txt", FileMode.CreateNew);
            fs.Close();
            EditorUtility.ClearProgressBar();
        }
    }

    /// <summary>
    /// 补丁包信息
    /// </summary>
    public class PatchInfo
    {
        public string Ver = string.Empty;
        public Dictionary<string, UpdateFileInfo> fileList = new Dictionary<string, UpdateFileInfo>();
        public bool isVaild = false;
        public string storePath = string.Empty;

        public PatchInfo(string name)
        {
            Ver = name;
        }

        /// <summary>
        /// 从文本文件读取信息
        /// </summary>
        /// <param name="path"></param>
        public void LoadContent(string path)
        {
            fileList.Clear();
            var ret = string.Empty;
            path += "/files.txt";
            try
            {
                ret = File.ReadAllText(path);
                var fileContent = ret.Split(new string[] {"\n"}, System.StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < fileContent.Length; i++)
                {
                    var fileInfo = new UpdateFileInfo(fileContent[i]);
                    fileList[fileInfo.FilePath] = fileInfo;
                }

                isVaild = true;
            }
            catch
            {
                LogUtil.Log(string.Format("没有找到文件 files.txt"), LogType.NormalLog);
            }

            storePath = Path.GetDirectoryName(path);
        }

        /// <summary>
        /// 获取补丁路径
        /// </summary>
        /// <returns></returns>
        public string GetPatchPath()
        {
            return storePath;
        }

        /// <summary>
        /// 添加文件信息
        /// </summary>
        /// <param name="content"></param>
        public void AddFileInfo(string content)
        {
            var info = new UpdateFileInfo(content);
            fileList[info.FilePath] = info;
        }

        /// <summary>
        /// 获取差异文件
        /// </summary>
        /// <param name="patchInfo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ArrayList GetDiffFiles(PatchInfo patchInfo)
        {
            var list = new ArrayList();
            foreach (var info in patchInfo.fileList)
            {
                var key = info.Key;
                var newInfo = info.Value;
                fileList.TryGetValue(key, out var curInfo);
                if (curInfo != null && curInfo.Equal(newInfo))
                    continue;
                list.Add(key);
            }

            return list;
        }
    }
}