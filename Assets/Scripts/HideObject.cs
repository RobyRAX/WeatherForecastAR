using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    public float cutLeft;
    public float cutRight;

    // Update is called once per frame
    void Update()
    {
        Hide();
    }

    void Hide()
    {
        foreach(Transform child in transform)
        {
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(child.transform.position);
            if(viewportPoint.x < cutLeft || viewportPoint.x > cutRight)
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
        }
        
        //Vector3 view = Camera.main.WorldToViewportPoint(transform.position);
        //Debug.Log(view.x + " - " + view.y);
    }
}
