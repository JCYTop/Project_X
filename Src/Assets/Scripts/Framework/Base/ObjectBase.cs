using System;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(AssetPoolItem))]
public abstract class ObjectBase : MonoEventEmitter
{
    #region 字段

    [BoxGroup("基本属性手动设置")] private string name = string.Empty;

    [BoxGroup("基本属性手动设置"), SerializeField, EnumPaging, OnValueChanged("SetCurrentLayer")]
    private Layer objectLayer = Layer.Default;

    [BoxGroup("基本属性手动设置"), SerializeField, EnumPaging, OnValueChanged("SetCurrentTag")]
    private Tag objectTag = Tag.None;

    [BoxGroup("基本属性手动设置")] public string Des = string.Empty;
    [BoxGroup("基本属性手动设置")] public bool IsPreLoad = false;

    [BoxGroup("自动设置"), Header("唯一资源标识ID"), SerializeField, ReadOnly]
    private int resID;

    [BoxGroup("自动设置"), Header("运行时场景唯一标识ID"), SerializeField, ReadOnly]
    protected int globalID;

    [SerializeField] private PointTrans[] PointTrans = new PointTrans[] { };
    protected GameObject go;

    #endregion

    #region 属性

    public int ObjectLayer
    {
        get => (int) objectLayer;
    }

    public string ObjectTag
    {
        get => Enum.GetName(typeof(Tag), objectTag);
    }

    public string Name
    {
        get => name;
        set { name = value; }
    }

    public int ResID
    {
        get => resID;
        set => resID = value;
    }

    #endregion

    void Awake()
    {
        globalID = ScenesMgr.GlobalID;
        gameObject.tag = ObjectTag;
        gameObject.layer = ObjectLayer;
        go = gameObject;
        Init();
    }

    void OnEnable()
    {
        On(globalID.ToString(), Refresh);
        Enable();
    }

    void OnDisable()
    {
        Off(globalID.ToString(), Refresh);
        Disable();
    }

    void OnDestroy()
    {
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

    private void SetCurrentTag()
    {
        gameObject.tag = ObjectTag;
    }

    private void SetCurrentLayer()
    {
        gameObject.layer = ObjectLayer;
    }

    [Button(ButtonSizes.Small), GUIColor(1, 0, 0)]
    private void ResetResID()
    {
        resID = 0;
    }
}

public enum ActPosType
{
    None = 0,
    Effect,
    Tip,
}

[Serializable]
public class PointTrans
{
    public ActPosType ActPosType;
    public Transform Trans;
}

public enum Tag
{
    None,
    UI,
    Character,
    Camera,
    Trigger,
    GameObject,
    DevTool,
    Manager,
    Util,
}

public enum Layer
{
    Default = 0,
    UI = 5,
    PostProcessing = 8,
    Scene = 9,
}