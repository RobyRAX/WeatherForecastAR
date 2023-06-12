using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.IO;

public class HTTPGetRegion : MonoBehaviour
{
    string URL;
    //string receivedJson;
    public string[] nameList;

    //public Text textNameList;

    [HideInInspector] public string textFileName = "LocalData/NameList.txt";

    void Start()
    {
        //URL = "https://localhost:7296/Weather/";
        //StartCoroutine(GetRequest(URL));

        textFileName = "LocalData/NameList.txt";

        //UpdateUI();
    }

    public void StartGet()
    {
        URL = "https://localhost:7296/Weather/";
        StartCoroutine(GetRequest(URL));
    }   

    public void UseSavedData()
    {
        ParseJSON(File.ReadAllText(textFileName));

        //UpdateUI();
    }

    // public void UpdateUI()
    // {
    //     textNameList.text = File.ReadAllText(textFileName);
    // }

    void ParseJSON(string jsonString)
    {
        Regex rgx = new Regex("[^A-Za-z_ ]");

        nameList = jsonString.Split(',');

        for(int i = 0; i < nameList.Length; i++)
        {
            nameList[i] = rgx.Replace(nameList[i], "");
        }
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else if(!uwr.isNetworkError && uwr.isDone)
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);          

            File.WriteAllText(textFileName, uwr.downloadHandler.text);
            
            ParseJSON(uwr.downloadHandler.text);
            
            //UpdateUI();

            //weatherList.SpawnWeathers(nameList);
        }
    }
}
