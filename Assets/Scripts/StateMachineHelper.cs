using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineHelper : MonoBehaviour
{
	[SerializeField]

	public GameObject SelectUnit;

	public Vector3 BotDestination;

	public GameObject TargetUnit;

	private void Update()
	{
		if (TargetUnit != null && SelectUnit != null)
		{
			GameObject go = GameObject.Find("GM");
			

			Debug.DrawLine(SelectUnit.transform.position, TargetUnit.transform.position, Color.red);
		}
	}


}
