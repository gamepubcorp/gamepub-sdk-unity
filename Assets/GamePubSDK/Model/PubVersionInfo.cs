using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubVersionInfo
    {
        [SerializeField]
        private int isUpdate = 0;
        [SerializeField]
        private int isActive = 0;
        [SerializeField]
        private string versionName = "";
        [SerializeField]
        private string link = "";

        public int IsUpdate { get { return isUpdate; } }

        public int IsActive { get { return isActive; } }

        public string VersionName { get { return versionName; } }

        public string Link { get { return link; } }
        
    }
}
