using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerControl : NetworkBehaviour
{
    void Start()
    {
        
    }

    [Command(requiresAuthority = false)]
    public void Damage(int amount)
    {
        Debug.Log("Damage = " + amount);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Damage(55);
        }
    }
}
