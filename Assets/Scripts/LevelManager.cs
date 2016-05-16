using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager: MonoBehaviour
{
      //Load level
      public void LoadLevel(string name)
      {
            //Print the request for a new level
            //Load that scene by name
            Debug.Log( "New Level load: " + name );
            SceneManager.LoadScene( name );
      }


      public void QuitRequest()
      {
            //Quit the game
            Debug.Log( "Quit requested" );
            Application.Quit();
      }


      public void LoadNextLevel()
      {
            //With this line of code, I will get the active scene I am on and add one.
            //This will add one to the build index or number of where the scene is resulting on jumping to the next level.
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
      }


      public void LastBrickDestroy()
      {
            //Load the next game level if the amount of brick in the scene is 0
            if ( Brick.BrokenBrickCount <= 0 )
            {
                  LoadNextLevel();
            }
      }


}
