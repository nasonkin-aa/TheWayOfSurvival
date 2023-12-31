// SoundManager.cs

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private Sound sound;

    private static float savedSoundVolume = 0.5f;
    private static float savedMusicVolume = 0.5f;

    public AudioMixerGroup audioMixer; 
    
    public Slider musicSlider;
    public Slider soundSlider;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicSlider.value = savedMusicVolume;
        }
        else
        {
            savedMusicVolume = musicSlider.value;
        }

        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            savedSoundVolume = PlayerPrefs.GetFloat("SoundVolume");
            soundSlider.value = savedSoundVolume;
        }
        else
        {
            savedSoundVolume = soundSlider.value;
        }
    }
    
    public void OnMusicSliderValueChanged()
    {
        savedMusicVolume = musicSlider.value;
        GetComponent<AudioSource>().volume = savedMusicVolume;
        PlayerPrefs.SetFloat("MusicVolume", savedMusicVolume);
    }

    public void OnSoundSliderValueChanged()
    {
        savedSoundVolume = soundSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", savedSoundVolume);
    }
    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SoundManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySound(string typeName)
    {
        // Get a random AudioClip based on typeName
        AudioClip clipToPlay = sound.GetRandomClip(typeName);

        if (clipToPlay == null)
        {
            Debug.LogWarning("Failed to get AudioClip for type: " + typeName);
            return;
        }

        // Create a new GameObject to hold the AudioSource
        GameObject soundObject = new GameObject("Sound_" + typeName);
        soundObject.transform.parent = transform; // Attach to the SoundManager object

        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioMixer;
        audioSource.clip = clipToPlay;

        audioSource.volume = savedSoundVolume;

        audioSource.Play();

        StartCoroutine(DestroyAfterPlay(audioSource, soundObject));
    }

    private IEnumerator DestroyAfterPlay(AudioSource audioSource, GameObject soundObject)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(soundObject);
    }
}
