/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     LogConfigEditor
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/05/19 01:21:38
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LogConfig))]
public class LogConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LogConfig config = (LogConfig) target;
        config.All = GUILayout.Toggle(config.All, "总开关");
        ShowLogData(config);
        if (GUILayout.Button("全部打开"))
        {
            SetAll(config, true);
        }

        if (GUILayout.Button("全部关闭"))
        {
            SetAll(config, false);
        }

        if (GUILayout.Button("保存"))
        {
            Save(config);
        }
    }

    private void ShowLogData(LogConfig config)
    {
        if (config.LogDatas == null || (config.LogDatas.Count != CommonUtil.GetFieldCount<LogType>()))
        {
            config.LogDatas = new List<LogData>(GetNewLogDataList(config));
        }

        //显示
        foreach (var data in config.LogDatas)
        {
            GUILayout.BeginHorizontal();
            data.Show = GUILayout.Toggle(data.Show, data.LogType.ToString());
            data.LogColor = EditorGUILayout.ColorField(data.LogColor);
            GUILayout.EndHorizontal();
        }
    }

    private List<LogData> GetNewLogDataList(LogConfig config)
    {
        List<LogData> datas = new List<LogData>(config.LogDatas);
        Array enums = CommonUtil.GetEnumFields(typeof(LogType));


        if (config.LogDatas.Count < CommonUtil.GetFieldCount<LogType>())
        {
            foreach (LogType e in enums)
            {
                if (datas.Find((i) => i.LogType.ToString().Equals(e.ToString())) == null)
                {
                    datas.Add(new LogData()
                    {
                        LogType = e,
                        Show = true,
                        LogColor = Color.white
                    });
                }
            }
        }
        else
        {
            foreach (var data in config.LogDatas)
            {
                if (!ArrayUtility.Contains((LogType[]) enums, data.LogType))
                {
                    LogData d = datas.Find((i) => i.LogType == data.LogType);
                    datas.Remove(d);
                }
            }
        }

        return datas;
    }

    private void SetAll(LogConfig config, bool state)
    {
        config.All = state;
        foreach (var data in config.LogDatas)
        {
            data.Show = state;
        }
    }

    private void Save(LogConfig config)
    {
        EditorUtility.SetDirty(config);
        AssetDatabase.SaveAssets();
    }
}