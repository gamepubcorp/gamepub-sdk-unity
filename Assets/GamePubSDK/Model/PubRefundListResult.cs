using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubRefundListResult
    {
        [SerializeField]
        private PubRefundInfo[] productList = null;

        public PubRefundInfo[] InAppProducts { get { return productList; } }
    }
}