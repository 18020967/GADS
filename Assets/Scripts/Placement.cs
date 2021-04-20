using UnityEngine;

public class Placement : MonoBehaviour
{
	public GameObject item;
	public GameObject item2;
	GameObject[,]CellsArray;
	Vector3 cellPos; 
	GameObject ClickUnit;

	//int MoveDistance = 5;

	string Turn = "blue";

	bool Distance = false;

	int x = 0;
	int y = 0;

	float Current_mana;
	float Max_mana;
	
	float Mana_cap = 10;
	


	// Start is called before the first frame update
	void Start()
    {
		Max_mana = 2;
		Current_mana = Max_mana;
		

		CellsArray = new GameObject[16, 16];

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				CellsArray[i, j] = Instantiate(item, new Vector3(i, 1, j), Quaternion.identity);
				CellsArray[i, j] = Instantiate(item2, new Vector3(i+12, 1, j+12), Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
		{
			cellPos = hit.transform.position + new Vector3(0, 1, 0);
			

			if ((hit.collider.tag == Turn))
			{
				ClickUnit = hit.collider.transform.gameObject;

				Debug.Log("Unit selected");


			}else if ((hit.collider.tag == "Mesh") && (ClickUnit != null))

			{
				CaculateDistance();
				PlaceUnit();
				
				
				Debug.Log("Cell selected  " + "  "+ cellPos.x+" "+  cellPos.z+" " + CellsArray[Mathf.RoundToInt(cellPos.x), Mathf.RoundToInt(cellPos.z)]);
			}else if((ClickUnit != null)&& (hit.collider.tag != "Mesh")&& (hit.collider.tag != Turn))
			{
				CaculateDistance();
				if ((Distance) && (Current_mana >= 1))
				{
					Destroy(hit.collider.gameObject);
					Distance = false;
					Current_mana--;
				}
				

				//PlaceUnit();
			}

		}
		GameObject go = GameObject.Find("Canvas");
		go.GetComponent<UI_Text>().UpdateScore(Max_mana,Current_mana);
	}
	void CaculateDistance()
	{
		float X;
		float Z;

		bool bX;
		bool bZ;

		X = ClickUnit.transform.position.x - cellPos.x;
		Z = ClickUnit.transform.position.z - cellPos.z;

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

	

	public void ChangeTurn()
	{
		if (Turn == "blue")
		{
			Turn = "red";
		}else
		{
			Turn = "blue";
		}
		Debug.Log("TurnChanged : " +Turn);

		if (Mana_cap > Max_mana)
		{
			Max_mana = Max_mana + 0.5f;
		}
		
		Current_mana = Max_mana;
	}

	void PlaceUnit()
	{
		if ((CellsArray[Mathf.RoundToInt(cellPos.x), Mathf.RoundToInt(cellPos.z)] == null) && (Distance == true)&&(Current_mana >=1))
		{
			CellsArray[Mathf.RoundToInt(ClickUnit.gameObject.transform.position.x), Mathf.RoundToInt(ClickUnit.gameObject.transform.position.z)] = null;

			ClickUnit.transform.position = cellPos;

			CellsArray[Mathf.RoundToInt(cellPos.x), Mathf.RoundToInt(cellPos.z)] = ClickUnit.gameObject;


			ClickUnit = null;
			Distance = false;
			Current_mana--;
		}
	}
}
