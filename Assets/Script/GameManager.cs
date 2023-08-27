using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Awning;
using TMPro;
using UnityEngine;
using Color = UnityEngine.Color;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject awningPrefab;
    
    public TMP_Text descriptionText;
    public TMP_Text dimensionsText;
    public TMP_Text userText;
    
    public AwningDataModel dataModel;

    [SerializeField] private GameObject button;
    

    public void Generate()
    {
        parseXml();
        SpawnObject();
    }

    private void parseXml() 
    {
        try
        {
            TextAsset xmlTextAsset = Resources.Load<TextAsset>("AwningData");
            string xmlContent = xmlTextAsset.text.Replace("\\",String.Empty).Replace("}",String.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(AwningDataModel));
            dataModel= (AwningDataModel) serializer.Deserialize(new MemoryStream(Encoding.ASCII.GetBytes(xmlContent)));
           
        }
        catch (Exception e)
        {
            Debug.LogError("Error parsing data : " + e.Message);
        }
    }
    
    private void SpawnObject()
    {
        var instantiatedAwning = Instantiate(awningPrefab, transform.position, Quaternion.identity);
        
        AwningComponent awningComponent = instantiatedAwning.GetComponent<AwningComponent>();

        awningComponent.parser = this;
        button.SetActive(false);
    }
    
}
