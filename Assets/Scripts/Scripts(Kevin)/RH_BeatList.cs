using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RH_BeatList : MonoBehaviour {

    public List<float> timings = new List<float>();
    public string fileName;
    int index = 0;

    void Awake()
    {
        readFile(fileName);
    }

	// Use this for initialization
	void OnEnable ()
    {
        index = 0;
	}

    public void readFile(string name)
    {
        if (name == null || name == "")
        {
            //have message say
            return;
        }

        TextReader tr = new StreamReader(name);
        string buffer;
        while ((buffer = tr.ReadLine()) != null)
        {
            timings.Add(float.Parse(buffer));
        }
        tr.Close();
    }

    public float nextTime()
    {
        float t = timings[index];
        if (index < timings.Count)
            index++;
        return t;
    }
}
