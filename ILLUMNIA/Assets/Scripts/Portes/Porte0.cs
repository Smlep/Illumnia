using UnityEngine;
using System.Collections;

public class Porte0 : MonoBehaviour
{
    RaycastHit hitted;
    public GameObject Door;
    public GameObject crocodile;
    public GameObject skeleton;
    public Transform spawncroco1;
    public Transform spawnskeleton1;
    private bool crocohasspawned;
    public GameObject nextlever;
    private Object croco1;
    private Object skeleton1;
    // Use this for initialization
    void Start()
    {
        crocohasspawned = false;
        nextlever.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (crocohasspawned)
        {
            if (croco1 == null && skeleton1 == null)
            {
                nextlever.SetActive(true);
            }
        }
    }

    void Activate()
    {
        // Get access to the 'DoorOpening' script attached to the door that was hit.
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (!crocohasspawned)
        {
            croco1 =Instantiate(crocodile, spawncroco1.position, spawncroco1.rotation);
            skeleton1 = Instantiate(skeleton, spawnskeleton1.position, spawnskeleton1.rotation);
        }
        Door dooropening = Door.GetComponent<Door>();
        crocohasspawned = true;
        // Check whether the door is opening/closing or not.
        if (dooropening.Running == false)
        {
            // Open/close the door by running the 'Open' function in the 'DoorOpening' script.
            StartCoroutine(Door.GetComponent<Door>().Open());
        }

    }

}
