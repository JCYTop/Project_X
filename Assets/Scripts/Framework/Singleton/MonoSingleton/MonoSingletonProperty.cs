using UnityEngine;

public class MonoSingletonProperty<T> where T : MonoBehaviour
{
    private static T instance = null;

    public static T Instance(bool isDefault = true, string parentName = "ManagerSet")
    {
        if (null == instance)
        {
            instance = MonoSingletonCreator.Create<T>(isDefault, parentName);
        }
        return instance;
    }

    /// <summary>
    /// 销毁方法
    /// </summary>
    public static void OnDestory()
    {
        instance = null;
    }
}