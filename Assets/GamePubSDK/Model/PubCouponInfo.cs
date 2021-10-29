using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubCouponInfo
    {
        [SerializeField]
        private int resultCode;
        [SerializeField]
        private string message = "";
        [SerializeField]
        private string reward = "";

        public int ResultCode { get { return resultCode; } }
        public string Message { get { return message; } }
        public string Reward { get { return reward; } }
    }
}
