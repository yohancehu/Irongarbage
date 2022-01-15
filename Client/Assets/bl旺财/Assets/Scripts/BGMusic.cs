using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip music;
    public AudioClip dieSound;
    public AudioClip bossMusic;
    public AudioClip congratulationMusic;

    public static BGMusic Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayNormalMusic()
    {
        audioSource.volume = 0.12f;
        audioSource.clip = music;
        audioSource.Play();
    }

    public void PlayBossMusic()
    {
        audioSource.volume = 0.24f;
        audioSource.clip = bossMusic;
        audioSource.Play();
    }

    public void PlayCongratulationMusic()
    {
        audioSource.volume = 0.24f;
        audioSource.clip = congratulationMusic;
        audioSource.Play();
        audioSource.loop = false;
    }

    public void PlayDeadMusic()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = dieSound;
        audioSource.Play();
    }
}
