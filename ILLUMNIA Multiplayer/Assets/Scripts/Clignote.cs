using UnityEngine;
using System.Collections;

public class Clignote : MonoBehaviour {

    public GameObject gameobject;
    public float tempson;
    public float tempsoff;
    private bool plop = true;

	// Use this for initialization
	void Start ()
    {
        gameobject.SetActive(true);
        StartCoroutine(ActivationRoutine());
	}
	

    private IEnumerator ActivationRoutine()
    {
        while(plop)
        {
            yield return new WaitForSeconds(tempson);
            gameobject.SetActive(false);
            yield return new WaitForSeconds(tempsoff);
            gameobject.SetActive(true);
        }
    }
}
