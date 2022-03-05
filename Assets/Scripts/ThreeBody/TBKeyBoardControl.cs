using UnityEngine;
using UnityEngine.UI;

public class TBKeyBoardControl : MonoBehaviour
{
    private Camera mainCamera;
    private Text text;
    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        text = GameObject.Find("Canvas/UI/Stats").GetComponent<Text>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameObject.Find("Canvas/Starter").GetComponent<CanvasGroup>().alpha == 1)
            {
                GameObject.Find("Canvas/Starter").GetComponent<CanvasGroup>().alpha = 0;
                GameObject.Find("Canvas/Starter").GetComponent<CanvasGroup>().interactable = false;
                GameObject.Find("Canvas/Starter").GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            else
            {
                GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha;
                GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().interactable = !GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().interactable;
                GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().blocksRaycasts = !GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().blocksRaycasts;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            text.text = "中心视角";
            mainCamera.transform.parent = null;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            text.text = "重心视角";
            mainCamera.transform.parent = GameObject.Find("Gravity").GetComponent<Transform>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            text.text = "恒星A视角";
            mainCamera.transform.parent = GameObject.Find("Stars/starA").GetComponent<Transform>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            text.text = "恒星B视角";
            mainCamera.transform.parent = GameObject.Find("Stars/starB").GetComponent<Transform>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            text.text = "恒星C视角";
            mainCamera.transform.parent = GameObject.Find("Stars/starC").GetComponent<Transform>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            text.text = "行星视角";
            mainCamera.transform.parent = GameObject.Find("Stars/planet").GetComponent<Transform>();
        }
    }
}
