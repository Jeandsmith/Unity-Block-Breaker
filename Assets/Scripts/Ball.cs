using UnityEngine;
using System.Collections;

public class Ball: MonoBehaviour
{

      public GameObject ParticleEffect;

      //Allow you to have access to the paddle class/Scrip and object. 
      private Paddle _paddle;
      //private Brick _brick;
      private bool _gameStarted;
      //Get the location of the paddles in relation to the ball
      private Vector3 _ballToPaddleVector;
      //Have control of the rigid body's properties
      private Rigidbody2D _ballRigidbody2D;
      // Use this for initialization
      private AudioSource _audioClip;
      private int _particleCount;
      private GameObject _particleClone;
      void Start()
      {
            //Find and returns the object of type (Data type);
            _paddle = GameObject.FindObjectOfType<Paddle>();
            _ballToPaddleVector = transform.position - _paddle.transform.position;
            _ballRigidbody2D = GetComponent<Rigidbody2D>();
            _audioClip = gameObject.GetComponent<AudioSource>();
      }

      // TODO keep coding 
      // Update is called once per frame
      void Update()
      {
            MoveBall();
      }


      void MoveBall()
      {
            //If the game has not started
            if ( !_gameStarted )
            {
                  //Lock the ball to relative position of the paddle
                  transform.position = _paddle.transform.position + _ballToPaddleVector;
                  //Wait for the mouse click then move the ball and set the game to true it has started.
                  if ( Input.GetMouseButtonDown( 0 ) )
                  {
                        _gameStarted = true;
                        _ballRigidbody2D.velocity = new Vector2( 2f, 10f );
                  }
            }
      }


      void OnCollisionEnter2D(Collision2D collision)
      {
            Vector2 tweakMovement = new Vector2( Random.Range( 0f, 0.2f ), Random.Range( 0f, 0.2f ) );
            if ( _gameStarted )  // If true. false if it has the (!) at the start.
            {
                  // Have the ball move in the scene
                  // Keep track of the particle when the ball hits something
                  // Play the hit sound
                  _ballRigidbody2D.velocity += tweakMovement;
                  KeepTrackOfParticles();
                  _audioClip.Play();
            }
      }


      void KeepTrackOfParticles()
      {
            //Save the particle clone
            //Increase the count of particle in the scene
            _particleClone = Instantiate( ParticleEffect, this.transform.position, this.transform.rotation ) as GameObject;
            _particleCount++;

            //Check if the count is more than 0
                  //if it is. Decrease the amount by 1;
                  //Destroy the clone
                  //Print the count
            if ( _particleCount >= 0 )
            {
                  _particleCount--;
                  Destroy( _particleClone, 1f );
                  print( _particleCount );
            }
      }


}
