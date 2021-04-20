using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonhandler : MonoBehaviour
{
	bool PlayerTurn = false;

	
	//public GameObject GM;

	public void PassTurn()
	{
		GameObject go = GameObject.Find("GM");
		go.GetComponent<Placement>().ChangeTurn();


		
		//Debug.Log("TurnChanged : " + PlayerTurn);
	}
}
