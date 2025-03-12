using UnityEngine;

public class GameRestartState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        AudioManager.Instance.MusicAudio.Stop();
        AudioManager.Instance.MusicAudio.Play();
    }
    public void UpdateState(GameManager gameManager)
    {
        gameManager.ChangeState(gameManager.playState);
    }
    public void ExitState(GameManager gameManager)
    {
        gameManager.score = 0;
        GameManager.Instance.result = "Loading";
    }
}
