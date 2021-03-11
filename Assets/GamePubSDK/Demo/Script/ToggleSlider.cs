using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(ToggleSlider))]
public class ToggleSliderEditor : Editor{

    public override void OnInspectorGUI(){
        ToggleSlider ts = target as ToggleSlider;
        ts.state=EditorGUILayout.Toggle("State:",ts.state);
        DrawDefaultInspector();
    }
}

#endif
[RequireComponent(typeof(EventTrigger))]
public class ToggleSlider : MonoBehaviour
{
    public Image sliderImage;
    public Color normalColor = Color.gray;
    public Color toggledColor = Color.green;
    public Image knobImage;
    public float xOffset = 16;
    public float moveTime = 0.25f;
    private float lastMove = 0;
    private bool isMove;
    [SerializeField]
    [HideInInspector]
    private bool _state;
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent OnToggle;
    public bool state
    {
        get { return _state; }
        set { UpdateGraphics(value); _state = value; }
    }
    void Start()
    {
        EventTrigger et = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((BaseEventData data) =>
        {
            state = !_state;
            OnToggle.Invoke(state);
        });
        et.triggers.Add(entry);
    }
    public void UpdateGraphics(bool newVal)
    {
        if (sliderImage != null)
            sliderImage.color = (newVal ? toggledColor : normalColor);
#if UNITY_EDITOR
        //don't bother animating at Edit Time
        if(knobImage!=null)
            knobImage.rectTransform.anchoredPosition=new Vector2((newVal?1:-1)*xOffset,0);
#endif

        isMove = newVal != _state;
        lastMove = Time.time;
    }

    void Update()
    {
        if (isMove)
        {
            float t = (Time.time - lastMove) / moveTime;
            float start = (state ? -1 : 1);
            float end = (state ? 1 : -1);
            knobImage.rectTransform.anchoredPosition = new Vector2(Mathf.SmoothStep(start * xOffset, end * xOffset, t), 0);
            isMove = !(t >= 1f);
        }
    }

#if UNITY_EDITOR
    [MenuItem("GameObject/UI/ToggleSlider",false)]
    static void CreateToggleSlider(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("ToggleSlider");

        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        RectTransform rt;
        Image image;
        rt=go.GetComponent<RectTransform>();
        if(rt==null){
            rt=go.AddComponent<RectTransform>();
        }
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,64);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,32);
        image=go.AddComponent<Image>();
        image.type=Image.Type.Sliced;
        image.raycastTarget=true;
        image.sprite=AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        go.AddComponent<EventTrigger>();

        GameObject goKnob = new GameObject("Knob");
        Image knobImage = goKnob.AddComponent<Image>();
        knobImage.raycastTarget=false;
        knobImage.sprite=AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        knobImage.type=Image.Type.Sliced;
        GameObjectUtility.SetParentAndAlign(goKnob,go);
        rt=goKnob.GetComponent<RectTransform>();
        if(rt==null){
            rt=goKnob.AddComponent<RectTransform>();
        }
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,32);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,32);
        rt.anchoredPosition=new Vector2(-16,0);

        ToggleSlider ts = go.AddComponent<ToggleSlider>();
        ts.sliderImage=image;
        ts.knobImage=knobImage;
        Selection.activeObject = go;
    }
#endif
}