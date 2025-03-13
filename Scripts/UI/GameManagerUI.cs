using UnityEngine;
using UnityEngine.UI;
public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private Text result;
    [SerializeField] private Text score;
    [SerializeField] private Transform endGame;
    private void Reset()
    {
        this.LoadText();
        this.LoadResult();
    }
    private void LoadText()
    {
        if (this.result != null || this.score != null) return;
        this.result = GameObject.Find("EndGame/Result").GetComponent<Text>();
        this.score = GameObject.Find("EndGame/Score").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadText", gameObject);
    }
    private void LoadResult()
    {
        if (this.endGame != null) return;
        this.endGame = transform.Find("EndGame");
        this.endGame.gameObject.SetActive(false);
        Debug.Log(transform.name + ": LoadResult", gameObject);
    }
    private void Update()
    {
        this.result.text = GameManager.Instance.result;
        this.score.text = GameManager.Instance.score.ToString();
        if (this.result.text == "Victory!" || this.result.text == "Lose!") this.endGame.gameObject.SetActive(true);
    }
}
