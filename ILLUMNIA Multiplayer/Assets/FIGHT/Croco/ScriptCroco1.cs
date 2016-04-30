using UnityEngine;
using System.Collections;

public class ScriptCroco1 : MonoBehaviour
{
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    private Animator Crocoanim;
    GameObject[] Players;
    int i;

    void Awake()
    {
        // Set up the references.        
        Crocoanim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        i = 0;
    }


    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        // If the enemy and the player have health left...
        if (Players[i] == null || Players[i].GetComponent<PlayerHealth>().currentHealth > 0)
            i += 1;
        if (Players.Length <= i)
            i = 0;
        if (nav.enabled&&Players[i] != null && enemyHealth.currentHealth > 0 && Players[i].GetComponent<PlayerHealth>().currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(Players[i].transform.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}
