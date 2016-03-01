using UnityEngine;
using System.Collections;
using System.Runtime.Remoting;

public class SalleBoss1 : MonoBehaviour
{
    private bool isintheroom;
    public GameObject lightforthisroom;
    public GameObject door;
	// Use this for initialization
	void Start ()
	{
	    isintheroom = false;
	}
    // détection de la premiere entrée dans cette salle
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SolBoss1"))
        {
            isintheroom = true;
        }
    }
	// Update is called once per frame
	void Update () {
	    if (isintheroom)
	    {
	        lightforthisroom.SetActive(true);
            door.SendMessage("Activate");
	    }
	}
}
