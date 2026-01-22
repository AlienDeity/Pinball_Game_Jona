using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class DeathTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) //If another collider than the one the object has touches the object run the code
    {
        if (other.CompareTag("Cannonball")) //If the other collider that touches the object has the tag "Cannonball" run the code under this line
        {
            Destroy(other.gameObject); //If the condintions above are met, destroy the object
        }

    }
}