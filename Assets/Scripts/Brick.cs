using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

	private int _hits;
	public Sprite [] HitSprites;

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
		int  maxHits = HitSprites.Length + 1;
		if(_hits >= maxHits)
		{
			//Destroy this game object if hits is equal to max hit allowed.
			Destroy(this.gameObject);
		} else {LoadSprites();}
	}
	//load sprites
	void LoadSprites()
	{
//		change thee sprite by how many times i have been hit and not by the length of my max hits
		int spriteIndex = _hits - 1;
		this.GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
	}
	//Load the next level
	private void MoveToNextLevel()
	{
		_levelManager.LoadNextLevel();

	}
}
