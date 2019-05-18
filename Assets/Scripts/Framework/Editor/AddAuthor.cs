﻿using System;
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
        var AuthorInfo = (AuthorInfo) Resources.Load("Configuation/" + "AuthorInfo");
        if (AuthorInfo != null)
        {
            path = path.Replace(".meta", "");
            if (path.EndsWith(".cs"))
            {
                string allText = File.ReadAllText(path);
                allText = allText.Replace("#Company#", "IndieGame");
                allText = allText.Replace("#AuthorName#", AuthorInfo.AuthorName);
                allText = allText.Replace("#Version#", AuthorInfo.Version);
                allText = allText.Replace("#AuthorEmail#", AuthorInfo.AuthorEmail);
                allText = allText.Replace("#UnityVersion#", AuthorInfo.UnityVersion);
                allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString(CreateTime));
                allText = allText.Replace("#Description#", AuthorInfo.Description);
                File.WriteAllText(path, allText);
                UnityEditor.AssetDatabase.Refresh();
            }
        }
    }
}