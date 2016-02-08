using UnityEngine;
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
    void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
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
        Time.timeScale = 1;
        Buttonquit.gameObject.SetActive(false);
        Buttonrestart.gameObject.SetActive(false);
        Buttonresume.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            Buttonquit.gameObject.SetActive(true);
            Buttonrestart.gameObject.SetActive(true);
            // Buttonresume.gameObject.SetActive(true);
            yourbuttontext = Buttonquit.transform.FindChild("Text").GetComponent<Text>();
            yourbuttontext.text = "Quitter !";
            yourbuttontext1 = Buttonrestart.transform.FindChild("Text").GetComponent<Text>();
            yourbuttontext1.text = "Recommencer !";
            // yourbuttonresumetext = Buttonresume.transform.FindChild("Text").GetComponent<Text>();
            // yourbuttonresumetext.text = "Reprendre !";
        }
    }

}
