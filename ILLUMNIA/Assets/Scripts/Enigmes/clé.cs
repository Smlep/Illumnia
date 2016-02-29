using UnityEngine;
using System.Collections;

public class clé : MonoBehaviour {
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject l5;
    public GameObject l6;
    public GameObject l7;
    public GameObject l8;
    public GameObject l9;
    public GameObject l10;
    public GameObject l11;
    public GameObject l12;
    public GameObject l13;
    public GameObject l14;
    public GameObject l15;
    public GameObject l16;
    public GameObject l17;
    public GameObject l18;
    public GameObject l19;
    public GameObject l20;
    public GameObject l21;
    public GameObject l22;
    public GameObject l23;
    public GameObject l24;
    public GameObject l25;
    private bool keyhasspawned = false; //sais pas si tu l'utilisera
    public GameObject key;
    private Object cle;
    public Transform spawnkey;
    // Use this for initialization
    void Start ()
    {
        keyhasspawned = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (l1.activeSelf == true && l2.activeSelf == true && l3.activeSelf == true && l4.activeSelf == true && l5.activeSelf == true && l6.activeSelf == true && l7.activeSelf == true && l8.activeSelf == true && l9.activeSelf == true && l10.activeSelf == true && l11.activeSelf == true && l12.activeSelf == true && l13.activeSelf == true && l14.activeSelf == true && l15.activeSelf == true && l16.activeSelf == true && l17.activeSelf == true && l18.activeSelf == true && l19.activeSelf == true && l20.activeSelf == true && l21.activeSelf == true && l22.activeSelf == true && l23.activeSelf == true && l24.activeSelf == true && l25.activeSelf == true)
        {
            cle = Instantiate(key, spawnkey.position, spawnkey.rotation);
            keyhasspawned = true;
        }
	}
}
