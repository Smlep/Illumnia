using UnityEngine;
using System.Collections;
using System.Reflection;


public class ScriptPersonnage : MonoBehaviour
{
    public float speed;
    public float _xSpeed = 1f;
    public float _ySpeed = 1f;
    private float _x = 0.0f;
    private float _y = 0.0f;
    public Animation characteranimation;
    public GameObject Camera;
    public float gravity = 10;
    public CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    // private Rigidbody rb;

    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
        // rb = GetComponent<Rigidbody>();
        Vector2 angles = transform.localEulerAngles;
        _x = angles.x;
        _y = angles.y;
        Rotate(_x, _y);
        // Code pour empécher la répétition automatique de l'animation d'attaque
        characteranimation["Attack"].wrapMode = WrapMode.Once;
        // Code pour empécher la répétition automatique de l'animation de saut
        characteranimation["Jump"].wrapMode = WrapMode.Once;
        // Code pour empécher la répétition automatique de l'animation de déplacement
        characteranimation["Walk"].wrapMode = WrapMode.Once;
    }

    void Update()
    {

        
        if (moveDirection.y > gravity * -1)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        controller.Move(moveDirection * Time.deltaTime);
        var left = transform.TransformDirection(Vector3.left);

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //characteranimation.Play("Jump");
                moveDirection.y = speed;
            }
            bool Allertoutdroit = Input.GetKey("z");
            bool Reculer = Input.GetKey("s");
            bool AlleràDroite = Input.GetKey("d");
            bool AlleràGauche = Input.GetKey("q");
            float coefficientdedéplacement;
            // Gestion du déplacement en diagonale
            if (Allertoutdroit ^ Reculer ^ AlleràGauche ^ AlleràDroite)
            {
                coefficientdedéplacement = 1;
            }
            else
            {
                coefficientdedéplacement = 1/Mathf.Sqrt(2);
            }
            if (Allertoutdroit && !Reculer)
            {
                controller.SimpleMove(transform.forward * speed * coefficientdedéplacement);
            }
            else if (Reculer && !Allertoutdroit)
            {
                controller.SimpleMove(transform.forward * -speed * coefficientdedéplacement);
            }
            if (AlleràGauche && !AlleràDroite)
            {
                controller.SimpleMove(left * speed * coefficientdedéplacement);
            }
            else if (AlleràDroite && !AlleràGauche)
            {
                controller.SimpleMove(left * -speed * coefficientdedéplacement);
            }
        }
        else
        {
            if (Input.GetKey("z"))
            {
                Vector3 relative;
                relative = transform.TransformDirection(0, 0, 1);
                controller.Move(relative * Time.deltaTime * speed / 1.5f);
                //controller.Move(forward * 2);
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            // Animation d'attaque
            characteranimation.Play("Attack");
        }

        if (!Main.Inpause)
        {
            RotateControls();
        }
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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.GetComponent<Rigidbody>())
        {
            hit.transform.GetComponent<Rigidbody>().AddForce(10 * transform.forward);
        }
    }
}
//float moveHorizontal = Input.GetAxis("Horizontal");
//float moveVertical = Input.GetAxis("Vertical");
// Vector3 movement =
// new Vector3( /* Déplacement sur X touche Horizontale */
// moveHorizontal*Mathf.Cos(((_x)*Mathf.PI)/180) + /* Déplacement sur X touche Verticale */
// moveVertical*Mathf.Sin((_x*Mathf.PI)/180),0,
/* Déplacement sur Y touche Horizontale */
//   -moveHorizontal*Mathf.Sin(((_x)*Mathf.PI)/180) + /* Déplacement sur Y touche Verticale */
//     moveVertical*Mathf.Cos((_x*Mathf.PI)/180));

//if (moveHorizontal != 0 && moveVertical != 0)
//{
//  transform.position += movement*speed/2*Time.timeScale;
// La multiplication par time.timescale fait bouger le personnage en fonction du temps (donc l'arrete en pause)


/* Animation de déplacement
characteranimation.Play("Walk"); */
//      }
//      else if (moveHorizontal != 0 || moveVertical != 0)
//      {
//           transform.position += movement*speed*Time.timeScale;


/* Animation de déplacement
 characteranimation.Play("Walk"); */
