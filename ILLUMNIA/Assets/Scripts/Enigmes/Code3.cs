using UnityEngine;
using System.Collections;

public class Code3 : MonoBehaviour {
    public bool signal3;
    public static Code3 main;
	// Use this for initialization
	void Start () {
        signal3 = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        StartCoroutine(MyMethod());
        signal3 = !signal3;
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
