using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public GameObject clientPanel;

    public GameObject obj;

    public WeatherList weatherData;

    public override void Awake()
    {
        // if(instance!=null)
        // Destroy(gameObject);
        // else
        // instance = this;

        base.Awake();
    }

    

    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("Server started");       

        clientPanel.SetActive(false);

        
    }

    public override void OnServerReady(NetworkConnectionToClient conn)
    {
        base.OnServerReady(conn);

        //GameObject.Find("ConnectPanel").SetActive(false);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        //GameObject.Find("ConnectPanel").SetActive(false);

        //weatherData.SpawnStuff();

        Debug.Log("Client Connected");

        if (NetworkServer.connections.Count > 0)
        {
            NetworkIdentity identity = GetComponent<NetworkIdentity>();
            NetworkConnection conn = NetworkServer.connections[0];
            
            if (conn is NetworkConnectionToClient)
            {
                NetworkConnectionToClient clientConn = conn as NetworkConnectionToClient;
                identity.AssignClientAuthority(clientConn);
            }
        }
    }

    public virtual void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        //var player = (GameObject)GameObject.Instantiate(playerPrefab);

        //player.transform.SetParent()
        
        //NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

}
