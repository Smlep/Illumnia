using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss3Attack : MonoBehaviour {

    float timerMecanic = 5f;
    bool playerInRange;
    float TimerLaser = 0.1f;
    public Slider enemyHealthSlider;
    GameObject spawnenemy, boss, player, laser1, laser2, baril_fin, baril_start, baril_pos_1, baril_pos_2, baril_pos_3, baril_pos_4;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth, e1Health;
    Animation Anim;
    private ScriptPersonnage scriptdupersonnage;
    private GameObject e1;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    // Use this for initialization
    void Awake()
    {

        spawnenemy = GameObject.Find("boss3spawn");
        Boss3Move.lebosspeutbouger = false;
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.Find("CaveWorm");
        baril_pos_1 = GameObject.Find("baril_pos_1");
        baril_pos_2 = GameObject.Find("baril_pos_2");
        baril_pos_3 = GameObject.Find("baril_pos_3");
        baril_pos_4 = GameObject.Find("baril_pos_4");
        laser1 = GameObject.Find("laser1");
        laser2 = GameObject.Find("laser2");
        baril_fin = GameObject.Find("baril_fin");
        baril_start = GameObject.Find("baril_start");
        scriptdupersonnage = GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptPersonnage>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        TimerLaser -= Time.deltaTime;
        timerMecanic -= Time.deltaTime;
        if (TimerLaser < 0)
        {
            laser();
            TimerLaser = 0.1f;
        }
        if (timerMecanic < 0)
        {
            timerMecanic = 15f;
            StartCoroutine(Mecanic1());
        }
    }

    IEnumerator Mecanic1()
    {
        System.Random rand_monster = new System.Random();
        int x = rand_monster.Next(1, 4);
        switch (x)
        {
            case 1:
                e1 = (GameObject)Instantiate(enemy1, spawnenemy.transform.position, spawnenemy.transform.rotation);
                e1Health = e1.GetComponent<EnemyHealth>();
                break;
            case 2:
                e1 = (GameObject)Instantiate(enemy2, spawnenemy.transform.position, spawnenemy.transform.rotation);
                e1Health = e1.GetComponent<EnemyHealth>();
                break;
            case 3:
                e1 = (GameObject)Instantiate(enemy3, spawnenemy.transform.position, spawnenemy.transform.rotation);
                e1Health = e1.GetComponent<EnemyHealth>();
                break;
        }
        yield return new WaitForSeconds(14f);
        if (e1Health.currentHealth > 0)
        {
            playerHealth.RpcTakeDamage((int)(0.5 * playerHealth.startingHealth));
            Destroy(e1, 0f);
        }
        else
        {
            enemyHealth.TakeDamage(100, Vector3.zero);
        }
    }
    

    void laser()
    { 
        if (scriptdupersonnage.laser1 || scriptdupersonnage.laser2)
        {
            playerHealth.RpcTakeDamage((int)(0.4 * playerHealth.startingHealth));
        }
        laser1.transform.position = new Vector3(laser1.transform.position.x, laser1.transform.position.y, laser1.transform.position.z - 0.5f);
        laser2.transform.position = new Vector3(laser2.transform.position.x, laser2.transform.position.y, laser2.transform.position.z - 0.5f);
        if (laser1.transform.position.z < baril_fin.transform.position.z)
        {
            System.Random position_rayon = new System.Random();
            int x = position_rayon.Next(1, 5);
            switch (x)
            {
                case 1:
                    laser1.transform.position = new Vector3(baril_pos_1.transform.position.x, laser1.transform.position.y, baril_start.transform.position.z);
                    laser2.transform.position = new Vector3(baril_pos_1.transform.position.x - 8, laser2.transform.position.y, baril_start.transform.position.z);
                    break;
                case 2:
                    laser1.transform.position = new Vector3(baril_pos_2.transform.position.x, laser1.transform.position.y, baril_start.transform.position.z);
                    laser2.transform.position = new Vector3(baril_pos_2.transform.position.x - 8, laser2.transform.position.y, baril_start.transform.position.z);
                    break;
                case 3:
                    laser1.transform.position = new Vector3(baril_pos_3.transform.position.x, laser1.transform.position.y, baril_start.transform.position.z);
                    laser2.transform.position = new Vector3(baril_pos_3.transform.position.x - 8, laser2.transform.position.y, baril_start.transform.position.z);
                    break;
                case 4:
                    laser1.transform.position = new Vector3(baril_pos_4.transform.position.x, laser1.transform.position.y, baril_start.transform.position.z);
                    laser2.transform.position = new Vector3(baril_pos_4.transform.position.x - 8, laser2.transform.position.y, baril_start.transform.position.z);
                    break;
            }
        }
    }
    
}
