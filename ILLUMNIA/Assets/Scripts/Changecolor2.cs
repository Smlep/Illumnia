using UnityEngine;
using System.Collections;

public class Changecolor2 : MonoBehaviour {

    private bool ColorON2 = false;
    private bool endloop = true;
    public GameObject lampeoff;
    public GameObject lampeon;
    // Use this for initialization
    void Start()
    {
        lampeon.SetActive(false);
        if (lampeon.activeSelf == true && lampeoff.activeSelf == false)
        {
            ColorON2 = true;
        }
        else
        {
            ColorON2 = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Activate()
    {
        StartCoroutine(MyMethod());
        if (ColorON2)
        {
            coloroff();
            ColorON2 = false;
        }
        else
        {
            coloron();
            ColorON2 = true;
        }
    }

    void coloron()
    {
        lampeoff.SetActive(false);
        lampeon.SetActive(true);
        StartCoroutine(MyMethod());
    }

    void coloroff()
    {
        lampeoff.SetActive(true);
        lampeon.SetActive(false);
        StartCoroutine(MyMethod());
    }

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 1 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("After Waiting 1 Seconds");
    }
}
