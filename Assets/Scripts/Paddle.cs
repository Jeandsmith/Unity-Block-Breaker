using UnityEngine;

public class Paddle : MonoBehaviour {


	// Update is called once per frame
	void Update ()
	{
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width) * 16f;
        Vector2 paddlePos = new Vector2(8f, 0.5f); 
	    paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 15f);
        gameObject.transform.position = paddlePos; 
    }
}
