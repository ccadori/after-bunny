using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Inspector
    [SerializeField]
    private float minTime;
    [SerializeField]
    private string sceneName;
    // Inspector

    void Start()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
