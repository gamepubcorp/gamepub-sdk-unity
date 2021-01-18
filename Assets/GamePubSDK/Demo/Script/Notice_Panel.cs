using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePub.PubSDK;

[System.Serializable]
public class Notices
{
    public Text title = null;
    public Text contents = null;
    public Notices(string _title, string _content)
    {
        title.text = _title;
        contents.text = _content;
    }
}

public class Notice_Panel : MonoBehaviour
{
    
    [SerializeField]
    public List<Notices> notices;
    public GameObject[] toggleObj;

    // Start is called before the first frame update
    void Start()
    {       

        GamePubSDK.Ins.OpenNotice(result =>
        {
            result.Match(
                value =>
                {
                    //foreach (PubNoticeData data in value.NoticeList)
                    for(int i=0; i<value.NoticeList.Length; i++)
                    {                        
                        toggleObj[i].SetActive(true);
                        notices[i].title.text = value.NoticeList[i].Title;
                        notices[i].contents.text = value.NoticeList[i].Contents;
                    }
                },
                error =>
                {
                    
                });
        });
    }    

    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }    
}
