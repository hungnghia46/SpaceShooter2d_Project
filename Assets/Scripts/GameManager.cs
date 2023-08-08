using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Uioption;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public AudioSource EffectSetting; 
    public AudioSource BGMSetting;
    [System.Obsolete]
    private void Start() {
        SFXSlider.value = .05f;
        BGMSlider.value = .5f;
    }

    [System.Obsolete]
    private void Update() {
        EffectSetting.volume = SFXSlider.value;
        BGMSetting.volume = BGMSlider.value;
        //
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Uioption.active == true)
            {
                Uioption.SetActive(false);
            }
            else
            {
                Uioption.SetActive(true);
            }
        }
        if(Uioption.active == true)
        {
            Time.timeScale = 0;
        }else
        {
             Time.timeScale = 1;
        }
    }
}
