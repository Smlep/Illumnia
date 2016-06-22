using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Multiplayersetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;
    Camera SceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
                componentsToDisable[i].enabled = false;
        }
        else
        {
            SceneCamera = GameObject.FindGameObjectWithTag("CamStart").GetComponent<Camera>();
            if (SceneCamera != null)
                SceneCamera.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDisable()
    {
        if (SceneCamera!=null)
        {
            SceneCamera.gameObject.SetActive(true);
        }
    }
}
