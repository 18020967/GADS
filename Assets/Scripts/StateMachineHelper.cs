using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineHelper : MonoBehaviour
{
	[SerializeField]

	public GameObject SelectUnit;

	public Vector3 BotDestination;

	public GameObject TargetUnit;


	public bool easy = false;



	public void EasyMode()
	{
		if (!easy){
			easy = true;
		}
		else if(easy)
		{
			easy = false;
		}
	}


	private void Update()
	{
		if (TargetUnit != null && SelectUnit != null)
		{
			GameObject go = GameObject.Find("GM");
			

			Debug.DrawLine(SelectUnit.transform.position, TargetUnit.transform.position, Color.red);
		}else if(TargetUnit == null && SelectUnit == null)
		{
			return;
		}
	}


}
