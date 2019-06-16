using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AssetPoolItem))]
public abstract class ObjectBase : MonoEventEmitter
{
    #region 字段

    [BoxGroup("基本属性手动设置")] private string name = string.Empty;

    [BoxGroup("基本属性手动设置")] [SerializeField]
    private int objectLayer = 0;

    [BoxGroup("基本属性手动设置")] [SerializeField] [Tag]
    private string objectTag = string.Empty;

    [BoxGroup("基本属性手动设置")] public string Des = string.Empty;

    [BoxGroup("基本属性手动设置")] [Header("是否预加载")]
    public bool IsPreLoad = false;

    [BoxGroup("自动设置")] [Header("唯一资源标识ID")] [SerializeField]
    private long resID;

    [BoxGroup("自动设置")] [Header("运行时场景唯一标识ID")] [SerializeField]
    public int globalID;

    protected GameObject go;

    #endregion

    #region 属性

    public int ObjectLayer
    {
        get => objectLayer;
    }

    public string ObjectTag
    {
        get => objectTag;
    }

    public string Name
    {
        get => name;
    }

    public long ResID
    {
        get => resID;
        set => resID = value;
    }

    #endregion

    void Awake()
    {
        globalID = ScenesMgr.GlobalID;
        name = gameObject.name;
        gameObject.tag = objectTag;
        gameObject.layer = objectLayer;
        go = gameObject;
        UnityActionMgr.Instance().RunUnityAction(globalID, RunTimeUnityAction.Before);
        Init();
    }

    void OnEnable()
    {
        UnityActionMgr.Instance().RunUnityAction(globalID, RunTimeUnityAction.Enable);
        On(globalID.ToString(), Refresh);
        Enable();
    }

    void OnDisable()
    {
        UnityActionMgr.Instance().RunUnityAction(globalID, RunTimeUnityAction.DisEnable);
        Off(globalID.ToString(), Refresh);
        Disable();
    }

    void OnDestroy()
    {
        UnityActionMgr.Instance().RunUnityAction(globalID, RunTimeUnityAction.After);
        Release();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// 释放
    /// </summary>
    public abstract void Release();

    /// <summary>
    /// 刷新    
    /// </summary>
    /// <param name="args">数据</param>
    public virtual void Refresh(params object[] args)
    {
    }

    public virtual void Enable()
    {
    }


    public virtual void Disable()
    {
    }
}