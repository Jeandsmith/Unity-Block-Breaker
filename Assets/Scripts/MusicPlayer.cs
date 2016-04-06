using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer instance = null;  //Meaning Is not pointing to anything to any object
    void Start()
    {
        if (instance != null) //There is an instance of the object
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
