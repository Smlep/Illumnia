using UnityEngine;
using System.Collections;

public class ScriptPrincipalFight : MonoBehaviour
{
    public Object e1;
    public Object e2;
    public Object e3;
    public Object e4;
    public GameObject TPtoBoss;
    bool quelqunestdanslasalle;
    bool débutactivé;
    bool finactivé;
    public GameObject messageEntrée;
    public GameObject messageFin;
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
    // Update is called once per frame
    void Update()
    {
        if (quelqunestdanslasalle&&!débutactivé)
        {
            débutactivé = true;
            StartCoroutine(FightBegin());
        }
        if (e1 == null && e2 == null && e3 == null && e4 == null&&!finactivé)
        {
            finactivé = true;
            StartCoroutine(FightOver());
        }
    }
    IEnumerator FightBegin()
    {
        messageEntrée.SetActive(true);
        yield return new WaitForSeconds(5);
        messageEntrée.SetActive(false);
    }
    
    public void Fincombats()
    {
        StartCoroutine(FightOver());
    }

    IEnumerator FightOver()
    {
        finactivé = true;
        TPtoBoss.SetActive(true);
        messageFin.SetActive(true);
        yield return new WaitForSeconds(5);
        messageFin.SetActive(false);
    }
}
