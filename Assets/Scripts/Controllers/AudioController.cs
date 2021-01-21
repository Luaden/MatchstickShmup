﻿using UnityEngine;

public class AudioController : MonoBehaviour, IAudioController
{
    protected AudioSource[] audioSources;
    protected AudioSource sfxAudioSource;
    protected AudioSource bgmAudioSource;
    //protected ConfigManager configManager;
    protected float masterVolume = 1;
    protected float sfxAudioVolume = 1f;
    protected float bgmAudioVolume = 1f;

    public float MasterVolume { get => masterVolume;  set => UpdateMasterVolume(value); }
    public float SFXVolume { get => SFXVolume; set => UpdateSFXVolume(value); }
    public float BGMVolume { get => BGMVolume; set => UpdateBGMVolume(value); }

    public void PlaySound(AudioClip clipToPlay) => sfxAudioSource.PlayOneShot(clipToPlay);
    public void PlayMusic(AudioClip clipToPlay)
    {
        bgmAudioSource.clip = clipToPlay;
        bgmAudioSource.Play();
    }

    protected void Awake()
    {
        audioSources = GetComponents<AudioSource>();
        sfxAudioSource = audioSources[0];
        bgmAudioSource = audioSources[1];

        //configManager = ConfigManager.instance;
        //configManager.AudioController = this;
    }

    protected void Start()
    {
        //MasterVolume = configManager.MasterVolume;
        //SFXVolume = configManager.SFXVolume;
        //BGMVolume = configManager.BGMVolume;
    }

    protected void UpdateMasterVolume(float value)
    {
        masterVolume = value;
        sfxAudioSource.volume = sfxAudioVolume * masterVolume;
        bgmAudioSource.volume = bgmAudioVolume * masterVolume;
    }

    protected void UpdateSFXVolume(float value)
    {
        sfxAudioVolume = value;
        sfxAudioSource.volume = sfxAudioVolume * masterVolume;
    }

    protected void UpdateBGMVolume(float value)
    {
        bgmAudioVolume = value;
        bgmAudioSource.volume = bgmAudioVolume * masterVolume;
    }
}
