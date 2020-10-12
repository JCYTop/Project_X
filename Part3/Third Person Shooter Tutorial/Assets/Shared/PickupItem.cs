using System;
using UnityEngine;

namespace Shared
{
    public class PickupItem : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.tag != "Player")
                return;
            PickUp(collider.transform);
        }

        public virtual void OnPickup(Transform item)
        {
        }

        private void PickUp(Transform Item)
        {
            OnPickup(Item);
        }
    }
}