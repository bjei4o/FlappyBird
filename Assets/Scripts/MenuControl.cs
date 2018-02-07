using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControl : MonoBehaviour {

	public void NewGame(string sceneLoader)
	{		
		SceneManager.LoadScene (sceneLoader);
	}


	public void ExitGame()
	{		
		Application.Quit ();
	}


}
