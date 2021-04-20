using UnityEngine;

public class Terrein_Generation : MonoBehaviour
{
	public GameObject Block_1;
	public GameObject Block_2;

	bool grid= false;
    // Start is called before the first frame update
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
    }
}
