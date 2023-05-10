using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class ButtonSelector : NetworkBehaviour
{
    [SerializeField] GameObject childButton;

    WeatherList weatherData;

    [SerializeField] bool selected;

    void Start()
    {
        weatherData = FindObjectOfType<WeatherList>();

        transform.SetParent(GameObject.FindGameObjectWithTag("ContentButton").transform);
    }

    public void Modify(Transform parent, string name)
    {
        transform.SetParent(parent);
        gameObject.name = "Button_" + name;
        transform.GetComponentInChildren<Text>().text = name;
    }

    public void Selection()
    {
        if(selected)
        {
            selected = false;
            childButton.SetActive(false);
        }
        else
        {
            selected = true;
            childButton.SetActive(true);
        }        
    }

    [Command(requiresAuthority = false)]
    public void Show()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
        {
            if(obj.name == this.transform.GetComponentInChildren<Text>().text)
            {
                if(obj.GetComponent<Weather>().show == true)
                {
                    obj.GetComponent<Weather>().show = false;
                    GetComponent<Image>().color = Color.white;


                    childButton.SetActive(false);
                    selected = false;
                }
                else
                {
                    if(weatherData.shownWeather.Count < weatherData.posSet.Length)
                    {
                        obj.GetComponent<Weather>().show = true;
                        GetComponent<Image>().color = Color.green;
                    }
                    
                }

                weatherData.UpdateShowHide();
                weatherData.UpdatePos();
            }
        }
    }
}
