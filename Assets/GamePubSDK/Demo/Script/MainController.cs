using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using GamePub.PubSDK;

public class MainController : MonoBehaviour
{
#if UNITY_ANDROID || UNITY_EDITOR
    string productID_1 = "gamepub_1000";
    string productID_2 = "com.gamepub.test2000";
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
    
    public GameObject notice_panel;
    public GameObject versionCheck_panel;
    public GameObject setting_panel;
    public GameObject coupon_panel;
    public GameObject popup_panel;
    public ImageBanner_Panel img_banner_panel;    

    string appUrl = "";

    void Awake()
    {
        //Ping 설정
        GamePubSDK.Ins.Ping(PingListener);

        //언어설정        
        foreach (PubLanguageCode langCode in GamePubSDK.Ins.GetLanguageList().LangList)
        {
            //Enum.TryParse(strLang, out langCode);
            UserInfoManager.Ins.LangList.Add(langCode);
        }
        dropdownLang.captionText.text = "언어설정";
        foreach (PubLanguageCode code in UserInfoManager.Ins.LangList)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = code.ToString();
            dropdownLang.options.Add(option);
        }
    }

    private void PingListener(Result<PubUnit> result)
    {        
        result.Match(
            value =>
            {
                UpdateRawSection(value);
                switch(value.Code)
                {
                    case (int)PubMessageCode.MultiStatus:
                        {
                            break;
                        }
                    case (int)PubMessageCode.Forbidden:
                        {
                            break;
                        }
                    case (int)PubMessageCode.PRECONDITION_FAILED:
                        {
                            break;
                        }
                    case (int)PubMessageCode.Locked:
                        {
                            break;
                        }
                    case (int)PubMessageCode.SERVICE_UNAVAILABLE:
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
        PubLoginResult loginResult = UserInfoManager.Ins.loginResult;
        UpdateUserInfo(loginResult);

        //결제초기화
        GamePubSDK.Ins.InitBilling(result =>
        {
            result.Match(
                value =>
                {
                    UserInfoManager.Ins.ProductList = value.InAppProducts;

                    for (int i = 0; i < value.InAppProducts.Length; i++)
                    {
                        UpdateRawSection(value.InAppProducts[i]);
                    }
                },error =>
                {
                    UpdateRawSection(error);
                });
        });               

        //이미지배너 설정
        GamePubSDK.Ins.GetImageBanner(result =>
        {
            result.Match(
                value =>
                {
                    if (value.ImgBannerList != null && value.ImgBannerList.Length != 0)
                    {
                        for (int i = 0; i < value.ImgBannerList.Length; i++)
                        {
                            UpdateRawSection(value.ImgBannerList[i]);
                            img_banner_panel.imgSlider.Banners.Add(new Banner(value.ImgBannerList[i].Images));
                        }
                        img_banner_panel.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("ImgBannerList is NULL");
                    }
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });        
    }

    public void OnClickRestorePurchases()
    {
        //소비되지 않은 결제건에 대하여 처리후 결제정보리스트 리턴)
        GamePubSDK.Ins.RestorePurchases(result =>
        {
            result.Match(
                value =>
                {
                    if(value.PurchaseResultList != null)
                    {
                        foreach (PubPurchaseData data in value.PurchaseResultList)
                        {
                            UpdateRawSection(data);
                        }
                    }
                    else
                    {
                        Debug.Log("PurchaseResultList is NULL");
                    }                    
                },
                error =>
                {
                    UpdateRawSection(error);
                });
        });
    }

    public void OnClickSecede()
    {        
        GamePubSDK.Ins.Secede(result =>
        {
            result.Match(
                value =>
                {
                    //UpdateRawSection(value);
                    GamePubSDK.Ins.Logout(response =>
                    {
                        response.Match(
                            success =>
                            {
                                SceneManager.LoadSceneAsync("Login");
                            },
                            failed =>
                            {
                                UpdateRawSection(failed);
                            });
                    });                    
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

    public void OnClickAppleLoginConvert()
    {
        GamePubSDK.Ins.Login(PubLoginType.APPLE,
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

    public void OnClickAppleLoginLink()
    {
        GamePubSDK.Ins.Login(PubLoginType.APPLE,
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

    public void SelectedLangBtn(int index)
    {
        UserInfoManager.Ins.currentCode = UserInfoManager.Ins.LangList[index];
        GamePubSDK.Ins.UserInfoUpdate(
            UserInfoManager.Ins.currentCode,
            UserInfoManager.Ins.push,
            UserInfoManager.Ins.pushNight,
            UserInfoManager.Ins.pushAd,
            result =>
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

    public void OnClickLogout()
    {        
        GamePubSDK.Ins.Logout(result =>
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

    public void OnClickQuit()
    {
        Application.Quit();
    }    

    public void OnClickImageBannerClose()
    {
        img_banner_panel.gameObject.SetActive(false);
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
                    Debug.Log(value.Price);
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

    public void OnClickRemoteConfig()
    {
        GamePubSDK.Ins.SyncRemoteConfig(result =>
        {
            result.Match(value =>
            {
                UpdateRawSection(value);

                var strValue = GamePubSDK.Ins.GetValue("server");
                Debug.Log(strValue);
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
            if (result.ResponseCode == (int)PubResponseCode.SUCCESS)
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
                    StartCoroutine(UpdateProfile(result.UserProfile.PhotoURL));
                }
                else if (result.UserLoginInfo.Status == (int)PubAccountStatus.S)
                {
                    //탈퇴처리.
                    rawJsonText.text += "탈퇴된 계정입니다.";
                }
            }
            else if (result.ResponseCode == (int)PubResponseCode.SERVICE_MAINTENANCE)
            {
                popupMessageText.text = result.Maintenance.Message;
                popup_panel.SetActive(true);
            }
            else if (result.ResponseCode == (int)PubResponseCode.USER_IP_BLOCK)
            {
                popupMessageText.text = "IP Block";
                popup_panel.SetActive(true);
            }
        }
    }

    IEnumerator UpdateProfile(string url)
    {        
        if (url != null)
        {
            var www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                var texture = DownloadHandlerTexture.GetContent(www);
                userImage.color = Color.white;
                userImage.sprite = Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0, 0));
            }
        }
        else
        {
            yield return null;
        }        
    }
}
