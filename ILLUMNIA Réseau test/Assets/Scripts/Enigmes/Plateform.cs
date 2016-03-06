using UnityEngine;
using System.Collections;

public class Plateform : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.transform.parent = gameObject.transform;
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
