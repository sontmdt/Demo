using UnityEngine;
public class GamePauseState : IGameState
{
    public void EnterState(GameManager gameManager)
    {
    }
    public void UpdateState(GameManager gameManager)
    {
        if (gameManager.state == "PlayGame") gameManager.ChangeState(gameManager.playState);
        else if (gameManager.state == "RestartGame") gameManager.ChangeState(gameManager.restartState);
        else if (gameManager.state == "OutGame") gameManager.ChangeState(gameManager.outState);

    }
    public void ExitState(GameManager gameManager)
    {

    }
}
