using UnityEngine;

public class BumperDetector : MonoBehaviour
{
    //A variable to use the scoreManager script in this script
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private SoundManager soundManager;

    //The amount of points the bumper gives
    [SerializeField] private int bumperPoints = 100;

    //A avriabel to control how long the duration is
    [SerializeField] private float duration = 0.5f;

    //A timer variable to be used later
    private float timer;

    //By default, isRunning should be off
    private bool isRunning = false;

    //A variable to contain the original colour of the bumpers
    private Color originalColor;

    //A variable which is a particle system
    private ParticleSystem bumperParticleSystem;

    //An audioclip called bumper sfx
    [SerializeField] private AudioClip bumperSFX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the game object with the ScoreManagerTag 
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManagerTag").GetComponent<ScoreManager>();

        //Get the particle system on the object this script is attached to
        bumperParticleSystem = GetComponent<ParticleSystem>();

        //get the original colour of the material
        originalColor = GetComponent<Renderer>().material.color;

    }


    private void Update()
    {
        //If isRunning is on, run the BumperEffectDelay method
        if(isRunning == true)
        {
            BumperEffectDelay();
        }
    }

    //If another collision other than the bumper to touches the bumpers hitbox, run the script
    private void OnCollisionEnter(Collision collision)
    {
        //If the colliding objcet has the tag Ball, run the script
        if (collision.transform.tag == "Ball")
        {
            //Add points to the score manager based on the amount from the bumper points variable
            scoreManager.AddScore(bumperPoints);
            
            //Start the particle system
            bumperParticleSystem.Play();

            //Change the colour to yellow
            GetComponent<Renderer>().material.color = Color.yellow;

            //From teh sound effects instance, play the sound effect
            SoundFXManager.instance.PlaySoundFXClip(bumperSFX, transform, 0.2f);
            
            //All this happens for how long the timer is, which is how long the duration is
            timer = duration;
            
            //Set isRunning to true
            isRunning = true;
        }
    }

    //A method to change back all the changes on the bumper
    private void BumperEffectDelay()
    {
        //subtract from the timer using seconds
        timer -= Time.deltaTime;
        
        //If the timer is lower or equal to 0, run the script
        if (timer <= 0f)
        {
            //Use the original material again for the bumper
            GetComponent<Renderer>().material.color = originalColor;

            //Stop the particle system on the bumper
            bumperParticleSystem.Stop();
        }
    }

}

