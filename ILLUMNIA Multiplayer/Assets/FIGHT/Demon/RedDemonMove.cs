using UnityEngine;
using System.Collections;

public class RedDemonMove : MonoBehaviour {

    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    private float vitessededépart;
    public bool doitcourir;
    public int Demonkind; // 1 Fire;2 Ice;3 Tree;

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        vitessededépart = nav.speed;
        if (Demonkind==1)
        {
            StartCoroutine(pretacourir());
        }        
    }


    void Update()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
    IEnumerator pretacourir()
    {
        yield return new WaitForSeconds(2f);
        doitcourir = true;
        nav.speed *=2;
    }

}
