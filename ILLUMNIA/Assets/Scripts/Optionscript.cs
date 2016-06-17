using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Optionscript : MonoBehaviour
{
    public Texture2D crosshairImage;
    public Canvas CheatMenu;
    public static bool Inpause;
    public GameObject player;
    Tutoriel tutoriel;



    void Start()
    {
        Cursor.visible = false;
        tutoriel = player.GetComponent<Tutoriel>();
        Time.timeScale = 1;
        Inpause = false;
    }

    public void resume()
    {
        Inpause = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        CheatMenu.gameObject.SetActive(false);
    }

    public void lobby()
    {
        player.transform.position = new Vector3(-7, 0, 40);
    }

    public void B1TP()
    {
        player.transform.position = new Vector3(-53, 0, 63);
    }

    public void B2TP()
    {
        player.transform.position = new Vector3(105, 0, 147);
    }

    public void B3TP()
    {
        player.transform.position = new Vector3(438, 0, 365);
    }

    public void JumpTP()
    {
        player.transform.position = new Vector3(46, 0, 12);
    }

    public void ParcourTP()
    {
        player.transform.position = new Vector3(-5, 1, 722);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            if (Time.timeScale != 0)
            {
                Inpause = true;
                Cursor.visible = true;
                Time.timeScale = 0;
                CheatMenu.gameObject.SetActive(true);
                // yourbuttonresumetext = Buttonresume.transform.FindChild("Text").GetComponent<Text>();
                // yourbuttonresumetext.text = "Reprendre !";
            }
        }
    }
}