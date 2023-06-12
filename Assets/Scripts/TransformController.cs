using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TransformController : NetworkBehaviour
{
    public Transform WeatherParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Command(requiresAuthority = false)]
    public void SetPosX(bool isPlus)
    {
        if(isPlus)
        {
            WeatherParent.position += new Vector3(0.1f, 0, 0);
        }
        else
        {
            WeatherParent.position -= new Vector3(0.1f, 0, 0);
        }
    }

    [Command(requiresAuthority = false)]
    public void SetPosY(bool isPlus)
    {
        if(isPlus)
        {
            WeatherParent.position += new Vector3(0, 0.1f, 0);
        }
        else
        {
            WeatherParent.position -= new Vector3(0, 0.1f, 0);
        }
    }

    [Command(requiresAuthority = false)]
    public void SetPosZ(bool isPlus)
    {
        if(isPlus)
        {
            WeatherParent.position += new Vector3(0, 0, 0.1f);
        }
        else
        {
            WeatherParent.position -= new Vector3(0, 0, 0.1f);
        }
    }

    [Command(requiresAuthority = false)]
    public void SetRotX(bool isPlus)
    {
        if(isPlus)
        {
            WeatherParent.Rotate(new Vector3(5f, 0, 0));
        }
        else
        {
            WeatherParent.Rotate(new Vector3(-5f, 0, 0));
        }
    }

    [Command(requiresAuthority = false)]
    public void SetRotY(bool isPlus)
    {
        if(isPlus)
        {
            WeatherParent.Rotate(new Vector3(0, 5f, 0));
        }
        else
        {
            WeatherParent.Rotate(new Vector3(0, -5f, 0));
        }
    }

    [Command(requiresAuthority = false)]
    public void SetRotZ(bool isPlus)
    {
        if(isPlus)
        {
            WeatherParent.Rotate(new Vector3(0, 0, 5f));
        }
        else
        {
            WeatherParent.Rotate(new Vector3(0, 0, -5f));
        }
    }

    [Command(requiresAuthority = false)]
    public void SetScale(bool isPlus)
    {
        if(isPlus)
        {
            WeatherParent.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            WeatherParent.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
