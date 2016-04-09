using UnityEngine;


public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer _instance = null;  //Meaning Is not pointing to anything to any object

    //Run before Start and just after an object is instantiated.
    private void Awake()
    {
        Debug.Log("Music player is Awake: " + GetInstanceID());
        if (_instance != null) //If thee script is attached already to something
        {
            Debug.Log("Music player Start: " + GetInstanceID()); //The id of the instance does not print to the console
            Destroy(gameObject);
            print("Music Player Is Playing.");
        } else{ // If the instance is not attached to anything
                _instance = this;
                GameObject.DontDestroyOnLoad(gameObject);
              }
    }
}
