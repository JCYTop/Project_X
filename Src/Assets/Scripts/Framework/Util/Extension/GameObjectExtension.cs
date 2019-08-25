using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension
{
    #region  Show

    public static GameObject Show(this GameObject selfObj)
    {
        selfObj.SetActive(true);
        return selfObj;
    }

    public static T Show<T>(this T selfComponent) where T : Component
    {
        selfComponent.gameObject.Show();
        return selfComponent;
    }

    #endregion

    #region  Hide

    public static GameObject Hide(this GameObject selfObj)
    {
        selfObj.SetActive(false);
        return selfObj;
    }

    public static T Hide<T>(this T selfComponent) where T : Component
    {
        selfComponent.gameObject.Hide();
        return selfComponent;
    }

    #endregion

    #region  DestroyGameObj

    public static void DestroyGameObj<T>(this T selfBehaviour) where T : Component
    {
        selfBehaviour.gameObject.DestroySelf();
    }

    #endregion

    #region  DestroyGameObjGracefully

    public static void DestroyGameObjGracefully<T>(this T selfBehaviour) where T : Component
    {
        if (selfBehaviour && selfBehaviour.gameObject)
        {
            selfBehaviour.gameObject.DestroySelfGracefully();
        }
    }

    #endregion

    #region  DestroyGameObjGracefully

    public static T DestroyGameObjAfterDelay<T>(this T selfBehaviour, float delay) where T : Component
    {
        selfBehaviour.gameObject.DestroySelfAfterDelay(delay);
        return selfBehaviour;
    }

    public static T DestroyGameObjAfterDelayGracefully<T>(this T selfBehaviour, float delay) where T : Component
    {
        if (selfBehaviour && selfBehaviour.gameObject)
        {
            selfBehaviour.gameObject.DestroySelfAfterDelay(delay);
        }

        return selfBehaviour;
    }

    #endregion

    #region Layer

    public static GameObject Layer(this GameObject selfObj, int layer)
    {
        selfObj.layer = layer;
        return selfObj;
    }

    public static T Layer<T>(this T selfComponent, int layer) where T : Component
    {
        selfComponent.gameObject.layer = layer;
        return selfComponent;
    }

    public static GameObject Layer(this GameObject selfObj, string layerName)
    {
        selfObj.layer = LayerMask.NameToLayer(layerName);
        return selfObj;
    }

    public static T Layer<T>(this T selfComponent, string layerName) where T : Component
    {
        selfComponent.gameObject.layer = LayerMask.NameToLayer(layerName);
        return selfComponent;
    }

    #endregion

    #region Component

    public static T GetOrAddComponent<T>(this GameObject selfComponent) where T : Component
    {
        var comp = selfComponent.gameObject.GetComponent<T>();
        return comp ? comp : selfComponent.gameObject.AddComponent<T>();
    }

    #endregion

    public static Vector3 WorldToScreenPoint(this GameObject selfComponent, Camera camera)
    {
        return TransformExtension.WorldToScreenPoint(selfComponent.transform, camera);
    }

    public static Vector3 WorldToViewportPoint(this GameObject selfComponent, Camera camera)
    {
        return TransformExtension.WorldToViewportPoint(selfComponent.transform, camera);
    }

    public static Vector3 SetScreenToWorldPoint(this GameObject selfComponent, Camera camera, Vector3 input)
    {
        selfComponent.transform.position = TransformExtension.SetScreenToWorldPoint(selfComponent.transform, camera, input);
        return selfComponent.transform.position;
    }

    public static Vector3 SetViewportToWorldPoint(this GameObject selfComponent, Camera camera, Vector3 input)
    {
        selfComponent.transform.position = TransformExtension.SetViewportToWorldPoint(selfComponent.transform, camera, input);
        return selfComponent.transform.position;
    }
}