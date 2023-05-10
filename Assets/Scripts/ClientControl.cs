using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ClientControl : NetworkBehaviour
{

    public GameObject button;
    public GameObject panel;
    public List<GameObject> serverObj;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer && !isServer)
        {

        }
            

        //identity.AssignClientAuthority(conn);
    }


    // Update is called once per frame
    void Update()
    {
        //button_1 = GameObject.Find("Button_1").GetComponent<Button>();
        

    }

    [Command(requiresAuthority = false)]
    public void SendSomething(string message)
    {
        Debug.Log(message);
    }

    public void SetUI() //Eksekusi di WeatherList
    {
        foreach(GameObject obj in serverObj)
        {
            GameObject tempButton;
            tempButton = Instantiate(button);
            tempButton.transform.SetParent(panel.transform);
            tempButton.name = "Button_" + obj.name;
            tempButton.transform.GetComponentInChildren<Text>().text = obj.name;
        }
    }

    //public 
}
