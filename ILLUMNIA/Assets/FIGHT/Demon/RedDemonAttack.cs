using UnityEngine;
using System.Collections;

public class RedDemonAttack : MonoBehaviour
{

    private float timeBetweenAttacks = 1f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    Animation Anim;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    RedDemonMove RDM;
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    float timerforspawn; // Timer entre l'invocation de monstres
    public bool jouelaniamtiondattaque;
    public int Demonkind; // 1 Fire;2 Ice;3 Tree;
    System.Random rnd;
    public bool isgrowing;
    public GameObject RedDemon;
    public GameObject IceDemon;
    public GameObject TreeDemon;

    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        RDM = GetComponent<RedDemonMove>();
        Anim = GetComponent<Animation>();
        // Code pour empécher la répétition automatique 
        Anim["DemDeath"].wrapMode = WrapMode.Once;
        Anim["DemHPunch"].wrapMode = WrapMode.Once;
        Anim["DemJump"].wrapMode = WrapMode.Once;
        Anim["DemPunch"].wrapMode = WrapMode.Once;
        Anim["DemRoar"].wrapMode = WrapMode.Once;
        Anim["DemRun"].wrapMode = WrapMode.Once;
        Anim["DemWalk"].wrapMode = WrapMode.Once;
        rnd = new System.Random();
        isgrowing = false;
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
        timerforspawn += Time.deltaTime;
        if (enemyHealth.currentHealth>0&&enemyHealth.currentHealth<30&&!jouelaniamtiondattaque&&Demonkind==2&&!isgrowing)
        {
            StartCoroutine(Grow());
        }
        else if (!playerInRange && !jouelaniamtiondattaque && RDM.doitcourir && enemyHealth.currentHealth > 0 && !isgrowing)
        {
            Anim.Play("DemRun");
        }
        else if (!playerInRange && !jouelaniamtiondattaque && enemyHealth.currentHealth > 0 && !isgrowing)
        {
            Anim.Play("DemWalk");
        }
        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && Demonkind == 1&&!isgrowing && enemyHealth.currentHealth > 0)
        {
            // Jouer l'animation d'attaque;

            // ... attack.
            StartCoroutine(Attacksimple());
        }
        else if (timer >= timeBetweenAttacks && playerInRange && Demonkind == 2&&!isgrowing && enemyHealth.currentHealth > 0)
        {
            int Random1 = rnd.Next(0, 2);
            if (Random1==0)
            {
                StartCoroutine(Attacksimple());
            }
            else
            {
                StartCoroutine(HPunch());
            } 
        }
        if (timer >= timeBetweenAttacks && Demonkind == 3 && !isgrowing && enemyHealth.currentHealth > 0)
        {
            int Random2 = rnd.Next(0, 4);
            if (Random2 == 0&&timerforspawn>6f)
            {
                StartCoroutine(SpawnLittle());
                timerforspawn = 2f;
            }
            else if (Random2==1&&timerforspawn>10f)
            {
                StartCoroutine(SpawnMedium());
                timerforspawn = 0f;
            }
            else if (playerInRange)
            {
                StartCoroutine(Attacksimple());
            }
            timer = 0f;
        }
    }


    IEnumerator Attacksimple()
    {
        Anim.Play("DemPunch");
        // Reset the timer.
        timer = 0f;
        jouelaniamtiondattaque = true;
        yield return new WaitForSeconds(0.7f);
        timer = 0f;
        // Première partie de l'anim
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
        yield return new WaitForSeconds(0.3f);
        timer = 0f;
        jouelaniamtiondattaque = false;
    }
    IEnumerator HPunch()
    {
        Anim.Play("DemHPunch");
        // Reset the timer.
        timer = 0f;
        jouelaniamtiondattaque = true;
        yield return new WaitForSeconds(0.85f);
        timer = 0f;
        // Première partie de l'anim
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(2*attackDamage);
        }
        yield return new WaitForSeconds(0.15f);
        timer = 0f;
        jouelaniamtiondattaque = false;
    }
    IEnumerator Grow()
    {
        isgrowing = true;
        Anim.Play("DemRoar");
        yield return new WaitForSeconds(1f);
        Instantiate(RedDemon, transform.position + new Vector3(2, 0, 2), transform.rotation);
        Instantiate(RedDemon, transform.position + new Vector3(-2, 0, -2), transform.rotation);
        yield return new WaitForSeconds(1.583f);
        Instantiate(TreeDemon, transform.position, transform.rotation);
        Destroy(gameObject, 0f);
    }
    IEnumerator SpawnLittle()
    {
        Anim.Play("DemRoar");
        yield return new WaitForSeconds(1f);
        Instantiate(RedDemon, transform.position + new Vector3(2, 0, 2), transform.rotation);
        Instantiate(RedDemon, transform.position + new Vector3(-2, 0, -2), transform.rotation);
        yield return new WaitForSeconds(1.583f);
    }
    IEnumerator SpawnMedium()
    {
        Anim.Play("DemRoar");
        yield return new WaitForSeconds(1f);
        Instantiate(IceDemon, transform.position + new Vector3(2, 0, 2), transform.rotation);
        yield return new WaitForSeconds(1.583f);
    }
}
