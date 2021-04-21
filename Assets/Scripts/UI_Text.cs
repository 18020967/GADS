using UnityEngine;
using UnityEngine.UI;

public class UI_Text : MonoBehaviour
{
	//Variables for each of the text panels
	public Text EnergyText;
	public Text PlayerText;
	public Text BUnitsText;
	public Text RUnitsText;
	public Text winner;

	//Here we recieve the information about the game from the Placement script and use that information to display the information on 
	//the dedicated UI elements
	public void UpdateScore(float Max_energy,float Current_energy,string player,int BUnit,int RUnit)
	{
		EnergyText.text = "Energy : " + Mathf.Floor(Max_energy).ToString() + "/" + Mathf.Floor(Current_energy).ToString();
		PlayerText.text = player + "'s Turn ";
		BUnitsText.text = "Blue Units : " + BUnit.ToString();
		RUnitsText.text = "Red Units : " + RUnit.ToString();
	}

	// the same concept applies here
	public void Winner(string team)
	{
		winner.text = team + " is the Winner!!!!";
	}

}
