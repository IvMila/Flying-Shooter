using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController AudioControllerInstance;

    [Header("------ Audio Source ------")]
    [SerializeField] private AudioSource _musicSourse;
    [SerializeField] private AudioSource _sFXSource;

    [Header("------ Audio Clip ------")]
    [SerializeField] private AudioClip _laserPlayer;
    [SerializeField] private AudioClip _explosion;
    [SerializeField] private AudioClip _soundLoss;
    [SerializeField] private AudioClip _soundWin;
    [SerializeField] private AudioClip _soundBackground;

    private void Awake()
    {
        AudioControllerInstance = this;
    }
    private void Start()
    {
        SoundBackground();
    }

    public void SoundBackground()
    {
        _musicSourse.clip = _soundBackground;
        _musicSourse.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sFXSource.PlayOneShot(clip);
    }
    public void PlayerShoot()
    {
        _sFXSource.PlayOneShot(_laserPlayer);
    }

    public void Explosion()
    {
        _sFXSource.PlayOneShot(_explosion);
    }

    public void SoundLoss()
    {
        _musicSourse.PlayOneShot(_soundLoss);
    }

    public void SoundWin()
    {
        _musicSourse.PlayOneShot(_soundWin);
    }
}
