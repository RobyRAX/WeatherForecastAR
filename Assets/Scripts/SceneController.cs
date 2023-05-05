using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MoveToSetCoordinate()
    {
        SceneManager.LoadScene("SetCoordinate");
    }

    public void MoveToAR()
    {
        SceneManager.LoadScene("AR");
    }
}
