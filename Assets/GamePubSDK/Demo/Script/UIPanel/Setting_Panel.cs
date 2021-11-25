using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePub.PubSDK;

public class Setting_Panel : MonoBehaviour
{
    //public GameObject pushToggle;
    //public GameObject adPushToggle;
    //public GameObject nightPushToggle;

    public ToggleController pushToggle;
    public ToggleController adPushToggle;
    public ToggleController nightPushToggle;

    // Start is called before the first frame update
    public void Start()
    {
        //pushToggle.GetComponent<SliderToggle>().SetToggle(
        //    UserInfoManager.Ins.loginResult.UserLoginInfo.AgreePush);
        //adPushToggle.GetComponent<SliderToggle>().SetToggle(
        //    UserInfoManager.Ins.loginResult.UserLoginInfo.AgreeAd);
        //nightPushToggle.GetComponent<SliderToggle>().SetToggle(
        //    UserInfoManager.Ins.loginResult.UserLoginInfo.AgreeNight);

        pushToggle.isOn = UserInfoManager.Ins.loginResult.UserLoginInfo.AgreePush;
        adPushToggle.isOn = UserInfoManager.Ins.loginResult.UserLoginInfo.AgreeAd;
        nightPushToggle.isOn = UserInfoManager.Ins.loginResult.UserLoginInfo.AgreeNight;
    }

    public void OnPushClick(bool enabled)
    {
        //SliderToggle push = pushToggle.GetComponent<SliderToggle>();
        //push.callback = (bool status) =>
        //{
        //    GamePubSDK.Ins.UserInfoUpdate(
        //    UserInfoManager.Ins.currentCode,
        //    status,
        //    UserInfoManager.Ins.pushNight,
        //    UserInfoManager.Ins.pushAd,
        //    result =>
        //    {
        //        result.Match(
        //            value =>
        //            {

        //                UserInfoManager.Ins.push = value.AgreePush;
        //            },
        //            error =>
        //            {

        //            });
        //    });
        //};
        //push.ChangeToggle();

        Debug.Log("OnPushClick : " + enabled);

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
        //SliderToggle push = adPushToggle.GetComponent<SliderToggle>();
        //push.callback = (bool status) =>
        //{
        //    GamePubSDK.Ins.UserInfoUpdate(
        //    UserInfoManager.Ins.currentCode,
        //    UserInfoManager.Ins.push,
        //    UserInfoManager.Ins.pushNight,
        //    status,
        //    result =>
        //    {
        //        result.Match(
        //            value =>
        //            {                        
        //                UserInfoManager.Ins.pushAd = value.AgreeAd;
        //            },
        //            error =>
        //            {
        //            });
        //    });
        //};
        //push.ChangeToggle();

        Debug.Log("OnAdPushClick : " + enabled);

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
        //SliderToggle push = nightPushToggle.GetComponent<SliderToggle>();
        //push.callback = (bool status) =>
        //{
        //    GamePubSDK.Ins.UserInfoUpdate(
        //    UserInfoManager.Ins.currentCode,
        //    UserInfoManager.Ins.push,
        //    status,
        //    UserInfoManager.Ins.pushAd,
        //    result =>
        //    {
        //        result.Match(
        //            value =>
        //            {                        
        //                UserInfoManager.Ins.pushNight = value.AgreeNight;
        //            },
        //            error =>
        //            {                        
        //            });
        //    });
        //};
        //push.ChangeToggle();

        Debug.Log("OnNightPushClick : " + enabled);

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
