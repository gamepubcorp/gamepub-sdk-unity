using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePub.PubSDK;

public class UserInfoManager : Singleton<UserInfoManager>
{
    public PubLoginResult loginResult = null;    
    public PubInAppProduct[] ProductList { get; set; }
    public List<PubLanguageCode> LangList = new List<PubLanguageCode>();

    public string temp = "test msg";

    private void Awake()
    {
        Debug.Log("UserInfoManager::Awake");
    }
}
