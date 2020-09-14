using System;
using Extend;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float damping;
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
        var targetPosition = cameraLookTarget.position +
                             locaPlayer.transform.forward * cameraOffset.z +
                             locaPlayer.transform.up * cameraOffset.y +
                             locaPlayer.transform.right * cameraOffset.x;
        var targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);
        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
    }
}