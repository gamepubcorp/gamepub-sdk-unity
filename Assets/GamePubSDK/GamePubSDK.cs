﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePub.PubSDK
{
    public class GamePubSDK : MonoBehaviour
    {
        private static GamePubSDK instance;        

        void Awake()
        {                                    
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);                
            }
            DontDestroyOnLoad(gameObject);            
        }

        public static GamePubSDK Ins
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("GamePubSDK");
                    instance = go.AddComponent<GamePubSDK>();                    
                }
                return instance;
            }            
        }

        private void OnApplicationPause(bool pause)
        {
            if (GetLastLoginType() != PubLoginType.NONE)
            {
                if (pause)
                {
                    Debug.Log("ping stop");
                    StopPing();
                }
                else
                {
                    Debug.Log("ping start");
                    StartPing();
                }
            }
        }

        public void SetupSDK(Action<Result<PubUnit>> action)
        {           
            if (string.IsNullOrEmpty(GamePubSDKSettings.AppID))
            {
                throw new System.Exception("Gamepub SDK AppID is not set.");
            }
            GamePubAPI.SetupSDK(GamePubSDKSettings.AppID, action);
        }

        public void Login(PubLoginType loginType, PubAccountServiceType serviceType, Action<Result<PubLoginResult>> action)
        {            
            GamePubAPI.Login(loginType, serviceType, action);
        }

        public void Logout(Action<Result<PubUnit>> action)
        {            
            GamePubAPI.Logout(action);
            StopPing();
        }

        public void UserInfoUpdate(PubLanguageCode languageCode,
                                   bool push,
                                   bool pushNight,
                                   bool pushAd,
                                   Action<Result<PubUserLoginInfo>> action)
        {
            GamePubAPI.UserInfoUpdate(languageCode, push, pushNight, pushAd, action);
        }

        public void SetAgreePush(bool push,
                                 bool pushNight,
                                 bool pushAd)
        {
            NativeInterface.SetAgreePush(push, pushNight, pushAd);
        }

        public void Secede(Action<Result<PubUnit>> action)
        {
            GamePubAPI.Secede(action);
        }

        public void SecedeCancel(PubLoginType type, Action<Result<PubUnit>> action)
        {
            GamePubAPI.SecedeCancel(type, action);
        }

        private PubAuthenticationState AuthenticationState
        {            
            get
            {
                var result = NativeInterface.GetLoginType();
                if (string.IsNullOrEmpty(result)) { return null; }
                return JsonUtility.FromJson<PubAuthenticationState>(result);
            }
        }

        public PubLoginType GetLastLoginType()
        {
            if (AuthenticationState == null)
                return PubLoginType.NONE;
            return (PubLoginType)AuthenticationState.LoginType;
        }

        public PubInAppListResult GetProductList()
        {            
            var result = NativeInterface.GetProductList();
            if (string.IsNullOrEmpty(result)) { return null; }
            return JsonUtility.FromJson<PubInAppListResult>(result);
        }

        public PubLanguageList GetLanguageList()
        {
            var result = NativeInterface.GetLanguageList();
            if (string.IsNullOrEmpty(result)) { return null; }
            return JsonUtility.FromJson<PubLanguageList>(result);
        }

        public void OpenPolicyLink(PubPolicyType policyType,
                                   Action<Result<PubUnit>> action)
        {
            GamePubAPI.OpenPolicyLink(policyType, action);            
        }

        //public void ImageBanner(string ratioWidth, string ratioHeight, Action<Result<PubUnit>> action)
        //{
        //    GamePubAPI.ImageBanner(ratioWidth, ratioHeight, action);
        //}

        public void GetImageBanner(Action<Result<PubImageBannerList>> action)
        {
            GamePubAPI.GetImageBanner(action);
        }

        public void InAppPurchase(string pid,
                                  string serverId,
                                  string playerId,
                                  string etc,
                                  Action<Result<PubPurchaseData>> action)
        {
            GamePubAPI.InAppPurchase(pid, serverId, playerId, etc, action);
        }

        public void UserRefundListSearch(string accountId,
                                         string loginType,
                                         string channelId,
                                         Action<Result<PubRefundListResult>> action)
        {
            GamePubAPI.UserRefundListSearch(accountId, loginType, channelId, action);
        }

        public void UserRefundRepurchase(string accountId,
                                         string loginType,
                                         string channelId,
                                         string pid,
                                         string serverId,
                                         string playerId,
                                         string etc,
                                         string voidedTid,
                                         Action<Result<PubPurchaseData>> action)
        {
            GamePubAPI.UserRefundRepurchase(
                accountId,
                loginType,
                channelId,
                pid,
                serverId,
                playerId,
                etc,
                voidedTid,
                action);
        }

        public void VersionCheck(Action<Result<PubVersionInfo>> action)
        {
            GamePubAPI.VersionCheck(action);
        }

        public void OpenNotice(Action<Result<PubNotices>> action)
        {
            GamePubAPI.OpenNotice(action);
        }

        public void OpenHelpURL(Action<Result<PubUnit>> action)
        {
            GamePubAPI.OpenHelpURL(action);
        }

        public void CouponUse(string key,
                              string serverId,
                              string playerId,
                              string etc,
                              Action<Result<PubUnit>> action)
        {
            GamePubAPI.CouponUse(key, serverId, playerId, etc, action);
        }

        public void SyncRemoteConfig(Action<Result<PubUnit>> action)
        {
            GamePubAPI.SyncRemoteConfig(action);
        }

        public string GetValue(string key)
        {
            var result = NativeInterface.GetRemoteConfigValue(key);
            if (string.IsNullOrEmpty(result)) { return null; }
            return result;
        }

        public void Ping(Action<Result<PubUnit>> action)
        {
            GamePubAPI.Ping(action);
        }

        public void StartPing()
        {
            NativeInterface.StartPing();
        }

        public void StopPing()
        {
            NativeInterface.StopPing();
        }

        public void OnApiOk(string result)
        {
            Debug.Log("OnApiOk : " + result);
            GamePubAPI._OnApiOk(result);
        }

        public void OnApiError(string result)
        {
            Debug.Log("OnApiError : " + result);
            GamePubAPI._OnApiError(result);
        }

        public void OnApiUpdate(string result)
        {
            Debug.Log("OnApiUpdate : " + result);
            GamePubAPI._OnApiUpdate(result);
        }
    }
}