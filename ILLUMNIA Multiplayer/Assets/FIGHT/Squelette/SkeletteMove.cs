using UnityEngine;
using System.Collections;

public class SkeletteMove : MonoBehaviour
{
    GameObject[] Players;
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    int i;

    void Awake()
    {
        // Set up the references.
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        i = 0;
    }


    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        if (Players[i] == null || Players[i].GetComponent<PlayerHealth>().currentHealth > 0)
            i++;
        if (Players.Length <= i)
            i = 0;
        // If the enemy and the player have health left...
        if (nav.enabled && Players[i] != null && enemyHealth.currentHealth > 0 && Players[i].GetComponent<PlayerHealth>().currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(Players[i].transform.position);
        }
        // Otherwise...
        /*else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }*/
    }
}
