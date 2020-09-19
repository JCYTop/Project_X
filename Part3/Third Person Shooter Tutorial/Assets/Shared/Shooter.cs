using Combat;
using Extend;
using UnityEngine;

namespace Shared
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private float rateOfFire;
        [SerializeField] private Transform projectile;
        [HideInInspector] public Transform muzzle;
        private float nextFireAllowed;
        public bool canFire;
        private WeaponReloader reloader;

        private void Awake()
        {
            muzzle = transform.FindInChild("Muzzle");
            reloader = GetComponent<WeaponReloader>();
        }

        public void Reload()
        {
            if (reloader == null)
                return;
            reloader.Reload();
        }

        public virtual void Fire()
        {
            canFire = false;
            if (Time.time < nextFireAllowed)
                return;
            if (reloader != null)
            {
                if (reloader.IsReloading)
                    return;
                if (reloader.RoundsRemainingInClip == 0)
                    return;
                reloader.TakeFromClip(1);
            }

            nextFireAllowed = Time.time + rateOfFire;
            Instantiate(projectile, muzzle.position, muzzle.rotation);
            canFire = true;
        }
    }
}