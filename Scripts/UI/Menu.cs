using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] protected Slider musicVolume;
    [SerializeField] protected Slider soundVolume;
    protected virtual void Reset()
    {
        this.LoadSlider();
    }
    protected virtual void Start()
    {
        musicVolume.value = AudioManager.Instance.MusicAudio.volume;
        musicVolume.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
        soundVolume.value = AudioManager.Instance.SoundAudio.volume;
        soundVolume.onValueChanged.AddListener(AudioManager.Instance.SetSoundVolume);
    }
    protected virtual void LoadSlider()
    {
        //
    }
    public void PauseGame()
    {
        GameManager.Instance.state = "PauseGame";
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        GameManager.Instance.state = "PlayGame";
        Time.timeScale = 1;
    }
}
