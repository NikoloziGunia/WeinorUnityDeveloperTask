using System.Collections.Generic;
using System.Xml.Serialization;

namespace Awning
{
    [XmlRoot("Awning")]
    public class AwningDataModel
    {
        [XmlElement("Description")] public Description description { get; set; }
        [XmlElement("Dimensions")] public Dimensions dimensions { get; set; }
        [XmlElement("Model")] public string model { get; set; }
        [XmlElement("Fabric")] public Fabric fabric { get; set; }
        [XmlElement("User")] public User user { get; set; }

    }

    public class Description
    {
        [XmlAttribute("type")] public string type { get; set; }
        [XmlAttribute("mechanism")] public string mechanism { get; set; }
        [XmlElement("Brand")] public string Brand { get; set; }
        [XmlElement("ModelName")] public string ModelName { get; set; }

    }

    public class Dimensions
    {
        [XmlAttribute("unit")] public string unit { get; set; }
        [XmlElement("Length")] public float Length { get; set; }
        [XmlElement("Width")] public float Width { get; set; }
        [XmlElement("Height")] public float Height { get; set; }
    }


    public class Fabric
    {
        [XmlAttribute("material")] public string material { get; set; }
        [XmlAttribute("pattern")] public string pattern { get; set; }

        [XmlElement("Color")] public Color color { get; set; }
    }

    public class Color
    {
        [XmlElement("Red")] public int Red { get; set; }
        [XmlElement("Green")] public int Green { get; set; }
        [XmlElement("Blue")] public int Blue { get; set; }
        [XmlElement("Alpha")] public int Alpha { get; set; }
    }

    public class User
    {
        [XmlElement("Name")] public string Name { get; set; }
        [XmlElement("Location")] public string Location { get; set; }
    }
}

