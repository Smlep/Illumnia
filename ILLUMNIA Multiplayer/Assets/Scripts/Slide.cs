using UnityEngine;
using System.Collections;

public class Slide : MonoBehaviour {

    public Transform Arrivee;
    private Vector3 PointA;
    private Vector3 PointB;
    public float tempsdeparcour;
    // Use this for initialization
    void Start ()
    {
        PointA = transform.position;
        PointB = Arrivee.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(PointA, PointB,Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / tempsdeparcour, 1f)));
    }
}
