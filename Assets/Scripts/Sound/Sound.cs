using System;
using System.Collections;
using AlexTools;
using AlexTools.Flyweight;
using UnityEngine;

public class Sound : MonoFlyweight<Sound, SoundSettings>
{
    [SerializeField] private AudioSource source;

    private Coroutine _coroutine;
    
    public override void Initialize(SoundSettings settings)
    {
        base.Initialize(settings);

        gameObject.AssignComponentIfUnityNull(ref source);

        source.outputAudioMixerGroup = Settings.AudioMixerGroup;
        source.volume = Settings.Volume;
        
        Settings.ChangeVolumeEvent += OnChangeVolume;

        PauseSystem.PauseEvent += OnPause;
        PauseSystem.UnpauseEvent += OnUnpause;
    }
    
    public override void OnRelease()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
    }

    private void OnDestroy()
    {
        Settings.ChangeVolumeEvent -= OnChangeVolume;

        PauseSystem.PauseEvent -= OnPause;
        PauseSystem.UnpauseEvent -= OnUnpause;
    }

    private IEnumerator ReleaseCoroutine(float clipLength)
    {
        yield return Waiters.GetWaitForSeconds(clipLength);
        ReleaseSelf();
    }
    
    public void PlayOneShot(string type)
    {
        if (!Settings.Clips.TryGetValue(type, out var clip))
            return;
        
        source.PlayOneShot(clip);
        _coroutine = StartCoroutine(ReleaseCoroutine(clip.length));
    }

    private void OnChangeVolume(float value) => source.volume = value;

    private void OnPause() => source.Pause();
    private void OnUnpause() => source.UnPause();
}
