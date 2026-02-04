using UnityEngine;
using TMPro;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    //Variable to keep count of the score
    [SerializeField] private int currentTotalScore = 0;

    //To convert the score to text shown on screen
    [SerializeField] private TMP_Text totalScoreText;

    //To convert the highscore text to shown on screen
    [SerializeField] private TMP_Text highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Method to add points to the score
    public void AddScore(int score)
    {
        //Add the points to the current score
        currentTotalScore += score;

        //Convert the new score to text shown on screen
        totalScoreText.text = currentTotalScore.ToString();

    }

    //Method to add and update the highscore
    public void HighScoreUpdate()
    {
        //If the there alreasy exists a saved highscore in player prefs run the script
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            //If the current score is higher than the saved high score
            if (currentTotalScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                //Save a new high score equal to the current score
                PlayerPrefs.SetInt("SavedHighScore", currentTotalScore);
            }
        }

        else
        {
            //If there aren't any saved high scores, save a new highscore equal to the current score
            PlayerPrefs.SetInt("SavedHighScore", currentTotalScore);
        }

        //Convert the saved highscore to text shown on screen 
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}