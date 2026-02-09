using UnityEngine;
using UnityEngine.SceneManagement; // Needed for reloading scenes
using TMPro; //Needed to make text

public class GameManager : MonoBehaviour
{   
    // How many balls you start with
    public int ballsLeft = 3; 

    //What the ball is/which prefab the script will use
    [SerializeField] private GameObject ballPrefab;

    //Currently not in use
    [SerializeField] private Transform spawnPoint;

    //Making a game over screen variable
    [SerializeField] private GameObject gameOverScreen;

    //Making the variable for the text for ball count 
    [SerializeField] private TMP_Text ballCount_Txt;


    private void Start()
    {
        //The amount of balls is converted to text 
        ballCount_Txt.text = ballsLeft.ToString();
    }

    // Run when we lose a ball. Spawn new ball or reset the scene.
    public void BallLost()
    {
        //When a ball is lost, subtract the amount of balls by one, and update the text 
        ballsLeft--;
        ballCount_Txt.text = ballsLeft.ToString();


        if (ballsLeft <= 0)
        {
            //If the amount of balls left is smaller than or equal to zero, make everything stop, and show the game over screen
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
      
    }
    public void RestartGame()
    {
        //When the player restarts the game, use the scene manager to reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //Start time again
        Time.timeScale = 1;
    }
}
