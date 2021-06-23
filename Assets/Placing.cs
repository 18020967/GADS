using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing : StateMachineBehaviour
{
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("HasTarget", false);
		GameObject go = GameObject.Find("GM");
		if ((GameObject.Find("GM").GetComponent<Placement>().Current_mana >= 1))
		{

			go.GetComponent<StateMachineHelper>().SelectUnit.transform.position =
				go.GetComponent<StateMachineHelper>().SelectUnit.transform.position - new Vector3(0, 0, 1);
			go.GetComponent<Placement>().ClickUnit = null;
			go.GetComponent<Placement>().Distance = false;
			go.GetComponent<Placement>().Current_mana--;
		}
		else//(GameObject.Find("GM").GetComponent<Placement>().Current_mana <= 0.5)
		{

			go.GetComponent<Placement>().ChangeTurn();
						
			animator.SetBool("IsWaiting", true);
			animator.SetBool("HasMana", false);

		}
	}


	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	



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
