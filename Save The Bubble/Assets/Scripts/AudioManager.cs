using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.file;
                if (s.name == "bgm")
                {
                    s.source.loop = true;
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            PlayMusic();
        }
    }

    public void PlaySound(string file_name)
    {
        if (PlayerPrefs.GetInt("Audio", 1) == 1)
        {
            Sound s = Array.Find(sounds, sound => sound.name == file_name);
            s.source.Play();
        }
    }

    public void StopMusic()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "bgm");
        s.source.Stop();
    }

    public void PlayMusic()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "bgm");
        s.source.Play();
    }
}
