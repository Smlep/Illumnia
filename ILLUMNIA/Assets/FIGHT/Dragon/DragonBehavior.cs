using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DragonBehavior : MonoBehaviour {
    public AudioClip[] sound;
    float TimerMecanic = 5;
    public GameObject boss;
    private ScriptPersonnage scriptdupersonage;
    private GameObject enemyhealthSliderObjectGameObject;
    public Slider enemyHealthSlider;
    public GameObject spawnenemy;
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    Animator anim;
    PlayerHealth playerHealth;
    GameObject player, ZoneMorteGauche, ZoneMorteDroite, BulleVerte, souffle_part;
    private GameObject e1;
    public GameObject enemy;
    EnemyHealth e1Health;
    float x;
    // Use this for initialization
    void Awake ()
    {
        boss = GameObject.Find("Boss2-v3");
        souffle_part = GameObject.Find("souffle_part");
        spawnenemy = GameObject.Find("SpawnBoss2");
        ZoneMorteDroite = GameObject.Find("ZoneMorteDroite");
        ZoneMorteGauche = GameObject.Find("ZoneMorteGauche");
        BulleVerte = GameObject.Find("BulleVerte");
        x = souffle_part.transform.position.y;
        BulleVerte.transform.position = new Vector3(BulleVerte.transform.position.x, -20f, BulleVerte.transform.position.z);
        ZoneMorteGauche.transform.position = new Vector3(ZoneMorteGauche.transform.position.x, -20f, ZoneMorteGauche.transform.position.z);
        ZoneMorteDroite.transform.position = new Vector3(ZoneMorteDroite.transform.position.x, -20f, ZoneMorteDroite.transform.position.z);
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyhealthSliderObjectGameObject = GameObject.FindGameObjectWithTag("BossHealthSlider2");
        enemyHealthSlider = enemyhealthSliderObjectGameObject.GetComponent<Slider>();
        enemyHealthSlider.maxValue = enemyHealth.startingHealth;
        anim = GetComponent<Animator>();
        scriptdupersonage = GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptPersonnage>();
        souffle_part.transform.position = new Vector3(souffle_part.transform.position.x, -20f, souffle_part.transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Slider de vie
        enemyHealthSlider.value = enemyHealth.currentHealth;
        TimerMecanic -= Time.deltaTime;
        if (TimerMecanic < 0)
        {
            MecanicRand();
            TimerMecanic = 22;
        }
    }
    void MecanicRand()
    {
        System.Random MecRand = new System.Random();
        int Mec = MecRand.Next(1, 4);
        switch (Mec)
        {
            case 1:
                StartCoroutine(Mecanic1());
                break;
            case 2:
                StartCoroutine(Mecanic2());
                break;
            case 3:
                StartCoroutine(Mecanic3());
                break;
        }
    }
    //Souffle
    IEnumerator Mecanic1()
    {
        anim.SetBool("souffle", true);
        yield return new WaitForSeconds(2f);
        souffle_part.transform.position = new Vector3(souffle_part.transform.position.x, x, souffle_part.transform.position.z);
        //mettre la mecanic ici
        AudioSource.PlayClipAtPoint(sound[1], boss.transform.position);
        if (!playerHealth.enmodedéfensif)
            playerHealth.TakeDamage((int)(0.2 * playerHealth.startingHealth));
        yield return new WaitForSeconds(0.8f);
        if (!playerHealth.enmodedéfensif)
            playerHealth.TakeDamage((int)(0.3 * playerHealth.startingHealth));
        yield return new WaitForSeconds(0.8f);
        if (!playerHealth.enmodedéfensif)
            playerHealth.TakeDamage((int)(0.4 * playerHealth.startingHealth));
        souffle_part.transform.position = new Vector3(souffle_part.transform.position.x, -20f, souffle_part.transform.position.z);
        //mettre la mecanic ici
        anim.SetBool("isFlying", true);
        anim.SetBool("souffle", false);
    }
    //Coup d'aile droite ou gauche
    IEnumerator Mecanic2()
    {
        System.Random GaucheDroite = new System.Random();
        AudioSource.PlayClipAtPoint(sound[1], boss.transform.position);
        int GD = GaucheDroite.Next(1, 3);
        if (GD == 1)
        {
            ZoneMorteDroite.transform.position = new Vector3(ZoneMorteDroite.transform.position.x, 0.1f, ZoneMorteDroite.transform.position.z);
            anim.SetBool("aileGauche", true);
            yield return new WaitForSeconds(3f);
            anim.SetBool("isFlying", true);
            anim.SetBool("aileGauche", false);
            ZoneMorteDroite.transform.position = new Vector3(ZoneMorteDroite.transform.position.x, -20f, ZoneMorteDroite.transform.position.z);
        }
        else
        {
            ZoneMorteGauche.transform.position = new Vector3(ZoneMorteGauche.transform.position.x, 0.1f, ZoneMorteGauche.transform.position.z);
            anim.SetBool("aileDroite", true);
            yield return new WaitForSeconds(3f);
            anim.SetBool("isFlying", true);
            anim.SetBool("aileDroite", false);
            ZoneMorteGauche.transform.position = new Vector3(ZoneMorteGauche.transform.position.x, -20f, ZoneMorteGauche.transform.position.z);
        }
        if (GD == 2 && scriptdupersonage.lejoueurestagauche)
        {
            playerHealth.TakeDamage((int)(0.5 * playerHealth.startingHealth));
        }
        if (GD == 1 && scriptdupersonage.lejoueurestadroite)
        {
            playerHealth.TakeDamage((int)(0.5 * playerHealth.startingHealth));
        }
    }
    //Envol
    IEnumerator Mecanic3()
    {
        AudioSource.PlayClipAtPoint(sound[1], boss.transform.position);
        e1 = (GameObject)Instantiate(enemy, spawnenemy.transform.position, spawnenemy.transform.rotation);
        e1Health = e1.GetComponent<EnemyHealth>();
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0.2f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0.4f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0.6f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0.8f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1.2f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1.4f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1.6f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1.8f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 2f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 2.2f, boss.transform.position.z);
        yield return new WaitForSeconds(12f);
        if (e1Health.currentHealth > 0)
        {
            enemyHealth.TakeDamage(e1Health.currentHealth, Vector3.zero);
            Destroy(e1, 0f);
        }
        else
        {
            enemyHealth.TakeDamage(e1Health.currentHealth, Vector3.zero);
            BulleVerte.transform.position = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
            Destroy(e1, 0f);
        }
        yield return new WaitForSeconds(5f);
        boss.transform.position = new Vector3(boss.transform.position.x, 2f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1.8f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1.6f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1.4f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1.2f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 1f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0.8f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0.6f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0.4f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0.2f, boss.transform.position.z);
        yield return new WaitForSeconds(0.1f);
        boss.transform.position = new Vector3(boss.transform.position.x, 0f, boss.transform.position.z);
        BulleVerte.transform.position = new Vector3(player.transform.position.x, -20f, player.transform.position.z);
        if (!scriptdupersonage.lejoueurestdanslabulle)
        {
            playerHealth.TakeDamage((int)(0.5 * playerHealth.startingHealth));
        }
    }
}
