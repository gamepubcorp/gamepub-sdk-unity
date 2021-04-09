using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubInAppProduct
    {
        [SerializeField]
        private int AppId = 0;
        [SerializeField]
        private string Store = "";
        [SerializeField]
        private string ProductID = "";        
        
        public int appId { get { return AppId; } }

        public string store { get { return Store; } }

        public string productID { get { return ProductID; } }        
    }
}