using System;
using UnityEngine;

namespace GamePub.PubSDK
{
    public static class Helpers
    {
        public static bool IsInvalidRuntime(string identifier, RuntimePlatform platform)
        {
            if(Application.platform != platform)
            {
                Debug.LogWarning("[GamePub SDK] This RuntimePlatform is not supported. Only iOS and Android devices are supported.");
                var errorJson = @"{""code"":-1, ""message"":""Platform not supported.""}";
                var result = CallbackMessageForUnity.WrapValue(identifier, errorJson);
                GamePubSDK.Ins.OnApiError(result);
                return true;
            }
            return false;
        }
    }
}
