using UnityEngine;

public class RightFlipperControll : MonoBehaviour
{
    //The position the flipper is in when not pressed
    public float restPosition = 0f;
    
    //The position the flipper will move to when pressed
    public float pressedPosition = 45f;
    
    //The speed the flipper will have when it moves to the pressed position
    public float hitStrength = 10000f;
    
    //The amount the speed of the flipper will reduce with when returning to the rest position
    public float flipperDamper = 150f;

    //This variable is a hingejoint
    private HingeJoint flipperHinge;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //flipperHinge gets the hingejoint component 
        flipperHinge = GetComponent<HingeJoint>();
        
        //The flipperHinge will have a spring 
        flipperHinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        //To make a method called joint update
        JointUpdate();
    }

    
    private void JointUpdate()
    {
        //Creates a new spring preset, so the flipper can move like a spring 
        JointSpring spring = new JointSpring();
        
        //How hard/fast the spring hits
        spring.spring = hitStrength;
        
        //How much the spring is slowed down after being pressed
        spring.damper = flipperDamper;


        //If the D key is pressed, move the spring to the target position, which is the pressed position
        if(Input.GetKey(KeyCode.D))
        {
            spring.targetPosition = pressedPosition;
        }

        //If the D key is not being pressed, the flipper will be in the rest position
        else
        {
            spring.targetPosition = restPosition;
        }

        //Applies the spring to the flipper hinge
        flipperHinge.spring = spring;
        
        //Use the limits of the hinge joint (pressed and rest position)
        flipperHinge.useLimits = true;
    }
}
