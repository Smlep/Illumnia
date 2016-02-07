using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {

    private Text yourbuttontext;
    private Text yourbuttontext1;
    public Button Buttonquit;
    public Button Buttonrestart;

    void Start()
    {
        Cursor.visible = false;
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

    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Buttonquit.gameObject.SetActive(false);
                Buttonrestart.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                Buttonquit.gameObject.SetActive(true);
                Buttonrestart.gameObject.SetActive(true);
                yourbuttontext = Buttonquit.transform.FindChild("Text").GetComponent<Text>();
                yourbuttontext.text = "Quitter !";
                yourbuttontext1 = Buttonrestart.transform.FindChild("Text").GetComponent<Text>();
                yourbuttontext1.text = "Recommencer !";
            }
        }
    }
    }
