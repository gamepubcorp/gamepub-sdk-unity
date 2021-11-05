
#if UNITY_IOS

using UnityEngine;
using System;
using System.Runtime.InteropServices;
using AOT;
using System.Reflection;

namespace GamePub.PubSDK
{
    public class NativeInterface
    {
        static NativeInterface()
        {
            var _ = GamePubSDK.Ins;
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_setup(string identifier,                                                 
                                                 string projectId);
        public static void SetupSDK(string identifier,                                    
                                    string projectId)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            pub_sdk_setup(identifier, projectId);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_login(string identifier,
                                                 int loginType,
                                                 int serviceType);
        public static void Login(string identifier,
                                 PubLoginType loginType,
                                 PubAccountServiceType serviceType)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_login(identifier, (int)loginType, (int)serviceType);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_logout(string identifier);
        public static void Logout(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_logout(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_userInfoUpdate(string identifier,
                                                          int languageCode,
                                                          bool push,
                                                          bool pushNight,
                                                          bool pushAd);
        public static void UserInfoUpdate(string identifier,
                                          PubLanguageCode languageCode,
                                          bool push,
                                          bool pushNight,
                                          bool pushAd)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_userInfoUpdate(identifier, (int)languageCode, push, pushNight, pushAd);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_setAgreePush(bool push,
                                                        bool pushNight,
                                                        bool pushAd);
        public static void SetAgreePush(bool push,
                                        bool pushNight,
                                        bool pushAd)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            pub_sdk_setAgreePush(push, pushNight, pushAd);
        }

        [DllImport("__Internal")]
        private static extern string pub_sdk_getLoginType();
        public static string GetLoginType()
        {
            if (!Application.isPlaying) { return null; }
            if (IsInvalidRuntime(null)) { return null; }

            return pub_sdk_getLoginType();
        }

        [DllImport("__Internal")]
        private static extern string pub_sdk_getLanguageList();
        public static string GetLanguageList()
        {
            if (!Application.isPlaying) { return null; }
            if (IsInvalidRuntime(null)) { return null; }

            return pub_sdk_getLanguageList();
        }

        //[DllImport("__Internal")]
        //private static extern string pub_sdk_getProductList();
        //public static string GetProductList()
        //{
        //    if (!Application.isPlaying) { return null; }
        //    if (IsInvalidRuntime(null)) { return null; }

        //    return pub_sdk_getProductList();
        //}

        [DllImport("__Internal")]
        private static extern void pub_sdk_secede(string identifier);
        public static void Secede(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_secede(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_secedeCancel(string identifier);
        public static void SecedeCancel(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_secedeCancel(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_openPolicyLink(string identifier, int policyType);
        public static void OpenPolicyLink(string identifier, PubPolicyType policyType)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_openPolicyLink(identifier, (int)policyType);
        }        

        [DllImport("__Internal")]
        private static extern void pub_sdk_getImageBanner(string identifier);
        public static void GetImageBanner(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_getImageBanner(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_initBilling(string identifier);
        public static void InitBilling(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_initBilling(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_inAppPurchase(string identifier,
                                                         string pid,
                                                         string serverId,
                                                         string playerId,
                                                         string etc);
        public static void InAppPurchase(string identifier,
                                         string pid,
                                         string serverId,
                                         string playerId,
                                         string etc)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_inAppPurchase(identifier, pid, serverId, playerId, etc);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_userRefundListSearch(string identifier,
                                                                string accountId,
                                                                string loginType,
                                                                string channelId);
        public static void UserRefundListSearch(string identifier,
                                                string accountId,
                                                string loginType,
                                                string channelId)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_userRefundListSearch(identifier, accountId, loginType, channelId);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_userRefundRepurchase(string identifier,
                                                                string accountId,
                                                                string loginType,
                                                                string channelId,
                                                                string pid,
                                                                string serverId,
                                                                string playerId,
                                                                string etc,
                                                                string voidedTid);
        public static void UserRefundRepurchase(string identifier,
                                                string accountId,
                                                string loginType,
                                                string channelId,
                                                string pid,
                                                string serverId,
                                                string playerId,
                                                string etc,
                                                string voidedTid)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_userRefundRepurchase(
                identifier,
                accountId,
                loginType,
                channelId,
                pid,
                serverId,
                playerId,
                etc,
                voidedTid);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_versionCheck(string identifier);
        public static void VersionCheck(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_versionCheck(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_openNotice(string identifier);
        public static void OpenNotice(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_openNotice(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_openHelpURL(string identifier);
        public static void OpenHelpURL(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_openHelpURL(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_couponUse(string identifier,
                                                     string key,
                                                     string serverId,
                                                     string playerId,
                                                     string etc);
        public static void CouponUse(string identifier,
                                     string key,
                                     string serverId,
                                     string playerId,
                                     string etc)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_couponUse(identifier, key, serverId, playerId, etc);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_syncRemoteConfig(string identifier);
        public static void SyncRemoteConfig(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_syncRemoteConfig(identifier);
        }

        [DllImport("__Internal")]
        private static extern string pub_sdk_getRemoteConfigValue(string key);
        public static string GetRemoteConfigValue(string key)
        {
            if (!Application.isPlaying) { return null; }
            if (IsInvalidRuntime(null)) { return null; }

            return pub_sdk_getRemoteConfigValue(key);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_ping(string identifier);
        public static void Ping(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            pub_sdk_ping(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_startPing();
        public static void StartPing()
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            pub_sdk_startPing();
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_stopPing();
        public static void StopPing()
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            pub_sdk_stopPing();
        }

        private static bool IsInvalidRuntime(string identifier)
        {
            return Helpers.IsInvalidRuntime(identifier, RuntimePlatform.IPhonePlayer);
        }
    }
}
#endif