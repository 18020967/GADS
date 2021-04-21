using UnityEngine;
using UnityEngine.SceneManagement;

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
}
