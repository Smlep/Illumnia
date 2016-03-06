using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {
    public GameObject Doorenigme;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        Doorenigme.SendMessage("Activate");
    }
}
