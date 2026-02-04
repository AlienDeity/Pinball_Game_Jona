using UnityEngine;

public class LeftFlipperControll : MonoBehaviour
{
    //The script of this flipper is identical to right flipper, except instead of the D key, it uses the A key
    
    
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;

    private HingeJoint flipperHinge;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flipperHinge = GetComponent<HingeJoint>();
        flipperHinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointUpdate();
    }

    private void JointUpdate()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;


        if(Input.GetKey(KeyCode.A))
        {
            spring.targetPosition = pressedPosition;
        }

        else
        {
            spring.targetPosition = restPosition;
        }


        flipperHinge.spring = spring;
        flipperHinge.useLimits = true;
    }   
}
