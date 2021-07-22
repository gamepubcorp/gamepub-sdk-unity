using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubImageBannerList
    {
        [SerializeField]
        private PubImageBannerInfo[] imgBannerList = null;

        public PubImageBannerInfo[] ImgBannerList { get { return imgBannerList; } }
    }
}