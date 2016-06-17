﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int tauxderégen;
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    private Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    // public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public bool enmodedéfensif;
    public bool healautorise; // A débloqué le pouvoir de Heal
    private float TimerHealPower; // Timer pour pouvoir se heal
    private Text CanvasTimerHeal; // Chronoaffiché
    private Text texteannonce; // texte d'annonce
    private Image HeartAfterHEal; // Coeur qui s'affiche après un Heal

    Animator anim;                                              // Reference to the Animator component.
    // AudioSource playerAudio;                                    // Reference to the AudioSource component.
    ScriptPersonnage playerMovement;                              // Reference to the player's movement.
    PlayerAttack playerShooting;                              // Reference to the PlayerShooting script.
    public bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    void Awake()
    {
        healthSlider = GameObject.FindGameObjectWithTag("SliderviePlayer").GetComponent<Slider>();
        damageImage = GameObject.FindGameObjectWithTag("DamageImage").GetComponent<Image>();
        // Setting up the references.
        anim = GetComponent<Animator>();
        // playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<ScriptPersonnage>();
        playerShooting = GetComponentInChildren<PlayerAttack>();
        // Set the initial health of the player.
        currentHealth = startingHealth;
        enmodedéfensif = false;
        StartCoroutine(Autoregen());
        CanvasTimerHeal = GameObject.FindGameObjectWithTag("ChronoHeal").GetComponent<Text>();
        texteannonce = GameObject.FindGameObjectWithTag("Annonce").GetComponent<Text>();
        HeartAfterHEal = GameObject.FindGameObjectWithTag("HeartAfterHeal").GetComponent<Image>();
        HeartAfterHEal.gameObject.SetActive(false);

    }


    void Update()
    {
        if (TimerHealPower < 25f)
        {
            TimerHealPower += Time.deltaTime;
        }
        if (TimerHealPower > 25f)
        {
            TimerHealPower = 25f;
        }
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
        if (healautorise)
        {
            if (TimerHealPower < 25)
                CanvasTimerHeal.text = "Heal ready in " + (25 - TimerHealPower).ToString() + " seconds !";
            else
                CanvasTimerHeal.text = "Heal Ready ! Press H to use !";
            if (Input.GetKeyUp(KeyCode.H))
            {
                StartCoroutine(HealPower());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Détecter les collisions
        if (other.gameObject.CompareTag("HealZone"))
        {
            Resethealth();
        }
    }

    public void Resethealth()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        if (!enmodedéfensif)
        {
            currentHealth -= amount;
        }
        else
        {
            currentHealth -= amount / 2;
        }

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        // playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    IEnumerator Autoregen()
    {
        while (true)
        {
            if (currentHealth <= startingHealth)
            {
                currentHealth += tauxderégen;
                healthSlider.value = currentHealth;
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }

    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        playerShooting.DisableEffects();

        // Tell the animator that the player is dead.
        // anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        // playerAudio.clip = deathClip;
        // playerAudio.Play();

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
    IEnumerator HealPower()
    {
        if (TimerHealPower >= 25f)
        {
            TimerHealPower = 0f;
            currentHealth += startingHealth * 3 / 4;
            if (currentHealth > startingHealth)
            {
                currentHealth = startingHealth;
            }
            texteannonce.text = "Healed !";
            HeartAfterHEal.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            HeartAfterHEal.gameObject.SetActive(false);
            texteannonce.text = " ";
        }
        yield return new WaitForSeconds(0);
    }
}