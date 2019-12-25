/* 创建日期：2018/07/25
 * 创建作者：JCY
 * 描述：Mono创建单例方法类
 */

using UnityEngine;

namespace Framework.Singleton
{
    public class MonoSingletonCreator : MonoBehaviour
    {
        /// <summary>
        /// 创建方法
        /// </summary>
        /// <typeparam name="T">输入类型</typeparam>
        /// <param name="isDefault">默认为true时放在场景中默认物体下</param>
        /// <returns>返回instance</returns>
        public static T Create<T>(bool isDefault = true, string parentName = "ManagerSet") where T : MonoBehaviour
        {
            T instance = null;
            instance = UnityEngine.Object.FindObjectOfType<T>();
            if (instance != null) return instance;
            else
            {
                GameObject obj = new GameObject(typeof(T).Name);
                if (isDefault)
                {
                    //生成的管理类默认方法ManagerSet中
                    GameObject parentSet = UnityEngine.GameObject.Find(parentName);
                    if (parentSet == null) parentSet = new GameObject(parentName);
                    obj.transform.parent = parentSet.transform;
                    DontDestroyOnLoad(parentSet.transform);
                }

                instance = obj.AddComponent<T>();
            }

            return instance;
        }
    }
}