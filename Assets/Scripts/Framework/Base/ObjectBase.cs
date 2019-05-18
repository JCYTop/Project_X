using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object类型
/// </summary>
public enum ObjectTag
{
    None = 0,
    UI = 1,
    Character = 2,
    Camera = 3,
    Trigger = 4,
    GameObject = 5,
    DevTool = 6,
    Manager = 7,
    Canvas = 8
}

/// <summary>
/// Object所在的层级
/// </summary>
public enum ObjectLayer
{
    Default = 0,
    FX = 1,
    Water = 4,
    UI = 5,
    Scene = 8,//场景
}

public class ObjectBase : MonoEventEmitter
{
    #region 字段
    [Header("唯一标识ID")]
    [SerializeField]
    protected long id;
    [Header("物体命名")]
    [SerializeField]
    private string name = string.Empty;
    [Header("Object类型")]
    public ObjectTag ObjectType = ObjectTag.None;
    [Header("Object所在的层级")]
    public ObjectLayer ObjectLayer = ObjectLayer.Default;
    [Header("描述")]
    public string Des = string.Empty;
    private GameObject go;
    #endregion

    #region 属性
    public long ID
    {
        get => id;
    }
    #endregion

    void Awake()
    {
        name = gameObject.name;
        gameObject.tag = ObjectType.ToString();
        gameObject.layer = (int)ObjectLayer;
        go = this.gameObject;
        Init();
    }

    void OnEnable()
    {
        On(id.ToString(), Refresh);
    }

    void OnDisable()
    {
        Off(id.ToString(), Refresh);
    }

    void OnDestroy()
    {
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