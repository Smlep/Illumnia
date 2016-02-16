using UnityEngine;
using System.Collections;

public class Porte1 : MonoBehaviour {

    RaycastHit hitted;
    public GameObject Door;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        // Get access to the 'DoorOpening' script attached to the door that was hit.
        Door dooropening = Door.GetComponent<Door>();

        // Check whether the door is opening/closing or not.
        if (dooropening.Running == false)
        {
            // Open/close the door by running the 'Open' function in the 'DoorOpening' script.
            StartCoroutine(Door.GetComponent<Door>().Open());
        }
    }
}
