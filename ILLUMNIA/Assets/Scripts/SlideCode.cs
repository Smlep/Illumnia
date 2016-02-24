using UnityEngine;
using System.Collections;

public class SlideCode : MonoBehaviour {
    public bool signal1;
    public bool signal2;
    public bool signal3;
    public bool signal4;
    private bool stop;
    public GameObject wall_part;
    // Use this for initialization
    void Start () {
        stop = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (stop && signal1 && signal2 && signal3 && signal4)
        {
            wall_part.SendMessage("Activate");
            stop = false;
        }
        if (stop == false && (signal1 == false || signal2 == false || signal3 == false || signal4 == false ))
        {
            wall_part.SendMessage("Activate");
            stop = true;
        }
	}
}
