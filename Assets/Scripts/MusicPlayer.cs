using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer instance = null;  //Meaning Is not pointing to anything to any object

    //Run before Start and just after an object is instantiated.
    private void Awake()
    {
       Debug.Log("Music player is Awake" + GetInstanceID()); 
    }

    //Run this at the start of the scene.
    void Start()
    {
        if (instance != null) //There is an instance of the object
        {
            Debug.Log("Music player Start" + GetInstanceID());
            Destroy(gameObject);
            print("Music Player Is Playing.");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Run this every frame of the game
    private void Update()
    {
        
    }
}
