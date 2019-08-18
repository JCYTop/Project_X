//=====================================================
// - FileName:      ObjectPoolBase.cs
// - Created:       @JCY
// - CreateTime:    2019/04/01 22:59:05
// - Email:         jcyemail@qq.com
// - Description:   
// -  (C) Copyright 2019 - 2019.
// -  独立游戏开发
//======================================================

public abstract class ObjectsPoolBase<T> : IPool where T : new()
{
    private IPoolable[] objPool;

    public ObjectsPoolBase()
    {
        objPool = new IPoolable[Count];
    }

    /// <summary>
    /// 池子存放最大值
    /// </summary>
    public int Count { get; set; }

    public PoolLifeCycle PoolLifeCycle { get; set; }

    /// <summary>
    /// 调用删除池子
    /// </summary>
    public void OnDestory()
    {
        //TODO 可以由全局GC管理进行
    }

    public void ChangePoolLifeCycle(PoolLifeCycle poolLifeCycle)
    {
        PoolLifeCycle = poolLifeCycle;
    }

    public void ClearPool()
    {
        objPool = null;
        objPool = new IPoolable[Count];
    }

    /// <summary>
    /// 获取一个要使用的池子对象
    /// </summary>
    /// <returns></returns>
    public IPoolable GetObj()
    {
        //创建数组必然大于0，不用进行是否大于0判断
        IPoolable tmp = null;
        for (int i = 0; i < objPool.Length; i++)
        {
            if (objPool[i] != null)
            {
                tmp = objPool[i];
                objPool[i] = null;
                return tmp;
            }
        }

        //进行到这了说明数组里面没有找到合适的
        return CreateObj();
    }

    /// <summary>
    /// 进行回收
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public bool Recycle(IPoolable go)
    {
        return false;
    }

    protected abstract IPoolable CreateObj();
}