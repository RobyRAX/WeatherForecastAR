using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weather : MonoBehaviour
{
    public bool selected;
    public bool show;
    //public GameObject button;

    [System.Serializable]
    public class WeatherAttribute
    {
        public int WeatherCode;
        public int Temperature;
        public int Humidity;
        public int WindSpeed;
        public string WindDir;
    }
    public WeatherAttribute weatherAttribute = new WeatherAttribute();

    [SerializeField] GameObject[] weatherObjects;
    [SerializeField] TextMeshProUGUI text_Name;
    [SerializeField] TextMeshProUGUI text_Weather;
    [SerializeField] TextMeshProUGUI text_Temperature;
    [SerializeField] TextMeshProUGUI text_Humidity;
    [SerializeField] TextMeshProUGUI text_WindSpeed;
    [SerializeField] TextMeshProUGUI text_WindDir;

    public void ParseJSON(string jsonString) //Diekseskusi di HTTPGetWeather
    {
        weatherAttribute = JsonUtility.FromJson<WeatherAttribute>(jsonString);

        UpdateUIData();
    }

    void Update()
    {
        SetWithClick();

        //transform.LookAt(Camera.main.transform);
    }

    void LateUpdate()
    {
        //transform.Rotate(new Vector3(0, 180, 0));
    }

    void SetWithClick()
    {
        if(selected)
        {
            if(Input.GetMouseButtonDown(1))
            {
                transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            }
        }
    }

    public void UpdateUIData()
    {
        text_Name.text = gameObject.name;

        switch(weatherAttribute.WeatherCode)
        {
            case 0:
                text_Weather.text = "Cerah";
                weatherObjects[0].SetActive(true);
                break;
            case 1:
                text_Weather.text = "Cerah Berawan";
                weatherObjects[1].SetActive(true);
                break;
            case 2:
                text_Weather.text = "Cerah Berawan";
                weatherObjects[1].SetActive(true);
                break;
            case 3:
                text_Weather.text = "Berawan";
                weatherObjects[2].SetActive(true);
                break;
            case 4:
                text_Weather.text = "Berawan Tebal";
                weatherObjects[3].SetActive(true);
                break;
            case 5:
                text_Weather.text = "Udara Kabur";
                weatherObjects[4].SetActive(true);
                break;
            case 10:
                text_Weather.text = "Asap";
                weatherObjects[5].SetActive(true);
                break;
            case 45:
                text_Weather.text = "Kabut";
                weatherObjects[6].SetActive(true);
                break;
            case 60:
                text_Weather.text = "Hujan Ringan";
                weatherObjects[7].SetActive(true);
                break;
            case 61:
                text_Weather.text = "Hujan Sedang";
                weatherObjects[8].SetActive(true);
                break;
            case 63:
                text_Weather.text = "Hujan Lebat";
                weatherObjects[9].SetActive(true);
                break;
            case 80:
                text_Weather.text = "Hujan Lokal";
                weatherObjects[10].SetActive(true);
                break;
            case 95:
                text_Weather.text = "Hujan Petir";
                weatherObjects[11].SetActive(true);
                break;
            case 97:
                text_Weather.text = "Hujan Petir";
                weatherObjects[11].SetActive(true);
                break;
        }
        
        text_Temperature.text = weatherAttribute.Temperature.ToString() + "°C";
        text_Humidity.text = weatherAttribute.Humidity.ToString() + "%";
        text_WindSpeed.text = weatherAttribute.WindSpeed.ToString() + " KM/Jam";

        text_WindDir.text = weatherAttribute.WindDir.ToString();
    }
}
