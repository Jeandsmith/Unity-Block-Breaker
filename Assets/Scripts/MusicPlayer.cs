using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer instance = null;  //Is not referring to any object
    void Start()
    {
        if (instance != null) //There is an instance of the object
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
