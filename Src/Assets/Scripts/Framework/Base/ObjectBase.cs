using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class ObjectBase : MonoEventEmitter
{
    #region 字段

    [BoxGroup("基本属性设置")] [Header("唯一标识ID")] [SerializeField]
    protected long id;

    [BoxGroup("基本属性设置")] private string name = string.Empty;

    [BoxGroup("基本属性设置")] [Header("Object所在的层级")] [SerializeField]
    private int objectLayer = 0;

    [BoxGroup("基本属性设置")] [Header("Object标签")] [SerializeField] [Tag]
    private string objectType = string.Empty;

    [BoxGroup("基本属性设置")] [Header("描述")] public string Des = string.Empty;
    private GameObject go;

    #endregion

    #region 属性

    public int ObjectLayer
    {
        get => objectLayer;
    }

    public string ObjectType
    {
        get => objectType;
    }

    public string Name
    {
        get => name;
    }

    public long ID
    {
        get => id;
        set => id = value;
    }

    #endregion

    void Awake()
    {
        UnityActionMgr.Instance().RunUnityAction(id, RunTimeUnityAction.Before);
        name = gameObject.name;
        gameObject.tag = objectType;
        gameObject.layer = objectLayer;
        go = this.gameObject;
        Init();
    }

    void OnEnable()
    {
        On(id.ToString(), Refresh);
        UnityActionMgr.Instance().RunUnityAction(id, RunTimeUnityAction.Enable);
    }

    void OnDisable()
    {
        Off(id.ToString(), Refresh);
        UnityActionMgr.Instance().RunUnityAction(id, RunTimeUnityAction.DisEnable);
    }


    void OnDestroy()
    {
        UnityActionMgr.Instance().RunUnityAction(id, RunTimeUnityAction.Enable);
        Release();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void Init()
    {
        GameObjectMgr.AddGameObjectInfo(id, this);
    }

    /// <summary>
    /// 释放
    /// </summary>
    public virtual void Release()
    {
        GameObjectMgr.RemoveGameObjectInfo(id);
    }

    /// <summary>
    /// 刷新    
    /// </summary>
    /// <param name="args">数据</param>
    public virtual void Refresh(params object[] args)
    {
    }
}