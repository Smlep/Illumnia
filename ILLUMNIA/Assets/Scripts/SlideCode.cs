using UnityEngine;
using System.Collections;

public class SlideCode : MonoBehaviour {
    private bool stop;
    public GameObject wall_part;
    // Use this for initialization
    void Start () {
        stop = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (stop && Code1.main.signal1 && Code2.main.signal2 && Code3.main.signal3 && Code4.main.signal4)
        {
            wall_part.SendMessage("Activate");
            stop = false;
        }
        if (stop == false && (Code1.main.signal1 == false || Code2.main.signal2 == false || Code3.main.signal3 == false || Code4.main.signal4 == false ))
        {
            wall_part.SendMessage("Activate");
            stop = true;
        }
	}
}
