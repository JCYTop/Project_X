using System;
using System.Text;
using UnityEngine;

public static class TransformExtension
{
    /// <summary>
    /// 免每次声明
    /// </summary>
    private static Vector3 mLocalPos;

    private static Vector3 mScale;
    private static Vector3 mPos;

    #region  Parent

    public static T Parent<T>(this T selfComponent, Transform parent) where T : Component
    {
        selfComponent.transform.SetParent(parent);
        return selfComponent;
    }

    #endregion

    #region  LocalIdentity

    /// <summary>
    /// 本地坐标重置化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selfComponent"></param>
    /// <returns></returns>
    public static T LocalIdentity<T>(this T selfComponent) where T : Component
    {
        selfComponent.transform.localPosition = Vector3.zero;
        selfComponent.transform.localRotation = Quaternion.identity;
        selfComponent.transform.localScale = Vector3.one;
        return selfComponent;
    }

    #endregion

    #region  LocalPosition

    public static T LocalPosition<T>(this T selfComponent, Vector3 localPos) where T : Component
    {
        selfComponent.transform.localPosition = localPos;
        return selfComponent;
    }

    public static Vector3 GetLocalPosition<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.localPosition;
    }

    public static T LocalPosition<T>(this T selfComponent, float x, float y, float z) where T : Component
    {
        selfComponent.transform.localPosition = new Vector3(x, y, z);
        return selfComponent;
    }

    public static T LocalPosition<T>(this T selfComponent, float x, float y) where T : Component
    {
        mLocalPos = selfComponent.transform.localPosition;
        mLocalPos.x = x;
        mLocalPos.y = y;
        selfComponent.transform.localPosition = mLocalPos;
        return selfComponent;
    }

    public static T LocalPositionX<T>(this T selfComponent, float x) where T : Component
    {
        mLocalPos = selfComponent.transform.localPosition;
        mLocalPos.x = x;
        selfComponent.transform.localPosition = mLocalPos;
        return selfComponent;
    }

    public static T LocalPositionY<T>(this T selfComponent, float y) where T : Component
    {
        mLocalPos = selfComponent.transform.localPosition;
        mLocalPos.y = y;
        selfComponent.transform.localPosition = mLocalPos;
        return selfComponent;
    }

    public static T LocalPositionZ<T>(this T selfComponent, float z) where T : Component
    {
        mLocalPos = selfComponent.transform.localPosition;
        mLocalPos.z = z;
        selfComponent.transform.localPosition = mLocalPos;
        return selfComponent;
    }

    public static T LocalPositionIdentity<T>(this T selfComponent) where T : Component
    {
        selfComponent.transform.localPosition = Vector3.zero;
        return selfComponent;
    }

    #endregion

    #region  LocalRotation

    public static Quaternion GetLocalRotation<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.localRotation;
    }

    public static T LocalRotation<T>(this T selfComponent, Quaternion localRotation) where T : Component
    {
        selfComponent.transform.localRotation = localRotation;
        return selfComponent;
    }

    public static T LocalRotationIdentity<T>(this T selfComponent) where T : Component
    {
        selfComponent.transform.localRotation = Quaternion.identity;
        return selfComponent;
    }

    #endregion

    #region  LocalScale

    public static T LocalScale<T>(this T selfComponent, Vector3 scale) where T : Component
    {
        selfComponent.transform.localScale = scale;
        return selfComponent;
    }

    public static Vector3 GetLocalScale<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.localScale;
    }

    public static T LocalScale<T>(this T selfComponent, float xyz) where T : Component
    {
        selfComponent.transform.localScale = Vector3.one * xyz;
        return selfComponent;
    }

    public static T LocalScale<T>(this T selfComponent, float x, float y, float z) where T : Component
    {
        mScale = selfComponent.transform.localScale;
        mScale.x = x;
        mScale.y = y;
        mScale.z = z;
        selfComponent.transform.localScale = mScale;
        return selfComponent;
    }

    public static T LocalScale<T>(this T selfComponent, float x, float y) where T : Component
    {
        mScale = selfComponent.transform.localScale;
        mScale.x = x;
        mScale.y = y;
        selfComponent.transform.localScale = mScale;
        return selfComponent;
    }

    public static T LocalScaleX<T>(this T selfComponent, float x) where T : Component
    {
        mScale = selfComponent.transform.localScale;
        mScale.x = x;
        selfComponent.transform.localScale = mScale;
        return selfComponent;
    }

    public static T LocalScaleY<T>(this T selfComponent, float y) where T : Component
    {
        mScale = selfComponent.transform.localScale;
        mScale.y = y;
        selfComponent.transform.localScale = mScale;
        return selfComponent;
    }

    public static T LocalScaleZ<T>(this T selfComponent, float z) where T : Component
    {
        mScale = selfComponent.transform.localScale;
        mScale.z = z;
        selfComponent.transform.localScale = mScale;
        return selfComponent;
    }

    public static T LocalScaleIdentity<T>(this T selfComponent) where T : Component
    {
        selfComponent.transform.localScale = Vector3.one;
        return selfComponent;
    }

    #endregion

    #region  Position

    public static T Position<T>(this T selfComponent, Vector3 position) where T : Component
    {
        selfComponent.transform.position = position;
        return selfComponent;
    }

    public static Vector3 GetPosition<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.position;
    }

    public static T Position<T>(this T selfComponent, float x, float y, float z) where T : Component
    {
        selfComponent.transform.position = new Vector3(x, y, z);
        return selfComponent;
    }

    public static T Position<T>(this T selfComponent, float x, float y) where T : Component
    {
        mPos = selfComponent.transform.position;
        mPos.x = x;
        mPos.y = y;
        selfComponent.transform.position = mPos;
        return selfComponent;
    }

    public static T PositionIdentity<T>(this T selfComponent) where T : Component
    {
        selfComponent.transform.position = Vector3.zero;
        return selfComponent;
    }

    public static T PositionX<T>(this T selfComponent, float x) where T : Component
    {
        mPos = selfComponent.transform.position;
        mPos.x = x;
        selfComponent.transform.position = mPos;
        return selfComponent;
    }

    public static T PositionX<T>(this T selfComponent, Func<float, float> xSetter) where T : Component
    {
        mPos = selfComponent.transform.position;
        mPos.x = xSetter(mPos.x);
        selfComponent.transform.position = mPos;
        return selfComponent;
    }

    public static T PositionY<T>(this T selfComponent, float y) where T : Component
    {
        mPos = selfComponent.transform.position;
        mPos.y = y;
        selfComponent.transform.position = mPos;
        return selfComponent;
    }

    public static T PositionY<T>(this T selfComponent, Func<float, float> ySetter) where T : Component
    {
        mPos = selfComponent.transform.position;
        mPos.y = ySetter(mPos.y);
        selfComponent.transform.position = mPos;
        return selfComponent;
    }

    public static T PositionZ<T>(this T selfComponent, float z) where T : Component
    {
        mPos = selfComponent.transform.position;
        mPos.z = z;
        selfComponent.transform.position = mPos;
        return selfComponent;
    }

    public static T PositionZ<T>(this T selfComponent, Func<float, float> zSetter) where T : Component
    {
        mPos = selfComponent.transform.position;
        mPos.z = zSetter(mPos.z);
        selfComponent.transform.position = mPos;
        return selfComponent;
    }

    #endregion

    #region  Rotation

    public static T RotationIdentity<T>(this T selfComponent) where T : Component
    {
        selfComponent.transform.rotation = Quaternion.identity;
        return selfComponent;
    }

    public static T Rotation<T>(this T selfComponent, Quaternion rotation) where T : Component
    {
        selfComponent.transform.rotation = rotation;
        return selfComponent;
    }

    public static Quaternion GetRotation<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.rotation;
    }

    #endregion

    #region  WorldScale/LossyScale/GlobalScale/Scale

    public static Vector3 GetGlobalScale<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.lossyScale;
    }

    public static Vector3 GetScale<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.lossyScale;
    }

    public static Vector3 GetWorldScale<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.lossyScale;
    }

    public static Vector3 GetLossyScale<T>(this T selfComponent) where T : Component
    {
        return selfComponent.transform.lossyScale;
    }

    #endregion

    #region  Destroy All Child

    public static T DestroyAllChild<T>(this T selfComponent) where T : Component
    {
        var childCount = selfComponent.transform.childCount;
        for (var i = 0; i < childCount; i++)
        {
            selfComponent.transform.GetChild(i).DestroyGameObjGracefully();
        }

        return selfComponent;
    }

    public static GameObject DestroyAllChild(this GameObject selfGameObj)
    {
        var childCount = selfGameObj.transform.childCount;
        for (var i = 0; i < childCount; i++)
        {
            selfGameObj.transform.GetChild(i).DestroyGameObjGracefully();
        }

        return selfGameObj;
    }

    #endregion

    #region  改变层级渲染

    public static T AsLastSibling<T>(this T selfComponent) where T : Component
    {
        selfComponent.transform.SetAsLastSibling();
        return selfComponent;
    }

    public static T AsFirstSibling<T>(this T selfComponent) where T : Component
    {
        selfComponent.transform.SetAsFirstSibling();
        return selfComponent;
    }

    public static T SiblingIndex<T>(this T selfComponent, int index) where T : Component
    {
        selfComponent.transform.SetSiblingIndex(index);
        return selfComponent;
    }

    #endregion

    /// <summary>
    /// 寻找物体下的子物体
    /// </summary>
    /// <param name="selfTransform"></param>
    /// <param name="uniqueName"></param>
    /// <returns></returns>
    public static Transform SeekTrans(this Transform selfTransform, string uniqueName)
    {
        var childTrans = selfTransform.Find(uniqueName);
        if (null != childTrans)
            return childTrans;
        foreach (Transform trans in selfTransform)
        {
            childTrans = trans.SeekTrans(uniqueName);
            if (null != childTrans)
                return childTrans;
        }

        return null;
    }

    /// <summary>
    /// 复制一个信息到另一个物体
    /// </summary>
    /// <param name="selfTrans"></param>
    /// <param name="fromTrans"></param>
    public static void CopyDataFromTrans(this Transform selfTrans, Transform fromTrans)
    {
        selfTrans.SetParent(fromTrans.parent);
        selfTrans.localPosition = fromTrans.localPosition;
        selfTrans.localRotation = fromTrans.localRotation;
        selfTrans.localScale = fromTrans.localScale;
    }

    /// <summary>
    /// 获取相对应的指定路径
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static string GetPath(this Transform transform)
    {
        var sb = new StringBuilder();
        var trans = transform;
        while (true)
        {
            sb.Insert(0, trans.name);
            trans = trans.parent;
            if (trans)
            {
                sb.Insert(0, "/");
            }
            else
            {
                return sb.ToString();
            }
        }
    }

    /// <summary>
    /// 物体直接返回屏幕坐标
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Vector3 WorldToScreenPoint(this Transform transform, Camera camera)
    {
        return camera.WorldToScreenPoint(transform.position);
    }

    /// <summary>
    /// 物体直接返回视图坐标
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="camera"></param>
    /// <returns></returns>
    public static Vector3 WorldToViewportPoint(this Transform transform, Camera camera)
    {
        return camera.WorldToViewportPoint(transform.position);
    }

    public static Vector3 SetScreenToWorldPoint(this Transform transform, Camera camera, Vector3 input)
    {
        transform.position = camera.ScreenToWorldPoint(input);
        return transform.position;
    }

    public static Vector3 SetViewportToWorldPoint(this Transform transform, Camera camera, Vector3 input)
    {
        transform.position = camera.ViewportToWorldPoint(input);
        return transform.position;
    }
}