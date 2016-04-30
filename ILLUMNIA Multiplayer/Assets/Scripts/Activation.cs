using UnityEngine;
using System.Collections;

public class Activation : MonoBehaviour
{
    public RaycastHit hit;
    public bool reached;
    public string TriggerTag1 = "Interact";
    public string TriggerTag2 = "PorteBoss1";
    public float range = 4F;
    private bool canbeactivated;
    [HideInInspector]
    public bool open;
    public static Activation main;

    // Use this for initialization
    void Start()
    {
        canbeactivated = true;
        StartCoroutine(Canturnon());
    }

    IEnumerator Canturnon()
    {
        while (true)
        {
            canbeactivated = true;
            yield return new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if ((Physics.Raycast(ray, out hit, range)) && (hit.collider.tag == TriggerTag1 || hit.collider.tag == TriggerTag2))
            {
                reached = true;


                if (Input.GetKey(KeyCode.E))
                {
                    if (canbeactivated)
                    {
                        //Raycast outward
                        if (Physics.Raycast(transform.position, transform.forward, out hit, 4))
                        {
                            //if there is an object tagged as "Interact"
                            if (hit.transform.tag == "Interact")
                            {
                                //call activate | this will call the activate function on whichever script is attached to the lever, as long as it has an Activate() function
                                hit.transform.gameObject.SendMessage("Activate");

                            }
                            if (hit.transform.tag == "PorteBoss1")
                            {
                                if (ScriptPersonnage.main.playerhasthekey)
                                {
                                    hit.transform.gameObject.SendMessage("Activate");
                                    ScriptPersonnage.main.playerhasthekey = false;
                                }
                            }

                        }
                        canbeactivated = false;
                    }

                }

            }
            else reached = false;
        }
        catch { }
    }

    void Awake()
    {
        main = this;
    }
}
