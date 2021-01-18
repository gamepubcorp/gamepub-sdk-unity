using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubSetupSDKResult
    {
        [SerializeField]
        private PubInAppProduct[] productList = null;
        [SerializeField]
        private string[] langList = null;

        public PubInAppProduct[] InAppProducts { get { return productList; } }
        public string[] LangList { get { return langList; } }
        
    }
}
