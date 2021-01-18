using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubNoticeData
    {
        [SerializeField]
        private string type = "";
        [SerializeField]
        private string title = "";
        [SerializeField]
        private string contents = "";
        [SerializeField]
        private string imageURL = "";
        [SerializeField]
        private string link = "";
        [SerializeField]
        private string startDate = "";
        [SerializeField]
        private string endDate = "";
        [SerializeField]
        private string regDate = "";

        public string Type { get { return type; } }
        public string Title { get { return title; } }
        public string Contents { get { return contents; } }
        public string ImageURL { get { return imageURL; } }
        public string Link { get { return link; } }
        public string StartDate { get { return startDate; } }
        public string EndDate { get { return endDate; } }
        public string RegDate { get { return regDate; } }

    }
}