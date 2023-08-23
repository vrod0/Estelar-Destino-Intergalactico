using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] musicSounds;

    [SerializeField] Sound[] sfxSounds;

    AudioSource musicSource;

    AudioSource sfxSource;

    void Awake()
    {
        musicSource = gameObject.AddComponent<AudioSource>();

        sfxSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        PlayMusic("Main");
    }

    public void PlayMusic(string name)
    {
        Sound sound = FindSound(name, musicSounds);

        if (sound != null)
        {
            musicSource.loop = true;

            musicSource.clip = sound.clip;

            musicSource.Play();
        }
    }

    Sound FindSound(string name, Sound[] musicSounds)
    {
        return Array.Find(musicSounds, s => s.name == name);
    }
}