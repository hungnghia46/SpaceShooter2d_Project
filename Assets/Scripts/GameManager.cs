using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Uioption;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public AudioSource EffectSetting;
    public AudioSource BGMSetting;
    [SerializeField] private GameObject EnemySpawnManager;
    [SerializeField] private GameObject GarbagePool;
    private void Start()
    {
        SFXSlider.value = .05f;
        BGMSlider.value = .5f;
    }
    private void Update()
    {
        EffectSetting.volume = SFXSlider.value;
        BGMSetting.volume = BGMSlider.value;
        //
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Uioption.activeSelf == true)
            {
                Uioption.SetActive(false);
            }
            else
            {
                Uioption.SetActive(true);
            }
        }
        if (Uioption.activeSelf == true)
        {
            EnemySpawnManager.SetActive(false);
            GarbagePool.SetActive(false);

            EffectSetting.volume = 0;
            BGMSetting.volume = 0;
        }
        else
        {
            EnemySpawnManager.SetActive(true);
            GarbagePool.SetActive(true);
        }
    }
}
