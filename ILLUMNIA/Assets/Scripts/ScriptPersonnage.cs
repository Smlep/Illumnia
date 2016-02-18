﻿using UnityEngine;
using System.Collections;


public class ScriptPersonnage : MonoBehaviour
{
    public float speed;
    public float _xSpeed = 1f;
    public float _ySpeed = 1f;
    private float _x = 0.0f;
    private float _y = 0.0f;
    public Animation characteranimation;
    public GameObject Camera;
    void Start()
    {
        Vector2 angles = transform.localEulerAngles;
        _x = angles.x;
        _y = angles.y;
        this.Rotate(_x, _y);
        // Code pour empécher la répétition automatique de l'animation d'attaque
        characteranimation["Attack"].wrapMode = WrapMode.Once;
        // Code pour empécher la répétition automatique de l'animation de saut
        characteranimation["Jump"].wrapMode = WrapMode.Once;
        // Code pour empécher la répétition automatique de l'animation de déplacement
        characteranimation["Walk"].wrapMode = WrapMode.Once;
    }
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(/* Déplacement sur X touche Horizontale */ moveHorizontal * Mathf.Cos(((_x) * Mathf.PI) / 180) + /* Déplacement sur X touche Verticale */ moveVertical * Mathf.Sin((_x * Mathf.PI) / 180),
                                        0,
                                       /* Déplacement sur Y touche Horizontale */ -moveHorizontal * Mathf.Sin(((_x) * Mathf.PI) / 180) + /* Déplacement sur Y touche Verticale */ moveVertical * Mathf.Cos((_x * Mathf.PI) / 180));

        if (moveHorizontal != 0 && moveVertical != 0)
        {
            transform.position += (movement * speed) / 2;
            // Animation de déplacement
            characteranimation.Play("Walk");
        }
        else if (moveHorizontal != 0 || moveVertical != 0)
        {
            transform.position += (movement * speed);
            // Animation de déplacement
            characteranimation.Play("Walk");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            // Animation d'attaque
            characteranimation.Play("Attack");
        }
        
         if (Input.GetKeyDown("space"))
        {            
           characteranimation.Play("Jump");
        } 
        RotateControls();
    }
    void Rotate(float x, float y)
    {
        Quaternion rotationcam = Quaternion.Euler(y, x, 0.0f);
        Camera.transform.rotation = rotationcam;
        Quaternion rotationjoueur = Quaternion.Euler(0, x, 0.0f);
        transform.rotation = rotationjoueur;
    }
    void RotateControls()
    {
        _x += Input.GetAxis("Mouse X") * _xSpeed;
        _y += -Input.GetAxis("Mouse Y") * _ySpeed;

        _y = Mathf.Clamp(_y, -45, 30);

        Rotate(_x, _y);
    }
}