using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubAuthenticationState
    {
        [SerializeField]
        private int loginType = 0;

        public int LoginType { get { return loginType; } }
    }
}