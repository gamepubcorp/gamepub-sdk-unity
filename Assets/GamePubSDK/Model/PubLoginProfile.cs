using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubUserProfile
    {
        [SerializeField]
        private string displayName = "";
        [SerializeField]
        private string channelId = "";
        [SerializeField]
        private string email = "";
        [SerializeField]
        private string photoURL = "";
        [SerializeField]
        private string loginType = "";

        public string DisplayName { get { return displayName; } }
        public string ChannelId { get { return channelId; } }
        public string Email { get { return email; } }
        public string PhotoURL { get { return photoURL; } }
        public string LoginType { get { return loginType; } }
    }
}

