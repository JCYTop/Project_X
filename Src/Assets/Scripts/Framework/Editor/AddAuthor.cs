using System.IO;
using UnityEngine;

namespace Framework.Editor
{
    public class AddAuthor : UnityEditor.AssetModificationProcessor
    {
        private const string AuthorName = "@JCY";
        private const string AuthorEmail = "jcyemail@qq.com";
        private const string UnityVersion = "2019.3.1f1";
        private const string CreateTime = "yyyy/MM/dd HH:mm:ss";
        private const string Description = "";

        private static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "");
            if (path.EndsWith(".cs"))
            {
                string allText = File.ReadAllText(path);
                allText = allText.Replace("#Company#", "IndieGame");
                allText = allText.Replace("#AuthorName#", AuthorName);
                allText = allText.Replace("#Version#", Application.version);
                allText = allText.Replace("#AuthorEmail#", AuthorEmail);
                allText = allText.Replace("#UnityVersion#", UnityVersion);
                allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString(CreateTime));
                allText = allText.Replace("#Description#", Description);
                File.WriteAllText(path, allText);
                UnityEditor.AssetDatabase.Refresh();
            }
        }
    }
}