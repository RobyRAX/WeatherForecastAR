using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShowHide : MonoBehaviour
{
    bool nameShown = true;
    bool detailShown = true;

    public void HideName()
    {
        if(nameShown)
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
            {
                obj.transform.GetChild(2).gameObject.SetActive(false);  
            }
            nameShown = false;
        }
        else
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
            {
                obj.transform.GetChild(2).gameObject.SetActive(true);  
            }
            nameShown = true;
        }        
    }

    public void HideDetails()
    {
        if(detailShown)
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
            {
                obj.transform.GetChild(1).gameObject.SetActive(false);     
            }
            detailShown = false;   
        }
        else
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
            {
                obj.transform.GetChild(1).gameObject.SetActive(true);     
            }
            detailShown = true;   
        }
    }
}
