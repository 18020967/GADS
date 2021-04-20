using UnityEngine;

public class Placement : MonoBehaviour
{
	public GameObject item;
	GameObject[,]CellsArray;
	Vector3 cellPos; 
	GameObject ClickUnit;


	bool Distance = false;

	int x = 0;
	int y = 0;

    // Start is called before the first frame update
    void Start()
    {
		CellsArray = new GameObject[16, 16];

		CellsArray[x, y] = Instantiate(item, new Vector3(x, 1, y), Quaternion.identity);

		CellsArray[15, 15] = Instantiate(item, new Vector3(15, 1, 15), Quaternion.identity);

	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
		{
			cellPos = hit.transform.position + new Vector3(0, 1, 0);
			

			if (hit.collider.tag != "Mesh")
			{
				ClickUnit = hit.collider.transform.gameObject;

				Debug.Log("Unit selected");


			}else if ((hit.collider.tag == "Mesh") && (ClickUnit != null))

			{
				CaculateDistance();


				if ((CellsArray[Mathf.RoundToInt(cellPos.x), Mathf.RoundToInt(cellPos.z)] == null)&&(Distance == true))
				{

						CellsArray[Mathf.RoundToInt(ClickUnit.gameObject.transform.position.x), Mathf.RoundToInt(ClickUnit.gameObject.transform.position.z)] = null;

						ClickUnit.transform.position = cellPos;

						CellsArray[Mathf.RoundToInt(cellPos.x), Mathf.RoundToInt(cellPos.z)] = ClickUnit.gameObject;

					
						ClickUnit = null;
						Distance = false;
				}
				
				Debug.Log("Cell selected  " + "  "+ cellPos.x+" "+  cellPos.z+" " + CellsArray[Mathf.RoundToInt(cellPos.x), Mathf.RoundToInt(cellPos.z)]);
			}

		}
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
}
