﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;           // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 0.5f;              // The speed at which the enemy sinks through the floor when dead.
                                                // public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
                                                // public AudioClip deathClip;                 // The sound to play when the enemy dies.


    Animator anim;
    Animation animation;// Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    //ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.
    public int typedemonstre; // 0= Croco ; 1=Squelette ; 2= MOB ; 3=Boss1 ; 4=Troll ; 5= Demon ; 6= Boss2
    bool deathanimationplayed;
    private Boss1Attack boss1attack;
    private TrollAttack trollAttack;

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        enemyAudio = GetComponent<AudioSource>();
        if (typedemonstre == 3)
        {
            boss1attack = GetComponent<Boss1Attack>();
        }
        if (typedemonstre == 4)
        {
            trollAttack = GetComponent<TrollAttack>();
        }
        //hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
        if (typedemonstre == 4)
        {
            // Code pour empécher la répétition automatique de l'animation d'attaque
            animation["Hit"].wrapMode = WrapMode.Once;
            // Code pour empécher la répétition automatique de l'animation de saut
            animation["Die"].wrapMode = WrapMode.Once;
        }
    }

    void Update()
    {
        // If the enemy should be sinking...
        if (isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (typedemonstre == 0 || typedemonstre == 2)
        {
            anim.SetTrigger("TakeDamage");
        }
        else if (typedemonstre == 1)
        {
            animation.Play("Hit1");
        }
        else if (typedemonstre == 3 && currentHealth > 0&&!boss1attack.seconcentre)
        {
            animation.Play("hit");
        }
        else if (typedemonstre == 4&&currentHealth>0&&!trollAttack.jouelaniamtiondattaque)
        {
            animation.Play("Hit");
        }

        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        // enemyAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        // Set the position of the particle system to where the hit was sustained.
        // hitParticles.transform.position = hitPoint;

        // And play the particles.
        //hitParticles.Play();

        // If the current health is less than or equal to zero...

    }


    void Death()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        if (typedemonstre == 0 || typedemonstre == 2)
        {
            anim.SetTrigger("Dead");
        }
        else if (typedemonstre == 1)
        {
            animation.Play("Hit1");
        }        
        else if (typedemonstre == 3&&!deathanimationplayed)
        {
            animation.Play("death");
            deathanimationplayed = true;
        }
        else if (typedemonstre==4&&!deathanimationplayed)
        {
            animation.Play("Die");
            deathanimationplayed = true;
        }
        else if (typedemonstre == 5 && !deathanimationplayed)
        {
            animation.Play("DemDeath");
            deathanimationplayed = true;
        }
        StartSinking();

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
    }


    public void StartSinking()
    {
        // Find and disable the Nav Mesh Agent.
        if (typedemonstre!=6)
           GetComponent<NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // Increase the score by the enemy's score value.
        //  ScoreManager.score += scoreValue;
        if (typedemonstre == 4)
        {
            Destroy(gameObject,2);
        }
        else
        {
            // After 5 seconds destory the enemy.
        Destroy(gameObject, 5f);
        }     
    }
}