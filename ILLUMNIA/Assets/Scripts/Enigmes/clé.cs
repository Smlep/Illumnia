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
    public GameObject caméracinématiqueramassage;
    private Object cle;
    public GameObject mobquifuit;
    public Transform mobquifuitspawn;
    public Transform spawnkey;
    // Use this for initialization
    void Start ()
    {
        keyhasspawned = false;
	}

	// Update is called once per frame
	void Update ()
    {
	    if (!keyhasspawned)
	    {
	        if (l1.activeSelf  &&
	            (l2.activeSelf  && l3.activeSelf  && l4.activeSelf   && l5.activeSelf &&
	             l6.activeSelf  && l7.activeSelf  && l8.activeSelf  && l9.activeSelf  &&
	             l10.activeSelf  && l11.activeSelf  && l12.activeSelf  && l13.activeSelf  &&
	             l14.activeSelf  && l15.activeSelf  && l16.activeSelf  && l17.activeSelf  &&
	             l18.activeSelf  && l19.activeSelf  && l20.activeSelf  && l21.activeSelf &&
	             l22.activeSelf  && l23.activeSelf && l24.activeSelf  && l25.activeSelf ))
	        {
	            cle = Instantiate(key, spawnkey.position, spawnkey.rotation);
	            Instantiate(mobquifuit, mobquifuitspawn.position, mobquifuitspawn.rotation);
                caméracinématiqueramassage.SetActive(true);
	            keyhasspawned = true;
	            StartCoroutine(fincinématique());
	        }
	    }
    }

    IEnumerator fincinématique()
    {
        yield return new WaitForSeconds(2);
        caméracinématiqueramassage.SetActive(false);
    }
}
