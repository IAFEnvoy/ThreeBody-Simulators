using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{
  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Click);
  }

  void Click()
  {
    GameObject.Find("UI").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("UI").GetComponent<CanvasGroup>().alpha;
  }
}
