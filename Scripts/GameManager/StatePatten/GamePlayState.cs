using UnityEngine;
using UnityEngine.AI;
public class GamePlayState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
        AudioManager.Instance.MusicAudio.UnPause();
    }
    public void UpdateState(GameManager gameManager)
    {
        if (gameManager.state == "OutGame") gameManager.ChangeState(gameManager.outState);
        else if (gameManager.state == "PauseGame") gameManager.ChangeState(gameManager.pauseState);
        else if (GameCtrl.Instance.PlayerCtrl.PlayerAttribute.IsDead()) gameManager.ChangeState(gameManager.loseState);
        else if (gameManager.score == gameManager.maxScore) gameManager.ChangeState(gameManager.winState);
    }
    public void ExitState(GameManager gameManager)
    {
    }
}
