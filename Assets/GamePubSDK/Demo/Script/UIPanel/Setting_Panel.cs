using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePub.PubSDK;

public class Setting_Panel : MonoBehaviour
{    
    public ToggleController pushToggle;
    public ToggleController adPushToggle;
    public ToggleController nightPushToggle;

    // Start is called before the first frame update
    public void Start()
    {        
        pushToggle.isOn = UserInfoManager.Ins.loginResult.UserLoginInfo.AgreePush;
        adPushToggle.isOn = UserInfoManager.Ins.loginResult.UserLoginInfo.AgreeAd;
        nightPushToggle.isOn = UserInfoManager.Ins.loginResult.UserLoginInfo.AgreeNight;
    }

    public void OnPushClick(bool enabled)
    {
        GamePubSDK.Ins.UserInfoUpdate(
            UserInfoManager.Ins.currentCode,
            enabled,
            UserInfoManager.Ins.pushNight,
            UserInfoManager.Ins.pushAd,
            result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Ins.push = value.AgreePush;
                    },
                    error =>
                    {

                    });
            });
    }

    public void OnAdPushClick(bool enabled)
    {
        GamePubSDK.Ins.UserInfoUpdate(
            UserInfoManager.Ins.currentCode,
            UserInfoManager.Ins.push,
            UserInfoManager.Ins.pushNight,
            enabled,
            result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Ins.pushAd = value.AgreeAd;
                    },
                    error =>
                    {

                    });
            });
    }

    public void OnNightPushClick(bool enabled)
    {
        GamePubSDK.Ins.UserInfoUpdate(
            UserInfoManager.Ins.currentCode,
            UserInfoManager.Ins.push,
            enabled,
            UserInfoManager.Ins.pushAd,
            result =>
            {
                result.Match(
                    value =>
                    {
                        UserInfoManager.Ins.pushNight = value.AgreeNight;
                    },
                    error =>
                    {

                    });
            });
    }
}
