using UnityEngine;
using System.Collections;

public class Code2 : MonoBehaviour {
    public bool signal2;
    public static Code2 main;
	// Use this for initialization
	void Start () {
        signal2 = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        StartCoroutine(MyMethod());
        signal2 = !signal2;
    }

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 1 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("After Waiting 1 Seconds");
    }

    void Awake()
    {
        main = this;
    }
}
