using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PorteAile3 : MonoBehaviour
{

    public GameObject enemy1;
    public Transform spawnenemy1;
    public GameObject camerapouranim;
    public GameObject nextdoor;
    private Object e1;
    private Object e3;
    private Object e2;
    private Object e4;
    private bool enemyhavespawned;
    private bool nextdooropened;
    private ScriptPersonnage Scriptdedéplacement;
    private GameObject player;
    public GameObject[] enemiesalive;
    // Use this for initialization
    void Start()
    {
        enemyhavespawned = false;
        // recherche du joueur
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Scriptdedéplacement = player.GetComponent<ScriptPersonnage>();
        }
        catch { }
        if (enemyhavespawned && !nextdooropened)
        {
            enemiesalive = GameObject.FindGameObjectsWithTag("Demon");
            if (enemiesalive.Length <= 0)
            {
                camerapouranim.SetActive(true);
                Scriptdedéplacement.playercanmove = false;
                StartCoroutine(Terminerlacinématique());
                nextdoor.SendMessage("Activate");
                SendMessage("Activate");
                nextdooropened = !nextdooropened;// lance l'ouverture de la prochaine porte sans avoir besoin de levier
            }
        }
        try
        {
            if (Scriptdedéplacement.lejoueurestdanslazonemobdelatroisièmeaile && !enemyhavespawned)
            {
                e1 = Instantiate(enemy1, spawnenemy1.position, spawnenemy1.rotation);
                //e4 = Instantiate(enemy4, spawnenemy4.position, spawnenemy4.rotation);
                SendMessage("Activate");
                enemyhavespawned = true;
            }
        }
        catch { }
    }

    IEnumerator Terminerlacinématique()
    {
        yield return new WaitForSeconds(2);
        camerapouranim.SetActive(false);
        Scriptdedéplacement.playercanmove = true;
    }

}
