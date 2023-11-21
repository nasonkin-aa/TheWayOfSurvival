using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Audio/Sound")]
public class Sound : ScriptableObject
{
    [System.Serializable]
    public class SoundType
    {
        public string typeName;
        public AudioClip[] clips;
    }

    public SoundType[] soundTypes;

    public AudioClip GetRandomClip(string typeName)
    {
        SoundType soundType = System.Array.Find(soundTypes, type => type.typeName == typeName);

        if (soundType == null)
        {
            Debug.LogWarning("Sound type not found: " + typeName);
            return null;
        }

        if (soundType.clips.Length == 0)
        {
            Debug.LogWarning("No clips assigned to the sound type: " + typeName);
            return null;
        }

        return soundType.clips[Random.Range(0, soundType.clips.Length)];
    }
}