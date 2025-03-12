using UnityEngine;

public class GameLoseState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        gameManager.result = "Lose!";
        AudioManager.Instance.MusicAudio.Stop();
        Time.timeScale = 0;
    }
    public void UpdateState(GameManager gameManager)
    {
        gameManager.state = "LoseGame";
        gameManager.ChangeState(gameManager.pauseState);
    }
    public void ExitState(GameManager gameManager)
    {
    }
}
