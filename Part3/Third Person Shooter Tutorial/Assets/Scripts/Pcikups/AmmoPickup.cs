using Combat;
using Shared;
using UnityEngine;

namespace Pcikups
{
    public class AmmoPickup : PickupItem
    {
        [SerializeField] private EWeaponType weaponType;
        [SerializeField] private float respawnTime;
        [SerializeField] private int amount;

        public override void OnPickup(Transform item)
        {
            var playerInventory = item.GetComponentInChildren<Container>();
            GameManager.Instance.Respawner.Despawn(gameObject, respawnTime);
            playerInventory.Put(weaponType.ToString(), amount);
            item.GetComponent<Player>().PlayerShoot.ActiveWeapon.Reloader.HandleOnAmmoChanged();
        }
    }
}