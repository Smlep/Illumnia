using UnityEngine;
using System.Collections;

public class Boss1Move : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;
    private Animation animation;
    public int portéededétectiondujoueur;// Reference to the nav mesh agent.

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animation>();
    }


    void Update()
    {
        // Si le monstre est pres du joueur
        if (Mathf.Abs(player.transform.position.x - transform.position.x) +
            Mathf.Abs(player.transform.position.z - transform.position.z) < portéededétectiondujoueur)
        {
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination(player.position);
            }
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
        else
        {
            animation.Play("idle");
        }
        // Otherwise...
       
    }
}
