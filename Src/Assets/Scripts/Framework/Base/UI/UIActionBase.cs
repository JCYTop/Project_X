/// <summary>
/// 父物体需要必定有一个UIBase
/// </summary>
public abstract class UIActionBase : MonoEventEmitter
{
    /// <summary>
    /// 初始化
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// 显示
    /// </summary>
    public abstract void Enable();

    /// <summary>
    /// 隐藏
    /// </summary>
    public abstract void Disable();

    /// <summary>
    /// 刷新，自判断过滤
    /// </summary>
    /// <param name="args"></param>
    public abstract void Refresh(params object[] args);

    /// <summary>
    /// 释放=Destroy
    /// </summary>
    public abstract void Release();
}