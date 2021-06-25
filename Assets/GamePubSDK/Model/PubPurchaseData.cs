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
        private int status = 0;
        [SerializeField]
        private string tid = ""; 
        [SerializeField]
        private string serverId = "";
        [SerializeField]
        private string playerId = "";
        [SerializeField]
        private string etc = "";
        [SerializeField]
        private string productId = "";
        [SerializeField]
        private string voidedTid = "";
        [SerializeField]
        private string itemSendCode = "";
        [SerializeField]
        private string reward = "";

        public int IntDate { get { return intDate; } }
        public int Status { get { return status; } }
        public string Tid { get { return tid; } }
        public string ServerId { get { return serverId; } }
        public string PlayerId { get { return playerId; } }
        public string Etc { get { return etc; } }
        public string ProductId { get { return productId; } }
        public string VoidedTid { get { return voidedTid; } }
        public string ItemSendCode { get { return itemSendCode; } }
        public string Reward { get { return reward; } }
    }
}
