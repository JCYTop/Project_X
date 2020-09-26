﻿using System;
using UnityEngine;

namespace Combat
{
    public class WeaponReloader : MonoBehaviour
    {
        [SerializeField] private int maxAmmo;
        [SerializeField] private float reloadTime;
        [SerializeField] private int clipSize;
        [SerializeField] private Container Inventory;
        public int shotsFiredInClip;
        private bool isReloading;
        private Guid containerItemID;

        public int RoundsRemainingInClip
        {
            get { return clipSize - shotsFiredInClip; }
        }

        public bool IsReloading => isReloading;

        private void Awake()
        {
            containerItemID = Inventory.Add(this.name, maxAmmo);
        }

        public void Reload()
        {
            if (isReloading)
                return;
            isReloading = true;
            GameManager.Instance.Timer.Add(() => { ExecuteReload(Inventory.TakeFromContainer(containerItemID, clipSize - RoundsRemainingInClip)); }, reloadTime);
        }

        private void ExecuteReload(int amount)
        {
            isReloading = false;
            shotsFiredInClip -= amount;
        }

        public void TakeFromClip(int amout)
        {
            shotsFiredInClip += amout;
        }
    }
}