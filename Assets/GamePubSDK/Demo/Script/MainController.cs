using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GamePub.PubSDK;

public class MainController : MonoBehaviour
{
#if UNITY_ANDROID
    string productID_1 = "gamepub_1000";
    string productID_2 = "gamepub_2000";
#elif UNITY_IOS
    string productID_1 = "com.gamepub.unity.inapp1200";
    string productID_2 = "com.gamepub.unity.inapp2500";    
#endif

    public Image userImage;
    public Text displayNameText;
    //public Text uniqueIdText;
    public Text channelIdText;
    public Text emailText;
    public Text accountIdText;

    public Text rawJsonText;

    //popup
    public Text popupTitleText;
    public Text popupMessageText;

    //coupon
    public InputField input;

    //language setting
    public Dropdown dropdownLang;
    private PubLanguageCode currentCode;

    public GameObject policy_panel;
    public GameObject notice_panel;
    public GameObject versionCheck_panel;
    public GameObject setting_panel;
    public GameObject coupon_panel;
    public GameObject popup_panel;

    public GameObject   pushToggle;
    public GameObject   adPushToggle;
    public GameObject   nightPushToggle;

    string appUrl = "";

    void Awake()
    {
        //GamePubSDK.Ins.Ping(Test);
        GamePubSDK.Ins.PurchaseInit(result =>
        {
            result.Match(
                value =>
                {
                    UserInfoManager.Instance.ProductList = value.InAppProducts;
                    UpdateRawSection(value);
                }, error =>
                 {
                     UpdateRawSection(error);
                 });
        });

        //demo
        //UserInfoManager.Instance.LangList.Add(PubLanguageCode.ko);
        //UserInfoManager.Instance.LangList.Add(PubLanguageCode.en);
        //UserInfoManager.Instance.LangList.Add(PubLanguageCode.ja);
        dropdownLang.captionText.text = "언어설정";
        foreach (PubLanguageCode code in UserInfoManager.Instance.LangList)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = code.ToString();
            dropdownLang.options.Add(option);
        }
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
        PubLoginResult result = UserInfoManager.Instance.loginResult;
        UpdateUserInfo(result);
    }    

    public void OnClickSecede()
    {
        GamePubSDK.Ins.Secede(result =>
        {
            result.Match(
                value =>
                {
                    //UpdateRawSection(value);
                    SceneManager.LoadSceneAsync("Login");
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickGoogleLoginConvert()
    {
        GamePubSDK.Ins.Login(PubLoginType.GOOGLE,
            PubAccountServiceType.ACCOUNT_CONVERSION, result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateUserInfo(value);                        
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                        popupTitleText.text = error.Code.ToString();
                        popupMessageText.text = error.Message.ToString();
                        popup_panel.SetActive(true);
                    });
            });
    }

    public void OnClickFacebookLoginConvert()
    {
        GamePubSDK.Ins.Login(PubLoginType.FACEBOOK,
            PubAccountServiceType.ACCOUNT_CONVERSION, result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateUserInfo(value);
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                        popupTitleText.text = error.Code.ToString();
                        popupMessageText.text = error.Message.ToString();
                        popup_panel.SetActive(true);
                    });
            });
    }

    public void OnClickGoogleLoginLink()
    {
        GamePubSDK.Ins.Login(PubLoginType.GOOGLE,
            PubAccountServiceType.ACCOUNT_LINK, result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateUserInfo(value);
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                        popupTitleText.text = error.Code.ToString();
                        popupMessageText.text = error.Message.ToString();
                        popup_panel.SetActive(true);
                    });
            });
    }

    public void OnClickFacebookLoginLink()
    {
        GamePubSDK.Ins.Login(PubLoginType.FACEBOOK,
            PubAccountServiceType.ACCOUNT_LINK, result =>
            {
                result.Match(
                    value =>
                    {
                        UpdateUserInfo(value);
                    },
                    error =>
                    {
                        UpdateRawSection(error);
                        popupTitleText.text = error.Code.ToString();
                        popupMessageText.text = error.Message.ToString();
                        popup_panel.SetActive(true);
                    });
            });
    }

    public void OnPushClick()
    {
        SliderToggle push = pushToggle.GetComponent<SliderToggle>();
        push.callback = (bool status) =>
        {
            //push.SetToggle(!status);
            Debug.Log(status);
        };
        push.ChangeToggle();
    }

    public void OnAdPushClick()
    {
        SliderToggle push = adPushToggle.GetComponent<SliderToggle>();
        push.callback = (bool status) =>
        {
            Debug.Log(status);
        };
        push.ChangeToggle();
    }

    public void OnNightPushClick()
    {
        SliderToggle push = nightPushToggle.GetComponent<SliderToggle>();
        push.callback = (bool status) =>
        {
            Debug.Log(status);
        };
        push.ChangeToggle();
    }

    public void SelectedLangBtn(int index)
    {
        
        switch (index)
        {
            case 0:
                {
                    currentCode = UserInfoManager.Instance.LangList[0];
                    
                }
                break;
            case 1:
                {
                    currentCode = UserInfoManager.Instance.LangList[1];
                    
                }
                break;
            case 2:
                {
                    currentCode = UserInfoManager.Instance.LangList[2];
                    
                }
                break;
        }
    }

    public void UserInfoUpdate()
    {
        GamePubSDK.Ins.UserInfoUpdate(
            currentCode.ToString(),
            false,
            false,
            false,
            result =>
            {
                result.Match(
                    value =>
                    {
                        //value.AccountId
                    },
                    error =>
                    {
                        //error.Message
                    });
            });
    }

    public void OnClickLogout()
    {
        GamePubSDK.Ins.Logout(PubLoginType.GOOGLE, result =>
        {
            result.Match(
                value =>
                {
                    //UpdateRawSection(value);
                    SceneManager.LoadSceneAsync("Login");
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
        GamePubSDK.Ins.InAppPurchase(productID_1, "11", "22", "aa", result =>
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
            productID_2,
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
        versionCheck_panel.gameObject.SetActive(true);
        Application.OpenURL(appUrl);
    }

    public void OnClickOpenNotice()
    {
        notice_panel.SetActive(true);        
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
        setting_panel.SetActive(true);
    }

    public void OnClickCloseSettingPanel()
    {
        setting_panel.SetActive(false);
    }

    public void OnClickOpenCoupon()
    {
        coupon_panel.SetActive(true);
    }

    public void OnClickCouponUse()
    {
        Debug.Log(input.text);
        coupon_panel.SetActive(false);

        string key = input.text;
        string server_id = "1";
        string player_id = "5dd5326c63d62c74a05787d0";
        string etc = "a=b=c";

        GamePubSDK.Ins.CouponUse(key, server_id, player_id, etc, result =>
        {
            result.Match(value =>
            {
                UpdateRawSection(value);
            }, error =>
            {
                UpdateRawSection(error);
            });
        });
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

    public void UpdateUserInfo(PubLoginResult result)
    {
        if (result != null)
        {
            UpdateRawSection(result);
            if (result.ResponseCode == (int)PubApiResponseCode.SUCCESS)
            {
                if (result.UserLoginInfo.Status == (int)PubAccountStatus.B)
                {
                    popupMessageText.text = result.UserLoginInfo.BlockMessage;
                    popup_panel.SetActive(true);
                }
                else if (result.UserLoginInfo.Status == (int)PubAccountStatus.U)
                {
                    displayNameText.text = result.UserProfile.DisplayName;                    
                    channelIdText.text = result.UserProfile.ChannelId;
                    emailText.text = result.UserProfile.Email;

                    accountIdText.text = result.UserLoginInfo.AccountID;
                }
                else if (result.UserLoginInfo.Status == (int)PubAccountStatus.S)
                {
                    //탈퇴처리.
                    rawJsonText.text += "탈퇴된 계정입니다.";
                }
            }
            else if (result.ResponseCode == (int)PubApiResponseCode.SERVICE_MAINTENANCE)
            {
                popupMessageText.text = result.Maintenance.Message;
                popup_panel.SetActive(true);
            }            
        }
    }
}
