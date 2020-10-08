using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private Text text;
    private PlayerShoot playerShoot;

    private void Awake()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        playerShoot = player.PlayerShoot;
        playerShoot.ActiveWeapon.Reloader.OnAmmoChanged += HandleOnAmmoChange;
    }

    private void HandleOnAmmoChange()
    {
        text.text = playerShoot.ActiveWeapon.Reloader.RoundsRemainingInClip
    }
}