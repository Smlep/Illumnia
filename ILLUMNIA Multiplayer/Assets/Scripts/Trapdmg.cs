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
        try {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        catch { }
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
            playerHealth.RpcTakeDamage(trapdmg);
        }
    }
}
