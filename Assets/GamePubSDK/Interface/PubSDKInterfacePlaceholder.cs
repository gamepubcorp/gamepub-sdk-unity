//  Copyright (c) 2020-present, GamePub Corporation. All rights reserved.

#if !UNITY_IOS && !UNITY_ANDROID
namespace GamePub.PubSDK
{
    public class NativeInterface
    {
        public static void SetupSDK(string identifier, string sdkAppId) { }
        public static void Login(string identifier, PubLoginType loginType, PubAccountServiceType serviceType) { }
        public static void Logout(string identifier) { }
        public static void UserInfoUpdate(string identifier, PubLanguageCode languageCode, bool push, bool pushNight, bool pushAd) { }
        public static void SetAgreePush(bool push, bool pushNight, bool pushAd) { }
        public static string GetLoginType() { return null; }
        public static string GetLanguageList() { return null; }
        public static string GetProductList() { return null; }
        public static void Secede(string identifier) { }
        public static void SecedeCancel(string identifier, PubLoginType loginType) { }
        public static void OpenPolicyLink(string identifier, PubPolicyType policyType) { }
        public static void GetImageBanner(string identifier) { }
        public static void InitBilling(string identifier) { }
        public static void InAppPurchase(string identifier, string pid, string serverId, string playerId, string etc) { }
        public static void UserRefundListSearch(string identifier, string accountId, string loginType, string channelId) { }
        public static void UserRefundRepurchase(string identifier, string accountId, string loginType, string channelId, string pid, string serverId, string playerId, string etc, string voidedTid) { }
        public static void VersionCheck(string identifier) { }
        public static void OpenNotice(string identifier) { }
        public static void OpenHelpURL(string identifier) { }
        public static void CouponUse(string identifier, string key, string serverId, string playerId, string etc) { }
        public static void SyncRemoteConfig(string identifier) { }
        public static string GetRemoteConfigValue(string key) { return null; }
        public static void Ping(string identifier) { }
        public static void StartPing() { }
        public static void StopPing() { }
    }
}
#endif