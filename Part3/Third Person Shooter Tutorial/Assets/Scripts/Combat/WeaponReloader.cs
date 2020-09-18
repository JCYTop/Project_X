using UnityEngine;

namespace Combat
{
    public class WeaponReloader : MonoBehaviour
    {
        [SerializeField] private int maxAmmo;
        [SerializeField] private float reloadTime;
        [SerializeField] private int clipSize;

        private int ammo;
        private int shotsFiredInClip;
        private bool isReloading;

        public int RoundsRemainingInClip
        {
            get { return clipSize - shotsFiredInClip; }
        }

        public bool IsReloading => isReloading;

        public void Reload()
        {
            if (isReloading)
                return;
            isReloading = true;
            // GameManager.Instance.Time
        }

        private void ExecuteReload()
        {
            isReloading = false;
            ammo -= shotsFiredInClip;
            shotsFiredInClip = 0;
            if (ammo < 0)
            {
                ammo = 0;
                shotsFiredInClip += -ammo;
            }
        }
    }
}