using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _endingSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        PlayDefault();
    }

    public void PlayDefault()
    {       
        _audioSource.Play();
    }

    public void PlayEnding()
    {
        _audioSource.Stop();
        _endingSource.Play();
    }
}
