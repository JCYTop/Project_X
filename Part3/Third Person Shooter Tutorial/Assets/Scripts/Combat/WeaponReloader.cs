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
            get
            {
                return inventory.GetAmountRemaining(containerItemId);
            }
        }

        public bool IsReloading => isReloading;

        private void Awake()
        {
            containerItemId = inventory.Add(this.gameObject.name, maxAmmo);
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
        }

        public void TakeFromClip(int amout)
        {
            shotsFiredInClip += amout;
            if (OnAmmoChanged != null)
                OnAmmoChanged();
        }
    }
}