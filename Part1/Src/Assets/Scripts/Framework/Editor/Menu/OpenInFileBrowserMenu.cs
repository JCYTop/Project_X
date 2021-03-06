//=====================================================
// - FileName:      OpenInFileBrowserMenu.cs
// - Created:       @JCY
// - CreateTime:    2019/03/16 23:28:18
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace Framework.Editor
{
    public class OpenInFileBrowserMenu : EditorMenu<OpenInFileBrowserMenu>
    {
        public override void CreatWindow()
        {
            if (SystemInfo.operatingSystem.IndexOf("Windows") != -1) //Win平台
            {
                OpenInWin(Application.dataPath);
            }
            else if (SystemInfo.operatingSystem.IndexOf("Mac OS") != -1) //Mac平台
            {
                OpenInMac(Application.dataPath);
            }
            else
            {
                OpenInWin(Application.dataPath);
                OpenInMac(Application.dataPath);
            }
        }

        private void OpenInMac(string path)
        {
            bool openInsidesOfFolder = false;
            string macPath = path.Replace("\\", "/");
            if (System.IO.Directory.Exists(macPath))
            {
                openInsidesOfFolder = true;
            }

            if (!macPath.StartsWith("\""))
            {
                macPath = "\"" + macPath;
            }

            if (!macPath.EndsWith("\""))
            {
                macPath = macPath + "\"";
            }

            string arguments = (openInsidesOfFolder ? "" : "-R ") + macPath;
            try
            {
                System.Diagnostics.Process.Start("open", arguments);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                e.HelpLink = "";
            }
        }

        private void OpenInWin(string path)
        {
            bool openInsidesOfFolder = false;
            string winPath = path.Replace("/", "\\");
            if (Directory.Exists(winPath))
            {
                openInsidesOfFolder = true;
            }

            try
            {
                Process.Start("explorer.exe", (openInsidesOfFolder ? "/root," : "/select,") + winPath);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                e.HelpLink = "";
            }
        }

        public override void OnDisable()
        {
        }

        public override void OnEnable()
        {
        }

        public override void OnGUI()
        {
        }
    }
}