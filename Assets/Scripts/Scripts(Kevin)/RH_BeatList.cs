using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RH_BeatList : MonoBehaviour {

    public List<double> timings = new List<double>();
    public List<string> spawnLocation = new List<string>();
    public string fileName;
    int index = 0;
    public bool isDone = false;

    void Awake()
    {
        readFile(fileName);
        isDone = false;
        index = 0;
    }

	// Use this for initialization
	void OnEnable ()
    {
        isDone = false;
        index = 0;
    }

    public void readFile(string name)
    {
        if (name == null || name == "")
        {
            //have message say cannot find file or similar
            return;
        }

        TextReader tr = new StreamReader(name);
        string buffer;
        while ((buffer = tr.ReadLine()) != null)
        {
            string[] components = buffer.Split('|');
            timings.Add(float.Parse(components[0]));
            //string spawn;
            spawnLocation.Add(components[1]);
            /*if (int.TryParse(components[1], out spawn))
                spawnLocation.Add(spawn);
            else
            {
                Debug.LogError("Unexpected input error! Closing stream.");
                tr.Close();
                Debug.Break();
            }*/
            //timings.Add(float.Parse(buffer));
        }
        tr.Close();
    }

    public double nextTime()
    {
        double t = 5.0;
        Debug.Log("Index: " + index + " Count: " + timings.Count);
		if (index < timings.Count) {
			t = timings [index];
			index++;
		} else {
			isDone = true;
			FindObjectOfType<SceneController> ().SendMessage("BeatListDone");
		}
        return t;
    }

    public int getSTLength()
    {
        return timings.Count;
    }
}
