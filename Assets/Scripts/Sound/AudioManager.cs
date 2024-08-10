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

    protected override void Awake()
    {
        base.Awake();
        
        gameObject.AssignComponentIfUnityNull(ref musicSource);
    }

    private void OnEnable()
    {
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
    }
    
    private void OnDisable()
    {
        musicSlider.onValueChanged.RemoveListener(OnMusicSliderValueChanged);
        soundSlider.onValueChanged.RemoveListener(OnSoundSliderValueChanged);
    }
    
    private void Start()
    {
        if (PlayerPrefs.HasKey(MusicVolumeKey))
            musicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey);

        if (PlayerPrefs.HasKey(SoundVolumeKey))
        {
            float value = PlayerPrefs.GetFloat(SoundVolumeKey);
            soundSlider.value = value;
            soundSettings.ChangeVolume(value);
        }
    }
    
    private void OnMusicSliderValueChanged(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat(MusicVolumeKey, value);
    }

    private void OnSoundSliderValueChanged(float value)
    {
        soundSettings.ChangeVolume(soundSlider.value);
        PlayerPrefs.SetFloat(SoundVolumeKey, soundSlider.value);
    }


    public void Play(string type)
    {
        var audioObject = soundSettings.Get();
        audioObject.PlayOneShot(type);
    }
}
