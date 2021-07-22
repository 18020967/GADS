using UnityEditor;
using System.IO;
using UnityEngine;

public class MachineLearning : MonoBehaviour
{

	public GameObject GAMEMANAGER;

	public string Documentation = "";
	string score;

	int Scores;

	int PickScore = 0;
	int MoveScore = 0;

	int xpoint;
	int zpoint;

	public bool AIAdvanced = false;

	GameObject MovingUnit;
	GameObject Target;
	public int itemIndex = 15;
	GameObject nearestObj = null;
	public GameObject SelectedUnit;


	public void AdvancedMode()
	{
		
		
			AIAdvanced = true;
		
	}

	private void Start()
	{
		AIAdvanced = false;
	}


	void Update()
    {
		GameObject GM = GameObject.Find("GM");
		PickScore = 0;

		Vector3 targetPoint;
		

		if ((GM.GetComponent<Placement>().Turn == "blue")&& AIAdvanced )
		{
			//Debug.Log(GM.GetComponent<Placement>().Turn + " " + AIAdvanced);
			if (GM.GetComponent<Placement>().Current_mana >= 1)
			{
				//choose unit


				
				

				Placement PlacmentScript = GM.GetComponent<Placement>();

				MovingUnit = PlacmentScript.BlueList[itemIndex];





				MoveScore = 0;
				GameObject go = GameObject.Find("GM");
				foreach (var REDUnit in go.GetComponent<Placement>().RedList)
				{
					var nearestDist = float.MaxValue;
					nearestObj = null;
					foreach (var BLUEUnit in go.GetComponent<Placement>().BlueList)
					{
						if ((Vector3.Distance(REDUnit.transform.position, BLUEUnit.transform.position) < nearestDist) && (REDUnit != null) && (BLUEUnit != null))
						{
							nearestDist = Vector3.Distance(REDUnit.transform.position, BLUEUnit.transform.position);
							nearestObj = BLUEUnit;
						}
					}
					SelectedUnit = nearestObj;
					GameObject.Find("GM").GetComponent<StateMachineHelper>().SelectUnit = SelectedUnit;

					Debug.DrawLine(REDUnit.transform.position, nearestObj.transform.position, Color.red);
				}








				if (MovingUnit == nearestObj)
				{
					PickScore += 1;
				}
				else
				{
					PickScore -= 1;
				}

				//Debug.Log(MovingUnit+" "+ MovingUnit.transform.position);
				//Debug.Log(PickScore);
				


				go.GetComponent<Placement>().Distance = true;


				xpoint = Random.Range(-1, 2);
				zpoint = Random.Range(-1, 2);

				targetPoint = new Vector3(MovingUnit.transform.position.x+xpoint, 1, MovingUnit.transform.position.z + zpoint);

				//Placing unit

				if (go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)] == null)
				{
					go.GetComponent<Placement>().PlaceUnit(targetPoint, MovingUnit);
				}
				else if(go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)] != null)
				{
					if (go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)].tag == "red")
					{
						go.GetComponent<Placement>().Red_Units--;
						Destroy(go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)]);
						go.GetComponent<StateMachineHelper>().TargetUnit = null;
					}
					if (go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)].tag == "obstacle")
					{
						Destroy(go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)]);
						go.GetComponent<StateMachineHelper>().TargetUnit = null;
					}
					go.GetComponent<Placement>().RedList.Remove(go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)]);
					go.GetComponent<Placement>().CellsArray[Mathf.RoundToInt(targetPoint.x), Mathf.RoundToInt(targetPoint.z)] = null;
					go.GetComponent<Placement>().Current_mana--;

				}
				go.GetComponent<Placement>().Distance = false;

				if (xpoint <=0)
				{
					MoveScore++;
				}
				else if (xpoint == -1)
				{
					MoveScore--;
				}
				if (zpoint <= 0)
				{
					MoveScore++;
				}
				else if (zpoint == -1)
				{
					MoveScore--;
				}
			}
			else if (GM.GetComponent<Placement>().Current_mana < 1)
			{
				Documentation = "";
				Documentation =MovingUnit.name+":"+MoveScore.ToString()+";"+ xpoint.ToString()+":"+zpoint.ToString();
				Debug.Log(Documentation);

				WriteString(Documentation);


				GM.GetComponent<Placement>().ChangeTurn();
			}
		}
    }



	public static void WriteString(string doc)
	{
		string path = "Assets/Documentation.txt";
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine(doc);
		writer.Close();

		StreamReader reader = new StreamReader(path);
		//Print the text from the file
		Debug.Log(reader.ReadToEnd());
		reader.Close();
	}

	public static void ReadString()
	{
		string path = "Assets/Documentation.txt";
		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path);
		Debug.Log(reader.ReadToEnd());
		reader.Close();
	}






}
