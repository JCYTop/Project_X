using System;
using System.IO;
using UnityEngine;

public class AddAuthor : UnityEditor.AssetModificationProcessor
{
    private const string AuthorName = "@JCY";
    private const string Version = "";
    private const string AuthorEmail = "jcyemail@qq.com";
    private const string UnityVersion = "2019.1.0f2";
    private const string CreateTime = "yyyy/MM/dd HH:mm:ss";
    private const string Description = "";

    private static void OnWillCreateAsset(string path)
    {
        if (Define.AuthorInfo != null)
        {
            path = path.Replace(".meta", "");
            if (path.EndsWith(".cs"))
            {
                string allText = File.ReadAllText(path);
                allText = allText.Replace("#Company#", "IndieGame");
                allText = allText.Replace("#AuthorName#", Define.AuthorInfo.AuthorName);
                allText = allText.Replace("#Version#", Define.AuthorInfo.Version);
                allText = allText.Replace("#AuthorEmail#", Define.AuthorInfo.AuthorEmail);
                allText = allText.Replace("#UnityVersion#", Define.AuthorInfo.UnityVersion);
                allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString(CreateTime));
                allText = allText.Replace("#Description#", Define.AuthorInfo.Description);
                File.WriteAllText(path, allText);
                UnityEditor.AssetDatabase.Refresh();
            }
        }
    }
}