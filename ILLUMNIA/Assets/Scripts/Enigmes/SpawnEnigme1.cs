using UnityEngine;
using System.Collections;

public class SpawnEnigme1 : MonoBehaviour
{
    public GameObject skeleton;
    public GameObject mob;
    public Transform spawnskeletonenigm1;
    public Transform spawnmobenigm1;
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
            Instantiate(skeleton, spawnskeletonenigm1.position, spawnskeletonenigm1.rotation);
            Instantiate(mob, spawnmobenigm1.position, spawnmobenigm1.rotation);
            spawnisallowed = false;
        }
    }
}
