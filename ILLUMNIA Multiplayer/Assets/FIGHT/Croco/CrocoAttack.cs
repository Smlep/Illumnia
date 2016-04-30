using UnityEngine;
using System.Collections;


public class CrocoAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.


    Animator anim;                              // Reference to the animator component.
    GameObject[] players;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    Collider playertoattack;
    GameObject[] Players;


    void Awake()
    {
        // Setting up the references.
        players = GameObject.FindGameObjectsWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject.CompareTag("Player")&&other.GetComponent<PlayerHealth>().currentHealth>0)
        {
            // ... the player is in range.
            playertoattack = other;
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject.CompareTag("Player"))
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        Players = GameObject.FindGameObjectsWithTag("Player");
        if (playerInRange)
        {
            anim.SetBool("IsMoving",false);
        }
        else
        {
            anim.SetBool("IsMoving", true);
        }
        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange &&  enemyHealth.currentHealth > 0  &&playertoattack.GetComponent<PlayerHealth>().currentHealth>0)
        {
            // Jouer l'animation d'attaque;
            
            // ... attack.
            Attack(playertoattack.gameObject);
        }
    }


    void Attack(GameObject target)
    {
        anim.SetTrigger("Attack");
        // Reset the timer.
        timer = 0f;
        playerHealth = target.GetComponent<PlayerHealth>();
        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.RpcTakeDamage(attackDamage);
        }
    }
}