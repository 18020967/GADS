using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		GameObject.Find("Pass Button").GetComponent<Buttonhandler>().EnableButton();
		animator.SetBool("HasMana", true);

	}

	

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (GameObject.Find("GM").GetComponent<Placement>().Turn == "red")
		{
			
			animator.SetBool("IsWaiting", false);
		}
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
