using System;
using Combat;
using Extend;
using UnityEngine;

namespace Shared
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private float rateOfFire;
        [SerializeField] private Transform projectile;
        [SerializeField] public Transform hand;
        [SerializeField] private AudioController audioReload;
        [SerializeField] private AudioController audioFire;
        private float nextFireAllowed;
        private Transform muzzle;
        public bool canFire;
        private WeaponReloader reloader;
        public WeaponReloader Reloader => reloader;

        private void Awake()
        {
            muzzle = transform.FindInChild("Muzzle");
            reloader = GetComponent<WeaponReloader>();
        }

        public void Equip()
        {
            transform.SetParent(hand);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        private void OnDisable()
        {
        }

        public void Reload()
        {
            if (reloader == null)
                return;
            reloader.Reload();
            audioReload.Play();
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
            audioFire.Play();
            canFire = true;
        }
    }
}