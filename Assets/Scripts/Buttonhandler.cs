using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonhandler : MonoBehaviour
{

	public void PassTurn()
	{
		GameObject go = GameObject.Find("GM");
		go.GetComponent<Placement>().ChangeTurn();
	
		//Debug.Log("TurnChanged : " + PlayerTurn);
	}

	public void RestartScene()
	{
		SceneManager.LoadScene("MainScene");
	}
}
