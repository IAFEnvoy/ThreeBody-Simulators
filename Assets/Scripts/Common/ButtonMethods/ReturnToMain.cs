using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToMain : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    void Click()
    {
        SceneManager.LoadScene("MainScene");
    }
}