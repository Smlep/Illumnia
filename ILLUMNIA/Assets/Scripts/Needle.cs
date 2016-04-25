using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {

    public float timeon;
    public float timeoff;
    private bool plop = true;
    Animation anim;

    // Use this for initialization
    void Start () {
        StartCoroutine(ActivationRoutine());
        anim = gameObject.GetComponent<Animation>();
    }

    private IEnumerator ActivationRoutine()
    {
        while (plop)
        {
            yield return new WaitForSeconds(timeon);
            anim.Play("Anim_TrapNeedle_Hide");
            yield return new WaitForSeconds(timeoff);
            anim.Play("Anim_TrapNeedle_Show");
        }
    }
}
