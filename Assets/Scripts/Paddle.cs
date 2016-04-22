using UnityEngine;

public class Paddle : MonoBehaviour
{
    //The default value of the boolean is alway false
    public bool GameAutoPlay;

    private Ball _ball;

    void Start()
    {
        //Find the object of the ball at the start of the game and assign it to the _ball variable.
        _ball = GameObject.FindObjectOfType<Ball>();
    }
	// Update is called once per frame
	void Update ()
	{
	    if (!GameAutoPlay) //If auto play is false or the public check box is not checked
	    {
	        MoveWithMouse();
	    }
	    else
	    {
	        AutoPlay();
	    }
	}

    void AutoPlay()
    {
        Vector2 ballPos = _ball.transform.position;
        Vector2 paddlePos = new Vector2(8f, 0.5f);
        paddlePos.x = Mathf.Clamp(ballPos.x, 0f, 15f) - 0.5f;
        gameObject.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16f;
        Vector2 paddlePos = new Vector2(8f, 0.5f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 15f);
        gameObject.transform.position = paddlePos;
    }
}
