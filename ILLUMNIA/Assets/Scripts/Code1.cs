using UnityEngine;
using System.Collections;

public class Code1 : MonoBehaviour {
    private bool on;
    public bool signal1 = true;
	// Use this for initialization
	void Start () {
	    if (signal1)
        {
            on = true;
        }
        else
        {
            on = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        StartCoroutine(MyMethod());
        if (on)
        {
            signal1 = false;
            on = false;
        }
        else
        {
            signal1 = true;
            on = true;
        }
    }

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 1 seconds");
        yield return new WaitForSeconds(1);
        Debug.Log("After Waiting 1 Seconds");
    }
}
