using UnityEngine;
using System.Collections.Generic;

public class Placement : MonoBehaviour
{
	public GameObject item;
	public GameObject item2;
	public GameObject Obstacle;

	public GameObject[,]CellsArray;

	//==============================
	public Vector3 cellPos; 

	public GameObject ClickUnit;

	public List<GameObject> RedList = new List<GameObject>();
	public List<GameObject> BlueList = new List<GameObject>();
	//==============================


	public int Blue_Units = 0;
	public int Red_Units = 0;

	public string Turn = "blue";

	public string word;

	public bool Distance = false;

	public float Current_mana;
	public float Max_mana;

	public float Mana_cap = 10;

	// Start is called before the first frame update
	void Start()
    {
		
		StartGame();
		

	}

	// Update is called once per frame
	void Update()
	{
		//ray casting to check what the player is selecting
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
		{
			cellPos = hit.transform.position + new Vector3(0, 1, 0);
			

			if ((hit.collider.tag == Turn))
			{
				ClickUnit = hit.collider.transform.gameObject;

				//Debug.Log("Unit selected");


			}else if ((hit.collider.tag == "Mesh") && (ClickUnit != null))

			{
				CaculateDistance();
				PlaceUnit(cellPos,ClickUnit);
				
				
				//Debug.Log("Cell selected  " + "  "+ cellPos.x+" "+  cellPos.z+" " + CellsArray[Mathf.RoundToInt(cellPos.x), Mathf.RoundToInt(cellPos.z)]);
			}else if((ClickUnit != null)&& (hit.collider.tag != "Mesh")&& (hit.collider.tag != Turn))
			{
				
				CaculateDistance();
				if ((Distance) && (Current_mana >= 1))
				{
					Destroy(hit.collider.gameObject);
					Distance = false;
					if (hit.collider.tag == "red")
					{
						RedList.Remove(hit.collider.gameObject);
						Red_Units--;
					}else if (hit.collider.tag == "blue")
					{
						BlueList.Remove(hit.collider.gameObject);
						Blue_Units--;
					}

					Current_mana--;
				}
				

				//PlaceUnit();
			}

		}
		GameObject go = GameObject.Find("Canvas");
		go.GetComponent<UI_Text>().UpdateScore(Max_mana,Current_mana,Turn,Blue_Units,Red_Units);

		//Simple if statements to check how many units are left on the board
		//if one player is left standing with units it calls the function of Winner in the other script
		if (Red_Units <=0)
		{
			Debug.Log("Blue Wins");
			
			go.GetComponent<UI_Text>().Winner("Blue");
			go.GetComponent<Animator>().SetBool("IsWaiting", true);
		}

		if (Blue_Units <=0)
		{
			Debug.Log("Red Wins");
			go.GetComponent<UI_Text>().Winner("Red");
			go.GetComponent<Animator>().SetBool("IsWaiting", true);
		}


	




	}
	void CaculateDistance()
	{
		float X;
		float Z;

		bool bX;
		bool bZ;
		//caculates the distance between the current unit position and where the player wants it to go
		X = ClickUnit.transform.position.x - cellPos.x;
		Z = ClickUnit.transform.position.z - cellPos.z;
		//checks here if it is within range of where the player wants it
		if ((X == -1) || (X == 0) || (X == 1))
		{
			bX = true;
		}
		else
		{
			bX = false;
		}

		if ((Z == -1) || (Z == 0) || (Z == 1))
		{
			bZ = true;
		}
		else
		{
			bZ = false;
		}

		if (bZ && bX)
		{
			Distance = true;
		}
	}

	
	//simple cript to change the player to the next players turn, this information is used for the UI and various other code
	public void ChangeTurn()
	{
		if (Turn == "blue")
		{
			Turn = "red";
		}else
		{
			Turn = "blue";
		}
		//Debug.Log("TurnChanged : " +Turn);
		//Increases the amount of moves a player can make each turn every +1 means an extra turn, i use code to remove decimals 
		//this allows me to increase energy ever time the players hits the pass button
		//the reason why i did it like this is to allow me to share the variables between teams
		if (Mana_cap > Max_mana)
		{
			Max_mana = Max_mana + 0.5f;
		}
		
		Current_mana = Max_mana;
		ClickUnit = null;
		Distance = false;
	}

	public void PlaceUnit(Vector3 Cellpos, GameObject Unit)
	{


		//This statement checks if the block where the player wants to place a unit is clear
		//it also checks if the block is next to the player
		//and looks to see if the player has the resources to place the unit
		if ((CellsArray[Mathf.RoundToInt(Cellpos.x), Mathf.RoundToInt(Cellpos.z)] == null) && (Distance == true)&&(Current_mana >=1))
		{
			//This clears the previous position of the unit in the arry
			CellsArray[Mathf.RoundToInt(Unit.gameObject.transform.position.x), Mathf.RoundToInt(Unit.gameObject.transform.position.z)] = null;
			//moves the unit to new location
			Unit.transform.position = Cellpos;
			//Fills the array with the new unit location
			CellsArray[Mathf.RoundToInt(Cellpos.x), Mathf.RoundToInt(Cellpos.z)] = Unit.gameObject;


			ClickUnit = null;
			Distance = false;
			Current_mana--;
		}
	}

	void StartGame()
	{
		//The array here is cleared to make room for units in the next round to start
		CellsArray = new GameObject[16, 16];
		Max_mana = 2;
		Current_mana = Max_mana;

		//This places 16 units on each of the players side of the map
		
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				CellsArray[i, j] = Instantiate(item, new Vector3(i, 1, j), Quaternion.identity);
				BlueList.Add(CellsArray[i, j]);
				//word = i.ToString() + ":" + j.ToString();
				CellsArray[i + 12, j + 12] = Instantiate(item2, new Vector3(i + 12, 1, j + 12), Quaternion.identity);
				RedList.Add(CellsArray[i+12, j+12]);
				//word = i + 12.ToString() + ":" + j + 12.ToString();
				Red_Units++;
				Blue_Units++;
			}
		}
		//This snip of code will place the Obstacles of the game in the center of the map
		//nested if statement used to place Obstacles in a Square pattern and also stores them in a 2D array
		for (int i1 = 5; i1 < 11; i1++)
		{
			for (int i2 = 5; i2 < 11; i2++)
			{
				CellsArray[i1, i2] = Instantiate(Obstacle, new Vector3(i1, 1, i2), Quaternion.identity);
			}
		}

		//a Random number generator to decide who will start the game first
		var number = Random.Range(0, 11);
		if (number> 5)
		{
			Turn = "red";
		}else if((number < 5))
		{
			Turn = "blue";
		}



	}


}
