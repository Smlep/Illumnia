using UnityEngine;
using System.Collections;

public class Enable : MonoBehaviour {

    public GameObject pyl;
    private bool pylOn;
	// Use this for initialization
	void Start ()
    {
        pyl.SetActive(false);
        if (pyl.activeSelf == true)
        {
            pylOn = true;
        }
        else
        {
            pylOn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        StartCoroutine(MyMethod());
        if (pylOn)
        {
            pyl.SetActive(false);
            pylOn = false;
        }
        else
        {
            pyl.SetActive(true);
            pylOn = true;
        }
    }

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 1 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("After Waiting 1 Seconds");
    }
}
