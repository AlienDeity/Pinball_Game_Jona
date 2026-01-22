using UnityEngine;
using UnityEngine.SceneManagement; // Needed for reloading scenes
using TMPro;

public class GameManager : MonoBehaviour
{
    public int ballsLeft = 3; // How many balls you start with
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private TMP_Text ballCount_Txt;


    private void Start()
    {
        ballCount_Txt.text = ballsLeft.ToString();
    }

    // Run when we lose a ball. Spawn new ball or reset the scene.
    public void BallLost()
    {
        ballsLeft--;
        ballCount_Txt.text = ballsLeft.ToString();


        if (ballsLeft > 0)
        {

        }
        else
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
