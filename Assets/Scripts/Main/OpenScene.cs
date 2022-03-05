using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public string sceneName;

    public void openScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(openScene);
    }

    void Update()
    {
        
    }
}
