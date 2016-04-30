using UnityEngine;
using System.Collections;

public class CinématiqueCaméra : MonoBehaviour {
    private GameObject player;
    private float timer;
    private GameObject cameraa;
    private bool letsrotate;
    private float distanceentrejoueuretmilieu;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
        cameraa = GameObject.FindGameObjectWithTag("Cameratutoriellobby");
	}
	public IEnumerator cinématiquetuto()
    {
        yield return new WaitForSeconds(0.001f);
        distanceentrejoueuretmilieu = Mathf.Pow((player.transform.position.x - transform.position.x), 2) + Mathf.Pow((player.transform.position.z - transform.position.z), 2);
        cameraa.transform.position = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z);
        timer = 0;
        letsrotate = true;     
        yield return new WaitForSeconds(6f);
        letsrotate = false;
    }
	// Update is called once per frame
	void Update () {
        if (letsrotate)
        {
            transform.Rotate(new Vector3(0,360/6,0)* Time.deltaTime);
            cameraa.transform.Rotate(new Vector3(0, -360 / (6*distanceentrejoueuretmilieu), 0) * Time.deltaTime);
        }
	}
}
