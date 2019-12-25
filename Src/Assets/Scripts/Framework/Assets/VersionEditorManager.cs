using UnityEngine;

namespace Framework.Assets
{
    public class VersionEditorManager : Singleton<VersionEditorManager>
    {
        private Ver ver = new Ver();

        public string CurrVersion
        {
            get
            {
                if (Platform.IsEditor)
                {
                    // 读取 version.txt
                    ver = FileUtils.JsonFile<Ver>(Application.streamingAssetsPath + "/Version.json");
                }

                return ver.Version;
            }
            set
            {
                ver.Version = value;
                if (Platform.IsEditor)
                {
                    SaveVersion(Application.streamingAssetsPath + "/Version.txt");
                }
                else
                {
                    SaveVersion(Application.persistentDataPath + "/Version.txt");
                }
            }
        }

        public void SaveVersion(string path)
        {
            FileUtils.JsonWrite<Ver>(ver, Application.streamingAssetsPath + "/Version.json");
        }

        class Ver
        {
            public string Version;
        }
    }
}