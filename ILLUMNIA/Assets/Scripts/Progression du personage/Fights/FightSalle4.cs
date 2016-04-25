using UnityEngine;
using System.Collections;

public class FightSalle4 : MonoBehaviour {

    public GameObject Demon;
    public GameObject TROLL;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    private Object e1;
    private Object e2;
    private bool quelqunestdanslasalle;
    private bool adébuté;
    public GameObject Sortie;
    public GameObject[] enemiesalive;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quelqunestdanslasalle = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        // En cas de problème
        if (other.gameObject.CompareTag("Player"))
        {
            quelqunestdanslasalle = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (quelqunestdanslasalle && !adébuté)
        {
            Instantiate(Demon, spawn1.position, spawn1.rotation);
            e1 = Instantiate(TROLL, spawn2.position, spawn2.rotation);
            e2 = Instantiate(TROLL, spawn3.position, spawn3.rotation);
            adébuté = true;
        }
        if (adébuté)
        {
            enemiesalive = GameObject.FindGameObjectsWithTag("Demon");
            if (e1 == null && e2 == null && enemiesalive.Length<=0)
            {
                Sortie.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
