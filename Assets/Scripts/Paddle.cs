using UnityEngine;
using System.Collections;

public class Paddle: MonoBehaviour
{
      //The default value of the boolean is alway false
      public bool GameAutoPlay; //Check if the paddle is on auto move

      private Ball _ball;  //Reference to the ball class 

      void Start()
      {
            //Find the object of the ball at the start of the game and assign it to the _ball variable.
            _ball = FindObjectOfType<Ball>();
      }
      // Update is called once per frame
      void Update()
      {
            if ( !GameAutoPlay ) //If auto play is false or the public check box is not checked
            {
                  MoveWithMouse(); //give control of the paddle to the player
            } else
            {
                  AutoPlay(); // Have the game play on it's own
            }
      }

      void AutoPlay()
      {
            //Pass the current position of the ball to the paddle
            // this instance of the paddle is equal to the ball position
            Vector2 ballPos = _ball.transform.position;
            Vector2 paddlePos = new Vector2( 8f, 0.5f );
            paddlePos.x = Mathf.Clamp( ballPos.x, 0f, 15f ) - 0.5f;
            gameObject.transform.position = paddlePos;
      }

      void MoveWithMouse()
      {
            //Get the current position of the mouse cursor 
            //Assigned the position of the mouse to the brick for the brick to fallow
            //Assign the value of the cursor to this game object.
            float mousePosInBlocks = ( Input.mousePosition.x / Screen.width ) * 16f;
            Vector2 paddlePos = new Vector2( 8f, 0.5f );
            paddlePos.x = Mathf.Clamp( mousePosInBlocks, 0f, 15f );
            gameObject.transform.position = paddlePos;
      }
}
