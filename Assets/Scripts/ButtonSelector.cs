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

    public struct ColorMessage : NetworkMessage
    {
        public string name;
        public bool colorOnOff;
    }

    void Start()
    {
        NetworkClient.ReplaceHandler<ColorMessage>(OnColorChange);
        weatherData = FindObjectOfType<WeatherList>();

        transform.SetParent(GameObject.FindGameObjectWithTag("ContentButton").transform);
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
                    SendColor(obj.name, obj.GetComponent<Weather>().show);

                    childButton.SetActive(false);
                    selected = false;
                }
                else
                {
                    if(weatherData.shownWeather.Count < weatherData.posSet.Length)
                    {
                        obj.GetComponent<Weather>().show = true;
                        GetComponent<Image>().color = Color.green;

                        SendColor(obj.name, obj.GetComponent<Weather>().show);
                    }
                    
                }

                weatherData.UpdateShowHide();
                weatherData.UpdatePos();
            }
        }
    }

    public void SendColor(string inputName, bool inputColor)
    {
        ColorMessage msg = new ColorMessage(){name = inputName, colorOnOff = inputColor};

        NetworkServer.SendToAll(msg);
    }

    public void OnColorChange(ColorMessage msg)
    {
        Debug.Log("ColorMessage " + msg.name + " - " + msg.colorOnOff);

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("ButtonCuaca"))
        {
            if(obj.name == "Button_" + msg.name)
            {
                if(msg.colorOnOff)
                {
                    obj.GetComponent<Image>().color = Color.green;
                    obj.GetComponent<ButtonSelector>().selected = true;
                }                  
                else
                {
                    obj.GetComponent<Image>().color = Color.white;
                    obj.transform.GetChild(1).gameObject.SetActive(false);
                    obj.GetComponent<ButtonSelector>().selected = false;
                }                  
            }
        }
    }
}
