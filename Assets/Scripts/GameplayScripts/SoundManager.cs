using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; //this will allow us to call it in every other scrip like this: SoundManager.instance.asdasdasd

    public AudioSource soundFxManager, soudFxManager2;
    public AudioSource themeSongManager;

    public AudioClip[] themeSongs;

    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    void Update()
    {
        if (!themeSongManager.isPlaying)
        {
            themeSongManager.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            themeSongManager.Play();
        }
    }

    public void PlaySoundFx(AudioClip audioClip, float volume)
    {
        if (!soundFxManager.isPlaying)
        {
            soundFxManager.clip = audioClip;
            soundFxManager.volume = volume;
            soundFxManager.Play();
        }
        else
        {
            soundFxManager.clip = audioClip;
            soundFxManager.volume = volume;
            soundFxManager.Play();
        }
    }

    public void PlayRandomSoundFx(AudioClip[] audioClips)
    {
        if (!soundFxManager.isPlaying)
        {
            soundFxManager.clip = audioClips[Random.Range(0, audioClips.Length)] ;
            soundFxManager.volume = Random.Range(.5f,.8f);
            soundFxManager.Play();
        }
    }

}
