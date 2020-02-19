using UnityEngine;
using Framework.Singleton;

namespace Framework.Assets
{
    public class VersionEditorManager : Singleton<VersionEditorManager>
    {
        private Ver ver = new Ver();

        public string CurrVersion
        {
            get
            {
#if UNITY_EDITOR
                // 读取 version.txt
                ver = FileUtils.JsonFile<Ver>(Application.streamingAssetsPath + "/Version.json");
#endif

                return ver.Version;
            }
            set
            {
                ver.Version = value;
#if UNITY_EDITOR
                SaveVersion(Application.streamingAssetsPath + "/Version.txt");
#else
                SaveVersion(Application.persistentDataPath + "/Version.txt");
#endif
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