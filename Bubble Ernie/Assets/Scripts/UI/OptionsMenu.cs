using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetMusicVolume(float musicVolume)
    {
        mixer.SetFloat("Music", musicVolume);
    }

    public void SetSFXVolume(float sfxVolume)
    {
        mixer.SetFloat("SFX", sfxVolume);
    }
}
