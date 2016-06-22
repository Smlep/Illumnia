using UnityEngine;
using System.Collections;

public class MultiplayerShit : MonoBehaviour {

    Camera SceneCamera;
	// Use this for initialization
	void Start () {
        SceneCamera = GameObject.FindGameObjectWithTag("CamStart").GetComponent<Camera>();
        SceneCamera.gameObject.SetActive(false);
        SceneCamera.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
