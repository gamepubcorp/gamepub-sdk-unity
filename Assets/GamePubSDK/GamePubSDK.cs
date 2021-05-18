using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePub.PubSDK
{
    public class GamePubSDK : MonoBehaviour
    {
        static GamePubSDK instance;

        private bool isSetup = false;
        private bool isPaused;        

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
            SetupSDK();

            Debug.Log("GamePubSDK::Awake");
        }

        private void OnApplicationPause(bool pause)
        {
            //초기화체크, 로그인체크
            if (isSetup)
            {
                if (pause)
                {
                    isPaused = true;
                    Debug.Log("stop");
                    StopPing();
                }
                else
                {
                    if (isPaused)
                    {
                        isPaused = false;
                        Debug.Log("start");
                        StartPing();
                    }
                }
            }
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

        private void SetupSDK()
        {
            Debug.LogError("isSetup = " + isSetup);            
            PubLanguageCode langCode;

            GamePubAPI.SetupSDK(result =>
            {
                result.Match(
                    value =>
                    {                        
                        foreach (string strLang in value.LangList)
                        {
                            Enum.TryParse(strLang, out langCode);
                            UserInfoManager.Instance.LangList.Add(langCode);
                        }
                        isSetup = true;
                    },
                    error =>
                    {
                        Debug.LogError("code = " + error.Code + ", msg = " + error.Message);
                    });
            });
        }

        public void Login(PubLoginType loginType, PubAccountServiceType serviceType, Action<Result<PubLoginResult>> action)
        {
            //this.loginType = loginType;
            GamePubAPI.Login(loginType, serviceType, action);
        }

        public void Logout(Action<Result<PubUnit>> action)
        {            
            GamePubAPI.Logout(action);
            StopPing();
        }

        public void UserInfoUpdate(string languageCode,
                                   bool push,
                                   bool pushNight,
                                   bool pushAd,
                                   Action<Result<PubUserLoginInfo>> action)
        {
            GamePubAPI.UserInfoUpdate(languageCode, push, pushNight, pushAd, action);
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
                var result = NativeInterface.AuthenticationState();
                if (string.IsNullOrEmpty(result)) { return null; }
                return JsonUtility.FromJson<PubAuthenticationState>(result);
            }
        }

        public PubLoginType GetActiveLoginType()
        {
            if (AuthenticationState == null)
                return PubLoginType.NONE;
            return (PubLoginType)AuthenticationState.LoginType;
        }

        public void OpenPolicyLink(PubPolicyType policyType)
        {
            NativeInterface.OpenPolicyLink(Guid.NewGuid().ToString(), policyType);
        }

        public void ImageBanner(string ratioWidth, string ratioHeight, Action<Result<PubUnit>> action)
        {
            GamePubAPI.ImageBanner(ratioWidth, ratioHeight, action);
        }

        public void PurchaseInit(Action<Result<PubInAppListResult>> action)
        {
            GamePubAPI.PurchaseInit(action);
        }

        public void InAppPurchase(string pid,
                                  string serverId,
                                  string playerId,
                                  string etc,
                                  Action<Result<PubPurchaseData>> action)
        {
            GamePubAPI.InAppPurchase(pid, serverId, playerId, etc, action);
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