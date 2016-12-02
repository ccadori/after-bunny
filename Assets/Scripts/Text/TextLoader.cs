using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class TextLoader : MonoBehaviour
{
    private UnityEngine.UI.Text component;

    void Start()
    {
        component = GetComponent<UnityEngine.UI.Text>();
        Load(TextController.GetText(component.text));
    }

    public void Load(Text text)
    {
        if (text == null) return;

        component.text = text.text;
    }
}
