using UnityEngine;
using System.Collections;

public class FightSalle1 : MonoBehaviour
{
    public GameObject Skeleton;
    public GameObject Crocodiles;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    private Object e1;
    private Object e2;
    private Object e3;
    private Object e4;
    private bool quelqunestdanslasalle;
    private bool adébuté;
    public GameObject Sortie;
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
        if (quelqunestdanslasalle&&!adébuté)
        {
            e1 = Instantiate(Skeleton, spawn1.position, spawn1.rotation);
            e2 = Instantiate(Skeleton, spawn2.position, spawn2.rotation);
            e3 = Instantiate(Skeleton, spawn3.position, spawn3.rotation);
            e4 = Instantiate(Crocodiles, spawn4.position, spawn4.rotation);
            adébuté = true;
        }
        if (adébuté)
        {
            if (e1==null&&e2==null&&e3==null&&e4==null)
            {
                Sortie.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}