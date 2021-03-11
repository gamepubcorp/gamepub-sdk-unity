using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderToggle : MonoBehaviour
{
    public delegate void ToggleCallback(bool enable);

    private bool _isToggleOn = false;
    public bool isToggleOn
    {
        get
        {
            return _isToggleOn;
        }
    }

    private bool _isPressed = false;
    public bool isPressed
    {
        get
        {
            return _isPressed;
        }
        set
        {
            _isPressed = value;
        }
    }

    private Slider slider;

    public ToggleCallback callback;


    public void Awake()
    {
        slider = this.GetComponent<Slider>();
    }


    private void Update()
    {
        if (_isPressed)
        {
            if (slider.value > 0.9f)
            {
                slider.value = 0.9f;
                StopCoroutine("TurnOnToggle");
                callback(_isToggleOn);
                LockToggle(false);
                return;
            }

            if (slider.value < 0.1f)
            {
                slider.value = 0.1f;
                StopCoroutine("TurnOffToggle");
                callback(_isToggleOn);
                LockToggle(false);
                return;
            }
        }
    }


    public void ChangeToggle()
    {
        if (!_isPressed)
        {
            LockToggle(true);

            //현 상태(on/off) 확인하고, 슬라이더 핸들위치 set -> 애니메이션 코루틴 시작
            if (_isToggleOn)
            {
                _isToggleOn = false;
                slider.value = 0.9f;
                Image i = transform.Find("Background").gameObject.GetComponent<Image>();
                i.color = new Color32(170, 170, 170, 255);
                StartCoroutine("TurnOffToggle");
            }
            else
            {
                _isToggleOn = true;
                slider.value = 0.1f;
                Image i = transform.Find("Background").gameObject.GetComponent<Image>();
                i.color = new Color32(235, 110, 146, 255);
                StartCoroutine("TurnOnToggle");
            }
        }
    }

    public void SetToggle(bool turnOn)
    {
        if (turnOn)
        {
            slider.value = 0.9f;
            Image i = transform.Find("Background").gameObject.GetComponent<Image>();
            i.color = new Color32(235, 110, 146, 255);
            _isToggleOn = true;
        }
        else
        {
            slider.value = 0.1f;
            Image i = transform.Find("Background").gameObject.GetComponent<Image>();
            i.color = new Color32(170, 170, 170, 255);
            _isToggleOn = false;
        }
    }


    public void LockToggle(bool lockOn)
    {
        if (lockOn)
        {
            _isPressed = true;
            slider.enabled = false;
            //Debug.Log("lock on");

        }
        else
        {
            _isPressed = false;
            slider.enabled = true;
            //Debug.Log("lock off");

        }
    }


    private IEnumerator TurnOnToggle()
    {
        Slider s = gameObject.GetComponent<Slider>();
        while (true)
        {
            s.value *= 1.2f;
            yield return new WaitForSeconds(0.01f);
        }
    }


    private IEnumerator TurnOffToggle()
    {
        Slider s = gameObject.GetComponent<Slider>();
        while (true)
        {
            s.value *= 0.82f;
            yield return new WaitForSeconds(0.01f);
        }
    }

}




