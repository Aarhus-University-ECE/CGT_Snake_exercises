using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int ScoreInt;
    // Update is called once per frame
    private void Start()
    {
        ScoreInt = Persisting_stats.Score;
        ScoreText.text = "Score : " + ScoreInt.ToString();
    }
    public void AddScore(int points)
    {
        ScoreInt += points;
        ScoreText.text = "Score : " + ScoreInt.ToString();
    }
    public int GetScore()
    {
        return ScoreInt;
    }
}
