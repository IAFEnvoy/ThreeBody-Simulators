using UnityEngine;
using UnityEngine.UI;

public class DFRestart : MonoBehaviour
{
  void Start()
  {
    this.GetComponent<Button>().onClick.AddListener(Click);
  }

  void Click()
  {
    if (GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha == 1)
    {
      DFCalculate.reload = true;
      GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha = 0;
      GameObject.Find("Menu").GetComponent<CanvasGroup>().interactable = false;
      GameObject.Find("Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;
      CameraMove.enable = true;
    }
  }
}
