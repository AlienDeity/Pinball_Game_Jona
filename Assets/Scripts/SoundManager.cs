using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //To put the audioclip in the inspector, so it knows what to play
    [SerializeField] private AudioSource backGroundMusic_AS;


    //On start, play the background music 
    void Start()
    {
        backGroundMusic_AS.Play();
    }

}

