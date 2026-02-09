using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
   
    //Make this an instance
    public static SoundFXManager instance;

    //A variable to contain the sound effect   
    [SerializeField] private AudioSource soundsFXObject;


    //Run this when the script instance is being loaded
    private void Awake()
    {
        //If theres no sound effects instance already in the scene
        if (instance == null)
        {
            //Use this instance
            instance = this;
        }
    }

    //Method to play the sound, at the specified location, with the specified volume
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //Creates a new audio source at runtime, at the location the soundsFXObject is, with no requirement to rotation
        AudioSource audioSource = Instantiate(soundsFXObject, spawnTransform.position, Quaternion.identity);

        //The audio that is played from this prefab is the audio placed in the inspector 
        audioSource.clip = audioClip;

        //To adjust the volume of the sound effect
        audioSource.volume = volume;

        //Play the audio source clip
        audioSource.Play();

        //Save the clip length, to know when to destroy the object
        float clipLenght = audioSource.clip.length;

        //Destroy the soundFXobject
        Destroy(audioSource.gameObject, clipLenght);
    }


}
