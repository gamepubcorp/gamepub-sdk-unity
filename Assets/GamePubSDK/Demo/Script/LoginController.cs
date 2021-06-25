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
                    popup_panel.SetActive(true);
                });
        });
    }

    private void Start()
    {
        //자동로그인 활성화 설정
        if (GamePubSDK.Ins.GetActiveLoginType() != PubLoginType.NONE)
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
        if (GamePubSDK.Ins.GetActiveLoginType() != PubLoginType.NONE)
        {
            GamePubSDK.Ins.Login(GamePubSDK.Ins.GetActiveLoginType(),
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

    public void UpdateLoginResult(PubLoginResult result)
    {
        if (result != null)
        {            
            if (result.ResponseCode == (int)PubApiResponseCode.SUCCESS)
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
                    messageText.text = "탈퇴된 계정입니다.";
                    popup_panel.SetActive(true);
                }
            }
            else if (result.ResponseCode == (int)PubApiResponseCode.SERVICE_MAINTENANCE)
            {
                messageText.text = result.Maintenance.Message;
                popup_panel.SetActive(true);
            }
            else if (result.ResponseCode == (int)PubApiResponseCode.USER_IP_BLOCK)
            {
                messageText.text = "IP Block";
                popup_panel.SetActive(true);
            }
        }
    }
}
