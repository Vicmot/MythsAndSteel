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

    public void PlaySound(AudioClip SoundPlay, string debug = null)
    {
        AudioClip tolpay = SoundPlay;
        _Source.clip = tolpay;

        if (debug == null) debug = SoundPlay.name;
        Debug.Log(debug);

        if (_Source.clip != null) _Source.Play();
        else Debug.Log("No sound");
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
