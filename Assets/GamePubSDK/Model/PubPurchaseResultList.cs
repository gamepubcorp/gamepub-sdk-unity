using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubPurchaseResultList
    {
        [SerializeField]
        private PubPurchaseData[] purchaseResultList = null;

        public PubPurchaseData[] PurchaseResultList { get { return purchaseResultList; } }
    }
}