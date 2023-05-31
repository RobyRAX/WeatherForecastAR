using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField] bool active = true;
    public GameObject buttonPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(active)
            {
                buttonPanel.SetActive(false);
                active = false;
            }
            else
            {
                buttonPanel.SetActive(true);
                active = true;
            }
        }
    }
}
