//=====================================================
// - FileName:      ScriptableObjectMenu.cs
// - Created:       @JCY
// - CreateTime:    2019/03/16 23:46:05
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace Framework.Editor
{
    internal class EndNameEdit : EndNameEditAction
    {
        #region implemented abstract members of EndNameEditAction

        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            AssetDatabase.CreateAsset(EditorUtility.InstanceIDToObject(instanceId), AssetDatabase.GenerateUniqueAssetPath(pathName));
        }

        #endregion
    }

    public class ScriptableObjectMenu : EditorMenu<ScriptableObjectMenu>
    {
        private int selectedIndex;
        private static string[] names;
        private static Type[] types;

        private static Type[] Types
        {
            get { return types; }
            set
            {
                types = value;
                names = types.Select(t => t.FullName).ToArray();
            }
        }

        public override void CreatWindow()
        {
            EditorWindow = (ScriptableObjectMenu) GetWindow<ScriptableObjectMenu>();
            EditorWindow.titleContent = new GUIContent("Create a new ScriptableObject");
            EditorWindow.position = new Rect(250, 300, 500, 550);
            EditorWindow.Show();
        }

        public override void OnDisable()
        {
        }

        public override void OnEnable()
        {
            Assembly assembly = GetAssembly();
            // Get all classes derived from ScriptableObject
            Type[] allScriptableObjects = (from t in assembly.GetTypes() where t.IsSubclassOf(typeof(ScriptableObject)) select t).ToArray();
            Types = allScriptableObjects;
        }

        public override void OnGUI()
        {
            GUILayout.Label("ScriptableObject Class");
            selectedIndex = EditorGUILayout.Popup(selectedIndex, names);
            if (GUILayout.Button("Create"))
            {
                var asset = ScriptableObject.CreateInstance(types[selectedIndex]);
                ProjectWindowUtil.StartNameEditingIfProjectWindowExists(asset.GetInstanceID(), ScriptableObject.CreateInstance<EndNameEdit>(),
                    string.Format("{0}.asset", names[selectedIndex]), AssetPreview.GetMiniThumbnail(asset), null);
                Close();
            }
        }

        /// <summary>
        /// Returns the assembly that contains the script code for this project (currently hard coded),Editor用法
        /// </summary>
        private static Assembly GetAssembly()
        {
            return Assembly.Load(new AssemblyName("Assembly-CSharp"));
        }
    }
}