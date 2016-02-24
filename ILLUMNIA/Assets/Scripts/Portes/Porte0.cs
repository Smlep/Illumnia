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
    // Use this for initialization
    void Start()
    {
        crocohasspawned = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Activate()
    {
        // Get access to the 'DoorOpening' script attached to the door that was hit.
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        if (!crocohasspawned)
        {
            Instantiate(crocodile, spawncroco1.position, spawncroco1.rotation);
            Instantiate(skeleton, spawnskeleton1.position, spawnskeleton1.rotation);
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
