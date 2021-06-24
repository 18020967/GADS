using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSingleplayer : MonoBehaviour
{
	[SerializeField]
	public Toggle toggle;
	void Start()
	{
		
		toggle.onValueChanged.AddListener(changeToggleEvent);
	
		var toggleActive = toggle.isOn;
		
		toggle.isOn = false;
	}
	void changeToggleEvent(bool isActive)
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
