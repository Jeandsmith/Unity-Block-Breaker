using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

	public void LoadNextLevel()
	{
		//With this line of code, I will get the active scene I am on and add one.
		//This will add one to the build index or number of where the scene is resulting on jumping to the next level.
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LastBrickDestroy()
	{
		if(Brick.BreakableCount <= 0)
		{
			LoadNextLevel();
		}
	}
}
