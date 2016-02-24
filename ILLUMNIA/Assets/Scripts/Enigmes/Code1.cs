using UnityEngine;
using System.Collections;

public class Code1 : MonoBehaviour {
    public bool signal1;
    public static Code1 main;
	// Use this for initialization
	void Start () {
        signal1 = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        StartCoroutine(MyMethod());
        signal1 = !signal1;
    }

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 1 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("After Waiting 1 Seconds");
    }

    void Awake ()
    {
        main = this;
    }
}
