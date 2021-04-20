using UnityEngine;
using UnityEngine.UI;

public class UI_Text : MonoBehaviour
{

	public Text EnergyText;
	public Text PlayerText;
	public Text BUnitsText;
	public Text RUnitsText;
	public Text winner;
	public void UpdateScore(float Max_energy,float Current_energy,string player,int BUnit,int RUnit)
	{
		EnergyText.text = "Energy : " + Mathf.Floor(Max_energy).ToString() + "/" + Mathf.Floor(Current_energy).ToString();
		PlayerText.text = player + "'s Turn ";
		BUnitsText.text = "Blue Units : " + BUnit.ToString();
		RUnitsText.text = "Red Units : " + RUnit.ToString();
	}


	public void Winner(string team)
	{
		winner.text = team + " is the Winner!!!!";
	}

}
