using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public static EnemySound EnemySoundInstance;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _laserSound;
    [SerializeField] private AudioClip _explosiomSound;
    private void Awake()
    {
        EnemySoundInstance = this;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void ShootSound()
    {
        _audioSource.PlayOneShot(_laserSound);
        _audioSource.volume = 0.2f;
    }

    public void ExplosionSound()
    {
        _audioSource.PlayOneShot(_explosiomSound);
        _audioSource.volume = 0.5f;
    }
}
