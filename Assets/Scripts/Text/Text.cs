using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Text
{
    [XmlAttribute]
    public string title;
    [XmlText]
    public string text;
}