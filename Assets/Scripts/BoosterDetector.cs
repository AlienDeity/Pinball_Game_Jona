using UnityEngine;

public class BoosterDetector : MonoBehaviour
{

    //variable of how strong the boost on the ball is
    public float boostVelocity = 5f;

    //When one collider enters this objects collider, trigger this script
    private void OnTriggerEnter(Collider other)
    {
        //If the other collider has the tag ball, run the script
        if (other.CompareTag("Ball"))
        {
            //Find the gameobject called boost muzzle
            GameObject muzzle = GameObject.Find("BoostMuzzle");
            
            //Get the rigidbody of the other object
            other.gameObject.transform.GetComponent<Rigidbody>().linearVelocity = 
                
                //And apply the boost velocity on it in the forward direction
                muzzle.transform.forward * boostVelocity;

        }
    }
}
