using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSelector : MonoBehaviour
{
    public void Select()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
        {
            if(obj.name == this.transform.GetComponentInChildren<Text>().text)
            {
                obj.GetComponent<Weather>().selected = true;
            }
            else
            {
                obj.GetComponent<Weather>().selected = false;
            }
        }
    }
}
