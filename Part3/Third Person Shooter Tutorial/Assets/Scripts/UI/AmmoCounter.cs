using Combat;
using Shared;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private Text text;
    private PlayerShoot playerShoot;
    private WeaponReloader reloader;

    private void Awake()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        playerShoot = player.PlayerShoot;
        playerShoot.OnWeaponSwitch += HandleOnWeaponSwitch;
    }

    private void HandleOnWeaponSwitch(Shooter activeWeapon)
    {
        reloader = activeWeapon.Reloader;
        reloader.OnAmmoChanged += HandleOnAmmoChange;
        HandleOnAmmoChange();
    }

    private void HandleOnAmmoChange()
    {
        var amountInventory = reloader.RoundsRemainingInInventory;
        var amountInClip = reloader.RoundsRemainingInClip;
        text.text = $"{amountInClip} / {amountInventory}";
    }
}