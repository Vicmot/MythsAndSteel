using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoSingleton<SoundController>
{
    AudioMixer AudioMixer;
    [SerializeField] AudioSource _Source;
    public AudioSource Source => _Source;
    [SerializeField] List<AudioClip> _audioClip = new List<AudioClip>();
    public List<AudioClip> AudioClips => _audioClip;

    public void PlaySound(AudioClip SoundPlay)
    {
        AudioClip tolpay = SoundPlay;
        _Source.clip = tolpay;

        _Source.Play();
    }

    public void nextPhaseSound()
    {
        PlaySound(_audioClip[0]);
    }
    private void Start()
    {
        PlaySound(_audioClip[1]);
    }
}
