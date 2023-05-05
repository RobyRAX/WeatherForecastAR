using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetaController : MonoBehaviour
{
    bool parented;

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "AR" && !parented)
        {
            transform.position = Vector3.zero;
            transform.SetParent(GameObject.FindGameObjectWithTag("Marker").transform);
            parented = true;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

            foreach(Transform child in transform)
            {
                child.GetComponent<HideObject>().enabled = true;
            }
            
            Debug.Log("Test");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale -= new Vector3(-1, 1, 1) * 25;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale += new Vector3(-1, 1, 1) * 25;
        }
    }
}
