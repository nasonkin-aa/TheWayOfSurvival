using System.Collections.Generic;
using System.Linq;
using AlexTools.Flyweight;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio/Create SoundSettings")]
public class SoundSettings : MonoFlyweightSettings<Sound, SoundSettings>
{
    [SerializeField] private AudioMixerGroup audioMixerGroup;
    [SerializeField] private List<AudioClip> clips;

    public AudioMixerGroup AudioMixerGroup => audioMixerGroup;
    public IReadOnlyDictionary<string, AudioClip> Clips { get; private set; }
    
    private readonly List<Sound> _soundList = new();

    protected override void OnEnable()
    {
        base.OnEnable();

        Clips = clips.ToDictionary(x => x.name);
    }

    protected override Sound Create()
    {
        var sound = base.Create();
        _soundList.Add(sound);
        return sound;
    }

    protected override void OnDestroyPoolObject(Sound flyweight)
    {
        _soundList.Remove(flyweight);
        base.OnDestroyPoolObject(flyweight);
    }

    public void ChangeVolume(float value) => _soundList.ForEach(x => x.ChangeVolume(value));
} 