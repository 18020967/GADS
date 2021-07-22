using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{

	[SerializeField]
	public Toggle toggle;
	[SerializeField]
	public Toggle toggleEasy;
	[SerializeField]
	public Toggle toggleAdvanced;

	public bool easyMode = false;

	public bool advanced = false;




	private void Start()
	{
		toggle.isOn = false;
		toggleAdvanced.isOn = false;

		toggleEasy.isOn = false;
	}

	public void StartGame()
	{


		var toggleActive = toggle.isOn;

		easyMode = toggleEasy.isOn;

		if (toggleAdvanced.isOn == true)
		{
			GameObject.Find("AdvancedAI").GetComponent<MachineLearning>().AdvancedMode();
		}

		advanced = toggleAdvanced.isOn;

		//toggle.onValueChanged.AddListener(changeToggleEvent);
		changeToggleEvent(toggleActive);

		toggle.isOn = false;

		if (easyMode)
		{
			GameObject.Find("GM").GetComponent<StateMachineHelper>().EasyMode();
		}

		//if (toggleAdvanced == true)
		//{
		//	GameObject.Find("AdvancedAI").GetComponent<MachineLearning>().AdvancedMode();
		//}

		toggleAdvanced.isOn = false;

		toggleEasy.isOn = false;

		GameObject.Find("MainMenu").SetActive(false);


	}

	public void changeToggleEvent(bool isActive)
	{
		GameObject go = GameObject.Find("GM");
		if (isActive == true)
		{
			go.GetComponent<Animator>().SetBool("IsWaiting", true);
			go.GetComponent<Animator>().SetBool("Singleplayer", true);
			toggle.enabled = false;
		}
		else
		{
			go.GetComponent<Animator>().SetBool("Singleplayer", false);
		}


	}
}
