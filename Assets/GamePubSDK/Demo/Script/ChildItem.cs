using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChildItem : RecyclingListViewItem {
    public Text leftText;
    public Text rightText;   

    public Button confirmBtn;

    private ChildData childData;
    public ChildData ChildData {
        get { return childData; }
        set {
            childData = value;
            leftText.text = childData.Title;
            rightText.text = childData.Note;
            //rightText2.text = childData.Note2;
        }
    }

    private void Awake()
    {
        EventListener();
    }

    void EventListener()
    {
        confirmBtn.onClick.AddListener(OnConfirmBtn);
    }

    void OnConfirmBtn()
    {
        Debug.Log(leftText.text + " - "+ rightText.text);
    }
}
