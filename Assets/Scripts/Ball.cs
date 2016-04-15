using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    //Allow you to have access to the paddle class/Scrip and object. 
	private Paddle Paddle;
    private bool _gameStarted = false;
	//Get the location of the paddles in relation to the ball
	private Vector3 _ballToPaddleVector;
	//Havee control of the rigidbody's properties
    private Rigidbody2D _ballRigidbody2D;
	// Use this for initialization
	void Start ()
	{
		//Find and returns the object of type (Data type);
		Paddle = GameObject.FindObjectOfType<Paddle>();
	    _ballToPaddleVector = this.transform.position - Paddle.transform.position;
	    _ballRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//If the game has not started
	    if (!_gameStarted)
	    {
            //Lock the ball to relative position of the paddle
            this.transform.position = Paddle.transform.position + _ballToPaddleVector;
            //Wait for the mouse click then move the ball and set the game to true it has started.
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse Pressed");
                _gameStarted = true;
                _ballRigidbody2D.velocity = new Vector2(2f, 10f);
            }
        }
	}
}
