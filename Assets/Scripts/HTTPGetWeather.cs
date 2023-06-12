using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using System;

public class HTTPGetWeather : MonoBehaviour
{
    string URL;
    //public string region;
    public int hour;
    string receivedJson;

    public Text textTimeStamp;
    public Text textWeatherDetails;

    HTTPGetRegion getRegion;

    public List<string> weatherDetails = new List<string>();
    [HideInInspector] public string textFileName;

    bool textWritten;

    void Start()
    {
        getRegion = GetComponent<HTTPGetRegion>();      

        textFileName = "LocalData/WeatherDetails.txt";

        //UpdateUI();
    }

    void Update()
    {
        if(weatherDetails.Count == (getRegion.nameList.Length * 2) + 1 && weatherDetails.Count != 0)
        {
            if(!textWritten)
            {
                File.WriteAllLines(textFileName, weatherDetails);
                //UpdateUI();

                textWritten = true;
            }
        }
    }

    public void StartGet()
    {
        URL = "https://localhost:7296/Weather/timestamp";
        StartCoroutine(GetTimeStamp(URL));

        foreach(string name in getRegion.nameList)
        {
            URL = "https://localhost:7296/Weather/" + name + "/" + hour.ToString();
            StartCoroutine(GetWeather(URL, name));
            //Debug.Log(URL);
        }           
    }

    public void UseSavedData()
    {
        string[] savedData = File.ReadAllLines(textFileName);

        weatherDetails.AddRange(savedData);
    }

    // public void UpdateUI()
    // {       
    //     textWeatherDetails.text = File.ReadAllText(textFileName);
    // }

    IEnumerator GetWeather(string uri, string name)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else if(!uwr.isNetworkError && uwr.isDone)
        {
            //Debug.Log(uwr.downloadHandler.text);
            weatherDetails.Add(name);
            weatherDetails.Add(uwr.downloadHandler.text);
        }
    }

    IEnumerator GetTimeStamp(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else if(!uwr.isNetworkError && uwr.isDone)
        {
            textTimeStamp.text = uwr.downloadHandler.text;

            weatherDetails.Insert(0, uwr.downloadHandler.text);
        }
    }
}
