using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubLanguageList
    {
        [SerializeField]
        private int[] langList = null;
        
        public int[] LangList { get { return langList; } }
    }
}
