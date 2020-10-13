using System;
using UnityEngine;

namespace Combat
{
    public class WeaponReloader : MonoBehaviour
    {
        [SerializeField] private int maxAmmo;
        [SerializeField] private float reloadTime;
        [SerializeField] private int clipSize;
        [SerializeField] private Container inventory;
        [SerializeField] private EWeaponType weaponType;
        public int shotsFiredInClip;
        private bool isReloading;
        private Guid containerItemId;
        public event Action OnAmmoChanged;

        public int RoundsRemainingInClip
        {
            get { return clipSize - shotsFiredInClip; }
        }

        public int RoundsRemainingInInventory
        {
            get { return inventory.GetAmountRemaining(containerItemId); }
        }

        public bool IsReloading => isReloading;

        private void Awake()
        {
            containerItemId = inventory.Add(weaponType.ToString(), maxAmmo);
        }

        public void Reload()
        {
            if (isReloading)
                return;
            isReloading = true;
            GameManager.Instance.Timer.Add(() => { ExecuteReload(inventory.TakeFromContainer(containerItemId, clipSize - RoundsRemainingInClip)); }, reloadTime);
        }

        private void ExecuteReload(int amount)
        {
            isReloading = false;
            shotsFiredInClip -= amount;
            HandleOnAmmoChanged();
        }

        public void TakeFromClip(int amout)
        {
            shotsFiredInClip += amout;
            HandleOnAmmoChanged();
        }

        public void HandleOnAmmoChanged()
        {
            if (OnAmmoChanged != null)
                OnAmmoChanged();
        }
    }
}