using UnityEngine;

namespace GamePub.PubSDK
{
    public static class ExtensionMethods
    {
        public static void Log(this object value)
        {
            if (GamePubSDKSettings.DevBuild)
                Debug.Log(value.ToString());
        }
        public static void SuccessLog(this object value)
        {
            if (GamePubSDKSettings.DevBuild)
                Debug.Log("OnApiOk : " + value.ToString());
        }

        public static void ErrorLog(this object value)
        {
            if (GamePubSDKSettings.DevBuild)
                Debug.Log("OnApiError : " + value.ToString());
        }

        public static void UpdateLog(this object value)
        {
            if (GamePubSDKSettings.DevBuild)
                Debug.Log("OnApiUpdate : " + value.ToString());
        }
    }
}
