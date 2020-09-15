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

        private void Awake()
        {
            muzzle = transform.FindInChild("Muzzle");
        }

        public virtual void Fire()
        {
            canFire = false;
            if (Time.time < nextFireAllowed)
                return;
            nextFireAllowed = Time.time + rateOfFire;
            Instantiate(projectile, muzzle.position, muzzle.rotation);
            canFire = true;
        }
    }
}