/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     CameraSettings
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/28 18:29:40
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System;
using Cinemachine;
using UnityEngine;

/// <summary>
/// TODO 暂时没有好的解决方案和新的输入系统结合
/// </summary>
public class CameraSettings : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private CinemachineFreeLook keyboardAndMouseCamera;
    [SerializeField] private InvertSettings keyboardAndMouseInvertSettings;
    [SerializeField] private bool allowRuntimeCameraSettingsChanges;
    public static Transform Follow;
    public static Transform LookAt;
    public static Camera MainCamera { set; get; }

    private void Awake()
    {
        UpdateCameraSettings();
    }

    private void OnEnable()
    {
        MainCamera = this.camera;
    }

    private void Start()
    {
        camera.targetTexture = MachineUtil.RenderTexture;
    }

    void Update()
    {
        if (allowRuntimeCameraSettingsChanges)
        {
            UpdateCameraSettings();
        }
    }

    private void OnDisable()
    {
        MainCamera = null;
    }

    private void UpdateCameraSettings()
    {
        #region keyboardAndMouseCamera 

        keyboardAndMouseCamera.Follow = Follow;
        keyboardAndMouseCamera.LookAt = LookAt;
        keyboardAndMouseCamera.m_XAxis.m_InvertInput = keyboardAndMouseInvertSettings.invertX;
        keyboardAndMouseCamera.m_YAxis.m_InvertInput = keyboardAndMouseInvertSettings.invertY;

        #endregion
    }

    [Serializable]
    public struct InvertSettings
    {
        public bool invertX;
        public bool invertY;
    }
}