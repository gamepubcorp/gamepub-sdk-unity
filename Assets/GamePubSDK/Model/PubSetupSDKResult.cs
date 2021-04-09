using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubSetupSDKResult
    {        
        [SerializeField]
        private string[] langList = null;
        
        public string[] LangList { get { return langList; } }
        
    }
}
