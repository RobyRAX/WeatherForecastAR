using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ClientControl : NetworkBehaviour
{
    [SerializeField] Button button_1;
    [SerializeField] Button button_2;
    [SerializeField] Button button_3;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer && !isServer)
        {
            button_1 = GameObject.Find("Button_1").GetComponent<Button>();
            button_1.onClick.AddListener(delegate{SendSomething("Alhamdulillah");});

            button_2 = GameObject.Find("Button_2").GetComponent<Button>();
            button_2.onClick.AddListener(delegate{SendSomething("Subhanallah");});

            button_3 = GameObject.Find("Button_3").GetComponent<Button>();
            button_3.onClick.AddListener(delegate{SendSomething("Allahu Akbar");});
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
}
