using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 各种文件的读写复制操作,主要是对System.IO的一些封装
/// </summary>
public static class IOExtension
{
    /// <summary>
    /// 创建新的文件夹,如果存在则不创建
    /// </summary>
    /// <param name="dirFullPath">路径</param>
    /// <returns>路径</returns>
    public static string CreateDirIfNotExists(this string dirFullPath)
    {
        if (!Directory.Exists(dirFullPath))
        {
            Directory.CreateDirectory(dirFullPath);
        }

        return dirFullPath;
    }

    /// <summary>
    /// 删除文件夹，如果存在
    /// </summary>
    /// <param name="dirFullPath">路径</param>
    public static void DeleteDirIfExists(this string dirFullPath)
    {
        if (Directory.Exists(dirFullPath))
        {
            Directory.Delete(dirFullPath, true);
        }
    }

    /// <summary>
    /// 清空 Dir,如果存在。
    /// </summary>
    /// <param name="dirFullPath">路径</param>
    public static void EmptyDirIfExists(this string dirFullPath)
    {
        if (Directory.Exists(dirFullPath))
        {
            Directory.Delete(dirFullPath, true);
        }

        Directory.CreateDirectory(dirFullPath);
    }

    /// <summary>
    /// 删除文件 如果存在
    /// </summary>
    /// <param name="fileFullPath">路径</param>
    /// <returns>是否删除</returns>
    public static bool DeleteFileIfExists(this string fileFullPath)
    {
        if (File.Exists(fileFullPath))
        {
            File.Delete(fileFullPath);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 合并路径
    /// </summary>
    /// <param name="selfPath">自身路径</param>
    /// <param name="toCombinePath">合并路径</param>
    /// <returns></returns>
    public static string CombinePath(this string selfPath, string toCombinePath)
    {
        return Path.Combine(selfPath, toCombinePath);
    }
}