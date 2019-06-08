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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootMgr : MonoBehaviour
{
    private static UIRootMgr instance;

    #region 字段

    [SerializeField] private Camera UICamera;
    [SerializeField] private Canvas[] canvas;
    [SerializeField] private Canvas[] toolCanvas;
    private Canvas rootCanvas;
    private Canvas stackCanvas;
    private Canvas topCanvas;
    private Queue<UIBase> rootUI = new Queue<UIBase>(1 << 4);
    private Stack<UIBase> stackUI = new Stack<UIBase>(1 << 4);
    private Queue<UIBase> topUI = new Queue<UIBase>(1 << 2);

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
        foreach (var toolCanvas in toolCanvas)
        {
            toolCanvas.gameObject.SetActive(false);
        }
    }

    public void PutUIBase(UIBase ui)
    {
        switch (ui.ShowType)
        {
            case UIType.Root:
                rootUI.Enqueue(ui);
                break;
            case UIType.Stack:
                stackUI.Push(ui);
                UICommonUtil.SetParent(ui.gameObject, StackCanvas.gameObject);
                break;
            case UIType.Top:
                topUI.Enqueue(ui);
                break;
        }
    }
}

public enum UIType
{
    Root,
    Stack,
    Top,
}