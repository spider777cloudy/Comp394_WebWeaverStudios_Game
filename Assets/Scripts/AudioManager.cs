using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        Play("AC");
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, x => x.name == name);
        sound.source.Play();

    }
    public void Stop(string name)
    {
        Sound sound = Array.Find(sounds, x => x.name == name);
        sound.source.Stop();

    }

}