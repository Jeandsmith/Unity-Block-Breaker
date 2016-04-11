using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    //Allow you to have access to the paddle class/Scrip and object. 
    public Paddle Paddle;

    private bool _gameStarted = false;
    private Vector3 _paddleToBallVector;
    private Rigidbody2D _ballRigidbody2D;
	// Use this for initialization
	void Start ()
	{
	    _paddleToBallVector = this.transform.position - Paddle.transform.position;
	    _ballRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!_gameStarted)
	    {
            //Lock the ball to relative position of the paddle
            this.transform.position = Paddle.transform.position + _paddleToBallVector;
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
