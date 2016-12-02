using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicVolume : UIBase
{
    // Inspector
    [SerializeField]
    private Slider slider;
    // Inspector

    private static MusicVolume singleton;
    private AudioSource audioSource;

    internal override void Awake()
    {
        base.Awake();
        singleton = this;
        audioSource = GetComponent<AudioSource>();
        LoadPlayerVolume();
    }

    private void LoadPlayerVolume()
    {
        float currentVolume = 0;

        if (!PlayerPrefs.HasKey("volume"))
        {
            currentVolume = 0.5f;
            PlayerPrefs.SetFloat("volume", currentVolume);
        }
        else
        {
            currentVolume = PlayerPrefs.GetFloat("volume");
        }

        audioSource.volume = currentVolume;
        slider.value = currentVolume;
    }

    public void OnSliderChange()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        audioSource.volume = slider.value;
    }

    static public void CloseSingleton()
    {
        singleton.Close();
    }

    static public void OpenSingleton()
    {
        singleton.Open();
    }
}