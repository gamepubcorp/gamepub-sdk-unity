using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubRefundListResult
    {
        [SerializeField]
        private PubRefundInfo[] refundList = null;

        public PubRefundInfo[] RefundList { get { return refundList; } }
    }
}