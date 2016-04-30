using UnityEngine;
using System.Collections;

public class PorteAile2 : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public Transform spawnenemy1;
    public Transform spawnenemy2;
    public GameObject camerapouranim;
    public GameObject nextdoor;
    private Object e1;
    private Object e2;
    private bool enemyhavespawned;
    private bool nextdooropened;
    private ScriptPersonnage Scriptdedéplacement;
    private GameObject player;
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
            if (e1 == null && e2 == null)
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
            if (Scriptdedéplacement.lejoueurestdanslazonemobdeladeuxiemeaile && !enemyhavespawned)
            {
                e1 = Instantiate(enemy1, spawnenemy1.position, spawnenemy1.rotation);
                //e2 = Instantiate(enemy2, spawnenemy2.position, spawnenemy2.rotation);
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
