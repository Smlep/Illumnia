    using UnityEngine;
using System.Collections;

public class Tutoriel : MonoBehaviour
{
    private bool estdanslelobby;
    private bool estdansletutomob;
    private bool estdansletutoenigme;
    private bool estdanslespawn;
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
    ScriptPersonnage scriptpersonage;


    // Use this for initialization
    void Start()
    {
        scriptpersonage = GetComponent<ScriptPersonnage>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lobby"))
        {
            estdanslelobby = true;
        }
        if (other.gameObject.CompareTag("Spawn"))
        {
            estdanslespawn = true;

        }
        if (other.gameObject.CompareTag("Tutomob"))
        {
            estdansletutomob = true;
        }
        if (other.gameObject.CompareTag("Tutoenigme"))
        {
            estdansletutoenigme = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Spawn"))
        {
            estdanslespawn = false;
            nestjamaisallédanslespawn = false;
            messagebienvenue.SetActive(false);
        }
        if (other.gameObject.CompareTag("Lobby"))
        {
            estdanslelobby = false;
            nestjamaisallédanslelobby = false;
        }
        if (other.gameObject.CompareTag("Tutomob"))
        {
            estdansletutomob = false;
            nestjamaisallédansletutomob = false;
        }
        if (other.gameObject.CompareTag("Tutoenigme"))
        {
            estdansletutoenigme = false;
            nestjamaisallédansletutoenigme = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (estdanslespawn && nestjamaisallédanslespawn)
        {
            messagebienvenue.SetActive(true);
            Tutomove.SetActive(true);
            nestjamaisallédanslespawn = false;
        }
        if (estdansletutomob && nestjamaisallédansletutomob)
        {
            TutoAttack.SetActive(true);
            Tutomob.SetActive(true);
            nestjamaisallédansletutomob = false;
        }
        if (estdansletutoenigme && nestjamaisallédansletutoenigme)
        {
            TutoAttack.SetActive(false);
            Tutomove.SetActive(false);
            Tutomob.SetActive(false);
            nestjamaisallédansletutoenigme = false;
            TutoEnigme.SetActive(true);
        }
        if (estdanslelobby && nestjamaisallédanslelobby)
        {
            TutoEnigme.SetActive(false);
            StartCoroutine(cinématiquelobby());
            nestjamaisallédanslelobby = false;
            nestjamaisallédanslelobby = false;
        }

    }
    IEnumerator cinématiquelobby()
    {
        TutoLobby1.SetActive(true);
        cameratutolobby.SetActive(true);
        cinematiquecamera = cameratutolobby.GetComponent<CinématiqueCaméra>();
        StartCoroutine(cinematiquecamera.cinématiquetuto());
        scriptpersonage.playercanmove = false;
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
        scriptpersonage.playercanmove = true;
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
        scriptpersonage.playercanmove = true;
    }
}
