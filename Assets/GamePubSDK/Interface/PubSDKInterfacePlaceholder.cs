//  Copyright (c) 2020-present, GamePub Corporation. All rights reserved.

#if !UNITY_IOS && !UNITY_ANDROID
namespace GamePub.PubSDK
{
    public class NativeInterface
    {
        public static void SetupSDK(string identifier, string url, string sdkAppId) { }
        public static void Login(string identifier, PubLoginType loginType, PubAccountServiceType serviceType) { }
        public static void Logout(string identifier) { }
        public static void UserInfoUpdate(string identifier, string languageCode, bool push, bool pushNight, bool pushAd) { }        
        public static string GetLoginType() { return null; }
        public static string GetLanguageList() { return null; }
        public static string GetProductList() { return null; }
        public static void Secede(string identifier) { }
        public static void SecedeCancel(string identifier, PubLoginType loginType) { }
        public static void OpenPolicyLink(string identifier, PubPolicyType policyType) { }
        public static void ImageBanner(string identifier, string ratioWidth, string ratioHeight) { }
        public static void InAppPurchase(string identifier, string pid, string serverId, string playerId, string etc) { }
        public static void VersionCheck(string identifier) { }
        public static void OpenNotice(string identifier) { }
        public static void OpenHelpURL(string identifier) { }
        public static void CouponUse(string identifier, string key, string serverId, string playerId, string etc) { }
        public static void RemoteConfig(string identifier) { }
        public static void Ping(string identifier) { }
        public static void StartPing() { }
        public static void StopPing() { }
    }
}
#endif