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
    }

    public override void OnRelease()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
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

    public void ChangeVolume(float value) => source.volume = value;
}
