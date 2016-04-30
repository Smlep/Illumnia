using UnityEngine;
using System.Collections;
using System.Runtime.Remoting;

public class SalleBoss1 : MonoBehaviour
{
    private bool isintheroom;
    private GameObject levieraile2;
    private ScriptPersonnage[] scriptPersonnages;
    private GameObject lightforthisroom;
    private GameObject door;
    private GameObject Canvasduboss;
    private GameObject Canvasbossdead;
    private GameObject Canvasbossdead2;
    private GameObject TéléporteurBoss1;
    private GameObject caméracinématiqueouvertureporte;
    public int intensitélumineuseapresboss;
    EnemyHealth enemyHealth;
    private GameObject Boss1;
    private bool estdéjaentréavant;
    private PlayerAttack playerAttack;
    private bool findéjajoué;
    private bool bossenvie;
    GameObject[] Players;
    // Use this for initialization
    void Awake()
    {
        Canvasduboss = GameObject.FindGameObjectWithTag("BossCanvas");
        Canvasduboss.SetActive(false);
        Canvasbossdead = GameObject.FindGameObjectWithTag("Boss1DeadCV");
        Canvasbossdead.SetActive(false);
        Canvasbossdead2 = GameObject.FindGameObjectWithTag("Boss1DeadCV2");
        Canvasbossdead2.SetActive(false);
        TéléporteurBoss1 = GameObject.FindGameObjectWithTag("TéléporteurBoss1");
        TéléporteurBoss1.SetActive(false);
        lightforthisroom = GameObject.FindGameObjectWithTag("LightBoss1");
        lightforthisroom.SetActive(false);
        levieraile2 = GameObject.FindGameObjectWithTag("Levierporteaile2");
        isintheroom = false;
        caméracinématiqueouvertureporte = GameObject.FindGameObjectWithTag("Cameradoor2");
        caméracinématiqueouvertureporte.SetActive(false);
        door = GameObject.FindGameObjectWithTag("PorteBoss1");
        Boss1 = GameObject.FindGameObjectWithTag("Boss1");
        Boss1.SetActive(false);
    }
    // détection de la premiere entrée dans cette salle
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isintheroom = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        scriptPersonnages = new ScriptPersonnage[Players.Length];
        for (int i = 0; i < Players.Length; i++)
            scriptPersonnages[i] = Players[i].GetComponent<ScriptPersonnage>();
        if (isintheroom && !estdéjaentréavant)
        {
            Canvasduboss.SetActive(true);
            estdéjaentréavant = true;
            lightforthisroom.SetActive(true);
            door.SendMessage("Activate");
            Boss1.SetActive(true);
            bossenvie = true;
            enemyHealth = Boss1.gameObject.GetComponent<EnemyHealth>();
            // StartCoroutine(test()); //Pour tester ce qui arrive a la mort du boss

        }
        if (bossenvie)
        {
            if (!findéjajoué && enemyHealth.currentHealth <= 0)
            {
                bossenvie = false;
                Boss1Terminé();
                findéjajoué = true;
            }
        }
    }

    public void Boss1Terminé()
    {
        if (bossenvie)
        {
            enemyHealth.currentHealth = 0;
            bossenvie = false;
        }
        TéléporteurBoss1.SetActive(true);
        Canvasduboss.SetActive(false);
        for (int i = 0; i < scriptPersonnages.Length; i++)
            scriptPersonnages[i].sprintautorisé = true;
        lightforthisroom.SetActive(false);
        door.SendMessage("Activate");
        StartCoroutine(Boostsdécalé());
        playerAttack.modedefensifautorisé = true;
    }

    IEnumerator Boostsdécalé()
    {
        Canvasbossdead.SetActive(true);
        // Augmentation progressive de la lumière de facon ultra-stylée
        float[] intensitélumineuses = new float[Players.Length];
        for (int i = 0; i < Players.Length; i++)
            intensitélumineuses[i] = Players[i].GetComponentInChildren<Light>().intensity;
        float[] portéelumineuses = new float[Players.Length];
        for (int i = 0; i < Players.Length; i++)
            portéelumineuses[i] = Players[i].GetComponentInChildren<Light>().range;
        while (intensitélumineuses[0] < intensitélumineuseapresboss)
        {
            yield return new WaitForSeconds(0.05f);
            for (int i = 0; i < Players.Length; i++)
            {
                intensitélumineuses[i] += 0.1f;
                portéelumineuses[i] += 0.25f;
                Players[i].GetComponentInChildren<Light>().intensity = intensitélumineuses[i];
                Players[i].GetComponentInChildren<Light>().range = portéelumineuses[i];
            }
        }
        // Cinématique
        yield return new WaitForSeconds(3);
        levieraile2.SendMessage("Activate");
        for (int i = 0; i < scriptPersonnages.Length; i++)
            scriptPersonnages[i].playercanmove = false;
        caméracinématiqueouvertureporte.SetActive(true);
        yield return new WaitForSeconds(2);
        caméracinématiqueouvertureporte.SetActive(false);
        Canvasbossdead.SetActive(false);
        Canvasbossdead2.SetActive(true);
        for (int i = 0; i < scriptPersonnages.Length; i++)
            scriptPersonnages[i].playercanmove = true;
        yield return new WaitForSeconds(8);
        Canvasbossdead2.SetActive(false);

    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(5);
        Boss1Terminé();
    }
}
