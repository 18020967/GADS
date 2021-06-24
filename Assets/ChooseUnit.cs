using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseUnit : StateMachineBehaviour
{
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		GameObject.Find("Pass Button").GetComponent<Buttonhandler>().DisableButton();
	}


	public GameObject SelectedUnit;
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{


		GameObject go = GameObject.Find("GM");
		foreach (var blueUnit in go.GetComponent<Placement>().BlueList)
		{
			var nearestDist = float.MaxValue;
			GameObject nearestObj = null;
			foreach (var redUnit in go.GetComponent<Placement>().RedList)
			{
				if ((Vector3.Distance(blueUnit.transform.position, redUnit.transform.position) < nearestDist)&&(blueUnit !=null)&& (redUnit != null))
				{
					nearestDist = Vector3.Distance(blueUnit.transform.position, redUnit.transform.position);
					nearestObj = redUnit;
				}
			}
			SelectedUnit = nearestObj;
			GameObject.Find("GM").GetComponent<StateMachineHelper>().SelectUnit = SelectedUnit;

			Debug.DrawLine(blueUnit.transform.position, nearestObj.transform.position, Color.red);
		}
	

		if (SelectedUnit != null)
		{			
			animator.SetBool("HasChosen", true);
		}
	}
	
	

	

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	//Debug.Log(SelectedUnit.name +' '+ SelectedUnit.transform.position);
	//	SelectedUnit.transform.position = SelectedUnit.transform.position - new Vector3(0, 0, 1);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove()
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that processes and affects root motion
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK()
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that sets up animation IK (inverse kinematics)
	//}
}
