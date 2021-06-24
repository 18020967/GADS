using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing : StateMachineBehaviour
{
	Vector3 movingPoint;
	Vector3 targetPoint;


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movingPoint.Set(0, 0, 0);
		GameObject go = GameObject.Find("GM");
		if (go.GetComponent<StateMachineHelper>().BotDestination.x > 0)
		{
			movingPoint.x = -1;
			setZ();
		}
		else if (go.GetComponent<StateMachineHelper>().BotDestination.x < 0)
		{
			movingPoint.x = 1;
			setZ();
		}else if (go.GetComponent<StateMachineHelper>().BotDestination.x == 0)
		{
			movingPoint.x = 0;
			setZ();
		}

		targetPoint = go.GetComponent<StateMachineHelper>().SelectUnit.transform.position + movingPoint;

		Debug.Log("Move point" + movingPoint);

		animator.SetBool("HasTarget", false);
		
		if (GameObject.Find("GM").GetComponent<Placement>().Current_mana >= 1)
		{

			go.GetComponent<Placement>().Distance = true;

			//Placing unit
			if (go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)] == null)
			{
				go.GetComponent<Placement>().PlaceUnit(targetPoint, go.GetComponent<StateMachineHelper>().SelectUnit);
			}
			else
			{
				Destroy(go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)]);
				go.GetComponent<StateMachineHelper>().TargetUnit = null;
				go.GetComponent<Placement>().BlueList.Remove(go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)]);
				go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)] = null;
				go.GetComponent<Placement>().Current_mana--;
			}
			go.GetComponent<Placement>().Distance = false;
				
		}
		else
		{
			go.GetComponent<Placement>().ChangeTurn();					
			animator.SetBool("IsWaiting", true);
			animator.SetBool("HasMana", false);
		}
	}


	void setZ()
	{
		GameObject go = GameObject.Find("GM");
		if (go.GetComponent<StateMachineHelper>().BotDestination.z > 0)
		{
			movingPoint.z = -1;


		}
		else if (go.GetComponent<StateMachineHelper>().BotDestination.z < 0)
		{
			movingPoint.z = 1;
		}else if (go.GetComponent<StateMachineHelper>().BotDestination.z == 0)
		{
			movingPoint.z = 0;
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
