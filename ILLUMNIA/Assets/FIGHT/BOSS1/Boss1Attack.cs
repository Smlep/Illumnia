using UnityEngine;
using System.Collections;

public class Boss1Attack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.


    Animation Anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    float Mecanic1TimeLeft = 2.0f;
    float TimerMecanic = 10f;
    int HPpourcent;




    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        Anim = GetComponent<Animation>();
        // Code pour empécher la répétition automatique de l'animation
        Anim["jump"].wrapMode = WrapMode.Once;
        // Code pour empécher la répétition automatique de l'animation
        Anim["run"].wrapMode = WrapMode.Once;
        // Code pour empécher la répétition automatique de l'animation 
        Anim["walk"].wrapMode = WrapMode.Once;
        Anim["punch"].wrapMode = WrapMode.Once;
        Anim["hpunch"].wrapMode = WrapMode.Once;
        Anim["hit"].wrapMode = WrapMode.Once;
        Anim["faint"].wrapMode = WrapMode.Once;
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        TimerMecanic -= Time.deltaTime;
        if (TimerMecanic < 0)
        {
            BossMecanic();
            TimerMecanic = 10f;
        }
        if (!playerInRange&&enemyHealth.currentHealth>0)
        {
            Anim.Play("walk");
        }
        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // Jouer l'animation d'attaque;

            // ... attack.
            Attack();
        }

        // If the player has zero or less health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the player is dead.
            // anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        Anim.Play("punch");
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }


    //---------------------------------Phase1(100-75)---------------------------------
    void Mecanic1(Collider other)
    {
        Mecanic1TimeLeft -= Time.deltaTime;
        while (Mecanic1TimeLeft > 0)
        {
            Anim.PlayQueued("faint");
        }
        if (!other.gameObject.CompareTag("ZoneSafe1"))
        {
            playerHealth.TakeDamage((int)(0.25 * playerHealth.startingHealth)); 
        }
    }
    //---------------------------------Phase2(75-50)---------------------------------
    void Mecanic2()
    {

    }
    //---------------------------------Phase3(50-25)---------------------------------
    void Mecanic3()
    {

    }
    //---------------------------------Phase4(25-0)---------------------------------
    void Mecanic4()
    {

    }
    //---------------------------------Phase1(100-75)---------------------------------
    void BossMecanic()
    {
        HPpourcent = 100 * enemyHealth.currentHealth / enemyHealth.startingHealth;
        if (HPpourcent > 75)
        {
        }
    }






}
