using UnityEngine;
public class GameOutState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        AudioManager.Instance.MusicAudio.Stop();
        AudioManager.Instance.MainMenuAudio.Play();
    }
    public void UpdateState(GameManager gameManager)
    {
        if (gameManager.state == "PlayGame") gameManager.ChangeState(gameManager.playState);
    }
    public void ExitState(GameManager gameManager)
    {
        gameManager.score = 0;
        GameManager.Instance.result = "Loading";
        AudioManager.Instance.MainMenuAudio.Stop();
        AudioManager.Instance.MusicAudio.Play();
    }
}
