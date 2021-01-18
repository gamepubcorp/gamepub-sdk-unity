using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubInAppProduct
    {
        [SerializeField]
        private int APDSeq = 0;
        [SerializeField]
        private int AppId = 0;
        [SerializeField]
        private string Store = "";
        [SerializeField]
        private string ProductID = "";
        [SerializeField]
        private string InGameID = "";
        [SerializeField]
        private string Title = "";
        [SerializeField]
        private string Description = "";
        [SerializeField]
        private string Price = "";

        public int aPDSeq { get { return APDSeq; } }

        public int appId { get { return AppId; } }

        public string store { get { return Store; } }

        public string productID { get { return ProductID; } }

        public string inGameID { get { return InGameID; } }

        public string title { get { return Title; } }

        public string description { get { return Description; } }

        public string price { get { return Price; } }
    }
}