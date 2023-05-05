using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class CoordinateSetter : MonoBehaviour
{
    List<string> content = new List<string>();
    string[] textContent;

    public GameObject button;
    public GameObject panel;
    //WeatherList weatherList;

    [HideInInspector] public string textFileName;

    void Start()
    {
        //weatherList = GetComponent<WeatherList>();
        //Save();

        //Load();

        textFileName = "LocalData/Coordinate.txt";
    }

    public void SetUI() //Eksekusi di WeatherList
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
        {
            GameObject tempButton;
            tempButton = Instantiate(button);
            tempButton.transform.SetParent(panel.transform);
            tempButton.name = "Button_" + obj.name;
            tempButton.transform.GetComponentInChildren<Text>().text = obj.name;
        }
    }

    public void Save()
    {
        File.Delete(textFileName);

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("IkonCuaca"))
        {
            content.Add(obj.name + "/" + obj.transform.localPosition.ToString());
        }

        File.WriteAllLines(textFileName, content);
    }

    public void Load()
    {
        if(File.Exists(textFileName))
        {
            textContent = File.ReadAllLines(textFileName);

            foreach(string line in textContent)
            {
                char[] charToRemove = {'(', ')'};
                string[] lineContent = new string[2];
                string[] sVector = new string[3];
                GameObject obj;

                lineContent = line.Split('/'); //Pisahkan nama kota dan koordinat
                sVector = lineContent[1].Split(','); //Pisahkan koordinar XYZ

                for(int i = 0; i < sVector.Length; i++) //Hilangkan tanda kurung
                {
                    foreach(char c in charToRemove)
                    {
                        sVector[i] = sVector[i].Replace(c.ToString(), String.Empty);
                    }

                    //Debug.Log(sVector[i]);
                }

                obj = GameObject.Find(lineContent[0]);

                obj.transform.localPosition = new Vector3(
                    float.Parse(sVector[0]),
                    float.Parse(sVector[1]),
                    float.Parse(sVector[2])
                );
            }

            //Debug.Log(lineContent[1]);          
        }
        else
        {
            Debug.Log("File Not Exist");
        }
    } 
}