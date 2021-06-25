using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubVersionInfo
    {        
        [SerializeField]
        private string store = "";
        [SerializeField]
        private string type = "";
        [SerializeField]
        private string versionName = "";
        [SerializeField]
        private string versionCode = "";
        [SerializeField]
        private string link = "";
        
        public string Store { get { return store; } }
        public string Type { get { return type; } }
        public string VersionName { get { return versionName; } }
        public string VersionCode { get { return versionCode; } }
        public string Link { get { return link; } }

    }
}
