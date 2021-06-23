using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttonhandler : MonoBehaviour
{
	//Button to pass the turn to the other player
	public void PassTurn()
	{
		GameObject go = GameObject.Find("GM");
		go.GetComponent<Placement>().ChangeTurn();
	
		//Debug.Log("TurnChanged : " + PlayerTurn);
	}
	//Button to restart the Game
	public void RestartScene()
	{
		SceneManager.LoadSceneAsync("MainScene");
	}
	//Button to quit the game
	public void QuitGame()
	{
		Application.Quit();

	}


	public Button Button;

	public void DisableButton()
	{
		Button.interactable = false;
	}

	public void EnableButton()
	{
		Button.interactable = true;
	}
}
