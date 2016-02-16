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
            GUI.color = Color.white;
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 25), "Press 'E' to activate");
        }
    }
}
