using UnityEngine;
using System.Collections;

public class CinéMenu : MonoBehaviour {

    public GameObject cameratutolobby;
    CinématiqueCaméra cinematiquecamera;

    void Start()
    {
        cinématiquemenu();
    }


    public void cinématiquemenu()
    {
        cameratutolobby.SetActive(true);
        cinematiquecamera = cameratutolobby.GetComponent<CinématiqueCaméra>();
        StartCoroutine(cinematiquecamera.cinématiquetuto());
    }
}
