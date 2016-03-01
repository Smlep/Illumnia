using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss1Attack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    private ScriptPersonnage scriptdupersonage;
    Animation Anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    float TimerMecanic = 10f;
    public Slider enemyHealthSlider;
    private GameObject enemyhealthSliderObjectGameObject;
    public bool seconcentre;
    int HPpourcent;
    GameObject ZoneSafe1, ZoneSafe2, ZoneSafe3, ZoneSafe4, ZoneSafe5;

    void Awake()
    {
        //Récupère les zones safes
        ZoneSafe1 = GameObject.Find("ZoneSafe1");
        ZoneSafe2 = GameObject.Find("ZoneSafe2");
        ZoneSafe3 = GameObject.Find("ZoneSafe3");
        ZoneSafe4 = GameObject.Find("ZoneSafe4");
        ZoneSafe5 = GameObject.Find("ZoneSafe5");
            

        //Initialise toutes les zones sous la carte (bullshit pour pas qu'on ne les vois)
        ZoneSafe1.transform.position = new Vector3(ZoneSafe1.transform.position.x, -20f, ZoneSafe1.transform.position.z);
        ZoneSafe2.transform.position = new Vector3(ZoneSafe2.transform.position.x, -20f, ZoneSafe2.transform.position.z);
        ZoneSafe3.transform.position = new Vector3(ZoneSafe3.transform.position.x, -20f, ZoneSafe3.transform.position.z);
        ZoneSafe4.transform.position = new Vector3(ZoneSafe4.transform.position.x, -20f, ZoneSafe4.transform.position.z);
        ZoneSafe5.transform.position = new Vector3(ZoneSafe5.transform.position.x, -20f, ZoneSafe5.transform.position.z);

        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        Anim = GetComponent<Animation>();
        scriptdupersonage = player.GetComponent<ScriptPersonnage>();
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
        // Récupère le slider
        enemyhealthSliderObjectGameObject = GameObject.FindGameObjectWithTag("BossHealthSlider");
        enemyHealthSlider = enemyhealthSliderObjectGameObject.GetComponent<Slider>();
        enemyHealthSlider.maxValue = enemyHealth.startingHealth;
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
        if (TimerMecanic < 0 && (Boss1Move.leplayerestassezproche))
        {
            BossMecanic();
            TimerMecanic = 10f;
        }
        if (!playerInRange && enemyHealth.currentHealth > 0 && Boss1Move.lebosspeutbouger)
        {
            Anim.PlayQueued("walk");
        }
        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0&&!seconcentre)
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
        enemyHealthSlider.value = enemyHealth.currentHealth;
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
    IEnumerator Mecanic1()
    {
        Boss1Move.lebosspeutbouger = false;
        Anim.Play("faint");
        Anim.PlayQueued("faint");
        Anim.PlayQueued("faint");
        Anim.PlayQueued("faint");
        Anim.PlayQueued("faint");
        System.Random ZoneRand = new System.Random();
        int ZoneSafe = ZoneRand.Next(1, 6);
        switch (ZoneSafe)
        {
            case 1:
                ZoneSafe1.transform.position = new Vector3(ZoneSafe1.transform.position.x, 0.03f, ZoneSafe1.transform.position.z);
                break;
            case 2:
                ZoneSafe2.transform.position = new Vector3(ZoneSafe2.transform.position.x, 0.03f, ZoneSafe2.transform.position.z);
                break;
            case 3:
                ZoneSafe3.transform.position = new Vector3(ZoneSafe3.transform.position.x, 0.03f, ZoneSafe3.transform.position.z);
                break;
            case 4:
                ZoneSafe4.transform.position = new Vector3(ZoneSafe4.transform.position.x, 0.03f, ZoneSafe4.transform.position.z);
                break;
            case 5:
                ZoneSafe5.transform.position = new Vector3(ZoneSafe5.transform.position.x, 0.03f, ZoneSafe5.transform.position.z);
                break;
        }
        seconcentre = true;
        yield return new WaitForSeconds(6.835f);// L'animation faint dure 1.367 sec x 5 = 6.835
        seconcentre = false;
        Boss1Move.lebosspeutbouger = true;
        switch (ZoneSafe)
        {
            case 1:
                if (!scriptdupersonage.Lejoueurestdanslazone1)
                {
                    playerHealth.TakeDamage((int)(0.25 * playerHealth.startingHealth));
                }
                ZoneSafe1.transform.position = new Vector3(ZoneSafe1.transform.position.x, -20f, ZoneSafe1.transform.position.z);
                break;
            case 2:
                if (!scriptdupersonage.Lejoueurestdanslazone2)
                {
                    playerHealth.TakeDamage((int)(0.25 * playerHealth.startingHealth));
                }
                ZoneSafe2.transform.position = new Vector3(ZoneSafe2.transform.position.x, -20f, ZoneSafe2.transform.position.z);
                break;
            case 3:
                if (!scriptdupersonage.Lejoueurestdanslazone3)
                {
                    playerHealth.TakeDamage((int)(0.25 * playerHealth.startingHealth));
                }
                ZoneSafe3.transform.position = new Vector3(ZoneSafe3.transform.position.x, -20f, ZoneSafe3.transform.position.z);
                break;
            case 4:
                if (!scriptdupersonage.Lejoueurestdanslazone4)
                {
                    playerHealth.TakeDamage((int)(0.25 * playerHealth.startingHealth));
                }
                ZoneSafe4.transform.position = new Vector3(ZoneSafe4.transform.position.x, -20f, ZoneSafe4.transform.position.z);
                break;
            case 5:
                if (!scriptdupersonage.Lejoueurestdanslazone5)
                {
                    playerHealth.TakeDamage((int)(0.25 * playerHealth.startingHealth));
                }
                ZoneSafe5.transform.position = new Vector3(ZoneSafe5.transform.position.x, -20f, ZoneSafe5.transform.position.z);
                break;
            default:
                playerHealth.TakeDamage((int)(0.25 * playerHealth.startingHealth));
                break;
        }
        TimerMecanic = 10f;
    }
    //---------------------------------Phase2(75-50)---------------------------------
    //IEnumerator Mecanic2()

    //---------------------------------Phase3(50-25)---------------------------------
    //IEnumerator Mecanic3()

    //---------------------------------Phase4(25-0)---------------------------------
    //IEnumerator Mecanic4()

    //---------------------------------Phase1(100-75)---------------------------------
    void BossMecanic()
    {
        // Il faut appeler les mechaniques avec startcoroutine
        HPpourcent = 100 * enemyHealth.currentHealth / enemyHealth.startingHealth;
        if (HPpourcent > 75)
        {
            StartCoroutine(Mecanic1());
        }
    }
}