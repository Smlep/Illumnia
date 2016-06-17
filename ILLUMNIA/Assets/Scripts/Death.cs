using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public Texture2D crosshairImage;
    public Canvas deathmenu;
    public static bool Inpause;
    public GameObject player;
    Tutoriel tutoriel;
    private PlayerHealth playerHealth;



    void Start()
    {
        Cursor.visible = false;
        tutoriel = player.GetComponent<Tutoriel>();
        Time.timeScale = 1;
        Inpause = false;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth.isDead)
        {
            if (Time.timeScale != 0)
            {
                Inpause = true;
                Cursor.visible = true;
                Time.timeScale = 0;
                deathmenu.gameObject.SetActive(true);
            }
        }
    }
}
