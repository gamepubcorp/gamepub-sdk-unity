using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    [Serializable]
    public class PubUserProfile
    {
        [SerializeField]
        private string idToken = "";
        [SerializeField]
        private string displayName = "";
        [SerializeField]
        private string channelId = "";
        [SerializeField]
        private string email = "";

        public string IdToken { get { return idToken; } }

        public string DisplayName { get { return displayName; } }

        public string ChannelId { get { return channelId; } }

        public string Email { get { return email; } }
    }
}

