﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour
{

    private Text yourbuttontext;
    private Text yourbuttontext1;
    private Text yourbuttonresumetext;
    public Button Buttonquit;
    public Button Buttonrestart;
    public Button Buttonresume;
    public Button Buttonoption;
    public Texture2D crosshairImage;
    public Canvas OptionMenu;
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

    public void end()
    {
        Application.Quit();
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

    public void lobby()
    {
        player.transform.position = new Vector3(-7,0,40);
    }

    public void B1TP()
    {
        player.transform.position = new Vector3(-53, 0, 63);
    }

    public void B2TP()
    {
        player.transform.position = new Vector3(105, 0, 147);
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
        if (!Inpause)
        {
            float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
            float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
            GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
        }
    }
}