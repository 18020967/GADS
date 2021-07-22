using UnityEditor;
using System.IO;
using UnityEngine;

public class Documentation
{
	public static void WriteString(string doc)
	{
		string path = Application.persistentDataPath + "/test.txt";
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
		string path = Application.persistentDataPath + "/test.txt";
		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path);
		Debug.Log(reader.ReadToEnd());
		reader.Close();
	}
}
