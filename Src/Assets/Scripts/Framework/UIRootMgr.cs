/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     UIRootMgr
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/08 17:30:34
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class UIRootMgr : MonoBehaviour
{
    #region 字段

    private static UIRootMgr instance;
    [SerializeField] private Canvas[] canvas;
    [SerializeField] private Canvas[] toolCanvas;
    private Canvas rootCanvas;
    private Canvas stackCanvas;
    private Canvas topCanvas;
    private List<UIBase> rootUI = new List<UIBase>(1 << 2);
    private Stack<UIBase> stackUI = new Stack<UIBase>(1 << 3);
    private Stack<UIBase> topUI = new Stack<UIBase>(1 << 3);
    private LinkedList<UIBase> uiLinkedList = new LinkedList<UIBase>();
    private int lruCapacity = 1 << 3;
    private float lruCapacityMultiple = 1.5f;

    [BoxGroup("RootUI Lists"), SerializeField]
    private List<UIBase> rootUIShow = new List<UIBase>(1 << 2);

    [BoxGroup("StackUI Lists"), SerializeField]
    private List<UIBase> stackUIShow = new List<UIBase>(1 << 3);

    [BoxGroup("TopUI Lists"), SerializeField]
    private List<UIBase> topUIShow = new List<UIBase>(1 << 3);

    [BoxGroup("UILinkedList Lists"), SerializeField]
    private List<UIBase> UILinkedListShow = new List<UIBase>(1 << 3);

    #endregion

    #region 属性

    public Canvas RootCanvas
    {
        get
        {
            if (rootCanvas == null)
            {
                foreach (var c in canvas)
                {
                    if (c.name.Equals("RootCanvas"))
                    {
                        rootCanvas = c;
                        break;
                    }
                }
            }

            return rootCanvas;
        }
    }

    public Canvas StackCanvas
    {
        get
        {
            if (stackCanvas == null)
            {
                foreach (var c in canvas)
                {
                    if (c.name.Equals("StackCanvas"))
                    {
                        stackCanvas = c;
                        break;
                    }
                }
            }

            return stackCanvas;
        }
    }

    public Canvas TopCanvas
    {
        get
        {
            if (topCanvas == null)
            {
                foreach (var c in canvas)
                {
                    if (c.name.Equals("TopCanvas"))
                    {
                        topCanvas = c;
                        break;
                    }
                }
            }

            return topCanvas;
        }
    }

    #endregion

    public static UIRootMgr Instance()
    {
        if (instance == null)
        {
            instance = MonoSingletonProperty<UIRootMgr>.Instance();
        }

        return instance;
    }

    public void InsertUIBase(UIBase ui)
    {
        GameObject go = default;
        switch (ui.ShowType)
        {
            case UIType.UIRoot:
                rootUI.Add(ui);
                go = RootCanvas.gameObject;
                rootUIShow = rootUI.ToList();
                break;
            case UIType.UIStack:
                stackUI.Push(ui);
                go = StackCanvas.gameObject;
                stackUIShow = stackUI.ToList();
                break;
            case UIType.UITop:
                topUI.Push(ui);
                go = TopCanvas.gameObject;
                topUIShow = topUI.ToList();
                break;
            default:
                return;
        }

        UIUtil.SetParent(ui.gameObject, go.gameObject);
        if (uiLinkedList.Contains(ui))
        {
            uiLinkedList.Remove(ui);
            if (uiLinkedList.Count > 0)
            {
                UILinkedListShow = uiLinkedList.ToList();
            }
            else
            {
                UILinkedListShow.Clear();
                uiLinkedList.Clear();
            }
        }
    }

    public void ReleaseUIBase(UIBase ui)
    {
        UIBase tmpUI = null;
        switch (ui.ShowType)
        {
            case UIType.UIRoot:
                if (rootUI.Contains(ui))
                {
                    tmpUI = ui;
                    rootUI.Remove(ui);
                }

                rootUIShow = rootUI.ToList();
                break;
            case UIType.UITop:
                topUI.Pop();
                topUIShow = topUI.ToList();
                break;
            case UIType.UIStack:
                tmpUI = stackUI.Pop();
                stackUIShow = stackUI.ToList();
                break;
            default:
                return;
        }

        if (tmpUI != null)
        {
            //可根据当前的数量进行场景中UI删除（UI原则不删除只是隐藏，但如果UI过多可以删除。原则LRU策略），此处相当于标记垃圾UI等待处理
            var value = uiLinkedList.LRUSort(ui, lruCapacity, lruCapacityMultiple);
            UILinkedListShow = value.Item1.ToList();
            Util.DestroyGo(value.Item2);
        }
    }

    /// <summary>
    /// UIRootMgr生成相关的子UI界面
    /// </summary>
    /// <param name="name"></param>
    /// <param name="callback"></param>
    public void SpawnUI(string name, Action<GameObject> callback)
    {
        var lruList = uiLinkedList.ToList();
        foreach (var uiBase in lruList)
        {
            var uiName = uiBase.gameObject.name.Replace("(Clone)", "");
            if (uiName == name)
            {
                uiBase.gameObject.SetActive(true);
                return;
            }
        }

        AssetsManager.Instance().GetPrefabAsync(name, callback);
    }
}