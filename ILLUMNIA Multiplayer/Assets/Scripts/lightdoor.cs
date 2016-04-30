using UnityEngine;
using System.Collections;

public class lightdoor : MonoBehaviour {

    public GameObject Door;
    public GameObject L1;
    public GameObject L2;
    bool b = true;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (L1.activeSelf == true && L2.activeSelf == true && b)
        {
            b = false;
            Door.SendMessage("Activate");
        }
        else
        {
            if (b == false &&(L1.activeSelf != true || L2.activeSelf != true))
            {
                b = true;
                Door.SendMessage("Activate");
            }
        }
	}
}
