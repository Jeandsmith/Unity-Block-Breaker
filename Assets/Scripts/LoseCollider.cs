using UnityEngine;
using System.Collections;

public class LoseCollider: MonoBehaviour
{
      
      private LevelManager _levelManager;

      //Check if the ball is triggered or not
      private void OnTriggerEnter2D(Collider2D loseColliderHit)
      {
            //This function will look for the object of type type when the game is active. If the object is active during run-time 
            //this function will return true.
            _levelManager = FindObjectOfType<LevelManager>();
            _levelManager.LoadLevel( "End" ); //Load the end level
      }
}
