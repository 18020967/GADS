using UnityEngine;

public class Terrein_Generation : MonoBehaviour
{
	public GameObject Block_1;
	public GameObject Block_2;

	bool grid= false;
    //Using nested for loops to place the grid in a 16 x 16 pattern
    void Start()
    {
		for (int i = 0; i < 16; i++)
		{	
			for (int j = 0; j < 16; j++)
			{			
				if (grid)
				{
					Instantiate(Block_1, new Vector3(i, 0, j), Quaternion.identity);
					grid = false;
				}else if (!grid)
				{
					Instantiate(Block_2, new Vector3(i, 0, j), Quaternion.identity);
					grid = true;
				}					
			}
			if (grid == true)
			{
				grid = false;
			}
			else if (grid == false)
			{
				grid = true;
			}	
		}

		//for (int i2 = -1; i2 < 17; i2++)
		//{
		//	for (int j2 = -1; j2 < 17; j2++)
		//	{

		//	}
		//}
    }
}
