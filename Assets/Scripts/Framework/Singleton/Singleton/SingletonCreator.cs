/* 创建日期：2018/07/25
 * 创建作者：JCY
 * 描述：创建单例方法类
 */
using System;
using System.Reflection;

/// <summary>
/// 负责创建单例的方法类，通过C#反射机制创建
/// </summary>
public abstract class SingletonCreator
{
    /// <summary>
    /// 创建方法
    /// </summary>
    /// <typeparam name="T">输入类型</typeparam>
    /// <returns>返回instance</returns>
    public static T Create<T>() where T : class
    {
        //获取传递进来类型的构造方法（寻找公共的和实例化的） 
        ConstructorInfo[] cotrs = typeof(T).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        //寻找到所有构造函数中无参数的构造方法
        ConstructorInfo cotr = Array.Find(cotrs, c => c.GetParameters().Length == 0);
        if (cotr == null) throw new Exception("私有构造函数并未找到  :" + typeof(T));
        //需要泛型约束，同时Invoke无参传入参数为null
        T instance = cotr.Invoke(null) as T;
        return instance;
    }
}
