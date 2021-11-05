using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GamePub.PubSDK;

public class LoginController : MonoBehaviour
{
    public Text messageText;
    public GameObject popup_panel;

    public GameObject content;
    public GameObject autoLogin;
    public GameObject policy_panel;
    public GameObject recovery_panel;    

    private void Awake()
    {       
        GamePubSDK.Ins.SetupSDK(result =>
        {
            result.Match(
                value =>
                {
                    //value.Code = 0
                    //value.Msg = "setupSDK Success"
                },
                error =>
                {
                    messageText.text = error.Message;
                    if (error.Code == (int)PubErrorCode.NETWORK)
                    {
                        messageText.text = "네트워크 연결을 확인해주세요.";
                    }
                    popup_panel.SetActive(true);
                });
        });
    }

    private void Start()
    {
        //자동로그인 활성화 설정
        if (GamePubSDK.Ins.GetLastLoginType() != PubLoginType.NONE)
        {
            content.SetActive(false);
            autoLogin.SetActive(true);
        }
        else
        {
            content.SetActive(true);
            autoLogin.SetActive(false);
        }

    }

    public void OnClickAutoLogin()
    {
        if (GamePubSDK.Ins.GetLastLoginType() != PubLoginType.NONE)
        {
            GamePubSDK.Ins.Login(GamePubSDK.Ins.GetLastLoginType(),
            PubAccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Ins.loginResult = value;
                        UpdateLoginResult(value);
                    },
                    error =>
                    {
                        messageText.text = error.Message;
                        popup_panel.SetActive(true);
                    });
            });
        }
    }

    public void OnClickGoogleLogin()
    {
        GamePubSDK.Ins.Login(PubLoginType.GOOGLE,
            PubAccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Ins.loginResult = value;
                        UpdateLoginResult(value);
                    },
                    error =>
                    {
                        messageText.text = error.Message;
                        popup_panel.SetActive(true);
                    });
            });
    }

    public void OnClickFacebookLogin()
    {
        GamePubSDK.Ins.Login(PubLoginType.FACEBOOK,
            PubAccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value => {
                        UserInfoManager.Ins.loginResult = value;
                        UpdateLoginResult(value);
                    },
                    error => {
                        messageText.text = error.Message;
                        popup_panel.SetActive(true);
                    });
            });
    }

    public void OnClickGuestLogin()
    {
        GamePubSDK.Ins.Login(PubLoginType.GUEST,
            PubAccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value => {
                        UserInfoManager.Ins.loginResult = value;
                        UpdateLoginResult(value);
                    },
                    error => {
                        messageText.text = error.Message;
                        popup_panel.SetActive(true);
                    });
            }); 
    }

    public void OnClickAppleLogin()
    {
        GamePubSDK.Ins.Login(PubLoginType.APPLE,
            PubAccountServiceType.ACCOUNT_LOGIN, result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Ins.loginResult = value;
                        UpdateLoginResult(value);
                    },
                    error =>
                    {                        
                        messageText.text = error.Message;
                        popup_panel.SetActive(true);
                    });
            });
    }

    public void OnClickClosePopup()
    {
        popup_panel.SetActive(false);        
    }

    public void OnClickRecoveryConfirm()
    {
        GamePubSDK.Ins.SecedeCancel(result =>
        {
            result.Match(
                value =>
                {
                    Debug.Log(value.Msg);
                },
                error =>
                {
                    Debug.Log(error.Message);
                });
        });
        recovery_panel.SetActive(false);
    }

    public void OnClickRecoveryClose()
    {
        GamePubSDK.Ins.Logout(result =>
        {
            result.Match(
                value =>
                {
                    Debug.Log(value.Msg);
                },
                error =>
                {
                    Debug.Log(error.Message);
                });
        });
        recovery_panel.SetActive(false);
    }

    public void OnPushCheck(bool bCheck)
    {
        UserInfoManager.Ins.push = bCheck;
    }

    public void OnPushNightCheck(bool bCheck)
    {
        UserInfoManager.Ins.pushNight = bCheck;
    }

    public void OnPushAdCheck(bool bCheck)
    {
        UserInfoManager.Ins.pushAd = bCheck;
    }

    public void OnClickOpenPrivacy()
    {
        GamePubSDK.Ins.OpenPolicyLink(PubPolicyType.PRIVACY, result =>
        {
            result.Match(
                value =>
                {                    
                },
                error =>
                {                    
                });
        });
    }

    public void OnClickOpenService()
    {
        GamePubSDK.Ins.OpenPolicyLink(PubPolicyType.SERVICE, result =>
        {
            result.Match(
                value =>
                {
                },
                error =>
                {                    
                });
        });
    }

    public void OnClickOpenPolicyPanel()
    {
        policy_panel.SetActive(true);
    }

    public void OnClickClosePolicyPanel()
    {        
        GamePubSDK.Ins.SetTermsOfServiceAgreePush(UserInfoManager.Ins.push,
                                                  UserInfoManager.Ins.pushNight,
                                                  UserInfoManager.Ins.pushAd);
        policy_panel.SetActive(false);
    }

    public void UpdateLoginResult(PubLoginResult result)
    {
        if (result != null)
        {            
            if (result.ResponseCode == (int)PubResponseCode.SUCCESS)
            {
                if (result.UserLoginInfo.Status == (int)PubAccountStatus.B)
                {
                    messageText.text = result.UserLoginInfo.BlockMessage;
                    popup_panel.SetActive(true);                    
                }
                else if (result.UserLoginInfo.Status == (int)PubAccountStatus.U)
                {
                    SceneManager.LoadSceneAsync("Main");
                }
                else if (result.UserLoginInfo.Status == (int)PubAccountStatus.S)
                {                    
                    recovery_panel.SetActive(true);
                }
            }
            else if (result.ResponseCode == (int)PubResponseCode.SERVICE_MAINTENANCE)
            {
                messageText.text = result.Maintenance.Message;
                popup_panel.SetActive(true);
            }
        }
    }
}
