using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class WeatherList : MonoBehaviour
{
    public List<GameObject> weatherList;
    public List<GameObject> shownWeather;
    public GameObject weatherPrefab;
    //public int[] hours;
    CoordinateSetter coorSetter;

    HTTPGetRegion getRegion;
    HTTPGetWeather getWeather;
    
    void Start()
    {
        coorSetter = this.GetComponent<CoordinateSetter>();
        getRegion = GameObject.FindGameObjectWithTag("DataManager").GetComponent<HTTPGetRegion>();
        getWeather = GameObject.FindGameObjectWithTag("DataManager").GetComponent<HTTPGetWeather>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnWeathers(getRegion.nameList);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            UpdateShowHide();
        }
    }

    public void UpdateShowHide()
    {
        foreach(GameObject weather in weatherList)
        {
            if(weather.GetComponent<Weather>().show)
            {
                weather.SetActive(true);
            }
            else
            {
                weather.SetActive(false);
            }
        }

    }

    public void RunSpawnWeathers()
    {
        SpawnWeathers(getRegion.nameList);
    }

    public void SpawnWeathers(string[] inputNameList) //Eksekusi di HTTPGetRegion
    {
        foreach(string name in inputNameList)
        {
            for(int i = 0; i < getWeather.weatherDetails.Count; i++)
            {
                if(name == getWeather.weatherDetails[i])
                {
                    GameObject tempWeather = Instantiate(weatherPrefab, this.transform.position, this.transform.rotation);

                    tempWeather.transform.SetParent(this.transform);
                    tempWeather.name = name;
                    tempWeather.GetComponent<Weather>().ParseJSON(getWeather.weatherDetails[i + 1]);

                    weatherList.Add(tempWeather);
                }
            }

            /*
            GameObject tempWeather = Instantiate(weatherPrefab, this.transform.position, this.transform.rotation);

            tempWeather.transform.SetParent(this.transform);
            tempWeather.name = name;            
            //tempWeather.GetComponent<HTTPGetWeather>().region = name;
            tempWeather.GetComponent<HTTPGetWeather>().StartGet();

            weatherList.Add(tempWeather);      
            */      
        }

        //coorSetter.SetUI();
        
    }
}
