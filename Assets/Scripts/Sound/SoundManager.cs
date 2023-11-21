using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private Sound sound;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of SoundManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySound(string typeName)
    {
        AudioClip clipToPlay = sound.GetRandomClip(typeName);

        if (clipToPlay == null)
        {
            Debug.LogWarning("Failed to get AudioClip for type: " + typeName);
            return;
        }

        GameObject soundObject = new GameObject("Sound_" + typeName);
        soundObject.transform.parent = transform;

        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clipToPlay;
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