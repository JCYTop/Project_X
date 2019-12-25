/* 创建日期：2018/07/25
 * 创建作者：JCY
 * 描述：单例泛型基类
 */
namespace Framework.Singleton
{
    /// <summary>
    /// 声明一个不可实例可继承的单例泛型基类
    /// </summary>
    /// <typeparam name="T">输入的类型</typeparam>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static object mLock = new object(); //添加线程锁
        protected static T instance = null;

        public static T Instance()
        {
            //考虑多线程
            lock (mLock)
            {
                if (instance == null)
                {
                    //创建单例
                    instance = SingletonCreator.Create<T>();
                }
            }

            return instance;
        }

        /// <summary>
        /// 销毁方法
        /// </summary>
        public virtual void Dispose()
        {
            instance = null;
        }
    }
}