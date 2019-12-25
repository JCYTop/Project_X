using System.IO;

namespace Framework.Editor
{
    public class AddAuthor : UnityEditor.AssetModificationProcessor
    {
        private const string AuthorName = "@JCY";
        private const string Version = "";
        private const string AuthorEmail = "jcyemail@qq.com";
        private const string UnityVersion = "2019.2.1f1";
        private const string CreateTime = "yyyy/MM/dd HH:mm:ss";
        private const string Description = "";

        private static void OnWillCreateAsset(string path)
        {
            if (GlobalDefine.AuthorInfo != null)
            {
                path = path.Replace(".meta", "");
                if (path.EndsWith(".cs"))
                {
                    string allText = File.ReadAllText(path);
                    allText = allText.Replace("#Company#", "IndieGame");
                    allText = allText.Replace("#AuthorName#", GlobalDefine.AuthorInfo.AuthorName);
                    allText = allText.Replace("#Version#", GlobalDefine.AuthorInfo.Version);
                    allText = allText.Replace("#AuthorEmail#", GlobalDefine.AuthorInfo.AuthorEmail);
                    allText = allText.Replace("#UnityVersion#", GlobalDefine.AuthorInfo.UnityVersion);
                    allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString(CreateTime));
                    allText = allText.Replace("#Description#", GlobalDefine.AuthorInfo.Description);
                    File.WriteAllText(path, allText);
                    UnityEditor.AssetDatabase.Refresh();
                }
            }
        }
    }
}