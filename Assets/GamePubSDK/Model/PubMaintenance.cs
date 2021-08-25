using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubMaintenance
    {
        [SerializeField]
        private int appId = 0;        
        [SerializeField]
        private string startDate = "";
        [SerializeField]
        private string endDate = "";
        [SerializeField]
        private string link = "";
        [SerializeField]
        private string regDate = "";
        [SerializeField]
        private string language = "";
        [SerializeField]
        private string message = "";

        public int AppId { get { return appId; } }        
        public string StartDate { get { return startDate; } }
        public string EndDate { get { return endDate; } }
        public string Link { get { return link; } }
        public string RegDate { get { return regDate; } }
        public string Language { get { return language; } }
        public string Message { get { return message; } }
    }
}