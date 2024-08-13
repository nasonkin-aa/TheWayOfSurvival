using System;
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
    public event Action<float> ChangeVolumeEvent;

    protected override void OnEnable()
    {
        base.OnEnable();
        
        Clips = clips.ToDictionary(x => x.name);
    }

    public void ChangeVolume(float value) => ChangeVolumeEvent?.Invoke(value);
} 