using UnityEngine;

public class BumperBounce : MonoBehaviour
{
    //A variable to make any tag in the inspector field work with this script
    [SerializeField] string ballTag;

    //A variable to make any amount written in the inspector field the amount of bounce force
    [SerializeField] float bounceForce;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //If another collision other than the bumper to touches the bumpers hitbox, run the script
    private void OnCollisionEnter(Collision collision)
    {
        //If the object touching the bumber has the tag written in the inspector field, run the script
        if (collision.transform.tag == ballTag)
        {
            //Get the rigidbody of the other object, and store it in otherRB
            Rigidbody otherRB = collision.rigidbody;

            //Add an explosion force to the other rigidbody, with the amount of bounce force from the point of collision at first contact with the radius of 5
            otherRB.AddExplosionForce(bounceForce, collision.contacts[0].point,5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
