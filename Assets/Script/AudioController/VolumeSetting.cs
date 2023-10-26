using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderSFX;
    [SerializeField] private AudioMixer _audioMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume")&& PlayerPrefs.HasKey("SFXvolume"))
            LoadVolume();
        else
        {
            SetVolumeMusic();
            SetVolumeSFX();
        }
    }

    public void SetVolumeMusic()
    {
        float volume = _sliderMusic.value;
        _audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetVolumeSFX()
    {
        float volume = _sliderSFX.value;
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("SFXvolume", volume);
    }

    private void LoadVolume()
    {
        _sliderMusic.value = PlayerPrefs.GetFloat("musicVolume");
        _sliderSFX.value = PlayerPrefs.GetFloat("SFXvolume");
        SetVolumeMusic();
        SetVolumeSFX();
    }
}
