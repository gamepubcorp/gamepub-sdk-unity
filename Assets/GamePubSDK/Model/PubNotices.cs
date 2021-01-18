using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubNotices
    {
        [SerializeField]
        private PubNoticeData[] noticeList = null;

        public PubNoticeData[] NoticeList { get { return noticeList; } }

    }
}
