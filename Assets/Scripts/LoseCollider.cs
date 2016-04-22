using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
	/// <summary>
	/// The level manager.
	/// 	data type
	private LevelManager _levelManager;


//	//Check for collision between the ball and the invisible floor.
//		private void OnCollisionEnter2D(Collision2D loseCollision)
//	    {
//	       if (loseCollision.collider)  //Check if something has collided with me.
//	       {
//	            print("Ball Still Safe");
//	        }
//	    }

	//Check if the ball is triggered or not
	private void OnTriggerEnter2D (Collider2D loseColliderHit)
	{
		//This function will look for the object ot type Type when the game is active. If the object is active during run-time 
		//this function will return true.
		_levelManager = GameObject.FindObjectOfType<LevelManager> ();
		_levelManager.LoadLevel ("End"); //Load the end level
	}
}
