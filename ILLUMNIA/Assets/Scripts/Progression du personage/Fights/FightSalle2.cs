using UnityEngine;
using System.Collections;

public class FightSalle2 : MonoBehaviour
{

    public GameObject FireDemon;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;
    public Transform spawn7;
    public Transform spawn8;
    private Object e1;
    private Object e2;
    private Object e3;
    private Object e4;
    private Object e5;
    private Object e6;
    private Object e7;
    private Object e8;
    private Object e9;
    private Object e10;
    private Object e11;
    private Object e12;
    private Object e13;
    private Object e14;
    private Object e15;
    private Object e16;
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
        if (quelqunestdanslasalle && !adébuté)
        {
            StartCoroutine(Spawn());
            adébuté = true;
        }
        if (adébuté)
        {
            if (e1 == null && e2 == null && e3 == null && e4 == null)
            {
                Sortie.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator Spawn()
    {
        e1 = Instantiate(FireDemon, spawn1.position, spawn1.rotation);
        e2 = Instantiate(FireDemon, spawn2.position, spawn2.rotation);
        e3 = Instantiate(FireDemon, spawn3.position, spawn3.rotation);
        e4 = Instantiate(FireDemon, spawn4.position, spawn4.rotation);
        e5 = Instantiate(FireDemon, spawn5.position, spawn1.rotation);
        e6 = Instantiate(FireDemon, spawn6.position, spawn2.rotation);
        e7 = Instantiate(FireDemon, spawn7.position, spawn3.rotation);
        e8 = Instantiate(FireDemon, spawn8.position, spawn4.rotation);
        yield return new WaitForSeconds(2);
        e9 = Instantiate(FireDemon, spawn1.position, spawn1.rotation);
        e10 = Instantiate(FireDemon, spawn2.position, spawn2.rotation);
        e11 = Instantiate(FireDemon, spawn3.position, spawn3.rotation);
        e12 = Instantiate(FireDemon, spawn4.position, spawn4.rotation);
        e13 = Instantiate(FireDemon, spawn5.position, spawn1.rotation);
        e14 = Instantiate(FireDemon, spawn6.position, spawn2.rotation);
        e15 = Instantiate(FireDemon, spawn7.position, spawn3.rotation);
        e16 = Instantiate(FireDemon, spawn8.position, spawn4.rotation);
    }
}
