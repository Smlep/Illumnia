using UnityEngine;
using System.Collections;


public class Camera1 : MonoBehaviour
{
    public float speed;
    public float _xSpeed = 1f;
    public float _ySpeed = 1f;
    private float _x = 0.0f;
    private float _y = 0.0f;
    void Start()
    {
        Vector2 angles = this.transform.localEulerAngles;
        _x = angles.x;
        _y = angles.y;
        this.Rotate(_x, _y);
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        if (moveHorizontal > 0 && moveVertical > 0)
        {
            transform.position += (movement * speed) / 2;
        }
        else
        {
            transform.position += (movement * speed);
        }
        this.RotateControls();
    }
    void Rotate(float x, float y)
    {
        Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
        transform.rotation = rotation;
    }
    void RotateControls()
    {
        _x += Input.GetAxis("Mouse X") * _xSpeed;
        _y += -Input.GetAxis("Mouse Y") * _ySpeed;
        this.Rotate(_x, _y);
    }
}
