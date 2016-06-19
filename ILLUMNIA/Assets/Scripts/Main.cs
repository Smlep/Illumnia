using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public Button Buttonquit;
    public Button Buttonrestart;
    public Button Buttonresume;
    public Button Buttonoption;
    public Texture2D crosshairImage;
    public Canvas OptionMenu;
    public static bool Inpause;
    public GameObject player;  
    private PlayerHealth playerHealth;
    private Slider healthSlider;

    

    void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        Inpause = false;
        playerHealth = player.GetComponent<PlayerHealth>();
        healthSlider = GameObject.FindGameObjectWithTag("SliderviePlayer").GetComponent<Slider>();
    }

    public void end()
    {
        SceneManager.LoadScene("Menu Scene");
    }

    public void restart()
    {
        Time.timeScale = 1;
        Application.LoadLevel("1");
    }

    public void resume()
    {
        Inpause = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        Buttonquit.gameObject.SetActive(false);
        Buttonrestart.gameObject.SetActive(false);
        Buttonresume.gameObject.SetActive(false);
        Buttonoption.gameObject.SetActive(false);
    }

    public void option()
    {
        OptionMenu.gameObject.SetActive(true);
        Buttonquit.gameObject.SetActive(false);
        Buttonrestart.gameObject.SetActive(false);
        Buttonresume.gameObject.SetActive(false);
        Buttonoption.gameObject.SetActive(false);
    }

    public void optionquit()
    {
        OptionMenu.gameObject.SetActive(false);
        Buttonquit.gameObject.SetActive(true);
        Buttonrestart.gameObject.SetActive(true);
        Buttonresume.gameObject.SetActive(true);
        Buttonoption.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                Inpause = true;
                Cursor.visible = true;
                Time.timeScale = 0;
                Buttonquit.gameObject.SetActive(true);
                Buttonrestart.gameObject.SetActive(true);
                Buttonresume.gameObject.SetActive(true);
                Buttonoption.gameObject.SetActive(true);
                // yourbuttonresumetext = Buttonresume.transform.FindChild("Text").GetComponent<Text>();
                // yourbuttonresumetext.text = "Reprendre !";
            }
        }
    }

    void OnGUI()
    {
        // CROSSHAIR
        if (Time.timeScale != 0)
        {
            float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
            float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
            GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
        }
    }
}