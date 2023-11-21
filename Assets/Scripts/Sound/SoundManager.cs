// SoundManager.cs
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private Sound sound;

    [Range(0.0f, 1.0f)]
    public float globalVolume = 0.5f;

    public AudioMixerGroup audioMixer; 

    public void VolumeSliderMusic(float volume)
    {
        globalVolume = volume;
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

        // Add AudioSource component to the GameObject
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioMixer;
        audioSource.clip = clipToPlay;

        // Apply global volume adjustment
        audioSource.volume = globalVolume;

        audioSource.Play();

        // Start a coroutine to destroy the GameObject after the sound finishes playing
        StartCoroutine(DestroyAfterPlay(audioSource, soundObject));
    }

    private IEnumerator DestroyAfterPlay(AudioSource audioSource, GameObject soundObject)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(soundObject);
    }
}
