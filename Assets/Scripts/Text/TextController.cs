using System.Xml.Serialization;
using UnityEngine;
using System.IO;

public class TextController : MonoBehaviour
{
    private static TextController singleton;

    // Inspector
    [SerializeField]
    private TextAsset languageFile;
    // Inspector

    private Text[] texts;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        singleton = this;
        texts = LoadFile();
    }

    private Text[] LoadFile()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Text[]));

        using (var reader = new StringReader(languageFile.text))
            return serializer.Deserialize(reader) as Text[];
    }

    static public Text GetText(string title)
    {
        if (singleton == null) return null;

        foreach (Text text in singleton.texts)
            if (text.title.Equals(title))
                return text;

        return null;
    }

    private void WriteText(Text[] texts)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Text[]));
        
        using (var stream = new FileStream("Assets/Scripts/Text/ptBR.xml", FileMode.Create))
        {
            serializer.Serialize(stream, texts);
            stream.Close();
        }
    }
}