using UnityEngine;
using System.Collections;

public class TrollAttack : MonoBehaviour
{
    private float timeBetweenAttacks = 3f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.


    Animation Anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    public bool jouelaniamtiondattaque;
    private GameObject target;

    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        Anim = GetComponent<Animation>();
        // Code pour empécher la répétition automatique 
        Anim["Run"].wrapMode = WrapMode.Once;
        Anim["Jump"].wrapMode = WrapMode.Once;
        Anim["Attack_01"].wrapMode = WrapMode.Once;
        Anim["Attack_02"].wrapMode = WrapMode.Once;
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
        if (!playerInRange&&!jouelaniamtiondattaque&&enemyHealth.currentHealth>50)
        {
            Anim.Play("Walk");
        }
        else if (!playerInRange&&!jouelaniamtiondattaque&&enemyHealth.currentHealth>0)
        {
            Anim.Play("Run");
        }
        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= 2f && playerInRange && enemyHealth.currentHealth > 50)
        {
            // Jouer l'animation d'attaque;

            // ... attack.
            StartCoroutine(Attackpeudevie());
        }
        else if (timer >= 2f && playerInRange && enemyHealth.currentHealth > 0)
        {
            // Jouer l'animation d'attaque;

            // ... attack.
            StartCoroutine(Attackforte());
        }
    }


    IEnumerator Attackforte()
    {
        Anim.Play("Attack_01");
        // Reset the timer.
        timer = 0f;
        jouelaniamtiondattaque = true;
        yield return new WaitForSeconds(1f);
        timer = 0f;
        jouelaniamtiondattaque = false;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0&&enemyHealth.currentHealth>0)
        {
            playerHealth = target.GetComponent<PlayerHealth>();
            // ... damage the player.
            playerHealth.RpcTakeDamage(attackDamage);
        }
    }
    IEnumerator Attackpeudevie()
    {
        Anim.Play("Attack_02");
        // Reset the timer.
        timer = 0f;
        jouelaniamtiondattaque = true;
        yield return new WaitForSeconds(0.6f);
        timer = 0f;
        // Première partie de l'anim
        if (playerHealth.currentHealth > 0&&enemyHealth.currentHealth>0)
        {
            // ... damage the player.
            playerHealth = target.GetComponent<PlayerHealth>();
            playerHealth.RpcTakeDamage(attackDamage/3);
        }
        yield return new WaitForSeconds(1.4f);
        timer = 0f;


        // Seconde partie de l'anim
        if (playerHealth.currentHealth > 0&&enemyHealth.currentHealth>0)
        {
            // ... damage the player.
            playerHealth = target.GetComponent<PlayerHealth>();
            playerHealth.RpcTakeDamage(attackDamage / 3);
        }
        jouelaniamtiondattaque = false;
    }
}
