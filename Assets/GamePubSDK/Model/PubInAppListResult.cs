using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubInAppListResult
    {
        [SerializeField]
        private PubInAppProduct[] productList = null;

        public PubInAppProduct[] InAppProducts { get { return productList; } }
    }
}