using UnityEngine;
using System.Collections;

public class TP : MonoBehaviour
{
    // Ce script tp un joueur d'une plateforme a une autre 
    // ATTENTION !!!!! Pour qu'il marche la plateforme de depart doit avoir un collider trigger
    // Solution : Devant gauche gauche droite droite gauche devant
    private GameObject player;
    public GameObject plateformedarrivée;
    bool justTPed;
	// Use this for initialization
	void Start () {
	player=GameObject.FindGameObjectWithTag("Player");
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Téléporte le joueur au dessus de la plateforme d'arrivé
            StartCoroutine(TPed());
            player.transform.position=new Vector3(plateformedarrivée.transform.position.x,plateformedarrivée.transform.position.y+1,plateformedarrivée.transform.position.z);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator TPed()
    {
        justTPed = true;
        yield return new WaitForSeconds(2);
        justTPed = false;
    }
    void OnGUI()
    {
        if (justTPed)
        {
            GUI.Box(new Rect(Screen.width/2-50, Screen.height/2-10, 100, 20), "Teleported !");
        }
    }
}
