using UnityEngine;

public interface IAudioController
{
    float MasterVolume { get; }
    float SFXVolume { get; }
    float BGMVolume { get; }
    void PlaySound(AudioClip sfx);
    void PlayMusic(AudioClip bgm);
}
