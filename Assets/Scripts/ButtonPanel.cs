using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    [SerializeField] bool active = true;
    public GameObject buttonPanel;
    public GameObject gizmo;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(active)
            {
                gizmo.SetActive(false);
                buttonPanel.SetActive(false);
                active = false;
            }
            else
            {
                gizmo.SetActive(true);
                buttonPanel.SetActive(true);
                active = true;
            }
        }
    }
}
