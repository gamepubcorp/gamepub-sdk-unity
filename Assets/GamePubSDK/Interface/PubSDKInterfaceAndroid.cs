
#if UNITY_ANDROID
using UnityEngine;

namespace GamePub.PubSDK
{
    public class NativeInterface
    {
#if UNITY_EDITOR
        static AndroidJavaObject pubSdkWrapper = null;
#else
        static AndroidJavaObject pubSdkWrapper = new AndroidJavaObject("com.gamepubcorp.sdk.unitywrapper.PubSdkWrapper");
#endif
        static NativeInterface()
        {
            var _ = GamePubSDK.Ins;
        }

        public static void SetupSDK(string identifier, string deviceUID)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[2];
            param[0] = identifier;
            param[1] = deviceUID;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("setupSDK", param);
        }

        public static void Login(string identifier,
                                 PubLoginType loginType,
                                 PubAccountServiceType serviceType)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[3];
            param[0] = identifier;
            param[1] = (int)loginType;
            param[2] = (int)serviceType;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("login", param);
        }

        public static void Logout(string identifier, PubLoginType loginType)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[2];
            param[0] = identifier;
            param[1] = (int)loginType;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("logout", param);
        }

        public static void UserInfoUpdate(string identifier,
                                          string languageCode,
                                          bool push,
                                          bool pushNight,
                                          bool pushAd)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[5];
            param[0] = identifier;
            param[1] = languageCode;
            param[2] = (push == true) ? 1 : 0;
            param[3] = (pushNight == true) ? 1 : 0;
            param[4] = (pushAd == true) ? 1 : 0;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("userInfoUpdate", param);
        }

        public static void AutoLogin(string identifier)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[1];
            param[0] = identifier;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("autoLogin", param);
        }

        public static string AuthenticationState()
        {
            if (!Application.isPlaying) { return null; }
            if(pubSdkWrapper == null) { return null; }

            return pubSdkWrapper.Call<string>("authenticationState");
        }

        public static void OpenPolicyLink(string identifier,
                                          PubPolicyType policyType)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[2];
            param[0] = identifier;
            param[1] = (int)policyType;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("openPolicyLink", param);
        }

        public static void ImageBanner(string identifier,
                                       string ratioWidth,
                                       string ratioHeight)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[3];
            param[0] = identifier;
            param[1] = ratioWidth;
            param[2] = ratioHeight;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("imageBanner", param);
        }

        public static void InAppPurchase(string identifier,
                                         string pid,
                                         string serverId,
                                         string playerId,
                                         string etc)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[5];
            param[0] = identifier;
            param[1] = pid;
            param[2] = serverId;
            param[3] = playerId;
            param[4] = etc;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("purchaseLaunch", param);
        }

        public static void VersionCheck(string identifier)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[1];
            param[0] = identifier;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("versionCheck", param);
        }

        public static void OpenNotice(string identifier)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[1];
            param[0] = identifier;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("openNotice", param);
        }

        public static void OpenHelpURL(string identifier)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[1];
            param[0] = identifier;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("openHelpURL", param);
        }

        public static void CouponUse(string identifier,
                                     string key,
                                     string serverId,
                                     string playerId,
                                     string etc)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[5];
            param[0] = identifier;
            param[1] = key;
            param[2] = serverId;
            param[3] = playerId;
            param[4] = etc;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("couponUse", param);
        }

        public static void Ping(string identifier)
        {
            if (!Application.isPlaying) { return; }

            object[] param = new object[1];
            param[0] = identifier;

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("ping", param);
        }

        public static void StartPing()
        {
            if (!Application.isPlaying) { return; }

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("startPing");
        }

        public static void StopPing()
        {
            if (!Application.isPlaying) { return; }

            if (pubSdkWrapper != null)
                pubSdkWrapper.Call("stopPing");            
        }
    }
}

#endif