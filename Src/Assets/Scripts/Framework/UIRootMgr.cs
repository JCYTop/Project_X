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
using Framework.Base;
using Framework.EventDispatcher;
using Sirenix.OdinInspector;
using UnityEngine;
using Framework.Singleton;

public sealed class UIRootMgr : MonoBehaviour
{
    #region 字段

    private static UIRootMgr instance;
    [SerializeField] private Canvas[] canvas;
    [SerializeField] private GameObject recycleTrash;
    private Canvas rootCanvas;
    private Canvas stackCanvas;
    private Canvas topCanvas;
    private List<UIBase> rootUI = new List<UIBase>(1 << 2);
    private Stack<UIBase> stackUI = new Stack<UIBase>(1 << 3);
    private Stack<UIBase> topUI = new Stack<UIBase>(1 << 3);
    public Dictionary<string, UIBase> UINameDic = new Dictionary<string, UIBase>(1 << 4);
    private int capacity = 1 << 3;
    private float multiple = 1.5f;
    private bool applicationQuit = false;
    [BoxGroup("Close Lists")] private LinkedList<UIBase> closeUIStroe = new LinkedList<UIBase>();

    [BoxGroup("RootUI Lists"), SerializeField]
    private List<UIBase> rootUIShow = new List<UIBase>(1 << 2);

    [BoxGroup("StackUI Lists"), SerializeField]
    private List<UIBase> stackUIShow = new List<UIBase>(1 << 3);

    [BoxGroup("TopUI Lists"), SerializeField]
    private List<UIBase> topUIShow = new List<UIBase>(1 << 3);

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

    private void OnEnable()
    {
        EventDispatcher.Instance().RegiestEvent(GlobalEventType.OnApplicationQuit, ApplicationQuit);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance().UnRegiestEvent(GlobalEventType.OnApplicationQuit, ApplicationQuit);
    }

    private void ApplicationQuit(params object[] args)
    {
        applicationQuit = true;
        UINameDic.Clear();
        closeUIStroe.Clear();
    }

    #region UI管理

    /// <summary>
    /// 设置UI的Canvas
    /// </summary>
    /// <param name="ui"></param>
    public void SetUICanvers(UIBase ui)
    {
        if (applicationQuit) return;
        GameObject go = default(GameObject);
        switch (ui.ShowType)
        {
            case UIType.UIRoot:
                go = RootCanvas.gameObject;
                break;
            case UIType.UITop:
                go = TopCanvas.gameObject;
                break;
            case UIType.UIStack:
                go = StackCanvas.gameObject;
                break;
            default:
                return;
        }

        UIUtil.SetParent(ui.gameObject, go.gameObject);
    }

    /// <summary>
    /// 插入UI管理
    /// </summary>
    /// <param name="ui"></param>
    public void InsertUIBase(UIBase ui)
    {
        if (applicationQuit) return;
        closeUIStroe.Remove(ui);
        UINameDic.Add(ui.BaseName, ui);
        switch (ui.ShowType)
        {
            case UIType.UIRoot:
                rootUI.Add(ui);
                rootUIShow = rootUI.ToList();
                break;
            case UIType.UITop:
                if (topUI.Count > 0)
                {
                    var beforeUI = topUI.Peek();
                    beforeUI.gameObject.SetActive(false);
                }

                topUI.Push(ui);
                topUIShow = topUI.ToList();
                break;
            case UIType.UIStack:
                if (stackUI.Count > 0)
                {
                    var beforeUI = stackUI.Peek();
                    beforeUI.gameObject.SetActive(false);
                }

                stackUI.Push(ui);
                stackUIShow = stackUI.ToList();
                break;
            default:
                return;
        }
    }

    /// <summary>
    /// 关闭UI管理
    /// </summary>
    /// <param name="ui"></param>
    public void CloseUIBase(UIBase ui)
    {
        if (applicationQuit) return;
        UINameDic.Remove(ui.BaseName);
        closeUIStroe.AddFirst(ui);
        //进行LRU尾部删除
        closeUIStroe.LRUSort(capacity, multiple, (list) =>
        {
            if (list.Count > 0)
            {
                Util.DestroyGo(list);
            }
        });
        switch (ui.ShowType)
        {
            case UIType.UIRoot:
                if (rootUI.Contains(ui))
                {
                    rootUI.Remove(ui);
                }

                rootUIShow = rootUI.ToList();
                break;
            case UIType.UITop:
                if (topUI.Count > 0)
                {
                    topUI.Pop();
                    if (topUI.Count > 0)
                    {
                        var currUI = topUI.Peek();
                        currUI.gameObject.SetActive(true);
                    }
                }

                topUIShow = topUI.ToList();
                break;
            case UIType.UIStack:
                if (stackUI.Count > 0)
                {
                    var closeUI = stackUI.Pop();
                    closeUI.transform.SetParent(recycleTrash.transform);
                    if (stackUI.Count > 0)
                    {
                        var currUI = stackUI.Peek();
                        currUI.gameObject.SetActive(true);
                    }
                }

                stackUIShow = stackUI.ToList();
                break;
            default:
                return;
        }
    }

    //TODO 需要添加一个时间监听，当游戏关闭时候 清空俩个俩个堆栈，以防关闭报错

    public void RemoveCloseUIDic(UIBase ui)
    {
        closeUIStroe.Remove(ui);
    }

    #endregion

    #region 生成UI

    /// <summary>
    /// UIRootMgr生成相关的UI界面
    /// </summary>
    /// <param name="name"></param>
    /// <param name="callback"></param>
    public void SpawnUI(string name, Action<GameObject> callback = null)
    {
        foreach (var ui in closeUIStroe)
        {
            if (ui.BaseName == name)
            {
                ui.gameObject.SetActive(true);
                SetUICanvers(ui);
                InsertUIBase(ui);
                return;
            }
        }

        AddressableAsync.LoadAssetAsync<GameObject>(name, (go) =>
        {
            Debug.Log($"UI Asset 加载完成");
            if (callback != null)
                callback(go);
        });
    }

    #endregion
}