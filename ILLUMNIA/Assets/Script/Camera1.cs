using UnityEngine;
using System.Collections;


public class Camera1 : MonoBehaviour {
    public float speed;
	void Start () {
    }
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.position+=(movement * speed);
    }
}
