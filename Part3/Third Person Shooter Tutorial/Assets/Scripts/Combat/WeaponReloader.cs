using UnityEngine;

namespace Combat
{
    public class WeaponReloader : MonoBehaviour
    {
        [SerializeField] private int maxAmmo;
        [SerializeField] private float reloadTime;
        [SerializeField] private int clipSize;

        private int ammo;
        public int shotsFiredInClip;
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
            Debug.Log("Reload Start");
            GameManager.Instance.Timer.Add(ExecuteReload, reloadTime);
        }

        private void ExecuteReload()
        {
            Debug.Log("Reload");
            isReloading = false;
            ammo -= shotsFiredInClip;
            shotsFiredInClip = 0;
            if (ammo < 0)
            {
                ammo = 0;
                shotsFiredInClip += -ammo;
            }
        }

        public void TakeFromClip(int amout)
        {
            shotsFiredInClip += amout;
        }
    }
}