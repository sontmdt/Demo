using UnityEngine;
public class GameWinState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        gameManager.result = "Victory!";
        AudioManager.Instance.MusicAudio.Stop();
        Time.timeScale = 0;
    }
    public void UpdateState(GameManager gameManager)
    {
        gameManager.state = "WinGame";
        gameManager.ChangeState(gameManager.pauseState);
    }
    public void ExitState(GameManager gameManager)
    {
    }
}
