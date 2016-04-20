using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{

    public Sprite[] HitSprites;
	public static int _breakableCount;

    private int _hits;
    private Brick _bricks;
    private LevelManager _levelManager;
	private Ball ball;
	private bool isBreakable;

    void Start()
    {
		isBreakable = (this.tag == "Breakable");
		//Keep track of the breakable bricks
		if(isBreakable)
		{
			_breakableCount++;
		}
        _bricks = GameObject.FindObjectOfType<Brick>();
        _levelManager = GameObject.FindObjectOfType<LevelManager>();
		_breakableCount = 0;
    }

	//Run this every frame
	void Update()
	{
		
	}
    //Check if this objects has been collided with.
    private void OnCollisionEnter2D(Collision2D other)
    {
		if (isBreakable)
		{
			BrickHitManager();
		}
		//BrickHitManager();
    }
	private void BrickHitManager()
    {
        _hits++;
        int maxHits = HitSprites.Length + 1;
        if (_hits >= maxHits)
        {
			_breakableCount--;
			if(_breakableCount <= 0) {_breakableCount = 0;}
			_levelManager.LastBrickDestroy();
            Destroy(gameObject);
			print("Brick Destroy: " + _breakableCount);
        } else { LoadSprites(); }
    }
    //load sprites
    private void LoadSprites()
    {
        //change thee sprite by how many times i have been hit and not by the length of my max hits   
        int spriteIndex = _hits - 1;
        if (HitSprites[spriteIndex] == true) //Checks if the index of the array contains an sprite. If not, nothing will happen.
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
        }
    }
}
