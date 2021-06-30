using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePub.PubSDK
{
    public class GamePubAPI
    {
        public static Dictionary<String, FlattenAction> actions =
            new Dictionary<string, FlattenAction>();

        public static void SetupSDK(string url,
                                    string sdkAppId,
                                    Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.SetupSDK(identifier, url, sdkAppId);
        }

        public static void Login(PubLoginType loginType,
                                 PubAccountServiceType serviceType,
                                 Action<Result<PubLoginResult>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubLoginResult>(action));

            NativeInterface.Login(identifier, loginType, serviceType);
        }

        public static void Logout(Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.Logout(identifier);
        }

        public static void UserInfoUpdate(string languageCode,
                                          bool push,
                                          bool pushNight,
                                          bool pushAd,
                                          Action<Result<PubUserLoginInfo>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUserLoginInfo>(action));
            NativeInterface.UserInfoUpdate(identifier,
                                           languageCode,
                                           push,
                                           pushNight,
                                           pushAd);
        }

        public static void Secede(Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.Secede(identifier);
        }

        public static void SecedeCancel(PubLoginType loginType,
                                        Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.SecedeCancel(identifier, loginType);
        }

        public static void ImageBanner(string ratioWidth,
                                       string ratioHeight,
                                       Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.ImageBanner(identifier, ratioWidth, ratioHeight);
        }        

        public static void InAppPurchase(string pid,
                                         string serverId,
                                         string playerId,
                                         string etc,
                                         Action<Result<PubPurchaseData>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubPurchaseData>(action));
            NativeInterface.InAppPurchase(identifier, pid, serverId, playerId, etc);
        }

        public static void VersionCheck(Action<Result<PubVersionInfo>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubVersionInfo>(action));
            NativeInterface.VersionCheck(identifier);
        }

        public static void OpenNotice(Action<Result<PubNotices>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubNotices>(action));
            NativeInterface.OpenNotice(identifier);
        }

        public static void OpenPolicyLink(PubPolicyType policyType,
                                          Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.OpenPolicyLink(identifier, policyType);
        }

        public static void OpenHelpURL(Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.OpenHelpURL(identifier);
        }

        public static void CouponUse(string key,
                                     string serverId,
                                     string playerId,
                                     string etc,
                                     Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.CouponUse(identifier, key, serverId, playerId, etc);
        }

        public static void SyncRemoteConfig(Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.SyncRemoteConfig(identifier);
        }

        public static void Ping(Action<Result<PubUnit>> action)
        {
            var identifier = AddAction(FlattenAction.JsonFlatten<PubUnit>(action));
            NativeInterface.Ping(identifier);
        }

        static string AddAction(FlattenAction action)
        {
            var identifier = Guid.NewGuid().ToString();
            actions.Add(identifier, action);
            return identifier;
        }

        static FlattenAction PopActionFromPayload(CallbackMessageForUnity payload)
        {
            var identifier = payload.Identifier;
            if (identifier == null)
            {
                return null;
            }
            FlattenAction action = null;
            if (actions.TryGetValue(identifier, out action))
            {
                actions.Remove(identifier);
                return action;
            }
            return null;
        }

        static FlattenAction FindActionFromPayload(CallbackMessageForUnity payload)
        {
            var identifier = payload.Identifier;
            if(identifier == null)
            {
                return null;
            }
            FlattenAction action = null;
            if(actions.TryGetValue(identifier, out action))
            {
                return action;
            }
            return null;
        }

        public static void _OnApiOk(string result)
        {
            var payload = CallbackMessageForUnity.FromJson(result);
            var action = PopActionFromPayload(payload);
            if (action != null)
            {
                action.CallOk(payload.Value);
            }
        }

        public static void _OnApiError(string result)
        {
            var payload = CallbackMessageForUnity.FromJson(result);
            var action = PopActionFromPayload(payload);
            if (action != null)
            {
                action.CallError(payload.Value);
            }
        }

        public static void _OnApiUpdate(string result)
        {
            var payload = CallbackMessageForUnity.FromJson(result);
            var action = FindActionFromPayload(payload);
            if(action != null)
            {
                action.CallOk(payload.Value);
            }
        }
    }

}