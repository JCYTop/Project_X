/* 创建日期：2018/07/25
 * 创建作者：JCY
 * 描述：创建单例方法类，应用于父类本身就是单例情况
 */

public static class SingletonProperty<T> where T : class
{
    private static T instance = null;
    private static object mLock = new object();//添加线程锁

    public static T Instance()
    {
        lock (mLock)
        {
            if (instance == null)
            {
                instance = SingletonCreator.Create<T>();
            }
        }
        return instance;
    }

    /// <summary>
    /// 销毁方法
    /// </summary>
    public static void Dispose()
    {
        instance = null;
    }
}