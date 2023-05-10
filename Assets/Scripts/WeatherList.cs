using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class WeatherList : NetworkBehaviour
{
    public List<GameObject> weatherList;
    public List<GameObject> shownWeather;
    public GameObject[] posSet;
    public GameObject weatherPrefab;
    //public int[] hours;
    CoordinateSetter coorSetter;

    public GameObject button;
    GameObject buttonParent;
    public GameObject obj;
    //int index;

    HTTPGetRegion getRegion;
    HTTPGetWeather getWeather;
    //public NetworkManager net;
    

    void Start()
    {
        coorSetter = this.GetComponent<CoordinateSetter>();
        getRegion = GameObject.FindGameObjectWithTag("DataManager").GetComponent<HTTPGetRegion>();
        getWeather = GameObject.FindGameObjectWithTag("DataManager").GetComponent<HTTPGetWeather>();
        buttonParent = GameObject.FindGameObjectWithTag("ContentButton");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnStuff();
        }
    }

    public void UpdateShowHide()
    {
        // if(isServer)
        // {
            foreach(GameObject weather in weatherList)
            {
                if(weather.GetComponent<Weather>().show)
                {
                    weather.transform.GetChild(0).gameObject.SetActive(true);
                    weather.transform.GetChild(1).gameObject.SetActive(true);
                    weather.transform.GetChild(2).gameObject.SetActive(true);

                    if(shownWeather.Contains(weather))
                    {
                        
                    }
                    else
                    {
                        shownWeather.Add(weather);
                    }
                }
                else
                {
                    weather.transform.GetChild(0).gameObject.SetActive(false);
                    weather.transform.GetChild(1).gameObject.SetActive(false);
                    weather.transform.GetChild(2).gameObject.SetActive(false);

                    shownWeather.Remove(weather);
                }
            }
        //}        
    }

    public void UpdatePos()
    {
        for(int i = 0; i < shownWeather.Count; i++)
        {
            Debug.Log(shownWeather[i].name);

            shownWeather[i].transform.position = posSet[i].transform.position;
        }
    }

    public void RunSpawnWeathers()
    {
        SpawnWeathers(getRegion.nameList);
    }

    public void SpawnWeathers(string[] inputNameList) //Eksekusi di HTTPGetRegion
    {
        // if(isServer)
        // {
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

                        //NetworkServer.Spawn(tempWeather);
                    }
                }     
            }
        //}
        // else // Client
        // {
        //     foreach(string name in inputNameList)
        //     {
        //         for(int i = 0; i < getWeather.weatherDetails.Count; i++)
        //         {
        //             if(name == getWeather.weatherDetails[i])
        //             {
        //                 SetUIClient(name);
        //             }
        //         }     
        //     }
        // }
        
        SetUI();
        UpdateShowHide();
    }

    public void SetUI()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
        {
            GameObject tempButton;
            tempButton = Instantiate(button);
            tempButton.transform.SetParent(buttonParent.transform);
            tempButton.name = "Button_" + obj.name;
            tempButton.transform.GetComponentInChildren<Text>().text = obj.name;

            NetworkServer.Spawn(tempButton);
        }
    }

    [Command(requiresAuthority = false)]
    public void SpawnStuff()
    {
        GameObject clone = Instantiate(obj);
        clone.name = "COK";
        //NetworkServer.Spawn(clone);

        Debug.Log("Alhamdulillah");        
    }
}
