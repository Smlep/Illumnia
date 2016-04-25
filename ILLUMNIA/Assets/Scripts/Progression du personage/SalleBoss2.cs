using UnityEngine;
using System.Collections;

public class SalleBoss2 : MonoBehaviour
{
    private ScriptPersonnage scriptPersonnage;
    bool isintheroom;
    bool bossenvie;
    bool estdéjaentréavant;
    public GameObject Boss2;
    EnemyHealth enemyHealth;
    bool findéjajoué;
    ScriptPersonnage scriptpersonnage;
    PlayerHealth playerHealth;
    private GameObject caméracinématiqueouvertureporte;
    private GameObject Canvasduboss;
    private GameObject Canvasbossdead;
    private GameObject Canvasbossdead2;
    private GameObject levieraile3;
    // Use this for initialization
    void Awake()
    {
        Canvasduboss = GameObject.FindGameObjectWithTag("BossCanvas2");
        Canvasduboss.SetActive(false);
        Canvasbossdead = GameObject.FindGameObjectWithTag("Boss2DeadCV");
        Canvasbossdead.SetActive(false);
        Canvasbossdead2 = GameObject.FindGameObjectWithTag("Boss2DeadCV2");
        Canvasbossdead2.SetActive(false);
        bossenvie = true;
        playerHealth = GetComponent<PlayerHealth>();
        scriptpersonnage = GetComponent<ScriptPersonnage>();
        caméracinématiqueouvertureporte = GameObject.FindGameObjectWithTag("Cameradoor3");
        caméracinématiqueouvertureporte.SetActive(false);
        scriptPersonnage = GetComponent<ScriptPersonnage>();
        levieraile3 = GameObject.FindGameObjectWithTag("Levierporteaile3");
    }

    // Update is called once per frame
    void Update()
    {
        if (isintheroom && !estdéjaentréavant&&!Boss2.activeSelf)
        {
            Canvasduboss.SetActive(true);
            estdéjaentréavant = true;
            //lightforthisroom.SetActive(true);
            //door.SendMessage("Activate");
            Boss2.SetActive(true);
            bossenvie = true;
            enemyHealth = Boss2.gameObject.GetComponent<EnemyHealth>();
            // StartCoroutine(test()); //Pour tester ce qui arrive a la mort du boss

        }
        /*if (bossenvie)
        {
            if (!findéjajoué && enemyHealth.currentHealth <= 0)
            {
                bossenvie = false;
                Boss2Terminé();
                findéjajoué = true;
            }
        }*/
    }
    public void Boss2Terminé()
    {
        /*
        if (bossenvie)
        {
            enemyHealth.currentHealth = 0;
            bossenvie = false;
        }
        */
        scriptpersonnage.Dashautorise = true;
        playerHealth.healautorise = true;
        StartCoroutine(BoostsBoss2());
    }
    IEnumerator BoostsBoss2()
    {
        Canvasbossdead.SetActive(true);
        // Augmentation progressive de la lumière de facon ultra-stylée
        float portéelumineuse = GetComponentInChildren<Light>().range;
        while (portéelumineuse < 40)
        {
            yield return new WaitForSeconds(0.05f);
            portéelumineuse += 0.25f;
            GetComponentInChildren<Light>().range = portéelumineuse;
        }
        // Cinématique
        yield return new WaitForSeconds(3);
        levieraile3.SendMessage("Activate");
        scriptPersonnage.playercanmove = false;
        caméracinématiqueouvertureporte.SetActive(true);
        yield return new WaitForSeconds(2);
        caméracinématiqueouvertureporte.SetActive(false);
        Canvasbossdead.SetActive(false);
        Canvasbossdead2.SetActive(true);
        scriptPersonnage.playercanmove = true;
        yield return new WaitForSeconds(8);
        Canvasbossdead2.SetActive(false);
    }
}
