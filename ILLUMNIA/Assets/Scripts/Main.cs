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
    public Button Buttonoption;
    public Texture2D crosshairImage;
    public Canvas OptionMenu;
    public static bool Inpause;
    public GameObject player;
    

    void Start()
    {
        Cursor.visible = false;

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
/*
public class clé : MonoBehaviour {
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject l5;
    public GameObject l6;
    public GameObject l7;
    public GameObject l8;
    public GameObject l9;
    public GameObject l10;
    public GameObject l11;
    public GameObject l12;
    public GameObject l13;
    public GameObject l14;
    public GameObject l15;
    public GameObject l16;
    public GameObject l17;
    public GameObject l18;
    public GameObject l19;
    public GameObject l20;
    public GameObject l21;
    public GameObject l22;
    public GameObject l23;
    public GameObject l24;
    public GameObject l25;
    private bool keyhasspawned = false; //sais pas si tu l'utilisera
    public GameObject key;
    public GameObject caméracinématiqueramassage;
    private Object cle;
    public GameObject mobquifuit;
    public Transform mobquifuitspawn;
    public Transform spawnkey;
    // Use this for initialization
    void Start ()
    {
        keyhasspawned = false;
	}

	// Update is called once per frame
	void Update ()
    {
	    if (!keyhasspawned)
	    {
	        if (l1.activeSelf  &&
	            (l2.activeSelf  && l3.activeSelf  && l4.activeSelf   && l5.activeSelf &&
	             l6.activeSelf  && l7.activeSelf  && l8.activeSelf  && l9.activeSelf  &&
	             !l10.activeSelf  && !l11.activeSelf  && !l12.activeSelf  && !l13.activeSelf  &&
	             !l14.activeSelf  && !l15.activeSelf  && !l16.activeSelf  && l17.activeSelf  &&
	             !l18.activeSelf  && l19.activeSelf  && l20.activeSelf  && l21.activeSelf &&
	             l22.activeSelf  && !l23.activeSelf && !l24.activeSelf  && l25.activeSelf ))
	        {
	            cle = Instantiate(key, spawnkey.position, spawnkey.rotation);
	            Instantiate(mobquifuit, mobquifuitspawn.position, mobquifuitspawn.rotation);
                caméracinématiqueramassage.SetActive(true);
	            keyhasspawned = true;
	            StartCoroutine(fincinématique());
	        }
	    }
    }

    IEnumerator fincinématique()
    {
        yield return new WaitForSeconds(2);
        caméracinématiqueramassage.SetActive(false);
    }
}
*/