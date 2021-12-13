using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Sprite backgroundActiveSprite;
    [SerializeField] Sprite handleActiveSprite;

    Image backgroundImage, handleImage;

    Sprite handleDefaultSprite, backgroundDefaultSprite;

    Toggle toggle;
    Vector2 handlePosition;

    
    void Start()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = uiHandleRectTransform.anchoredPosition;
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultSprite = backgroundImage.sprite;
        handleDefaultSprite = handleImage.sprite;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
        {
            if(MusicManager.Instance.backsound.mute == false)
            {
                OnSwitch(true);
            }
            else
            {
                OnSwitch(false);
            }
            
        }
    }


    public void OnSwitch(bool off)
    {
        if (off)
        {
            uiHandleRectTransform.anchoredPosition = handlePosition;
        }
        else
        {
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;

        }
        backgroundImage.sprite = off ? backgroundDefaultSprite : backgroundActiveSprite ;
        handleImage.sprite = off ? handleDefaultSprite : handleActiveSprite ;
        MusicManager.Instance.ButtonMusicMute();
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




