using UnityEngine;
using System.Collections;
using System.Runtime.Remoting;

public class SalleBoss1 : MonoBehaviour
{
    private bool isintheroom;
    private ScriptPersonnage scriptPersonnage;
    public GameObject lightforthisroom;
    public GameObject door;
    public GameObject Canvasduboss;
    public GameObject TéléporteurBoss1;
    public int intensitélumineuseapresboss;
    private bool estdéjaentréavant;
    private PlayerAttack playerAttack;
	// Use this for initialization
	void Start ()
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
	void Update () {
	    if (isintheroom&&!estdéjaentréavant)
	    {
            Canvasduboss.SetActive(true);
	        estdéjaentréavant = true;
	        lightforthisroom.SetActive(true);
            door.SendMessage("Activate");
	        // StartCoroutine(test()); //Pour tester ce qui arrive a la mort du boss

	    }
	}

    void Boss1Terminé()
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
        while (intensitélumineuse<intensitélumineuseapresboss)
        {
            yield return new WaitForSeconds(0.05f);
            intensitélumineuse += 0.1f;
            portéelumineuse += 0.25f;
            GetComponentInChildren<Light>().intensity=intensitélumineuse ;
            GetComponentInChildren<Light>().range = portéelumineuse;
        }

    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(5);
        Boss1Terminé();
    }
}
