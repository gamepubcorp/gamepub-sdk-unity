using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePub.PubSDK;

public class Coupon_Panel : MonoBehaviour
{
    public InputField input;    

    public void OnClickCouponUse()
    {
        Debug.Log(input.text);
        gameObject.SetActive(false);

        string key = input.text;
        string server_id = "1";
        string player_id = "5dd5326c63d62c74a05787d0";
        string etc = "a=b=c";

        GamePubSDK.Ins.CouponUse(key, server_id, player_id, etc, result =>
        {
            result.Match(value =>
            {
                Debug.Log(value.Code);
                Debug.Log(value.Msg);
            }, error =>
            {
                Debug.Log(error.Message);
            });
        });
    }
}
