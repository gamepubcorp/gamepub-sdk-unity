using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubPurchaseData
    {
        [SerializeField]
        private int intDate = 0;
        [SerializeField]
        private string transactionId = "";
        [SerializeField]
        private int status = 0;
        [SerializeField]
        private string serverId = "";
        [SerializeField]
        private string playerId = "";
        [SerializeField]
        private string productId = "";

        public int IntDate { get { return intDate; } }

        public string TransactionId { get { return transactionId; } }

        public int Status { get { return status; } }

        public string ServerId { get { return serverId; } }

        public string PlayerId { get { return playerId; } }

        public string ProductId { get { return productId; } }
    }
}
