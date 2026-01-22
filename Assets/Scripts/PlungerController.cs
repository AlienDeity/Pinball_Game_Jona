using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class PlungerController : MonoBehaviour {

    [SerializeField] private float muzzleVelocity;
    [SerializeField] private GameObject BallPrefab;    
	
	
	// Update is called once per frame
	void Update () 
	{
        CannonInputs();
    }

    //the keys that we use to control and shoot

    void CannonInputs()
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FirePlunger();
        }
    }
	
	void FirePlunger() 
    {		
		GameObject muzzle = GameObject.Find("Muzzle");
		GameObject cannonBall = (GameObject)Instantiate(BallPrefab, muzzle.transform.position, muzzle.transform.rotation);
		cannonBall.transform.GetComponent<Rigidbody>().linearVelocity = muzzle.transform.forward*muzzleVelocity;
	}
}
