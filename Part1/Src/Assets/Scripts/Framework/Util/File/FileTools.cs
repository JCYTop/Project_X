//=====================================================
// - FileName:      FileTools.cs
// - Created:       @JCY
// - CreateTime:    2019/03/17 00:38:06
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.IO;
using System.Text;

public class FileTools
{
    public static void VerifyDirection(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
    }

    public static void Copy(string fromDir, string toDir, bool overwrite)
    {
        VerifyDirection(toDir);
        File.Copy(fromDir, toDir, overwrite);
    }

    public static object Create(string dir)
    {
        VerifyDirection(dir);
        return File.Create(dir);
    }

    public static void Delete(string dir)
    {
        File.Delete(dir);
    }

    public static bool Exists(string dir)
    {
        return File.Exists(dir);
    }

    public static void Move(string fromdir, string todir)
    {
        VerifyDirection(todir);
        File.Move(fromdir, todir);
    }

    public static FileStream Open(string dir, FileMode mode)
    {
        return File.Open(dir, mode);
    }

    public static byte[] ReadAllBytes(string dir)
    {
        FileInfo fi = new FileInfo(dir);
        long len = fi.Length;
        FileStream fs = new FileStream(dir, FileMode.Open);
        byte[] buffer = new byte[len];
        fs.Read(buffer, 0, (int) len);
        fs.Close();
        return buffer;
    }

    public static string ReadAllText(string dir)
    {
        if (!Exists(dir))
        {
            FileStream fs = Create(dir) as FileStream;
            fs.Close();
        }

        return File.ReadAllText(dir);
    }

    public static void WriteAllText(string dir, string datas)
    {
        VerifyDirection(dir);
        File.WriteAllText(dir, datas, Encoding.UTF8);
    }


    /// <summary>
    /// 获得文件MD5码
    /// </summary>
    /// <param name="fs"></param>
    /// <returns></returns>
    public static string FSToMD5(FileStream fs)
    {
        try
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(fs);
            var sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }

            return sb.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("md5file() fail, error:" + ex.Message);
        }
    }
}