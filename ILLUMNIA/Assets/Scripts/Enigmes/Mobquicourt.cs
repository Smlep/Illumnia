using UnityEngine;
using System.Collections;
using System.Net;

public class Mobquicourt : MonoBehaviour
{


    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    private Animator anim;
    private bool keyhasspawned; // booléen pour pas faire spawn la clef plusieurs fois
    private GameObject Coin1;
    private GameObject Coin2;
    private GameObject Coin3;
    private GameObject Coin4;
    private bool isdead;
    public GameObject clefenigme1;

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsMoving", true);        
        Coin1 = GameObject.FindGameObjectWithTag("Coin1");
        Coin2 = GameObject.FindGameObjectWithTag("Coin2");
        Coin3 = GameObject.FindGameObjectWithTag("Coin3");
        Coin4 = GameObject.FindGameObjectWithTag("Coin4");
        nav.SetDestination(Coin1.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clef")&&!isdead)
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Coin1"))
        {
            nav.SetDestination(Coin2.transform.position);
        }
        if (other.gameObject.CompareTag("Coin2"))
        {
            nav.SetDestination(Coin3.transform.position);
        }
        if (other.gameObject.CompareTag("Coin3"))
        {
            nav.SetDestination(Coin4.transform.position);
        }
        if (other.gameObject.CompareTag("Coin4"))
        {
            nav.SetDestination(Coin1.transform.position);
        }
    }
    
    void Update()
    {
        if (enemyHealth.currentHealth <= 0 && !keyhasspawned)
        {
            isdead = true;
            StartCoroutine(keywillspawn());
            keyhasspawned = true;
        }
    }

    IEnumerator keywillspawn()
    {
        yield return new WaitForSeconds(2);
        Instantiate(clefenigme1, transform.position, transform.rotation);
    }
}
