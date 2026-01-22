using UnityEngine;

public class TiltController : MonoBehaviour
{
    public float rotationSpeed = 0;

    private float currentRotationX = 0;

    private float currentRotationZ = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            currentRotationX += rotationSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            currentRotationX -= rotationSpeed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.A))
        {
            currentRotationZ += rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentRotationZ -= rotationSpeed * Time.deltaTime;
        }



        transform.rotation = Quaternion.Euler(currentRotationX, 0, currentRotationZ);

    }
}
