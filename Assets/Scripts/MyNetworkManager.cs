using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public GameObject panelDownload;

    public override void OnStartClient()
    {
        base.OnStartClient();

        panelDownload.SetActive(false);
    }
}
