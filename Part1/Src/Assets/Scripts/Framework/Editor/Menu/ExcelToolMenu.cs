//=====================================================
// - FileName:      ExcelToolMenu.cs
// - Created:       @JCY
// - CreateTime:    2019/03/16 23:58:54
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor
{
    public class ExcelToolMenu : EditorMenu<ExcelToolMenu>
    {
        #region Field

        /// <summary>
        /// 输出根目录
        /// </summary>
        private string outPath;

        /// <summary>
        /// 项目根路径	
        /// </summary>
        private static string pathRoot;

        /// <summary>
        /// Excel文件列表
        /// </summary>
        private static List<string> excelList;

        /// <summary>
        /// 滚动窗口初始位置
        /// </summary>
        private static Vector2 scrollPos;

        /// <summary>
        /// 输出格式索引
        /// </summary>
        private static int indexOfFormat = 0;

        /// <summary>
        /// 输出格式
        /// </summary>
        private static string[] formatOption = new string[] {"JSON", "CSV", "XML", "LUA"};

        /// <summary>
        /// 编码索引
        /// </summary>
        private static int indexOfEncoding = 0;

        /// <summary>
        /// 编码选项
        /// </summary>
        private static string[] encodingOption = new string[] {"UTF-8", "GB2312"};

        /// <summary>
        /// 是否保留原始文件
        /// </summary>
        private static bool keepSource = true;

        #endregion

        public override void CreatWindow()
        {
            Init();
            //加载Excel文件
            LoadExcel();
        }

        public override void OnDisable()
        {
            excelList = new List<string>();
            outPath = string.Empty;
        }

        public override void OnEnable()
        {
            excelList = null;
            outPath = Application.dataPath + "/Addressable Asset/Data/";
        }

        public override void OnGUI()
        {
            DrawOptions();
            DrawExport();
        }

        private void Init()
        {
            //获取当前实例
            EditorWindow = GetWindow<ExcelToolMenu>();
            //初始化
            pathRoot = Application.dataPath;
            //注意这里需要对路径进行处理
            //目的是去除Assets这部分字符以获取项目目录
            //我表示Windows的/符号一直没有搞懂
            pathRoot = pathRoot.Substring(0, pathRoot.LastIndexOf("/"));
            excelList = new List<string>();
            scrollPos = new Vector2(this.position.x, this.position.y + 75);
        }

        /// <summary>
        /// 加载Excel
        /// </summary>
        private static void LoadExcel()
        {
            if (excelList == null) excelList = new List<string>();
            excelList.Clear();
            //获取选中的对象
            object[] selection = Selection.objects;
            //判断是否有对象被选中
            if (selection.Length == 0)
                return;
            //遍历每一个对象判断不是Excel文件
            foreach (Object obj in selection)
            {
                string objPath = AssetDatabase.GetAssetPath(obj);
                if (objPath.EndsWith(".xlsx"))
                {
                    excelList.Add(objPath);
                }
            }
        }

        /// <summary>
        /// 绘制插件界面配置项
        /// </summary>
        private void DrawOptions()
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("请选择格式类型:", GUILayout.Width(85));
            indexOfFormat = EditorGUILayout.Popup(indexOfFormat, formatOption, GUILayout.Width(125));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("请选择编码类型:", GUILayout.Width(85));
            indexOfEncoding = EditorGUILayout.Popup(indexOfEncoding, encodingOption, GUILayout.Width(125));
            GUILayout.EndHorizontal();
            keepSource = GUILayout.Toggle(keepSource, "保留Excel源文件");
        }

        private void DrawExport()
        {
            if (excelList == null) return;
            if (excelList.Count < 1)
            {
                EditorGUILayout.LabelField("目前没有Excel文件被选中哦!");
            }
            else
            {
                EditorGUILayout.LabelField("下列项目将被转换为" + formatOption[indexOfFormat] + ":");
                GUILayout.BeginVertical();
                scrollPos = GUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Height(450));
                foreach (string s in excelList)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Toggle(true, s);
                    GUILayout.EndHorizontal();
                }

                GUILayout.EndScrollView();
                GUILayout.EndVertical();
                //输出
                if (GUILayout.Button("转换"))
                {
                    Convert();
                }
            }
        }

        /// <summary>
        /// 转换Excel文件
        /// </summary>
        private void Convert()
        {
            foreach (string assetsPath in excelList)
            {
                //获取Excel文件的绝对路径
                string excelPath = pathRoot + "/" + assetsPath;
                //构造Excel工具类
                ExcelUtility excel = new ExcelUtility(excelPath);
                //判断编码类型
                Encoding encoding = null;
                if (indexOfEncoding == 0 || indexOfEncoding == 3)
                {
                    encoding = Encoding.GetEncoding("utf-8");
                }
                else if (indexOfEncoding == 1)
                {
                    encoding = Encoding.GetEncoding("gb2312");
                }

                //判断输出类型
                string output = "";
                if (indexOfFormat == 0)
                {
                    output = excelPath.Replace(".xlsx", ".json");
                    output = output.Replace(Application.dataPath + "/ExcelDataMgr/", "");
                    output = outPath + output;
                    excel.ConvertToJson(output, encoding);
                }
                else if (indexOfFormat == 1)
                {
                    output = excelPath.Replace(".xlsx", ".csv");
                    output = output.Replace(Application.dataPath + "/ExcelDataMgr/", "");
                    output = outPath + output;
                    excel.ConvertToCSV(output, encoding);
                }
                else if (indexOfFormat == 2)
                {
                    output = excelPath.Replace(".xlsx", ".xml");
                    output = output.Replace(Application.dataPath + "/ExcelDataMgr/", "");
                    output = outPath + output;
                    excel.ConvertToXml(output);
                }
                else if (indexOfFormat == 3)
                {
                    output = excelPath.Replace(".xlsx", ".lua");
                    output = output.Replace(Application.dataPath + "/ExcelDataMgr/", "");
                    output = outPath + output;
                    excel.ConvertToLua(output, encoding);
                }

                //判断是否保留源文件
                if (!keepSource)
                {
                    FileUtil.DeleteFileOrDirectory(excelPath);
                }

                AssetDatabase.Refresh();
            }

            //转换完后关闭插件
            //这样做是为了解决窗口
            //再次点击时路径错误的Bug
            Close();
        }

        /// <summary>
        /// 官方API，数据变化重新绘制
        /// </summary>
        void OnSelectionChange()
        {
            LoadExcel();
            Repaint();
        }
    }
}