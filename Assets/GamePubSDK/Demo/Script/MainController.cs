using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePub.PubSDK;

public class MainController : MonoBehaviour
{
    public Image userImage;
    public Text displayNameText;
    public Text uniqueIdText;
    public Text channelIdText;
    public Text emailText;

    public Text rawJsonText;
    public Text messageText;

    public GameObject policy_panel;
    public GameObject notice_panel;
    public GameObject versionCheck_panel;
    public Setting_Panel setting_panel;
    public GameObject coupon_panel;
    public GameObject popup_panel;

    string appUrl = "";

    void Awake()
    {
        //GamePubSDK.Ins.Ping(Test);
    }    

    private void Test(Result<PubUnit> result)
    {
        result.Match(
            value =>
            {
                UpdateRawSection(value);
                switch(value.Code)
                {
                    case 207:
                        {
                            break;
                        }
                    case 412:
                        {
                            break;
                        }
                    case 423:
                        {
                            break;
                        }
                    case 503:
                        {
                            break;
                        }
                }
            }, error =>
            {
                UpdateRawSection(error);
            });
    }

    void Start()
    {        
        //if (GamePubSDK.Ins.GetActiveLoginType() != PubLoginType.NONE)
        //{
        //    GamePubSDK.Ins.AutoLogin(autoLogin =>
        //    {
        //        autoLogin.Match(
        //            autoLoginValue =>
        //            {
        //                UpdateRawSection(autoLoginValue);                        
        //            },
        //            error =>
        //            {
        //                UpdateRawSection(error);
        //            });
        //    });
        //}
    }

    public void OnClickGoogleLogin()
    {
        GamePubSDK.Ins.Login(PubLoginType.GOOGLE,
            PubAccountServiceType.ACCOUNT_LOGIN, result =>
        {            
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                    if(value.ResponseCode == (int)PubApiResponseCode.SUCCESS)
                    {                        
                        if(value.UserLoginInfo.Status == (int)PubAccountStatus.B)
                        {
                            messageText.text = value.UserLoginInfo.BlockMessage;
                            popup_panel.SetActive(true);
                        }else if(value.UserLoginInfo.Status == (int)PubAccountStatus.U)
                        {
                            displayNameText.text = value.UserProfile.DisplayName;
                            uniqueIdText.text = value.UserProfile.UniqueId;
                            channelIdText.text = value.UserProfile.ChannelId;
                            emailText.text = value.UserProfile.Email;                            
                        }
                        else if(value.UserLoginInfo.Status == (int)PubAccountStatus.S)
                        {
                            //탈퇴처리.
                            rawJsonText.text += "탈퇴된 계정입니다.";
                        }
                    }
                    else if(value.ResponseCode == (int)PubApiResponseCode.SERVICE_MAINTENANCE)
                    {
                        messageText.text = value.Maintenance.Message;
                        popup_panel.SetActive(true);
                    }
                },
                error =>
                {
                    UpdateRawSection(error);
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
                    UpdateRawSection(value);
                    displayNameText.text = value.UserProfile.DisplayName;
                    uniqueIdText.text = value.UserProfile.UniqueId;
                    channelIdText.text = value.UserProfile.ChannelId;
                    emailText.text = value.UserProfile.Email;
                },
                error => {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickGuestLogin()
    {
        GamePubSDK.Ins.Login(PubLoginType.GUEST,
            PubAccountServiceType.NONE, result =>
        {
            result.Match(
                value => {
                    UpdateRawSection(value);
                    displayNameText.text = value.UserProfile.DisplayName;
                    uniqueIdText.text = value.UserProfile.UniqueId;
                    channelIdText.text = value.UserProfile.ChannelId;
                    emailText.text = value.UserProfile.Email;
                },
                error => {
                    UpdateRawSection(error);
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
                        UpdateRawSection(value);
                        displayNameText.text = value.UserProfile.DisplayName;
                        uniqueIdText.text = value.UserProfile.UniqueId;
                        channelIdText.text = value.UserProfile.ChannelId;
                        emailText.text = value.UserProfile.Email;
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                    });
            });
    }

    public void OnClickLogout()
    {
        GamePubSDK.Ins.Logout(GamePubSDK.Ins.GetActiveLoginType(), result =>
        {
            result.Match(
                value =>
                {                    
                    UpdateRawSection(value);                    
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickOpenPolicyPanel()
    {
        policy_panel.SetActive(true);
    }

    public void OnClickClosePolicyPanel()
    {
        policy_panel.SetActive(false);
    }

    public void OnClickOpenPrivacy()
    {
        GamePubSDK.Ins.OpenPolicyLink(PubPolicyType.PRIVACY);
    }    

    public void OnClickOpenService()
    {
        GamePubSDK.Ins.OpenPolicyLink(PubPolicyType.SERVICE);
    }

    public void OnClickImageBanner()
    {
        GamePubSDK.Ins.ImageBanner("9", "16", result =>
        {
            result.Match(
                value =>
                {
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickInPurchase1000()
    {
        GamePubSDK.Ins.InAppPurchase("gamepub_1000", "11", "22", "aa", result =>
        {
            result.Match(
                value => {
                    //value.IntDate
                    //value.PlayerId
                    //value.ProductId
                    //value.ServerId
                    //value.Status
                    UpdateRawSection(value);
                },
                error => {
                    //error.Code
                    //error.Message
                    UpdateRawSection(error);
                });
        });        
    }

    public void OnClickInPurchase2000()
    {
        GamePubSDK.Ins.InAppPurchase(
            "gamepub_2000",
            "serverId",
            "playerId",
            "etc",
            result =>
        {
            result.Match(
                value => {
                    UpdateRawSection(value);
                },
                error => {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickVersionCheck()
    {
        Application.OpenURL(appUrl);
    }

    public void OnClickOpenNotice()
    {
        notice_panel.SetActive(true);
        //GamePubSDK.Instance.OpenNotice(result =>
        //{
        //    result.Match(
        //        value =>
        //        {
        //            UpdateRawSection(value);
        //        },
        //        error =>
        //        {
        //            UpdateRawSection(error);
        //        });
        //});
    }

    public void OnClickOpenServiceCenter()
    {
        GamePubSDK.Ins.OpenHelpURL(result =>
        {
            result.Match(
                value => {
                    UpdateRawSection(value);                    
                },
                error => {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickOpenVersionCheck()
    {        
        GamePubSDK.Ins.VersionCheck(result =>
        {
            result.Match(
                value =>
                {
                    if (value.IsUpdate == 1)
                    {
                        versionCheck_panel.gameObject.SetActive(true);
                        appUrl = value.Link;
                    }
                    UpdateRawSection(value);
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickOpenSettingPanel()
    {
        setting_panel.gameObject.SetActive(true);
    }

    public void OnClickOpenCoupon()
    {
        coupon_panel.SetActive(true);
    }

    public void OnClickCloseMaintenance()
    {
        popup_panel.SetActive(false);
    }    

    public void UpdateRawSection(object obj)
    {
        if (obj == null)
        {
            rawJsonText.text = "null";
            return;
        }
        var text = JsonUtility.ToJson(obj);
        if (text == null)
        {
            rawJsonText.text = "Invalid Object";
            return;
        }
        rawJsonText.text = text + "\n\n" +rawJsonText.text;
        var scrollContentTransform = (RectTransform)rawJsonText.gameObject.transform.parent;
        scrollContentTransform.localPosition = Vector3.zero;
    }
}
