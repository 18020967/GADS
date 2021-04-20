using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Text : MonoBehaviour
{

	public Text myText;
	public void UpdateScore(float Max_energy,float Current_energy)
	{
		myText.text = "Energy : " + Mathf.Floor(Max_energy).ToString() + "/" + Mathf.Floor(Current_energy).ToString();
	}
}
