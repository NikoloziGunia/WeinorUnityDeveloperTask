using UnityEngine;
using Color = UnityEngine.Color;


public class AwningComponent : MonoBehaviour
{
    public GameManager parser;

    public Renderer fabricRenderer;


    private void Start()
    {
        if (parser.dataModel == null)
        {
            Debug.LogError("Error Datamodel Is Null");
            return;
        };
        
        SetFabricColor();
        SetDimensions();
        SetDescription();
        SetUserInfo();
    }

    public void SetDescription()
    {
        parser.descriptionText.text =
            $"Model: {parser.dataModel.description.ModelName}\nBrand: {parser.dataModel.description.Brand}";
    }

    public void SetDimensions()
    {
        var width = parser.dataModel.dimensions.Width; // x
        var height = parser.dataModel.dimensions.Height; // y
        var length = parser.dataModel.dimensions.Width; // z

        transform.localScale = new Vector3(width, height, length);
        parser.dimensionsText.text = $"Dimensions: {length}m x {width}m x {height}m";
    }

    public void SetFabricColor()
    {
      Color color = new Color(
            parser.dataModel.fabric.color.Red / 255f,
            parser.dataModel.fabric.color.Green / 255f,
            parser.dataModel.fabric.color.Blue / 255f,
            parser.dataModel.fabric.color.Alpha / 255f);

        fabricRenderer.material.color = color;
    }

    public void SetUserInfo()
    {
        parser.userText.text = $"Owner: {parser.dataModel.user.Name}\nLocation: {parser.dataModel.user.Location}";
    }
}