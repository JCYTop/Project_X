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
    private DBLinkedList<UIBase> uiLinkedList;

    [BoxGroup("RootUI Lists"), TableList, SerializeField]
    private List<UIBase> rootUIShow = new List<UIBase>(1 << 2);

    [BoxGroup("StackUI Lists"), TableList, SerializeField]
    private List<UIBase> stackUIShow = new List<UIBase>(1 << 3);

    [BoxGroup("TopUI Lists"), TableList, SerializeField]
    private List<UIBase> topUIShow = new List<UIBase>(1 << 3);

    [BoxGroup("UILinkedList Lists"), TableList, SerializeField]
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

    private void Start()
    {
//        foreach (var toolCanvas in toolCanvas)
//        {
//            toolCanvas.gameObject.SetActive(false);
//        }
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
            if (uiLinkedList == null)
            {
                uiLinkedList = new DBLinkedList<UIBase>(new DBNode<UIBase>(ui), 1 << 3);
            }

            uiLinkedList.LRUSort(ui);
            if (uiLinkedList.IsLRUbyCapacity)
            {
                UIUtil.DestroyGO(uiLinkedList.LRUSortRemove());
            }

            UILinkedListShow = uiLinkedList.ToList();
        }
    }

    /// <summary>
    /// UIRootMgr生成相关的子UI界面
    /// </summary>
    /// <param name="name"></param>
    /// <param name="callback"></param>
    public void SpawnUI(string name, Action<GameObject> callback)
    {
        if (uiLinkedList != null)
        {
            var lruList = uiLinkedList.ToList();
            foreach (var uiBase in lruList)
            {
                if (uiBase.Des == name)
                {
                    uiBase.gameObject.SetActive(true);
                }
            }
        }

        AssetsManager.Instance().GetPrefabAsync(name, callback);
    }
}