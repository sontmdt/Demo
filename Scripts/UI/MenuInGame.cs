using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuInGame : Menu
{
    [SerializeField] private Transform menuTable;
    protected override void Reset()
    {
        base.Reset();
        this.LoadMenuTable();
    }
    protected override void Start()
    {
        base.Start();
    }
    private void LoadMenuTable()
    {
        if (this.menuTable != null) return;
        this.menuTable = transform.Find("MenuTable");
        this.menuTable.gameObject.SetActive(false);
        Debug.Log(transform.name + ": LoadMenuTable", gameObject);
    }
    protected override void LoadSlider()
    {
        base.LoadSlider();
        if (this.musicVolume != null || this.soundVolume != null) return;
        this.musicVolume = transform.Find("MenuTable/MusicVolume").GetComponentInChildren<Slider>();
        this.soundVolume = transform.Find("MenuTable/SoundVolume").GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }
    public void GoHome()
    {
        GameManager.Instance.state = "OutGame";
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.state = "RestartGame";
        Time.timeScale = 1;
    }

}
