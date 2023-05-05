using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ClientButtons : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    //[SerializeField] GameObject localPlayer = ClientScene.localPlayer.gameObject;
    public GameObject network;

    // Start is called before the first frame update
    void Start()
    {
       //localPlayer = ClientScene.localPlayer.gameObject;

        
    }

    // Update is called once per frame
    void Update()
    {
        // if(client == null)
        // {
        //     foreach(GameObject obj in players)
        //     {
        //         if(obj.GetComponent<NetworkIdentity>().isLocalPlayer)
        //         {
        //             Debug.Log(obj.name);
        //         }
        //     }
        // }       
    }
}
