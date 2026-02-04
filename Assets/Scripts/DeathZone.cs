using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    //Variable to use the GameManager script in this script 
    public GameManager gameManager;


    //When another hitbox enters the hitbox of the deathzone, run the script
    private void OnTriggerEnter(Collider other)
    {
        //Run the script if the other hitbox has the tag Ball
        if (other.CompareTag("Ball"))
        {
            //Give a message to the GameManager that a ball has been lost 
            gameManager.BallLost();

            //Then destroy the object that entered the deathzone hitbox 
            Destroy(other.gameObject);
        }

    }

}