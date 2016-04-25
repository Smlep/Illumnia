using UnityEngine;
using System.Collections;

public class Trapdmg : MonoBehaviour {

    private float timeBetweenAttacks = 1f;
    private GameObject player;
    PlayerHealth playerHealth;
    public int trapdmg;
    bool playerInRange;
    float timer;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Damage();
        }
    }

    void Damage()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(trapdmg);
        }
    }
}
