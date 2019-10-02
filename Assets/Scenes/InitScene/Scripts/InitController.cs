using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InitController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    /// Starts the game by moving to main scene.
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(Constants.Scenes.MainScene, LoadSceneMode.Single);
    }
}
