using UnityEngine;
using System.Collections;
using System.Runtime.Remoting;

public class SalleBoss1 : MonoBehaviour
{
    private bool isintheroom;
    public GameObject levieraile2;
    private ScriptPersonnage scriptPersonnage;
    public GameObject lightforthisroom;
    public GameObject door;
    public GameObject Canvasduboss;
    public GameObject TéléporteurBoss1;
    public GameObject caméracinématiqueouvertureporte;
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
        isintheroom = false;
        playerAttack = GetComponent<PlayerAttack>();
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
                Boss1Terminé();
                bossenvie = false;
                findéjajoué = true;
            }
        }
    }

    public void Boss1Terminé()
    {
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
