using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Check for collision between the ball and the invisible floor.
    private void OnCollisionEnter2D(Collision2D theLoseColliision)
    {
        if (theLoseColliision.collider)  //Check if something has collided with me.
        {
            print("Collision has happened.");
        }
    }

    //Check if the ball is triggered or not
    private void OnTriggerEnter2D(Collider2D theLoseCollider)
    {
        if (theLoseCollider)
        {
            // collider.IsTrigger will return true if i trigger the other object
            //The method alone with no addition will check if i was triggered.
            print("This i have trigger checked and will ignore collision.");
        }
    }
}
