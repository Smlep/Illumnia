using UnityEngine;
using System.Collections;

public class SqueletteAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.


    Animation Anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    private GameObject target;


    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        Anim = GetComponent<Animation>();
        // Code pour empécher la répétition automatique de l'animation d'attaque
        Anim["Attack1h1"].wrapMode = WrapMode.Once;
        // Code pour empécher la répétition automatique de l'animation de saut
        Anim["Hit1"].wrapMode = WrapMode.Once;
        // Code pour empécher la répétition automatique de l'animation de déplacement
        Anim["Walk"].wrapMode = WrapMode.Once;
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject.CompareTag("Player"))
        {
            // ... the player is in range.
            target = other.gameObject;
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
        if (!playerInRange)
        {
            Anim.Play("Walk");
        }
        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0 && target.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            // Jouer l'animation d'attaque;

            // ... attack.
            Attack();
        }   
    }


    void Attack()
    {
        Anim.Play("Attack1h1");
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
