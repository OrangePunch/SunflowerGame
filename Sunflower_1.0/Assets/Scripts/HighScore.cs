using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public float currentScore;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        // Load the high score from player preferences
        currentScore = PlayerPrefs.GetFloat("highScore", 0);
        highScoreText.text = "High Score: " + currentScore;
    }

    public void UpdateHighScore(float newScore)
    {
        // Check if the new score is higher than the current high score
        if (newScore > currentScore)
        {
            currentScore = newScore;
            highScoreText.text = "High Score: " + currentScore;

            // Save the new high score to player preferences
            PlayerPrefs.SetFloat("highScore", currentScore);
        }
    }
}
