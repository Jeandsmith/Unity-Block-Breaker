using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int _hits;
	public int _maxHits = 2;

	private Brick _bricks;
	private LevelManager _levelManager;

	void Start()
	{
		_bricks = GameObject.FindObjectOfType<Brick>();
		_levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	//Check if this objects has been collided with.
	private void OnCollisionEnter2D(Collision2D other)
	{
		_hits++;
		//Check if that was the last brick
		BrickHitManager();
	}

	private void BrickHitManager()
	{
		if(_hits >= _maxHits)
		{
			//Destroy this game object if hits is equal to max hit allowed.
			Destroy(this.gameObject);
		}
	}
	private void MoveToNextLevel()
	{
		_levelManager.LoadNextLevel();
	}
}
