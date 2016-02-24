using UnityEngine;
using System.Collections;

public class Code4 : MonoBehaviour {
    public bool signal4;
    public static Code4 main;
	// Use this for initialization
	void Start () {
        signal4 = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        StartCoroutine(MyMethod());
        signal4 = !signal4;
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
