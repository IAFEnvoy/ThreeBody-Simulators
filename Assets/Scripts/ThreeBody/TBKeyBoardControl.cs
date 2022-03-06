using UnityEngine;
using UnityEngine.UI;

public class TBKeyBoardControl : MonoBehaviour
{
  private Camera mainCamera;
  private Text text;
  private void Start()
  {
    mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    text = GameObject.Find("UI/Stats").GetComponent<Text>();
    GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha = 0;
    GameObject.Find("Menu").GetComponent<CanvasGroup>().interactable = false;
    GameObject.Find("Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;
    CameraMove.enable = true;
  }
  private void Update()
  {
    CameraMove.enable = !GameObject.Find("Menu").GetComponent<CanvasGroup>().interactable && !GameObject.Find("Starter").GetComponent<CanvasGroup>().interactable;
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (GameObject.Find("Starter").GetComponent<CanvasGroup>().alpha == 1)
      {
        GameObject.Find("Starter").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Starter").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Starter").GetComponent<CanvasGroup>().blocksRaycasts = false;
      }
      else
      {
        GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha;
        GameObject.Find("Menu").GetComponent<CanvasGroup>().interactable ^= true;
        GameObject.Find("Menu").GetComponent<CanvasGroup>().blocksRaycasts ^= true;
      }
    }
    if (Input.GetKeyDown(KeyCode.H))
    {
      GameObject.Find("UI").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("UI").GetComponent<CanvasGroup>().alpha;
      GameObject.Find("UI").GetComponent<CanvasGroup>().interactable ^= true;
      GameObject.Find("UI").GetComponent<CanvasGroup>().blocksRaycasts ^= true;
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
