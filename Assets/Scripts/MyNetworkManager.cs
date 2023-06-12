using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager
{
    public GameObject panelDownload;
    public GameObject[] AR;

    public InputField input;
    public GameObject panelServerClient;

    public override void Start()
    {
        // Debug.Log(SystemInfo.deviceType);

        // if(SystemInfo.deviceType == DeviceType.Desktop)
        // {
        //     StartServer();
        // }
    }

    public void ChangeAddress()
    {
        networkAddress = input.text;

        StartClient();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        panelDownload.SetActive(false);
    }

    public override void OnStartServer()
    {
        base.OnStartServer();

        foreach(GameObject obj in AR)
        {
            obj.SetActive(true);
        }
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);

        panelServerClient.SetActive(false);
        panelDownload.SetActive(true);
    }
}
