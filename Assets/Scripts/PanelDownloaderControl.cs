using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using UnityEngine.UI;
using TMPro;

public class PanelDownloaderControl : MonoBehaviour
{
    public TextMeshProUGUI pesanText;
    public TextMeshProUGUI tanggalText;
    public TextMeshProUGUI tanggalText2;

    public HTTPGetRegion getRegion;
    bool isYes;

    void Start()
    {
        if(File.Exists("LocalData/NameList.txt"))
        {
            Debug.Log("LocalData/NameList.txt - Exist");
            getRegion.UseSavedData();
        }
        else
        {
            Debug.Log("LocalData/NameList.txt - Not Exist");
            getRegion.StartGet();
        }

        //----------------------------------------------------------------------------------

        if(File.Exists("LocalData/WeatherDetails.txt"))
        {
            Debug.Log("LocalData/WeatherDetails.txt - Exist");
            string line1 = File.ReadLines("LocalData/WeatherDetails.txt").First();
            string outputString = line1.Substring(0, line1.Length - 6);

            Debug.Log(outputString + " --> " + RearrangeDate(outputString));
            tanggalText.text = "(Tanggal  data : " + RearrangeDate(outputString) + ")";
            tanggalText2.text = "(Tanggal  data : " + RearrangeDate(outputString) + ")";
        }
        else
        {
            Debug.Log("LocalData/WeatherDetails.txt - Not Exist");
            pesanText.text = "Tidak ditemukan data cuaca 'Lokal' dalam device ini!";
        }
    }

    void Update()
    {
        if(tanggalText2.text == tanggalText.text && isYes)
            UpdateDate();
    }

    public void Yes()
    {
        isYes = true;
    }

    public void UpdateDate()
    {
        if(File.Exists("LocalData/WeatherDetails.txt"))
        {
            Debug.Log("LocalData/WeatherDetails.txt - Exist");
            string line1 = File.ReadLines("LocalData/WeatherDetails.txt").First();
            string outputString = line1.Substring(0, line1.Length - 6);

            Debug.Log(outputString + " --> " + RearrangeDate(outputString));
            tanggalText2.text = "(Tanggal  data : " + RearrangeDate(outputString) + ")";
        }
        else
        {
            Debug.Log("LocalData/WeatherDetails.txt - Not Exist");
            pesanText.text = "Tidak ditemukan data cuaca 'Lokal' dalam device ini!";
        }       
    }

    public static string RearrangeDate(string date)
    {
        DateTime dateTime = DateTime.ParseExact(date, "yyyyMMdd", null);
        string rearrangedDate = dateTime.ToString("dd MM yyyy");
        return rearrangedDate;
    }
}
