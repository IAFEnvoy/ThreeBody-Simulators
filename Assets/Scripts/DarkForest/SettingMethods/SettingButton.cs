using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Click);
  }

  void Click()
  {
    if (GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha == 0)
    {
      GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha;
      GameObject.Find("Setting").GetComponent<CanvasGroup>().interactable ^= true;
      GameObject.Find("Setting").GetComponent<CanvasGroup>().blocksRaycasts ^= true;
      CameraMove.enable ^= true;
    }
  }
}
