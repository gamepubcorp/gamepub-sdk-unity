using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    public class GamePubSDKSettings : ScriptableObject
    {
        public const string settingsAssetName = "GamePubSDKSettings";
        public const string settingsPath = "GamePubSDK/Resources";
        public const string settingsAssetExtension = ".asset";        

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
        private string sdkAppId = "";
        [SerializeField]
        private bool devBuild = true;

        public static string AppID
        {
            get { return Instance.sdkAppId; }
            set { Instance.sdkAppId = value; }
        }

        public static bool DevBuild
        {
            get { return Instance.devBuild; }
            set { Instance.devBuild = value; }
        }
    }
}