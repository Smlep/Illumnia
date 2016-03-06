using UnityEngine;
using System.Collections;
using System.Runtime.Remoting;

public class SalleBoss1 : MonoBehaviour
{
    private bool isintheroom;
    private GameObject levieraile2;
    private ScriptPersonnage scriptPersonnage;
    private GameObject lightforthisroom;
    private GameObject door;
    private GameObject Canvasduboss;
    private GameObject TéléporteurBoss1;
    private GameObject caméracinématiqueouvertureporte;
    public int intensitélumineuseapresboss;
    EnemyHealth enemyHealth;
    public GameObject Boss1;
    private bool estdéjaentréavant;
    private PlayerAttack playerAttack;
    private bool findéjajoué;
    private bool bossenvie;
    // Use this for initialization
    void Start()
    {
        Canvasduboss = GameObject.FindGameObjectWithTag("BossCanvas");
        Canvasduboss.SetActive(false);
        TéléporteurBoss1 = GameObject.FindGameObjectWithTag("TéléporteurBoss1");
        TéléporteurBoss1.SetActive(false);
        lightforthisroom = GameObject.FindGameObjectWithTag("LightBoss1");
        lightforthisroom.SetActive(false);
        levieraile2 = GameObject.FindGameObjectWithTag("Levierporteaile2");
        isintheroom = false;
        caméracinématiqueouvertureporte = GameObject.FindGameObjectWithTag("Cameradoor2");
        caméracinématiqueouvertureporte.SetActive(false);
        playerAttack = GetComponent<PlayerAttack>();
        door = GameObject.FindGameObjectWithTag("PorteBoss1");
        scriptPersonnage = GetComponent<ScriptPersonnage>();
    }
    // détection de la premiere entrée dans cette salle
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SolBoss1"))
        {
            isintheroom = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
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
        scriptPersonnage.sprintautorisé = true;
        lightforthisroom.SetActive(false);
        door.SendMessage("Activate");
        StartCoroutine(Boostsdécalé());
        playerAttack.modedefensifautorisé = true;
    }

    IEnumerator Boostsdécalé()
    {
        // Augmentation progressive de la lumière de facon ultra-stylée
        float intensitélumineuse = GetComponentInChildren<Light>().intensity;
        float portéelumineuse = GetComponentInChildren<Light>().range;
        while (intensitélumineuse < intensitélumineuseapresboss)
        {
            yield return new WaitForSeconds(0.05f);
            intensitélumineuse += 0.1f;
            portéelumineuse += 0.25f;
            GetComponentInChildren<Light>().intensity = intensitélumineuse;
            GetComponentInChildren<Light>().range = portéelumineuse;
        }
        // Cinématique
        yield return new WaitForSeconds(3);
        levieraile2.SendMessage("Activate");
        scriptPersonnage.playercanmove = false;
        caméracinématiqueouvertureporte.SetActive(true);
        yield return new WaitForSeconds(2);
        caméracinématiqueouvertureporte.SetActive(false);
        scriptPersonnage.playercanmove = true;


    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(5);
        Boss1Terminé();
    }
}
