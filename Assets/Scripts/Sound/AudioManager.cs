using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private SoundSettings soundSettings;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SoundVolumeKey = "SoundVolume";

    private const float DefaultMusicVolume = 0.5f;
    private const float DefaultSoundVolume = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        
        gameObject.AssignComponentIfUnityNull(ref musicSource);
    }

    private void OnEnable()
    {
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, DefaultMusicVolume);
        musicSlider.value = musicVolume;
        musicSource.volume = musicVolume;
        
        float soundVolume = PlayerPrefs.GetFloat(SoundVolumeKey, DefaultSoundVolume);
        soundSlider.value = soundVolume;
        soundSettings.ChangeVolume(soundVolume);
        
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
    }
    
    private void OnDisable()
    {
        musicSlider.onValueChanged.RemoveListener(OnMusicSliderValueChanged);
        soundSlider.onValueChanged.RemoveListener(OnSoundSliderValueChanged);
        
        PlayerPrefs.SetFloat(MusicVolumeKey, musicSlider.value);
        PlayerPrefs.SetFloat(SoundVolumeKey, soundSlider.value);
    }

    private void OnMusicSliderValueChanged(float value) => musicSource.volume = value;
    private void OnSoundSliderValueChanged(float value) => soundSettings.ChangeVolume(value);


    public void Play(string type)
    {
        var audioObject = soundSettings.Get();
        audioObject.PlayOneShot(type);
    }
}
