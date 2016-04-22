using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{

	public Sprite[] HitSprites;
	public static int BreakableCount; //This variable is static in order for me to be able to easily use it within other LevelManager Class.
    public AudioClip CrackSound;

	private int _hits;
	private Brick _bricks;
	private LevelManager _levelManager;
	private bool _isBreakable;

	void Start ()
	{
		_isBreakable = (this.tag == "Breakable");
		//Keep track of the bricks
		if (_isBreakable) 
		{
			BreakableCount++;
			print ("Breakable count: " + BreakableCount);
		}
		_bricks = GameObject.FindObjectOfType<Brick> ();
		_levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	//Run this every frame
	void Update ()
	{
		
	}
	//Check if this objects has been collided with.
	private void OnCollisionEnter2D (Collision2D other)
	{
        AudioSource.PlayClipAtPoint(CrackSound, gameObject.transform.position, .25f);
		if (_isBreakable)
		{
			BrickHitManager ();
		}
	}

	private void BrickHitManager ()
	{
		_hits++;
		int maxHits = HitSprites.Length + 1;
		if (_hits >= maxHits)
		{
			BreakableCount--;
			if (BreakableCount <= 0) 
			{
				BreakableCount = 0;
			}
			_levelManager.LastBrickDestroy ();
			Destroy (gameObject);
			//print("Brick Destroy: " + BreakableCount);
		} else 
		{
			LoadSprites ();
		}
	}
	//load sprites
	private void LoadSprites ()
	{
		//change thee sprite by how many times i have been hit and not by the length of my max hits   
		int spriteIndex = _hits - 1;
		if (HitSprites [spriteIndex] == true) 
		{ 
            //Checks if the index of the array contains an sprite. If not, nothing will happen.
			gameObject.GetComponent<SpriteRenderer> ().sprite = HitSprites [spriteIndex];
		}
	}
}
