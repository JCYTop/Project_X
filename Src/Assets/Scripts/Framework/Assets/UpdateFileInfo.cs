/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     UpdateFileInfo
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/01 23:13:31
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace Framework.Assets
{
    public class UpdateFileInfo
    {
        public string FilePath { private set; get; }
        public string MD5 { private set; get; }
        public float FileSize { private set; get; }

        public UpdateFileInfo(string content)
        {
            var info = content.Split(new string[] {"|"}, System.StringSplitOptions.RemoveEmptyEntries);
            FilePath = info[0];
            MD5 = info[1];
            FileSize = float.Parse(info[2]);
        }

        public bool Equal(UpdateFileInfo other)
        {
            return MD5.Equals(other.MD5);
        }
    }
}