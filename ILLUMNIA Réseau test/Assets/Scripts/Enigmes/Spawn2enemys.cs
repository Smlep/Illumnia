using UnityEngine;
using System.Collections;

public class Spawn2enemys : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public Transform spawnenemy1;
    public Transform spawnenemy2;
    private bool spawnisallowed;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawnallowed());
    }

    IEnumerator Spawnallowed()
    {
        while (true)
        {
            spawnisallowed = true;
            yield return new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    void Activate()
    {
        if (spawnisallowed)
        {
            Instantiate(enemy1, spawnenemy1.position, spawnenemy1.rotation);
            Instantiate(enemy2, spawnenemy2.position, spawnenemy2.rotation);
            spawnisallowed = false;
        }
    }
}
