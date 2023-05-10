using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    bool active = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(active)
            {
                gameObject.SetActive(false);
                active = false;
            }
            else
            {
                gameObject.SetActive(true);
                active = true;
            }
        }
    }
}
