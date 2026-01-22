using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class CannonController : MonoBehaviour {

    [SerializeField] private float deltaAngle = 1.0f;
	private float elevationAngle = 0.0f;  //up and down
    private float turnAngle = 0.0f; //right and left
    [SerializeField] private float speed = 2.0f;


    [SerializeField] private float muzzleVelocity;
    [SerializeField] private GameObject cannonBallPrefab;    
	
	
	// Update is called once per frame
	void Update () 
	{
        CannonInputs();
    }

    //the keys that we use to control and shoot

    void CannonInputs()
	{
        if (Input.GetKey(KeyCode.S))
        {
            elevationAngle -= deltaAngle;
        }
        if (Input.GetKey(KeyCode.W))
        {
            elevationAngle += deltaAngle;
        }
        if (Input.GetKey(KeyCode.A))
        {
            turnAngle -= deltaAngle;
        }
        if (Input.GetKey(KeyCode.D))
        {
            turnAngle += deltaAngle;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireCannon();
        }

        //a special vector data type to deal with rotation in 3d space
        Quaternion target = Quaternion.Euler(elevationAngle, turnAngle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * speed);
    }
	
	void FireCannon() 
    {		
		GameObject muzzle = GameObject.Find("Muzzle");
		GameObject cannonBall = (GameObject)Instantiate(cannonBallPrefab, muzzle.transform.position, muzzle.transform.rotation);
		cannonBall.transform.GetComponent<Rigidbody>().linearVelocity = muzzle.transform.forward*muzzleVelocity;
	}
}
