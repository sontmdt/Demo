
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    public IGameState currentState;
    public GameWinState winState;
    public GameLoseState loseState;
    public GamePlayState playState;
    public GamePauseState pauseState;
    public GameOutState outState;
    public GameRestartState restartState;

    public Scene currentScene;

    public string state = "";
    public string result ="";
    public float score = 0f;
    public float maxScore = 1000f;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        currentScene = SceneManager.GetActiveScene();
    }

    protected void Start()
    {
        winState = new GameWinState();
        loseState = new GameLoseState();
        playState = new GamePlayState();
        pauseState = new GamePauseState();
        outState = new GameOutState();
        restartState = new GameRestartState();

        ChangeState(outState);
    }
    protected void Update()
    {
        currentState?.UpdateState(this);
    }

    public void ChangeState(IGameState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
