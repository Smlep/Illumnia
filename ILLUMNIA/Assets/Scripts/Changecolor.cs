using UnityEngine;
using System.Collections;

public class Changecolor : MonoBehaviour {
    private bool ColorON;
    public GameObject lampeoff;
    public GameObject lampeon;
	// Use this for initialization
	void Start () {
        if (lampeon.activeSelf == true && lampeoff.activeSelf == false)
        {
            ColorON = true;
        }
        else
            ColorON = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        if (ColorON)
        {
            ColorON = false;
            coloroff();
        }
        else
        {
            ColorON = true;
            coloron();
        }
    }

    void coloron()
    {
        lampeoff.SetActive(false);
        lampeon.SetActive(true);
    }

    void coloroff()
    {
        lampeoff.SetActive(true);
        lampeon.SetActive(false);
    }
}
