using UnityEngine;
using System.Collections;

public class Tutoriel : MonoBehaviour
{
    private bool nestjamaisallédanslelobby = true;
    private bool nestjamaisallédanslespawn = true;
    private bool nestjamaisallédansletutomob = true;
    private bool nestjamaisallédansletutoenigme = true;
    public GameObject messagebienvenue;
    public GameObject Tutomove;
    public GameObject TutoAttack;
    public GameObject TutoEnigme;
    public GameObject TutoLobby1;
    public GameObject TutoLobby2;
    public GameObject TutoLobby3;
    public GameObject TutoLobby4;
    public GameObject TutoLobby5;
    public GameObject Tutomob;
    public GameObject cameratutolobby;
    public GameObject cameratutodoor1;
    public GameObject cameratutodoor2;
    public GameObject cameratutodoor3;
    public GameObject cameratutotp;
    public GameObject cameratutoheal;
    CinématiqueCaméra cinematiquecamera;
    ScriptPersonnage[] scriptpersonages;
    GameObject[] Players;


    // Use this for initialization
    void Awake()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < Players.Length; i++)
        {
            scriptpersonages = new ScriptPersonnage[Players.Length];
            scriptpersonages[i]= Players[i].GetComponent<ScriptPersonnage>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            scriptpersonages = new ScriptPersonnage[Players.Length];
            scriptpersonages[i] = Players[i].GetComponent<ScriptPersonnage>();
        }
        if (scriptpersonages[0].estdanslespawn && nestjamaisallédanslespawn)
        {
            messagebienvenue.SetActive(true);
            Tutomove.SetActive(true);
            nestjamaisallédanslespawn = false;
        }
        if (scriptpersonages[0].estdansletutomob && nestjamaisallédansletutomob)
        {
            messagebienvenue.SetActive(false);
            TutoAttack.SetActive(true);
            Tutomob.SetActive(true);
            nestjamaisallédansletutomob = false;
        }
        if (scriptpersonages[0].estdansletutoenigme && nestjamaisallédansletutoenigme)
        {
            TutoAttack.SetActive(false);
            Tutomove.SetActive(false);
            Tutomob.SetActive(false);
            nestjamaisallédansletutoenigme = false;
            TutoEnigme.SetActive(true);
        }
        if (scriptpersonages[0].estdanslelobby && nestjamaisallédanslelobby)
        {
            TutoEnigme.SetActive(false);
            StartCoroutine(cinématiquelobby());
            nestjamaisallédanslelobby = false;
        }

    }
    IEnumerator cinématiquelobby()
    {
        TutoLobby1.SetActive(true);
        cameratutolobby.SetActive(true);
        cinematiquecamera = cameratutolobby.GetComponent<CinématiqueCaméra>();
        StartCoroutine(cinematiquecamera.cinématiquetuto());
        for (int i = 0; i < scriptpersonages.Length; i++)
            scriptpersonages[i].playercanmove = false;
        yield return new WaitForSeconds(3);
        TutoLobby1.SetActive(false);
        TutoLobby2.SetActive(true);
        yield return new WaitForSeconds(3);
        TutoLobby2.SetActive(false);
        TutoLobby3.SetActive(true);
        cameratutolobby.SetActive(false);
        cameratutodoor1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        cameratutodoor1.SetActive(false);
        cameratutodoor2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        cameratutodoor2.SetActive(false);
        cameratutodoor3.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        cameratutodoor3.SetActive(false);
        cameratutotp.SetActive(true);
        TutoLobby3.SetActive(false);
        TutoLobby4.SetActive(true);
        yield return new WaitForSeconds(2);
        cameratutotp.SetActive(false);
        cameratutoheal.SetActive(true);
        TutoLobby4.SetActive(false);
        TutoLobby5.SetActive(true);
        yield return new WaitForSeconds(2);
        cameratutoheal.SetActive(false);
        TutoLobby5.SetActive(false);
        for (int i = 0; i < scriptpersonages.Length; i++)
            scriptpersonages[i].playercanmove = true;
    }
    public void endtutoriel()
    {
        nestjamaisallédanslelobby = false; ;
        nestjamaisallédanslespawn = false;
        nestjamaisallédansletutomob = false;
        nestjamaisallédansletutoenigme = false;
        messagebienvenue.SetActive(false);
        Tutomove.SetActive(false);
        TutoAttack.SetActive(false);
        TutoEnigme.SetActive(false);
        TutoLobby1.SetActive(false);
        TutoLobby2.SetActive(false);
        TutoLobby3.SetActive(false);
        TutoLobby4.SetActive(false);
        TutoLobby5.SetActive(false);
        Tutomob.SetActive(false);
        cameratutolobby.SetActive(false);
        cameratutodoor1.SetActive(false);
        cameratutodoor2.SetActive(false);
        cameratutodoor3.SetActive(false);
        cameratutotp.SetActive(false);
        cameratutoheal.SetActive(false);
        for (int i = 0; i < scriptpersonages.Length; i++)
            scriptpersonages[i].playercanmove = true;
    }
}
