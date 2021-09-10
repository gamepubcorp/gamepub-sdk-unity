using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePub.PubSDK;

public class Setting_Panel : MonoBehaviour
{
    public GameObject pushToggle;
    public GameObject adPushToggle;
    public GameObject nightPushToggle;

    // Start is called before the first frame update
    void Start()
    {
        pushToggle.GetComponent<SliderToggle>().SetToggle(
            UserInfoManager.Ins.loginResult.UserLoginInfo.AgreePush);
        adPushToggle.GetComponent<SliderToggle>().SetToggle(
            UserInfoManager.Ins.loginResult.UserLoginInfo.AgreeAd);
        nightPushToggle.GetComponent<SliderToggle>().SetToggle(
            UserInfoManager.Ins.loginResult.UserLoginInfo.AgreeNight);
    }    

    public void OnPushClick()
    {
        SliderToggle push = pushToggle.GetComponent<SliderToggle>();
        push.callback = (bool status) =>
        {
            GamePubSDK.Ins.UserInfoUpdate(
            UserInfoManager.Ins.currentCode,
            status,
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
        };
        push.ChangeToggle();
    }

    public void OnAdPushClick()
    {
        SliderToggle push = adPushToggle.GetComponent<SliderToggle>();
        push.callback = (bool status) =>
        {
            GamePubSDK.Ins.UserInfoUpdate(
            UserInfoManager.Ins.currentCode,
            UserInfoManager.Ins.push,
            UserInfoManager.Ins.pushNight,
            status,
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
        };
        push.ChangeToggle();
    }

    public void OnNightPushClick()
    {
        SliderToggle push = nightPushToggle.GetComponent<SliderToggle>();
        push.callback = (bool status) =>
        {
            GamePubSDK.Ins.UserInfoUpdate(
            UserInfoManager.Ins.currentCode,
            UserInfoManager.Ins.push,
            status,
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
        };
        push.ChangeToggle();
    }
}
