using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    public class GamePubSDKSettings : ScriptableObject
    {
        public const string settingsAssetName = "GamePubSDKSettings";
        public const string settingsPath = "GamePubSDK/Resources";
        public const string settingsAssetExtension = ".asset";
        private static readonly string httpBase = "https://{0}";

        private static GamePubSDKSettings instance;        

        public static GamePubSDKSettings Instance
        {
            get
            {
                if (ReferenceEquals(instance, null))
                {
                    instance = Resources.Load(settingsAssetName) as GamePubSDKSettings;
                    if (ReferenceEquals(instance, null))
                    {
                        instance = CreateInstance<GamePubSDKSettings>();
                    }
                }
                return instance;
            }
        }

        [SerializeField]
        private string liveServerUrlBase = "";
        [SerializeField]
        private string testServerUrlBase = "";
        [SerializeField]
        private bool testBuild = true;

        public static string LiveServer
        {
            get { return Instance.liveServerUrlBase; }
            set { Instance.liveServerUrlBase = value; }
        }

        public static string TestServer
        {
            get { return Instance.testServerUrlBase; }
            set { Instance.testServerUrlBase = value; }
        }

        public static bool TestBuild
        {
            get { return Instance.testBuild; }
            set { Instance.testBuild = value; }
        }

        public static string ServiceDomain
        {
            get
            {
                if (Instance.testBuild)
                {
                    return string.Format(httpBase, Instance.testServerUrlBase);
                }
                return string.Format(httpBase, Instance.liveServerUrlBase);
            }
        }
    }
}