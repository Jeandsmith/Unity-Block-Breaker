using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    /*
        Collisions Practice
    */
    //Check for collision between the ball and the invisible floor.
    private void OnCollisionEnter2D(Collision2D theLoseColliision)
    {
        if (theLoseColliision.collider)  //Check if something has collided with me.
        {
            print("Ball Still Safe");
        }
    }

    //Check if the ball is triggered or not
    private void OnTriggerEnter2D(Collider2D theLoseCollider)
    {
        if (theLoseCollider)
        {
            // collider.IsTrigger will return true if i trigger the other object
            //The method alone with no addition will check if i was triggered.
            print("The Ball Has Fallen");
        }
    }
}
