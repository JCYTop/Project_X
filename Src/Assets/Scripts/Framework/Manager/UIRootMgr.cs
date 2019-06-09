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

using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class UIRootMgr : MonoBehaviour
{
    #region 字段

    public UIBase UIBase;
    private static UIRootMgr instance;
    [SerializeField] private Camera UICamera;
    [SerializeField] private Canvas[] canvas;
    [SerializeField] private Canvas[] toolCanvas;
    private Canvas rootCanvas;
    private Canvas stackCanvas;
    private Canvas topCanvas;
    private List<UIBase> rootUI;
    private Stack<UIBase> stackUI;
    private Stack<UIBase> topUI;
    private DbLinkedList<UIBase> UILinkedList;

    [BoxGroup("RootUI Lists")] [ReorderableList]
    public List<UIBase> rootUIShow = new List<UIBase>(1 << 4);

    [BoxGroup("StackUI Lists")] [ReorderableList]
    public List<UIBase> stackUIShow = new List<UIBase>(1 << 4);

    [BoxGroup("TopUI Lists")] [ReorderableList]
    public List<UIBase> topUIShow = new List<UIBase>(1 << 2);

    [BoxGroup("UILinkedList Lists")] [ReorderableList]
    public List<UIBase> UILinkedListShow = new List<UIBase>(1 << 2);

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

    private void Awake()
    {
        rootUI = new List<UIBase>(1 << 4);
        stackUI = new Stack<UIBase>(1 << 4);
        topUI = new Stack<UIBase>(1 << 2);
        UILinkedList = new DbLinkedList<UIBase>(new DbNode<UIBase>(UIBase), 1 << 2);
        foreach (var toolCanvas in toolCanvas)
        {
            toolCanvas.gameObject.SetActive(false);
        }
    }

    public void OpenUIBase(UIBase ui)
    {
        GameObject go = default;
        switch (ui.ShowType)
        {
            case UIType.Root:
                rootUI.Add(ui);
                go = RootCanvas.gameObject;
                rootUIShow = rootUI.ToList();
                break;
            case UIType.Stack:
                stackUI.Push(ui);
                go = StackCanvas.gameObject;
                stackUIShow = stackUI.ToList();
                break;
            case UIType.Top:
                topUI.Push(ui);
                go = TopCanvas.gameObject;
                topUIShow = topUI.ToList();
                break;
            default:
                return;
        }

        UICommonUtil.SetParent(ui.gameObject, go.gameObject);
        //可根据当前的数量进行场景中UI删除（UI原则不删除只是隐藏，但如果UI过多可以删除。原则LRU策略），此处相当于标记垃圾UI等待处理
        if (UILinkedList.Contains(ui))
        {
            UILinkedList.LRUSort(ui);
            UILinkedList.LRUSort(UIBase);
        }
        else
        {
            UILinkedList.AddBefore(ui, 0);
        }

        if (UILinkedList.IsHandlebyCapacity)
        {
            UICommonUtil.DestroyGO(UILinkedList.LRUSortRemove());
        }

        UILinkedListShow = UILinkedList.ToList();
    }

    public UIBase CloseUIBase(UIBase ui)
    {
        UIBase tmp = null;
        switch (ui.ShowType)
        {
            case UIType.Root:
                tmp = ui;
                rootUI.Remove(ui);
                break;
            case UIType.Stack:
                tmp = stackUI.Pop();
                break;
            case UIType.Top:
                tmp = topUI.Pop();
                break;
        }


        return tmp;
    }
}

public enum UIType
{
    None,
    Root,
    Stack,
    Top,
}