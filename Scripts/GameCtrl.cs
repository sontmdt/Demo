using UnityEngine;
public class GameCtrl : Singleton<GameCtrl>
{
    [SerializeField] private PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    [SerializeField] private Transform player;
    public Transform Player => player;

    [SerializeField] private Canvas UI;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Reset()
    {
        this.LoadPlayerCtrl();
        this.LoadPlayer();
        this.LoadUI();
    }
    private void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        this.playerCtrl = FindAnyObjectByType<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    private void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player")?.transform;
        Debug.Log(transform.name + " LoadPlayer", gameObject);
    }
    private void LoadUI()
    {
        if (this.UI != null) return;
        this.UI = FindAnyObjectByType<Canvas>();
        Debug.Log(transform.name + " LoadUI", gameObject);
    }
}
