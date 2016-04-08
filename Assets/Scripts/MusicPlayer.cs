using UnityEngine;


public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer _instance = null;  //Meaning Is not pointing to anything to any object

    //Run before Start and just after an object is instantiated.
    private void Awake()
    {
        Debug.Log("Music player is Awake: " + GetInstanceID());
        if (_instance != null) //There is an instance of the object
        {
            Debug.Log("Music player Start: " + GetInstanceID()); //The id of the instance does not print to the console
            Destroy(gameObject);
            print("Music Player Is Playing.");
        } else
        {
            _instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    //Run this at the start of the scene.
    void Start()
    {

    }

    // Run this every frame of the game
    private void Update()
    {

    }
}
