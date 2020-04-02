using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Framework.Addressable
{
    public class AddressableTest : MonoBehaviour
    {
        public AssetReference archerObject;

        private void Start()
        {
            archerObject.LoadAssetAsync<GameObject>().Completed += handle => { };
        }
    }
}