using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : StateMachineBehaviour
{

	public GameObject targetUnit;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GameObject go = GameObject.Find("GM");
		var nearestDist1 = float.MaxValue;
		GameObject nearestObj1 = null;
		foreach (var blueUnit in go.GetComponent<Placement>().BlueList)
		{
			if (Vector3.Distance(go.GetComponent<StateMachineHelper>().SelectUnit.transform.position, blueUnit.transform.position) < nearestDist1)
			{
				nearestDist1 = Vector3.Distance(go.GetComponent<StateMachineHelper>().SelectUnit.transform.position, blueUnit.transform.position);
				nearestObj1 = blueUnit;
			}
		}
		targetUnit = nearestObj1;
		go.GetComponent<StateMachineHelper>().TargetUnit = targetUnit;

		if (go.GetComponent<Placement>().BlueList != null) ;
		{


			go.GetComponent<StateMachineHelper>().BotDestination = go.GetComponent<StateMachineHelper>().SelectUnit.transform.position - targetUnit.transform.position;
			Debug.Log("Destination point" + go.GetComponent<StateMachineHelper>().BotDestination);
		}

	}




	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		
		animator.SetBool("HasTarget", true);
		animator.SetBool("HasChosen", false);
	}



	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		

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
