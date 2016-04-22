using UnityEngine;
using System.Collections;


public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer _instance = null;  //Meaning Is not pointing to anything to any object
                                            //everything created starts as null as a default. So is not needed to 
                                            // Pass it as a value.

    //Run before Start and just after an object is instantiated.
    private void Awake()
    {
        //Debug.Log("Music player is Awake: " + GetInstanceID());

        if (_instance != null) //If thee script is attached already to something
        {
            //Debug.Log("Music player Start: " + GetInstanceID()); //The id of the instance does not print to the console
            Destroy(gameObject); //Destroy the second instance of the game object.
        } else{ // If the instance is not attached to anything
            //print("We are unable to play the radio");
            _instance = this; // The instance is assigned this class instance.
            DontDestroyOnLoad(gameObject);
        }
    }
}
