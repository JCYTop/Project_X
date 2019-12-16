using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
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

    [BoxGroup("自动设置"), Header("基础命名"), SerializeField, ReadOnly]
    private string baseName;

    [SerializeField] private List<PointTrans> PointTrans = new List<PointTrans>();
    [SerializeField] private List<ConfigInfo> Config = new List<ConfigInfo>();

    #endregion

    #region 属性

    public string BaseName
    {
        get => baseName;
        set => baseName = value;
    }

    public int ObjectLayer
    {
        get => (int) objectLayer;
    }

    public string ObjectTag
    {
        get => Enum.GetName(typeof(Tag), objectTag);
    }

    public int ResID
    {
        get => resID;
        set => resID = value;
    }

    #endregion

    void Awake()
    {
        BaseInit();
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

    private void BaseInit()
    {
        globalID = ScenesCenterMgr.GlobalID;
        gameObject.tag = ObjectTag;
        gameObject.layer = ObjectLayer;
        Config.ForEach((config) =>
        {
            switch (config.Type)
            {
                //TODO 根据不同的表进行加载。道具表；技能表。。。要保证全局只有唯一配置表ID
            }
        });
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
        if (!Application.isPlaying)
        {
            resID = -1;
        }
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

[Serializable]
public class ConfigInfo
{
    public ConfigType Type;
    [Header("配置ID")] public int ConfigID;
}

public enum ConfigType
{
    None,
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