using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class PlungerController : MonoBehaviour {

    //Make a variable which you can edit in the inspector field to control the speed the ball is shot out
    [SerializeField] private float muzzleVelocity;

    //Which ball 
    [SerializeField] private GameObject BallPrefab;

    // variable to count how many balls the player has
    public int ballsLeft = 3;
	
	
	
	void Update () 
	{
        //Make a new method called cannon inputs to run        
        CannonInputs();
    }

    //The method to detect the key is being pressed and to run the fire plunger code
    void CannonInputs()
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FirePlunger();
        }
    }

    //Run the method fire plunger
    void FirePlunger()
    {
        // If the player has more than 0 balls left, they can fire the plunger
        if (ballsLeft > 0)

        {
            //Subtract one ball from the count 
            ballsLeft--;
            
            //Find the game object called Muzzle
            GameObject muzzle = GameObject.Find("Muzzle");

            //Shoot an object called cannonBall, which is the ballPrefab, from the position and rotation of the muzzle game object
            GameObject cannonBall = (GameObject)Instantiate(BallPrefab, muzzle.transform.position, muzzle.transform.rotation);

            //Shoot the cannonball (ball) rigidbody with the linear velocity (speed) of the muzzle velocity value in the forward direction 
            cannonBall.transform.GetComponent<Rigidbody>().linearVelocity = muzzle.transform.forward * muzzleVelocity;


        }

    }
}
