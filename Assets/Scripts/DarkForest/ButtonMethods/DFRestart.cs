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
    if (GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha == 1)
    {
      DFCalculate.reload = true;
      GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha;
      GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().interactable = !GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().interactable;
      GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().blocksRaycasts = !GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().blocksRaycasts;
    }
  }
}
