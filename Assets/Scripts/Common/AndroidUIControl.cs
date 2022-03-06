using UnityEngine;

public class AndroidUIControl : MonoBehaviour
{
  void Start()
  {
    if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
    {
      GetComponent<CanvasGroup>().alpha = 1;
      GetComponent<CanvasGroup>().interactable = true;
      GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    else
    {
      GetComponent<CanvasGroup>().alpha = 0;
      GetComponent<CanvasGroup>().interactable = false;
      GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
  }
}
