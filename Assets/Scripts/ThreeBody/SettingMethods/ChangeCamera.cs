using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
  Camera mainCamera;
  Text text;
  int now=1;
  void Start()
  {
    mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    text = GameObject.Find("UI/Stats").GetComponent<Text>();
    GetComponent<Button>().onClick.AddListener(Click);
  }

  void Click()
  {
    now++;
    if (now > 6)
      now = 1;
    switch (now)
    {
      case 1:
        text.text = "中心视角";
        mainCamera.transform.parent = null;
        break;
      case 2:
        text.text = "重心视角";
        mainCamera.transform.parent = GameObject.Find("Gravity").transform;
        break;
      case 3:
        text.text = "恒星A视角";
        mainCamera.transform.parent = GameObject.Find("Stars/starA").GetComponent<Transform>();
        break;
      case 4:
        text.text = "恒星B视角";
        mainCamera.transform.parent = GameObject.Find("Stars/starB").GetComponent<Transform>();
        break;
      case 5:
        text.text = "恒星C视角";
        mainCamera.transform.parent = GameObject.Find("Stars/starC").GetComponent<Transform>();
        break;
      case 6:
        text.text = "行星视角";
        mainCamera.transform.parent = GameObject.Find("Stars/planet").GetComponent<Transform>();
        break;
      default:
        text.text = "中心视角";
        mainCamera.transform.parent = null;
        break;
    }
  }
}
