using UnityEngine;

public class BumperDetector : MonoBehaviour
{
    //A variable to use the scoreManager script in this script
    [SerializeField] private ScoreManager scoreManager;
    
    //The amount of points the bumper gives
    [SerializeField] private int bumperPoints = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the game object with the ScoreManagerTag 
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManagerTag").GetComponent<ScoreManager>();
    }


    //If another collision other than the bumper to touches the bumpers hitbox, run the script
    private void OnCollisionEnter(Collision collision)
    {
        //If the colliding objcet has the tag Ball, run the script
        if (collision.transform.tag == "Ball")
        {
            //Add points to the score manager based on the amount from the bumper points variable
            scoreManager.AddScore(bumperPoints);
        }
    }
}

