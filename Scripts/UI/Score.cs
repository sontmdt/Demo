using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private Text score;
    private void Reset()
    {
        this.LoadScore();
    }
    private void LoadScore()
    {
        if (this.score != null) return;
        this.score = transform.GetComponentInChildren<Text>();
        Debug.Log(transform.name + ": LoadScore", gameObject);
    }
    private void Update()
    {
        this.score.text = GameManager.Instance.score.ToString();
    }
}
