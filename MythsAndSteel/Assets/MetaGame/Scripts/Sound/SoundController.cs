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

    [SerializeField] List<AudioClip> Waitlist = new List<AudioClip>();
    bool Iscoroutplay = false;

    public void PlaySound(AudioClip SoundPlay, string debug = null)
    {
        if (_Source.isPlaying)
        {
            Waitlist.Add(SoundPlay);
            if (!Iscoroutplay)
            {
                StartCoroutine(DelayPlay());
            }

        }
        else
        {

            _Source.clip = SoundPlay;
            if (debug == null) debug = SoundPlay.name;
            Debug.Log(debug);

            if (_Source.clip != null)
            {
                _Source.Play();
            }
            else Debug.Log("No sound");
        }
    }

    public void Multisong(AudioClip ClipOne, AudioClip ClipTwo, AudioClip ClipThree = null, string debug = null)
    {
        PlaySound(ClipOne, debug);
        PlaySound(ClipTwo, debug);
        if (ClipThree != null) PlaySound(ClipThree, debug);
    }


    public void nextPhaseSound()
    {
        PlaySound(_audioClip[0]);
    }
    private void Start()
    {
        PlaySound(_audioClip[1]);
    }



    IEnumerator DelayPlay()
    {
        yield return new WaitUntil(() => !_Source.isPlaying);
        PlaySound(Waitlist[0]);
        Waitlist.Remove(Waitlist[0]);
    }
}
