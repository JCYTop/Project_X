using Shared;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Shooter assaultRifle;

    private void Update()
    {
        if (GameManager.Instance.InputController.Fire1)
        {
            assaultRifle.Fire();
        }
    }
}