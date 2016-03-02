using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;


public class ScriptPersonnage : MonoBehaviour
{
    public bool playercanmove;
    private float speed;
    public float speeddemarche;
    public float speeddecourse;
    public float _xSpeed = 1f;
    public float _ySpeed = 1f;
    private float _x = 0.0f;
    private float _y = 0.0f;
    public Animation characteranimation;
    public GameObject Camera;
    public float gravity = 10;
    public Texture2D Keypicture;
    public CharacterController controller;
    public bool playerhasthekey;
    private Vector3 moveDirection = Vector3.zero;
    public bool Lejoueurestdanslazone1;
    public bool Lejoueurestdanslazone2;
    public bool Lejoueurestdanslazone3;
    public bool Lejoueurestdanslazone4;
    public bool Lejoueurestdanslazone5;
    public bool sprintautorisé;
    private PlayerHealth playerHealth;
    public bool Lejoueurestdanslazonemortemecanic2;
    public static ScriptPersonnage main;
    // private Rigidbody rb;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
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
        Lejoueurestdanslazone2 = false;
        Lejoueurestdanslazone1 = false;
        Lejoueurestdanslazone3 = false;
        Lejoueurestdanslazone4 = false;
        Lejoueurestdanslazone5 = false;
        Lejoueurestdanslazonemortemecanic2 = false;
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = speeddemarche;
            
        }
        else if (sprintautorisé)
        {
            speed = speeddecourse;
            
        }
        if (playercanmove&&!playerHealth.enmodedéfensif)
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
                    if (speed == speeddecourse)
                    {
                        characteranimation.Play("Run");
                    }
                    else
                    {
                        characteranimation.Play("Walk");
                    }
                }
                else
                {
                    coefficientdedéplacement = 1 / Mathf.Sqrt(2);
                    if (speed == speeddecourse)
                    {
                        characteranimation.Play("Run");
                    }
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
        }
        if (Input.GetButtonDown("Fire1")&&!playerHealth.enmodedéfensif)
        {
            // Animation d'attaque
            characteranimation.Play("Attack");
        }

        if (!Main.Inpause)
        {
            RotateControls();
        }

    }
    // Détection des Collision
    void OnTriggerEnter(Collider other)
    {
        // Téléportation
        if (other.gameObject.CompareTag("Téléporteur"))
        {
            transform.position = new Vector3(-7.5f, 2, 40);
        }
        if (other.gameObject.CompareTag("Clef"))
        {
            other.gameObject.SetActive(false);
            playerhasthekey = true;
        }
        if (other.gameObject.CompareTag("ZoneSafe1"))
        {
            Lejoueurestdanslazone1 = true;
        }
        if (other.gameObject.CompareTag("ZoneSafe2"))
        {
            Lejoueurestdanslazone2 = true;
        }
        if (other.gameObject.CompareTag("ZoneSafe3"))
        {
            Lejoueurestdanslazone3 = true;
        }
        if (other.gameObject.CompareTag("ZoneSafe4"))
        {
            Lejoueurestdanslazone4 = true;
        }
        if (other.gameObject.CompareTag("ZoneSafe5"))
        {
            Lejoueurestdanslazone5 = true;
        }
        if (other.gameObject.CompareTag("ZoneMorteMecanic2"))
        {
            Lejoueurestdanslazonemortemecanic2 = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ZoneSafe1"))
        {
            Lejoueurestdanslazone1 = false;
        }
        if (other.gameObject.CompareTag("ZoneSafe2"))
        {
            Lejoueurestdanslazone2 = false;
        }
        if (other.gameObject.CompareTag("ZoneSafe3"))
        {
            Lejoueurestdanslazone3 = false;
        }
        if (other.gameObject.CompareTag("ZoneSafe4"))
        {
            Lejoueurestdanslazone4 = false;
        }
        if (other.gameObject.CompareTag("ZoneSafe5"))
        {
            Lejoueurestdanslazone5 = false;
        }
        if (other.gameObject.CompareTag("ZoneMorteMecanic2"))
        {
            Lejoueurestdanslazonemortemecanic2 = false;
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
        _y = Mathf.Clamp(_y, -45, 40);

        Rotate(_x, _y);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.GetComponent<Rigidbody>())
        {
            hit.transform.GetComponent<Rigidbody>().AddForce(10 * transform.forward);
        }
    }

    void OnGUI()
    {
        //affichage de la clef
        if (playerhasthekey)
        {
            GUI.DrawTexture(
                new Rect(Screen.width - 50 - Keypicture.width / 2, Screen.height - 50 - Keypicture.height / 2,
                    Keypicture.width / 2, Keypicture.height / 2), Keypicture);
        }
    }

    void Awake()
    {
        main = this;
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
