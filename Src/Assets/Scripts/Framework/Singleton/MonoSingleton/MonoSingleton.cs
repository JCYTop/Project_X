/* 创建日期：2018/07/25
 * 创建作者：JCY
 * 描述：Mono单例泛型基类
 */
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static T instance = null;

    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="isDefault">true需要创建父物体，false不需要</param>
    /// <returns></returns>
    public static T Instance(bool isDefault = true, string parentName = "ManagerSet")
    {

        if (instance == null)
        {
            instance = MonoSingletonCreator.Create<T>(isDefault, parentName);
        }
        return instance;
    }

    /// <summary>
    /// 销毁方法
    /// </summary>
    public virtual void OnDestory()
    {
        instance = null;
    }
}