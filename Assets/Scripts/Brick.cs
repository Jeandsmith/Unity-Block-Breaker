using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick: MonoBehaviour
{

      //Publics
      public Sprite [] HitSprites;  //Get  all the sprites of the brick.
      public static int BrokenBrickCount; //This variable is static in order for me to be able to easily use it within other LevelManager Class.
      public AudioClip CrackSound;  //get the audio sound of the brick

      //privates 
      private int _hits; //Manage how many hits the brick is able to take
      private Brick _bricks; //reference the brick class
      private LevelManager _levelManager; //Reference the LevelManager Class
      private bool _isBreakable; // Check if a brick is able to be broken

      void Start()
      {
            _isBreakable = ( tag == "Breakable" ); //Check if the tag of this class is equals "Breakable"

            //if the brick is able to be broken.
            if ( _isBreakable )
            {
                  BrokenBrickCount++; //Increase the brick count by 1;
                  print( "Breakable count: " + BrokenBrickCount ); //Print out the value
            }
            _bricks = FindObjectOfType<Brick>(); //Search for all the Brick class on the scene
            _levelManager = FindObjectOfType<LevelManager>();  //Search for all instances of the class
      }


      //Run this every frame
      void Update()
      {

      }


      //Check if this objects has been collided with.
      private void OnCollisionEnter2D(Collision2D other)
      {
            //Player the crack sound every time this game instance is collided with. 
            AudioSource.PlayClipAtPoint( CrackSound, transform.position, .25f );

            //If the brick is breakable
            if ( _isBreakable )
            {
                  BrickHitManager();// Run the hit function 
            }
      }


      private void BrickHitManager()
      {
            _hits++; //The hit increase to the brick increase by one.
            int maxHits = HitSprites.Length + 1; // Use the amount of sprite as the max amount of hits
                                                 // the brick is able to take.

            if ( _hits >= maxHits ) // If the current hits of the bricks is equals the max amount of hits
            {
                  BrokenBrickCount--; //Decrease the amount of bricks in the scene
                  if ( BrokenBrickCount <= 0 ) // If the amount of bricks in the scene is less than or equals to 0
                  {
                        BrokenBrickCount = 0; //The count of brick is assigned 0;
                  }
                  _levelManager.LastBrickDestroy(); // load the LastBrickDestroy function
                  Destroy( gameObject ); //Destroy this instance of the game object
            } else // Or, if the hits is not equal to the max hits
            {
                  LoadSprites(); // Load the next sprite.
            }
      }


      //load sprites
      private void LoadSprites()
      {
            //change thee sprite by how many times i have been hit and not by the length of my max hits   
            int spriteIndex = _hits - 1;
            if ( HitSprites [ spriteIndex ] == true ) //If the sprite exits. Not null
            {
                  //Checks if the index of the array contains an sprite. If not, nothing will happen.
                  gameObject.GetComponent<SpriteRenderer>().sprite = HitSprites [ spriteIndex ];
            }
      }


}
