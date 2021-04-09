
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
        private static extern void pub_sdk_setup(string identifier);
        public static void SetupSDK(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            pub_sdk_setup(identifier);
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
        private static extern void pub_sdk_logout(string identifier, int loginType);
        public static void Logout(string identifier, PubLoginType loginType)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_logout(identifier, (int)loginType);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_userInfoUpdate(string identifier,
                                                          string languageCode,
                                                          bool push,
                                                          bool pushNight,
                                                          bool pushAd);
        public static void UserInfoUpdate(string identifier,
                                          string languageCode,
                                          bool push,
                                          bool pushNight,
                                          bool pushAd)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_userInfoUpdate(identifier, languageCode, push, pushNight, pushAd);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_autoLogin(string identifier);
        public static void AutoLogin(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_autoLogin(identifier);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_authenticationState(string identifier);
        public static void AuthenticationState(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(null)) { return; }

            pub_sdk_authenticationState(identifier);
        }

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
        private static extern void pub_sdk_imageBanner(string identifier,
                                                       string ratioWidth,
                                                       string ratioHeight);
        public static void ImageBanner(string identifier, string ratioWidth, string ratioHeight)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_imageBanner(identifier, ratioWidth, ratioHeight);
        }

        [DllImport("__Internal")]
        private static extern void pub_sdk_purchaseInit(string identifier);
        public static void PurchaseInit(string identifier)
        {
            if (!Application.isPlaying) { return; }
            if (IsInvalidRuntime(identifier)) { return; }

            pub_sdk_purchaseInit(identifier);
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