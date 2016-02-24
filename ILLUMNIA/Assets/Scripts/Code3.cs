using UnityEngine;
using System.Collections;

public class Code3 : MonoBehaviour {
    private bool on;
    public bool signal3 = false;
	// Use this for initialization
	void Start () {
	    if (signal3)
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
            signal3 = false;
            on = false;
        }
        else
        {
            signal3 = true;
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
