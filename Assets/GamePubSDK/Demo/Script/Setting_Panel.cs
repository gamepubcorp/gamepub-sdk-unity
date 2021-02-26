using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePub.PubSDK;

public class Setting_Panel : MonoBehaviour
{
    public Dropdown dropdown;
    public Toggle push;
    public Toggle pushNight;
    public Toggle pushAd;

    public List<PubLanguageCode> langList = new List<PubLanguageCode>();

    private PubLanguageCode currentCode;
    
    void Start()
    {
        langList = GamePubSDK.Ins.LangList;
        dropdown.captionText.text = "언어설정";

        foreach(PubLanguageCode code in langList)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = code.ToString();
            dropdown.options.Add(option);
        }
    }

    public void SelectedBtn(int index)
    {
        Debug.Log(index);

        switch(index)
        {
            case 0:
                {
                    currentCode = langList[0];
                }
                break;
            case 1:
                {
                    currentCode = langList[1];
                }
                break;
            case 2:
                {
                    currentCode = langList[2];
                }
                break;
        }        
    }

    public void OnClickClose()
    {
        GamePubSDK.Ins.UserInfoUpdate(
            currentCode.ToString(),
            push.isOn,
            pushNight.isOn,
            pushAd.isOn,
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

        gameObject.SetActive(false);
    }
}
