using UnityEngine;
using System.Collections;

public class Changecolor1 : MonoBehaviour {
    private bool ColorON1 = false;
    public GameObject lampeoff;
    public GameObject lampeon;
	// Use this for initialization
	void Start () {
        lampeon.SetActive(false);
        if (lampeon.activeSelf == true && lampeoff.activeSelf == false)
        {
            ColorON1 = true;
        }
        else
        {
            ColorON1 = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        StartCoroutine(MyMethod());
        if (ColorON1)
        {
            coloroff();
            ColorON1 = false;
        }
        else
        {
            coloron();
            ColorON1 = true;
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

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 1 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("After Waiting 1 Seconds");
    }
}
