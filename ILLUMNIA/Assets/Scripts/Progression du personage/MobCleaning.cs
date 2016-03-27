using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class MobCleaning : MonoBehaviour
{
    private bool isintheroom;
    private ScriptPersonnage scriptPersonnage;
    public GameObject doorin;
    public GameObject doorout;
    public GameObject caméracinématiqueouvertureporteout;
    EnemyHealth enemyHealth;
    public GameObject Mob;
    public GameObject Squelette;
    public GameObject Croco;
    public GameObject Troll;
    private UnityEngine.Object ennemi1vague1;
    private UnityEngine.Object ennemi2vague1;
    private UnityEngine.Object ennemi3vague1;
    private UnityEngine.Object ennemi4vague1;
    private UnityEngine.Object ennemi1vague2;
    private UnityEngine.Object ennemi2vague2;
    private UnityEngine.Object ennemi1vague3;
    private UnityEngine.Object ennemi2vague3;
    private UnityEngine.Object ennemi3vague3;
    private bool estdéjaentréavant;
    private PlayerAttack playerAttack;
    private bool findéjajoué;
    public List<Transform> listpositionspawn;
    private bool vague1terminée;
    private bool vague2terminée;
    private bool vague3terminée;
    private bool vague4terminée;
    // Use this for initialization
    void Start()
    {
        isintheroom = false;
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        scriptPersonnage = GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptPersonnage>();
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
        if (isintheroom && !estdéjaentréavant)
        {
            estdéjaentréavant = true;
            doorin.SendMessage("Activate");
            StartCoroutine(Startfight());
        }
    }
    IEnumerator Startfight()
    {
        vague1terminée = false;
        vague2terminée = false;
        vague3terminée = false;
        System.Random ran = new System.Random();
        yield return new WaitForSeconds(3);
        ennemi1vague1 = Instantiate(Squelette, listpositionspawn[ran.Next(listpositionspawn.Count)].position, listpositionspawn[ran.Next(listpositionspawn.Count)].rotation);
        ennemi2vague1 = Instantiate(Squelette, listpositionspawn[ran.Next(listpositionspawn.Count)].position, listpositionspawn[ran.Next(listpositionspawn.Count)].rotation);
        ennemi3vague1 = Instantiate(Croco, listpositionspawn[ran.Next(listpositionspawn.Count)].position, listpositionspawn[ran.Next(listpositionspawn.Count)].rotation);
        ennemi4vague1 = Instantiate(Mob, listpositionspawn[ran.Next(listpositionspawn.Count)].position, listpositionspawn[ran.Next(listpositionspawn.Count)].rotation);
        while (ennemi1vague1 != null || ennemi2vague1 != null || ennemi3vague1 != null || ennemi4vague1 != null)
        { yield return new WaitForSeconds(1); }
        vague1terminée = true;
        ennemi1vague2 = Instantiate(Troll, listpositionspawn[ran.Next(listpositionspawn.Count)].position, listpositionspawn[ran.Next(listpositionspawn.Count)].rotation);
        while (ennemi1vague2 != null)
        { yield return new WaitForSeconds(1); }
        vague2terminée = true;
        ennemi1vague3 = Instantiate(Troll, listpositionspawn[ran.Next(listpositionspawn.Count)].position, listpositionspawn[ran.Next(listpositionspawn.Count)].rotation);
        ennemi2vague3 = Instantiate(Squelette, listpositionspawn[ran.Next(listpositionspawn.Count)].position, listpositionspawn[ran.Next(listpositionspawn.Count)].rotation);
        ennemi3vague3 = Instantiate(Squelette, listpositionspawn[ran.Next(listpositionspawn.Count)].position, listpositionspawn[ran.Next(listpositionspawn.Count)].rotation);
        while (ennemi1vague3 != null || ennemi2vague3 != null || ennemi3vague3 != null)
        { yield return new WaitForSeconds(1); }
        vague3terminée = true;
        StartCoroutine(over());
    }
    IEnumerator over ()
    {
        caméracinématiqueouvertureporteout.SetActive(true);
        doorin.SendMessage("Activate");
        doorout.SendMessage("Activate");
        yield return new WaitForSeconds(3);
        caméracinématiqueouvertureporteout.SetActive(false);
    }
}
