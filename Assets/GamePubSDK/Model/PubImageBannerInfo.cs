using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubImageBannerInfo
    {
        [SerializeField]
        private int sort = 0;
        [SerializeField]
        private string storeList = "";        
        [SerializeField]
        private string startDate = "";
        [SerializeField]
        private string endDate = "";
        [SerializeField]
        private string regDate = "";
        [SerializeField]
        private string title = "";
        [SerializeField]
        private string contents = "";
        [SerializeField]
        private string images = "";
        [SerializeField]
        private string link = "";

        public int Sort { get { return sort; } }
        public string StoreList { get { return storeList; } }
        public string StartDate { get { return startDate; } }
        public string EndDate { get { return endDate; } }
        public string RegDate { get { return regDate; } }
        public string Title { get { return title; } }
        public string Contents { get { return contents; } }
        public string Images { get { return images; } }
        public string Link { get { return link; } }
    }
}
