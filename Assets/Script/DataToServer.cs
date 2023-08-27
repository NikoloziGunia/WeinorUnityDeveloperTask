using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Xml;
using System.Text;

public class DataToServer : MonoBehaviour
{
    
    //  there was not give server URL ,  so I came across with the idea to create a localhost server with the given two
    // endpoints to send and get the data to/from server.
    // to make this functionality work, the url needs to be changed with working server url and attach handler Js script 

    
    public void SendXMLToServer(string xmlData)
    {
        StartCoroutine(PostXMLData(xmlData));
    }

   
    IEnumerator PostXMLData(string xmlData)
    {
        string serverUrl = "http://localhost:3000/save-awning-xml"; 
    
        // Create a UnityWebRequest for POST
        UnityWebRequest request = UnityWebRequest.PostWwwForm(serverUrl, "");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(xmlData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
    
        yield return request.SendWebRequest();
    
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("XML data sent to the server successfully.");
        }
        else
        {
            Debug.LogError("Error sending XML data: " + request.error);
        }
    }
    
    public void ReceiveXMLFromServer()
    {
        StartCoroutine(GetXMLData());
    }
    
    IEnumerator GetXMLData()
    {
        string serverUrl = "http://localhost:3000/get-awning-xml"; 
    
        using (UnityWebRequest request = UnityWebRequest.Get(serverUrl))
        {
            yield return request.SendWebRequest();
    
            if (request.result == UnityWebRequest.Result.Success)
            {
                string xmlData = request.downloadHandler.text;
                
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlData);
                }
                catch (Exception e)
                {
                    Debug.LogError("Error processing XML data: " + e.Message);
                }
            }
            else
            {
                Debug.LogError("Error fetching XML data: " + request.error);
            }
        }
    }
}
