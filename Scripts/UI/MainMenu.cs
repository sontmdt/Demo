using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : Menu
{
    [SerializeField] private Transform optionsMenu;
    protected override void Reset()
    {
        base.Reset();
        this.LoadOptionsMenu();
    }
    protected override void Start()
    {
        base.Start();
    }
    private void LoadOptionsMenu()
    {
        if (this.optionsMenu != null) return;
        this.optionsMenu = transform.Find("OptionsMenu");
        this.optionsMenu.gameObject.SetActive(false);
        Debug.Log(transform.name + ": LoadOptionsMenu", gameObject);
    }
    protected override void LoadSlider()
    {
        base.LoadSlider();
        if (this.musicVolume != null || this.soundVolume != null) return;
        this.musicVolume = transform.Find("OptionsMenu/MusicVolume").GetComponentInChildren<Slider>();
        this.soundVolume = transform.Find("OptionsMenu/SoundVolume").GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        this.ResumeGame();
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
