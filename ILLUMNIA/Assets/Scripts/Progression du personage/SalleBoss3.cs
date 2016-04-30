using UnityEngine;
using System.Collections;

public class SalleBoss3 : MonoBehaviour {

    bool isintheroom;
    bool bossenvie;
    bool estdéjaentréavant;
    public GameObject Light;
    private GameObject Boss3;
    EnemyHealth enemyHealth;
    bool findéjajoué;
    GameObject[] Players;
    ScriptPersonnage[] scriptpersonnages;
    PlayerHealth[] playerHealths;
    private GameObject Canvasduboss;
    private GameObject Canvasbossdead;
    private GameObject Canvasbossdead2;
    private GameObject levieraile3;
    private GameObject TPout;
    // Use this for initialization
    void Awake()
    {
        Canvasduboss = GameObject.FindGameObjectWithTag("BossCanvas3");
        Canvasduboss.SetActive(false);
        /*Canvasbossdead = GameObject.FindGameObjectWithTag("Boss3DeadCV");
        Canvasbossdead.SetActive(false);
        Canvasbossdead2 = GameObject.FindGameObjectWithTag("Boss3DeadCV2");
        Canvasbossdead2.SetActive(false);*/

        /*TPout = GameObject.FindGameObjectWithTag("TéléporteurBoss3");
        TPout.SetActive(false);
        */
        Boss3 = GameObject.FindGameObjectWithTag("Boss3");
        Boss3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // recherche de script 

        Players = GameObject.FindGameObjectsWithTag("Player");
        playerHealths = new PlayerHealth[Players.Length];
        for (int i = 0; i < Players.Length; i++)
        {
            playerHealths[i] = Players[i].GetComponent<PlayerHealth>();
        }
        scriptpersonnages = new ScriptPersonnage[Players.Length];
        for (int i = 0; i < Players.Length; i++)
        {
            scriptpersonnages[i] = Players[i].GetComponent<ScriptPersonnage>();
        }
        if (isintheroom && !estdéjaentréavant && !Boss3.activeSelf)
        {
            Canvasduboss.SetActive(true);
            estdéjaentréavant = true;
            Light.SetActive(true);
            //door.SendMessage("Activate");
            Boss3.SetActive(true);
            bossenvie = true;
            enemyHealth = Boss3.gameObject.GetComponent<EnemyHealth>();
            // StartCoroutine(test()); //Pour tester ce qui arrive a la mort du boss

        }
        if (bossenvie)
        {
            if (!findéjajoué && enemyHealth.currentHealth <= 0)
            {
                bossenvie = false;
                Boss2Terminé();
                findéjajoué = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) ;
        {
            isintheroom = true;
        }
    }

    public void Boss2Terminé()
    {

        if (bossenvie)
        {
            enemyHealth.currentHealth = 0;
            bossenvie = false;
        }

        for (int i = 0; i < scriptpersonnages.Length; i++)
        {
            scriptpersonnages[i].playercanmove = true;
        }
        for (int i = 0; i < playerHealths.Length; i++)
        {
            playerHealths[i].healautorise = true;
        }
        StartCoroutine(BoostsBoss2());
  //      TPout.SetActive(true);
    }
    IEnumerator BoostsBoss2()
    {
        //Canvasbossdead.SetActive(true);
        // Augmentation progressive de la lumière de facon ultra-stylée
        /*float[] portéelumineuses = new float[Players.Length];
        for (int i = 0; i < portéelumineuses.Length; i++)
            portéelumineuses[i] = Players[i].GetComponentInChildren<Light>().range;
        while (portéelumineuses[0] < 40)
        {
            yield return new WaitForSeconds(0.05f);
            for (int i = 0; i < portéelumineuses.Length; i++)
                portéelumineuses[i] += 0.25f;
        }
        */
        // Cinématique
        yield return new WaitForSeconds(3);
        /*
        for (int i = 0; i < scriptpersonnages.Length; i++)
        {
            scriptpersonnages[i].playercanmove = false;
        }
        Canvasbossdead.SetActive(false);
        Canvasbossdead2.SetActive(true);
        for (int i = 0; i < scriptpersonnages.Length; i++)
        {
            scriptpersonnages[i].playercanmove = true;
        }
        */
        yield return new WaitForSeconds(8);
        //Canvasbossdead2.SetActive(false);
    }
}
