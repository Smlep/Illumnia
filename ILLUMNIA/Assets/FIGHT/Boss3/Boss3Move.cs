using UnityEngine;
using System.Collections;

public class Boss3Move : MonoBehaviour {

    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;
    private Animation animation;
    public static bool leplayerestassezproche;
    public static bool lebosspeutbouger;
    public int portéededétectiondujoueur;// Reference to the nav mesh agent.

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        animation = GetComponent<Animation>();
        lebosspeutbouger = true;
    }


    void Update()
    {
        leplayerestassezproche = Mathf.Abs(player.transform.position.x - transform.position.x) +
                                 Mathf.Abs(player.transform.position.z - transform.position.z) <
                                 portéededétectiondujoueur;
        // Si le monstre est pres du joueur
        if (leplayerestassezproche)
        {
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination(player.position);
                animation.Play("Walk");
            }
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
        if (lebosspeutbouger && enemyHealth.currentHealth > 0)
        {
            nav.Resume();
        }
        else if (enemyHealth.currentHealth > 0)
        {
            nav.Stop();
        }
    }
}
