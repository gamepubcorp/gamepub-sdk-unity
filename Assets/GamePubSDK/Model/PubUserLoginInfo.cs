using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubUserLoginInfo
    {
        [SerializeField]
        private string accountID = "";
        [SerializeField]
        private string language = "";        
        [SerializeField]
        private string regDate = "";
        [SerializeField]
        private string secedeDate = "";
        [SerializeField]
        private string blockDate = "";
        [SerializeField]
        private string blockExpire = "";
        [SerializeField]
        private string blockMessage = "";
        [SerializeField]
        private int appId = 0;
        [SerializeField]
        private int intDate = 0;
        [SerializeField]
        private int status = 0;
        [SerializeField]
        private bool agreePush = false;
        [SerializeField]
        private bool agreeNight = false;
        [SerializeField]
        private bool agreeAd;
        [SerializeField]
        private int blockReason = 0;

        public string AccountID { get { return accountID; } }
        public string Language { get { return language; } }
        
        public string RegDate { get { return regDate; } }
        public string SecedeDate { get { return secedeDate; } }
        public string BlockDate { get { return blockDate; } }
        public string BlockExpire { get { return blockExpire; } }
        public string BlockMessage { get { return blockMessage; } }

        public int AppId { get { return appId; } }
        public int IntDate { get { return intDate; } }
        public int Status { get { return status; } }
        public bool AgreePush { get { return agreePush; } }
        public bool AgreeNight { get { return agreeNight; } }
        public bool AgreeAd { get { return agreeAd; } }
        public int BlockReason { get { return blockReason; } }
    }
}