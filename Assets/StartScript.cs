using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{

	[SerializeField]
	public Toggle toggle;

	

	public void StartGame()
	{

		GameObject go = GameObject.Find("SinglePlayer");


		

		var toggleActive = toggle.isOn;

		//toggle.onValueChanged.AddListener(changeToggleEvent);
		changeToggleEvent(toggleActive);

		toggle.isOn = false;

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
