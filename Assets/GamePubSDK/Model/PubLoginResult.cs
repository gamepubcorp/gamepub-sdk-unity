using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubLoginResult
    {
        [SerializeField]
        private int responseCode = 0;
        [SerializeField]
        private PubUserProfile userProfile = null;
        [SerializeField]
        private PubUserLoginInfo userLoginInfo = null;
        [SerializeField]
        private PubMaintenance userMaintenance = null;

        public int ResponseCode { get { return responseCode; } }
        public PubUserProfile UserProfile { get { return userProfile; } }
        public PubUserLoginInfo UserLoginInfo { get { return userLoginInfo; } }
        public PubMaintenance Maintenance { get { return userMaintenance; } }
        
    }
}