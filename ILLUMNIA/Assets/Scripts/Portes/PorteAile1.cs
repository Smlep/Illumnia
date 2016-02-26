﻿using UnityEngine;
using System.Collections;

public class PorteAile1 : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public Transform spawnenemy1;
    public Transform spawnenemy2;
    public Transform spawnenemy3;
    public Transform spawnenemy4;
    public GameObject nextdoor;
    private object e1;
    private object e3;
    private object e2;
    private object e4;
    private bool enemyhavespawned;
    private bool nextdooropened;
    // Use this for initialization
    void Start()
    {
        enemyhavespawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyhavespawned && !nextdooropened)
        {
            if (e1 == null && e2 == null && e3 == null && e4 == null)
            {
                // lance l'ouverture de la prochaine porte sans avoir besoin de levier
            }
        }
    }
    void Activate()
    {
        if (!enemyhavespawned)
        {
            e1 = Instantiate(enemy1, spawnenemy1.position, spawnenemy1.rotation);
            e2 = Instantiate(enemy2, spawnenemy2.position, spawnenemy2.rotation);
            e3 = Instantiate(enemy3, spawnenemy3.position, spawnenemy3.rotation);
            e4 = Instantiate(enemy4, spawnenemy4.position, spawnenemy4.rotation);
            enemyhavespawned = true;
        }
    }
}
