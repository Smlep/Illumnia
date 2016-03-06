using UnityEngine;
using System.Collections;

public class GUItest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        // Access InReach variable from raycasting script.
        GameObject Player = GameObject.Find("Player");
        Activation activation = Player.GetComponent<Activation>();

        if (activation.reached == true)
        {
            if (Activation.main.hit.transform.tag == "Interact")
            {
                GUI.color = Color.white;
                GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 25), "Press 'E' to activate");
            }
            if (Activation.main.hit.transform.tag == "PorteBoss1")
            {
                if (ScriptPersonnage.main.playerhasthekey)
                {
                    GUI.color = Color.white;
                    GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 25), "Press 'E' to use the key");
                }
                else
                {
                    GUI.color = Color.white;
                    GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 25), "It's locked");
                }
            }
        }
    }
}
