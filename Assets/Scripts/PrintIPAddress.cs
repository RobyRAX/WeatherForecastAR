using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrintIPAddress : MonoBehaviour
{
    public TextMeshProUGUI textIP;

    private void Start()
    {
        string ipAddress = GetIPAddress();
        Debug.Log("IP Address: " + ipAddress);

        textIP.text = "Alamat IP : " + ipAddress;
    }

    private string GetIPAddress()
    {
        string ipAddress = "";
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                ipAddress = ip.ToString();
                break;
            }
        }

        return ipAddress;
    }
}
