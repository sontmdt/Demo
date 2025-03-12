using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource musicAudio;
    public AudioSource MusicAudio => musicAudio;

    [SerializeField] private AudioSource soundAudio;
    public AudioSource SoundAudio => soundAudio;

    [SerializeField] private AudioSource mainMenuAudio;
    public AudioSource MainMenuAudio => mainMenuAudio;

    public AudioClip moveSound;
    public AudioClip attackSound;
    public AudioClip fireBallSound;
    public AudioClip dashSound;
    public AudioClip lightningSound;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        soundAudio.Stop();
        musicAudio.Stop();
    }
    private void Reset()
    {
        this.LoadAudio();
    }
    private void LoadAudio()
    {
        if (this.musicAudio != null || this.soundAudio != null || this.mainMenuAudio != null) return;
        this.musicAudio = transform.Find("MusicAudio").GetComponent<AudioSource>();
        this.soundAudio = transform.Find("SoundAudio").GetComponent<AudioSource>();
        this.mainMenuAudio = transform.Find("MainMenuAudio").GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadAudio", gameObject);
    }
    public void SetMusicVolume(float volume)
    {
        musicAudio.volume = volume;
        mainMenuAudio.volume = volume;
    }
    public void SetSoundVolume(float volume)
    {
        soundAudio.volume = volume;
    }
}
