using System;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Serializable]
    public class CameraRig
    {
        public Vector3 CameraOffset;
        public float CrouchedHeight;
        public float Damping;
    }

    [SerializeField] private CameraRig defaultCamera;
    [SerializeField] private CameraRig aimCamera;
    [SerializeField] private CameraRig crouchedCamera;
    private Player locaPlayer;
    private Transform cameraLookTarget;

    private void Awake()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        locaPlayer = player;
        cameraLookTarget = locaPlayer.transform.Find("cameraLookTarget");
        if (cameraLookTarget == null)
            cameraLookTarget = locaPlayer.transform;
    }

    private void Update()
    {
        if (locaPlayer == null)
            return;
        var cameraRig = defaultCamera;
        if (locaPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMING || locaPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMEDFIRING)
        {
            cameraRig = aimCamera;
        }

        var targetHeight = cameraRig.CameraOffset.y + (locaPlayer.PlayerState.MoveState == PlayerState.EMoveState.CROUCHING ? cameraRig.CrouchedHeight : 0);
        var targetPosition = cameraLookTarget.position +
                             locaPlayer.transform.forward * cameraRig.CameraOffset.z +
                             locaPlayer.transform.up * targetHeight +
                             locaPlayer.transform.right * cameraRig.CameraOffset.x;
        var targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraRig.Damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraRig.Damping * Time.deltaTime);
    }
}